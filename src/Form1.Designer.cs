namespace TicTacToe_Bot
{
    partial class TicTacToe
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GameBoard = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)GameBoard).BeginInit();
            SuspendLayout();
            // 
            // GameBoard
            // 
            GameBoard.AllowUserToAddRows = false;
            GameBoard.AllowUserToDeleteRows = false;
            GameBoard.AllowUserToResizeColumns = false;
            GameBoard.AllowUserToResizeRows = false;
            GameBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GameBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GameBoard.ColumnHeadersVisible = false;
            GameBoard.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            GameBoard.Cursor = Cursors.Hand;
            GameBoard.Location = new Point(371, 83);
            GameBoard.MultiSelect = false;
            GameBoard.Name = "GameBoard";
            GameBoard.RowHeadersVisible = false;
            GameBoard.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GameBoard.RowTemplate.Height = 25;
            GameBoard.ScrollBars = ScrollBars.None;
            GameBoard.Size = new Size(550, 550);
            GameBoard.TabIndex = 0;
            GameBoard.TabStop = false;
            GameBoard.RowCount = 3;
            GameBoard.ColumnCount = 3;
            GameBoard.ReadOnly = true;
            GameBoard.DefaultCellStyle.Font = new Font("Arial", 24);
            GameBoard.DefaultCellStyle.ForeColor = Color.White;
            GameBoard.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // GameBoard.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            GameBoard.CellClick += GameBoard_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // TicTacToe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(GameBoard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "TicTacToe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicTacToe";
            ((System.ComponentModel.ISupportInitialize)GameBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GameBoard;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}