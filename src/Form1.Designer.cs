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
            ((System.ComponentModel.ISupportInitialize)GameBoard).BeginInit();
            SuspendLayout();
            // 
            // GameBoard
            // 
            GameBoard.AllowUserToAddRows = false;
            GameBoard.AllowUserToDeleteRows = false;
            GameBoard.AllowUserToResizeColumns = false;
            GameBoard.AllowUserToResizeRows = false;
            GameBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GameBoard.Location = new Point(371, 83);
            GameBoard.Name = "GameBoard";
            GameBoard.RowTemplate.Height = 25;
            GameBoard.Size = new Size(550, 550);
            GameBoard.TabIndex = 0;
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
    }
}