namespace TicTacToe_Bot
{
    public partial class TicTacToe : Form
    {
        int turn = 0;
        public TicTacToe()
        {
            InitializeComponent();
            GameBoard.RowHeadersVisible = false;
            GameBoard.ColumnHeadersVisible = false;
            GameBoard.AllowUserToAddRows = false;
            GameBoard.AllowUserToDeleteRows = false;
            GameBoard.AllowUserToResizeColumns = false;
            GameBoard.AllowUserToResizeRows = false;
            GameBoard.ScrollBars = ScrollBars.None;
            GameBoard.TabStop = false;
            GameBoard.MultiSelect = false;
            GameBoard.ColumnCount = 3;
            GameBoard.RowCount = 3;
            GameBoard.ReadOnly = true;

            // Set the height of each row to make them fit the grid
            int rowHeight = GameBoard.ClientSize.Height / 3;
            for (int i = 0; i < 3; i++)
            {
                GameBoard.Rows[i].Height = rowHeight;
            }

            GameBoard.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GameBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GameBoard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            GameBoard.CurrentCell = null;
            GameBoard.Cursor = Cursors.Hand;
        }
    }
}