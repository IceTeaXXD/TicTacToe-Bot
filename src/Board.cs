namespace BoardSpace;
class Board{
    /* Attributes */
    public int[,] matrix;
    
    /* Constructor */
    public Board(){
        this.matrix = new int[3, 3];
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                this.matrix[i, j] = -1;
            }
        }
    }

    /* Methods */
    public void move(int row, int col, int turn){
        /*
            -1 is empty
            O is 0
            X is 1
        */
        if (!isEmpty(row, col)){
            throw new Exception("Invalid move");
        }
        int value = turn % 2 == 1 ? 0 : 1;
        this.matrix[row, col] = value;
    }

    public Boolean isEmpty(int row, int col){
        return this.matrix[row, col] == -1;
    }

    public int checkWinner(){
        // Horizontal
        if (this.matrix[0, 0] == this.matrix[0, 1] && this.matrix[0, 1] == this.matrix[0, 2] && !isEmpty(0, 0)){
            return this.matrix[0, 0];
        } else if (this.matrix[1, 0] == this.matrix[1, 1] && this.matrix[1, 1] == this.matrix[1, 2] && !isEmpty(1, 0)){
            return this.matrix[1, 0];
        } else if (this.matrix[2, 0] == this.matrix[2, 1] && this.matrix[2, 1] == this.matrix[2, 2] && !isEmpty(2, 0)){
            return this.matrix[2, 0];
        }

        // Vertical
        else if (this.matrix[0, 0] == this.matrix[1, 0] && this.matrix[1, 0] == this.matrix[2, 0] && !isEmpty(0, 0)){
            return this.matrix[0, 0];
        } else if (this.matrix[0, 1] == this.matrix[1, 1] && this.matrix[1, 1] == this.matrix[2, 1] && !isEmpty(0, 1)){
            return this.matrix[0, 1];
        } else if (this.matrix[0, 2] == this.matrix[1, 2] && this.matrix[1, 2] == this.matrix[2, 2] && !isEmpty(0, 2)){
            return this.matrix[0, 2];
        }

        // Diagonal
        else if (this.matrix[0, 0] == this.matrix[1, 1] && this.matrix[1, 1] == this.matrix[2, 2] && !isEmpty(0, 0)){
            return this.matrix[0, 0];
        } else if (this.matrix[0, 2] == this.matrix[1, 1] && this.matrix[1, 1] == this.matrix[2, 0] && !isEmpty(0, 2)){
            return this.matrix[0, 2];
        } 
        
        // Draw
        else { 
            return  -1;
        }
    }

    public void resetGame(){
        this.matrix = new int[3, 3];
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                this.matrix[i, j] = -1;
            }
        }
    }

    public Tuple<int, int> getBestMove(){
        int bestScore = int.MinValue;
        Tuple<int, int> bestMove = Tuple.Create(-1, -1);

        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                if(isEmpty(i, j)){
                    matrix[i, j] = 1;
                    int score = minimax(false);
                    matrix[i, j] = -1;
                    if(score > bestScore){
                        bestScore = score;
                        bestMove = Tuple.Create(i, j);
                    }
                }
            }
        }

        return bestMove;
    }

    private int minimax(bool isMaximizing){
        int winner = checkWinner();
        if(winner != -1){
            return winner == 1 ? 1 : -1;
        }

        if(isMaximizing){
            int bestScore = int.MinValue;
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    if(isEmpty(i, j)){
                        matrix[i, j] = 1;
                        int score = minimax(false);
                        matrix[i, j] = -1;
                        bestScore = Math.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        } else {
            int bestScore = int.MaxValue;
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    if(isEmpty(i, j)){
                        matrix[i, j] = 2;
                        int score = minimax(true);
                        matrix[i, j] = -1;
                        bestScore = Math.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }
}