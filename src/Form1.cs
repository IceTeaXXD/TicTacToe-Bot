using BoardSpace;
namespace TicTacToe_Bot
{
    public partial class TicTacToe : Form
    {
        int turn = 0;
        Board board = new Board();
        public TicTacToe()
        {
            InitializeComponent();
            //  Set the height of each row to make them fit the grid
            int rowHeight = GameBoard.ClientSize.Height / 3;
            for (int i = 0; i < 3; i++)
            {
                GameBoard.Rows[i].Height = rowHeight;
            }
        }

        private void GameBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  Get the row and column of the clicked cell
            DataGridViewCell clickedCell = GameBoard.Rows[e.RowIndex].Cells[e.ColumnIndex];
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            //  Check if the cell is empty
            if (board.isEmpty(row, col))
            {
                //  Get the value of the current turn
                int value = turn % 2 == 1 ? 0 : 1;
                //  Update the board
                board.move(row, col, turn);
                //  Update the UI
                GameBoard.Rows[row].Cells[col].Value = value == 0 ? "O" : "X";
                // Update the color of the cell, O is red, X is blue
                GameBoard.Rows[row].Cells[col].Style.BackColor = value == 0 ? Color.Red : Color.Blue;
                GameBoard.DefaultCellStyle.SelectionBackColor = value == 0 ? Color.Red : Color.Blue;
                //  Check if there is a winner
                int winner = board.checkWinner();
                if (winner != -1)
                {
                    //  Display the winner
                    MessageBox.Show(winner == 0 ? "O wins!" : "X wins!");
                    //  Reset the game
                    resetGame();
                }
                //  Check if the game is a draw
                else if (turn == 9)
                {
                    //  Display the draw
                    MessageBox.Show("Draw!");
                    //  Reset the game
                    resetGame();
                }
                //  Update the turn
                turn++;
            } 
        }

        private void resetGame(){
            //  Reset the board
            board = new Board();
            //  Reset the UI
            for (int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    GameBoard.Rows[i].Cells[j].Value = "";
                    GameBoard.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            //  Reset the turn
            turn = 0;
            GameBoard.DefaultCellStyle.SelectionBackColor = Color.White;
        }
    }
}