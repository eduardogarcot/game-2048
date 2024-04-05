namespace _2048
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SizeComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.generateBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.max_number_value = new System.Windows.Forms.Label();
            this.max_score_value = new System.Windows.Forms.Label();
            this.current_score_value = new System.Windows.Forms.Label();
            this.max_number_label = new System.Windows.Forms.Label();
            this.max_score_label = new System.Windows.Forms.Label();
            this.current_score_label = new System.Windows.Forms.Label();
            this.board_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.UndoMenuItem,
            this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem,
            this.loadGameToolStripMenuItem,
            this.SaveGameMenuItem,
            this.exitToolStripMenuItem1});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SizeComboBox1,
            this.generateBoardToolStripMenuItem});
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(216, 28);
            this.newGameMenuItem.Text = "New Game";
            // 
            // SizeComboBox1
            // 
            this.SizeComboBox1.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.SizeComboBox1.Name = "SizeComboBox1";
            this.SizeComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SizeComboBox1.Size = new System.Drawing.Size(121, 28);
            this.SizeComboBox1.Text = "4";
            // 
            // generateBoardToolStripMenuItem
            // 
            this.generateBoardToolStripMenuItem.Name = "generateBoardToolStripMenuItem";
            this.generateBoardToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.generateBoardToolStripMenuItem.Text = "Generate Board";
            this.generateBoardToolStripMenuItem.Click += new System.EventHandler(this.GenerateBoardToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.LoadGameToolStripMenuItem_Click);
            // 
            // SaveGameMenuItem
            // 
            this.SaveGameMenuItem.Name = "SaveGameMenuItem";
            this.SaveGameMenuItem.Size = new System.Drawing.Size(216, 28);
            this.SaveGameMenuItem.Text = "Save Game";
            this.SaveGameMenuItem.Click += new System.EventHandler(this.SaveGameMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(216, 28);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // UndoMenuItem
            // 
            this.UndoMenuItem.Name = "UndoMenuItem";
            this.UndoMenuItem.Size = new System.Drawing.Size(64, 27);
            this.UndoMenuItem.Text = "Undo";
            this.UndoMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(69, 27);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // max_number_value
            // 
            this.max_number_value.AutoSize = true;
            this.max_number_value.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_number_value.ForeColor = System.Drawing.Color.Silver;
            this.max_number_value.Location = new System.Drawing.Point(240, 295);
            this.max_number_value.Name = "max_number_value";
            this.max_number_value.Size = new System.Drawing.Size(34, 33);
            this.max_number_value.TabIndex = 5;
            this.max_number_value.Text = "0";
            this.max_number_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // max_score_value
            // 
            this.max_score_value.AutoSize = true;
            this.max_score_value.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_score_value.ForeColor = System.Drawing.Color.Silver;
            this.max_score_value.Location = new System.Drawing.Point(240, 235);
            this.max_score_value.Name = "max_score_value";
            this.max_score_value.Size = new System.Drawing.Size(34, 33);
            this.max_score_value.TabIndex = 4;
            this.max_score_value.Text = "0";
            this.max_score_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // current_score_value
            // 
            this.current_score_value.AutoSize = true;
            this.current_score_value.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_score_value.ForeColor = System.Drawing.Color.Silver;
            this.current_score_value.Location = new System.Drawing.Point(240, 175);
            this.current_score_value.Name = "current_score_value";
            this.current_score_value.Size = new System.Drawing.Size(34, 33);
            this.current_score_value.TabIndex = 3;
            this.current_score_value.Text = "0";
            this.current_score_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // max_number_label
            // 
            this.max_number_label.AutoSize = true;
            this.max_number_label.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_number_label.ForeColor = System.Drawing.Color.Silver;
            this.max_number_label.Location = new System.Drawing.Point(23, 295);
            this.max_number_label.Name = "max_number_label";
            this.max_number_label.Size = new System.Drawing.Size(145, 33);
            this.max_number_label.TabIndex = 2;
            this.max_number_label.Text = "Max Item:";
            this.max_number_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // max_score_label
            // 
            this.max_score_label.AutoSize = true;
            this.max_score_label.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_score_label.ForeColor = System.Drawing.Color.Silver;
            this.max_score_label.Location = new System.Drawing.Point(23, 235);
            this.max_score_label.Name = "max_score_label";
            this.max_score_label.Size = new System.Drawing.Size(158, 33);
            this.max_score_label.TabIndex = 1;
            this.max_score_label.Text = "Max Score:";
            this.max_score_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // current_score_label
            // 
            this.current_score_label.AutoSize = true;
            this.current_score_label.Font = new System.Drawing.Font("Facebook Letter Faces", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_score_label.ForeColor = System.Drawing.Color.Silver;
            this.current_score_label.Location = new System.Drawing.Point(23, 175);
            this.current_score_label.Name = "current_score_label";
            this.current_score_label.Size = new System.Drawing.Size(195, 33);
            this.current_score_label.TabIndex = 0;
            this.current_score_label.Text = "Current Score:";
            this.current_score_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // board_panel
            // 
            this.board_panel.BackColor = System.Drawing.Color.Transparent;
            this.board_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.board_panel.ForeColor = System.Drawing.Color.Black;
            this.board_panel.Location = new System.Drawing.Point(447, 82);
            this.board_panel.Name = "board_panel";
            this.board_panel.Size = new System.Drawing.Size(720, 720);
            this.board_panel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Candy Script", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 104);
            this.label1.TabIndex = 6;
            this.label1.Text = "2048 Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1300, 1055);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.max_number_value);
            this.Controls.Add(this.board_panel);
            this.Controls.Add(this.current_score_label);
            this.Controls.Add(this.max_score_label);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.max_number_label);
            this.Controls.Add(this.max_score_value);
            this.Controls.Add(this.current_score_value);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "2048 Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label max_number_value;
        private System.Windows.Forms.Label max_score_value;
        private System.Windows.Forms.Label current_score_value;
        private System.Windows.Forms.Label max_number_label;
        private System.Windows.Forms.Label max_score_label;
        private System.Windows.Forms.Label current_score_label;
        private System.Windows.Forms.Label[,] label_matrix;
        private System.Windows.Forms.PictureBox[,] picture_Box_matrix;
        private Board board;
        private System.Windows.Forms.Panel board_panel;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        private System.Windows.Forms.ToolStripComboBox SizeComboBox1;
        private System.Windows.Forms.ToolStripMenuItem generateBoardToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

