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
    public (int, int) getBestMove(int botToken = 0){
        int bestScore = -1000;
        int moveRow = -1;
        int moveCol = -1;

        // Explore all cells in the board
        for (int row = 0; row < 3; row++){
            for (int col = 0; col < 3; col++){
                // Check if the cell is empty
                if (isEmpty(row, col)){
                    // Make the move
                    this.matrix[row, col] = botToken;
                    
                    // Compute evaluation function for this move.
                    int moveScore = minimax(0, false, -1000, 1000);
                    
                    // Undo the move
                    this.matrix[row, col] = -1;
                    
                    // If the result of the move is better than the best score, update bestScore, moveRow, and moveCol
                    if (moveScore >= bestScore){
                        bestScore = moveScore;
                        moveRow = row;
                        moveCol = col;
                    }
                }
            }
        }
        return (moveRow, moveCol);
    }

    private int minimax(int depth, bool isMaximizingPlayer, int alpha, int beta){
        int winner = checkWinner();
        if (winner != -1){
            return winner == 0 ? 10 : -10; // 10 for bot win, -10 for player win
        }

        // Tie
        bool isFull = true;
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                if (isEmpty(i, j)){
                    isFull = false;
                    break;
                }
            }
            if (!isFull) break;
        }
        if (isFull) return 0; // Tie game returns score of 0

        if (isMaximizingPlayer){
            int bestScore = -1000;
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    if (isEmpty(i, j)){
                        this.matrix[i, j] = 0; // Bot's move
                        int score;
                        if (checkImmediateWin() == 1) { // If immediate win for bot, prioritize that
                            score = 1000;
                        } else {
                            score = minimax(depth + 1, false, alpha, beta);
                        }
                        this.matrix[i, j] = -1; // Undo move
                        bestScore = Math.Max(score, bestScore);
                        alpha = Math.Max(alpha, bestScore);
                        if (beta <= alpha) break; // Alpha Beta Pruning
                    }
                }
            }
            return bestScore - depth; // Subtract depth to prioritize faster wins
        } else {
            int bestScore = 1000;
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    if (isEmpty(i, j)){
                        this.matrix[i, j] = 1; // Player's move
                        int score;
                        if (checkImmediateThreat() == 1) { // If immediate win for player, prioritize that
                            score = -1000;
                        } else {
                            score = minimax(depth + 1, true, alpha, beta);
                        }
                        this.matrix[i, j] = -1; // Undo move
                        bestScore = Math.Min(score, bestScore);
                        beta = Math.Min(beta, bestScore);
                        if (beta <= alpha) break; // Alpha Beta Pruning
                    }
                }
            }
            return bestScore + depth; // Add depth to prioritize blocking the player faster
        }
    }

    private int checkImmediateThreat() {
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (this.matrix[i, j] == -1) { // Check empty spots
                    this.matrix[i, j] = 1; // Assume the player places a piece here
                    int winner = checkWinner(); // Check if this would make the player win
                    this.matrix[i, j] = -1; // Reset the cell
                    if (winner == 1) return 1; // If the player could win, it's an immediate threat
                }
            }
        }
        return -1; // If no immediate threat found
    }

    private int checkImmediateWin(){
        for (int i = 0 ; i < 3 ; i++) {
            for (int j = 0 ; j < 3 ; j++) {
                if (this.matrix[i, j] == -1) { // Check empty spots
                    this.matrix[i, j] = 0; // Assume the bot places a piece here
                    int winner = checkWinner(); // Check if this would make the bot win
                    this.matrix[i, j] = -1; // Reset the cell
                    if (winner == 0) return 1; // If the bot could win, it's an immediate win
                }
            }
        }
        return -1; // If no immediate win found
    }
}