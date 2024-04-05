using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Generate_Label_Board(4);
            board = new Board(4);
            Paint_board();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Generate_Label_Board(int size)
        {
            this.SuspendLayout();
            this.board_panel.Controls.Clear();
            this.board_panel.Size = new System.Drawing.Size(720, 720);
            this.label_matrix = new System.Windows.Forms.Label[size, size];
            string name_l = "label_";
            int block_size = size<9?80:50;
            float text_size = size < 9 ? 16F : 10F;//(this.board_panel.Size.Height - size * 2) / size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.label_matrix[i, j] = new System.Windows.Forms.Label();
                    this.board_panel.Size = new System.Drawing.Size(720, 720);
                    this.board_panel.Controls.Add(this.label_matrix[i, j]);
                    this.label_matrix[i, j].SuspendLayout();
                    this.label_matrix[i, j].AutoEllipsis = true;
                    this.label_matrix[i, j].BackColor = System.Drawing.SystemColors.ActiveCaption;
                    this.label_matrix[i, j].Location = new System.Drawing.Point(j * block_size, i * block_size);
                    this.label_matrix[i, j].Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    this.label_matrix[i, j].Name = name_l + i.ToString() + "x" + j.ToString();
                    this.label_matrix[i, j].Size = new System.Drawing.Size(block_size- 3, block_size - 3);
                    this.label_matrix[i, j].TabIndex = 0;
                    this.label_matrix[i, j].Text = "65536";
                    this.label_matrix[i, j].ForeColor = Color.Black;
                    this.label_matrix[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", text_size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.label_matrix[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    this.label_matrix[i, j].Visible = true;
                    this.label_matrix[i, j].Show();
                    this.label_matrix[i, j].ResumeLayout();
                }
            }
            int new_size = size * (block_size);
            this.board_panel.Size = new System.Drawing.Size(new_size,new_size);
            this.board_panel.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(460+new_size, 100+new_size);
            this.ResumeLayout();
            
        }
        private void Paint_board()
        {
            for (int i = 0; i < this.board.board_size; i++)
            {
                for (int j = 0; j < this.board.board_size; j++)
                {
                    Set_label_color_and_text(i, j);
                }
            }
        }

        private void Set_label_color_and_text(int row, int column)
        {
            this.current_score_value.Text = this.board.current_score.ToString();
            this.max_score_value.Text = this.board.max_score.ToString();
            this.max_number_value.Text = this.board.max_item.ToString();
            int color = this.board.board_matrix[row, column];
            switch (color)
            {
                case 0:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.White;
                    break;
                case 2:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Pink;
                    break;
                case 4:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Moccasin;
                    break;
                case 8:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.DarkOrange;
                    break;
                case 16:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Chocolate;
                    break;
                case 32:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Tomato;
                    break;
                case 64:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Red;
                    break;
                case 128:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Yellow;
                    break;
                case 256:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Gold;
                    break;
                case 512:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.PaleGoldenrod;
                    break;
                case 1024:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Coral;
                    break;
                case 2048:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.DarkOrange;
                    break;
                case 4096:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.GreenYellow;
                    break;
                case 8192:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.LimeGreen;
                    break;
                case 16384:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Aquamarine;
                    break;
                case 32768:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.PaleTurquoise;
                    break;
                case 65536:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Cyan;
                    break;
                case 131072:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.SkyBlue;
                    break;
                case 262144:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.DodgerBlue;
                    break;
                default:
                    this.label_matrix[row, column].BackColor = System.Drawing.Color.Yellow;
                    break;
            }
            if (color == 0)
            {
                this.label_matrix[row, column].Text = "";
                return;
            }
            this.label_matrix[row, column].Text = color.ToString();

        }

        private void Generate_Picture_Box(int size)
        {
            this.SuspendLayout();
            this.board_panel.Controls.Clear();
            this.board_panel.Size = new System.Drawing.Size(720, 720);
            this.picture_Box_matrix = new System.Windows.Forms.PictureBox[size, size];
            string name_l = "box_";
            int PB_size = size<8?100:80;
            PB_size = size >= 10 ? 50 : PB_size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.picture_Box_matrix[i, j] = new System.Windows.Forms.PictureBox();
                    this.picture_Box_matrix[i, j].Location = new System.Drawing.Point((j * PB_size),(i * PB_size));
                    this.picture_Box_matrix[i, j].Size = new System.Drawing.Size(PB_size-2,PB_size-2);
                    this.picture_Box_matrix[i,j].Name = name_l + i.ToString() + "x" + j.ToString(); 
                    this.picture_Box_matrix[i,j].TabIndex = 0;
                    this.picture_Box_matrix[i,j].TabStop = false;
                    this.picture_Box_matrix[i, j].Image = Image.FromFile("2.jpg");
                    this.picture_Box_matrix[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.board_panel.Controls.Add(this.picture_Box_matrix[i, j]);
                }
            }
            int new_size = size * (PB_size);
            this.board_panel.Size = new System.Drawing.Size(new_size, new_size);
            this.board_panel.BackColor = System.Drawing.Color.Silver;
            this.ResumeLayout();

        }

        private void Paint_board(bool isPictureBox)
        {
            for (int i = 0; i < this.board.board_size; i++)
            {
                for (int j = 0; j < this.board.board_size; j++)
                {
                    Set_box_color_and_text(i, j);
                }
            }
        }

        private void Set_box_color_and_text(int row, int column)
        {
            this.current_score_value.Text = this.board.current_score.ToString();
            this.max_score_value.Text = this.board.max_score.ToString();
            this.picture_Box_matrix[row, column].Image = Image.FromFile(this.board.board_matrix[row, column].ToString() + ".jpg");
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && this.board.available_move[0])
                if (!this.board.SlideBoard(0))
                {
                    Paint_board();
                    GameOver();
                }
                else
                    Paint_board();
            if (e.KeyCode == Keys.Down && this.board.available_move[1])
                if (!this.board.SlideBoard(1))
                {
                    Paint_board();
                    GameOver();
                }
                else
                    Paint_board();
            if (e.KeyCode == Keys.Left && this.board.available_move[2])
                if (!this.board.SlideBoard(2))
                {
                    Paint_board();
                    GameOver();
                }
                else
                    Paint_board();
            if (e.KeyCode == Keys.Up && this.board.available_move[3])
                if (!this.board.SlideBoard(3))
                {
                    Paint_board();
                    GameOver();
                }
                else
                    Paint_board();
        }

        private void GameOver()
        {
            string message = "You don't have possible move. \n Please generate new board to continue playing";
            string caption = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, caption, buttons);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.board != null && this.board.Get_undo_count() > 0)
            {
                this.board.Press_Undo();
                Paint_board();
            }
            else if (this.board == null)
            {
                string message = "There is no loaded board";
                string caption = "Undo is not available";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                string message = "This is the first board. It is imposible get a previous board";
                string caption = "Undo is not available";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Developed by:\n\t\tEduardo García Cotrina\n\t\tTelecommunications and Electronics Engineering";
            string caption = "2048 Game";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, caption, buttons);
        }
       
        private void GenerateBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt16(this.SizeComboBox1.Text);
            Generate_Label_Board(size);
            board = new Board(size);
            Paint_board();
        }

        private void SaveGameMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Saved_Game.txt";
            this.board.Save_Board(path);
        }

        private void LoadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Saved_Game.txt";
            this.board = Board.Load_Board(path);
            Generate_Label_Board(this.board.board_size);
            Paint_board();
        }
    }
}