using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _2048
{
    class Board
    {
        const string path = "maxScore";
        const string format = ".txt";
        public int[,] board_matrix;
        private Random random_gen;
        private ArrayList zero_value_positions_list;
        public bool[] available_move;
        private Stack<int[,]> previous_boards;
        private Stack<long> previous_scores;
        public long current_score { get; private set; }
        public long max_score { get; private set; }
        public int board_size { get; private set; }
        public int max_item;
        
        public Board(int size)
        {
            this.random_gen = new Random();
            this.zero_value_positions_list = new ArrayList();
            this.board_size = size;
            this.previous_boards = new Stack<int[,]>();
            this.previous_scores = new Stack<long>();
            this.board_matrix = new int[size, size];
            this.max_item = 0;
            Load_Max_Score();
            bool residual = Exist_Available_Move();
            if (this.zero_value_positions_list.Count > 1)
            {
                Generate_Random_Number();
                Generate_Random_Number();
            }
            this.current_score = 0;
            residual = Exist_Available_Move();
        }

        public Board()
        {
            this.random_gen = new Random();
            this.zero_value_positions_list = new ArrayList();
            this.previous_boards = new Stack<int[,]>();
            this.previous_scores = new Stack<long>();
        }

        private bool Exist_Zero_Value_Cell()
        {
            this.zero_value_positions_list.Clear();
            bool exist = false;
            for (int i = 0; i < this.board_size; i++)
            {
                for (int j = 0; j < this.board_size; j++)
                {
                    if (this.board_matrix[i, j] == 0)
                    {
                        exist = true;
                        zero_value_positions_list.Add(new int[] { i, j });
                    }
                }
            }
            return exist;
        }

        private void Generate_Random_Number()
        {
            int index = this.random_gen.Next(this.zero_value_positions_list.Count);
            int[] position = (int[])this.zero_value_positions_list[index];
            this.board_matrix[position[0], position[1]] = (this.random_gen.Next(10) > 7 ? 4 : 2);
            this.zero_value_positions_list.RemoveAt(index);
        }

        private void Load_Max_Score()
        {
            if (!File.Exists(path + this.board_size.ToString() + format))
            {
                StreamWriter writer = File.CreateText(path + this.board_size.ToString() + format);
                writer.WriteLine("0");
                writer.Close();
            }
            else
            {
                StreamReader reader = File.OpenText(path + this.board_size.ToString() + format);
                string temp_max_score = reader.ReadLine();
                this.max_score = (long)Convert.ToInt32(temp_max_score);
                reader.Close();
            }
        }

        private void Update_Max_Score()
        {
            if (this.max_score < this.current_score)
            {
                this.max_score = this.current_score;
                StreamWriter writer = File.CreateText(path + this.board_size.ToString() + format);
                writer.WriteLine(max_score.ToString());
                writer.Close();
            }
        }

        private void Save_Previous_Board()
        {
            this.previous_boards.Push((int[,])this.board_matrix.Clone());
            this.previous_scores.Push(this.current_score);
        }
        
        public void Save_Board(string path)
        {
            TextWriter writer = File.CreateText(path);
            writer.WriteLine(this.board_size.ToString());
            Stack<int[,]> temp_stack = new Stack<int[,]>();
            Stack<long> temp_score_stack = new Stack<long>();
            temp_stack.Push(this.board_matrix);
            temp_score_stack.Push(this.current_score);
            int stack_size = this.previous_boards.Count+1;
            for (int i = 0; i < stack_size-1; i++)
            {
                temp_stack.Push(this.previous_boards.Pop());
                temp_score_stack.Push(this.previous_scores.Pop());
            }
            for (int counter = 0; counter < stack_size; counter++)
            {
                this.previous_scores.Push(temp_score_stack.Pop());
                this.previous_boards.Push(temp_stack.Pop());
                Write_Matrix_on_File(this.previous_boards.First<int[,]>(),writer);
                writer.WriteLine(this.previous_scores.First<long>().ToString());
            }
            this.current_score = this.previous_scores.Pop();
            this.board_matrix = this.previous_boards.Pop();
            writer.WriteLine("Finished");
            writer.Close();
        }

        public static Board Load_Board(string path)
        {
            Board newBoard = new Board();
            TextReader reader = File.OpenText(path);
            string temp_reader = reader.ReadLine();
            newBoard.board_size = Convert.ToInt16(temp_reader);
            bool finished = false;
            while (!finished)
            {
                temp_reader = reader.ReadLine();
                if (temp_reader == "Finished")
                {
                    finished = true;
                }
                if (temp_reader == "New Matrix")
                {
                    newBoard.previous_boards.Push(Get_Matrix_from_File(reader,newBoard.board_size));
                    temp_reader = reader.ReadLine();
                    newBoard.previous_scores.Push((long)Convert.ToInt32(temp_reader));
                }
            }
            newBoard.board_matrix = newBoard.previous_boards.Pop();
            newBoard.current_score = newBoard.previous_scores.Pop();
            bool residual = newBoard.Exist_Available_Move();
            newBoard.Load_Max_Score();
            reader.Close();
            return newBoard;
        }

        private static int[,] Get_Matrix_from_File(TextReader reader,int size)
        {
            bool finished = false;
            int[,] new_board_matrix = new int[size, size];
            string temp;
            int index,row,column,value;
            string[] number; 
            while (!finished)
            {
                temp = reader.ReadLine();
                if (temp == "End Matrix")
                    finished = true;
                else
                {
                    index = 0;
                    number = new string[] { "", "", "" };
                    foreach (var item in temp)
                    {
                        if (item == ',' || item == '=')
                        {
                            index++;
                            continue;
                        }
                        number[index] += item;
                    }
                    row = Convert.ToInt16(number[0]);
                    column = Convert.ToInt16(number[1]);
                    value = Convert.ToInt16(number[2]);
                    new_board_matrix[row, column] = value;
                }
            }
            return new_board_matrix;
        }

        private void Write_Matrix_on_File(int[,] board_matrix,TextWriter writer)
        {
            writer.WriteLine("New Matrix");
            for (int i = 0; i < board_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < board_matrix.GetLength(1); j++)
                {
                    if (board_matrix[i, j] != 0)
                        writer.WriteLine(i.ToString() + "," + j.ToString() + "=" + board_matrix[i, j].ToString());
                }
            }
            writer.WriteLine("End Matrix");
        }
        
        public void Press_Undo()
        {
            this.current_score = previous_scores.Pop();
            this.board_matrix = previous_boards.Pop();
            bool temporal = Exist_Available_Move();
        }

        public int Get_undo_count()
        { return previous_scores.Count; }

        private bool Exist_Available_Move()
        {
            this.zero_value_positions_list.Clear();
            this.available_move = new bool[] { false, false, false, false };
            for (int i = 0; i < this.board_size; i++)
            {
                Review_Column_Mov(i);
                Review_Row_Mov(i);
            }
            foreach (var item in available_move)
            {
                if (item)
                    return true;
            }
            return false;
        }
        #region Exist_Available_Move() Derivated Methods Implementation
        private void Review_Column_Mov(int column)
        {
            ArrayList zero_values_index_list = new ArrayList();
            for (int row = 0; row < this.board_size; row++)
            {
                if (row == 0 && this.board_matrix[row, column] != 0)
                    continue;
                if (this.board_matrix[row, column] == 0)
                {
                    this.zero_value_positions_list.Add(new int[] { row, column });
                    zero_values_index_list.Add(row);
                    continue;
                }
                if (this.board_matrix[row, column] == this.board_matrix[row - 1, column])
                {
                    this.available_move[1] = true;
                    this.available_move[3] = true;
                    continue;
                }
            }
            if (zero_values_index_list.Count == 0 || zero_values_index_list.Count == this.board_size)
                return;
            else if (zero_values_index_list.Count == this.board_size - 1)
            {
                if ((int)zero_values_index_list[0] != 0)
                    this.available_move[1] = true;
                else if ((int)zero_values_index_list[zero_values_index_list.Count - 1] != this.board_size - 1)
                    this.available_move[3] = true;
                else
                {
                    this.available_move[1] = true;
                    this.available_move[3] = true;
                }
            }
            else if (zero_values_index_list.Count < this.board_size - 1 && (int)zero_values_index_list[0] == 0)
            {
                if (zero_values_index_list.Count == 2 && ((int)zero_values_index_list[1] - (int)zero_values_index_list[0] != 1))
                {
                    this.available_move[1] = true;
                    this.available_move[3] = true;
                    return;
                }
                for (int a = 1; a < zero_values_index_list.Count; a++)
                {
                    if ((int)zero_values_index_list[a] - (int)zero_values_index_list[a - 1] != 1)
                    {
                        this.available_move[1] = true;
                        this.available_move[3] = true;
                        return;
                    }
                }
                this.available_move[3] = true;
            }
            else if (zero_values_index_list.Count < this.board_size - 1 && (int)zero_values_index_list[zero_values_index_list.Count - 1] == this.board_matrix.GetLength(0) - 1)
            {
                if (zero_values_index_list.Count == 2 && ((int)zero_values_index_list[zero_values_index_list.Count - 1] - (int)zero_values_index_list[zero_values_index_list.Count - 2] != 1))
                {
                    this.available_move[1] = true;
                    this.available_move[3] = true;
                    return;
                }
                for (int a = zero_values_index_list.Count - 1; a > 0; a--)
                {
                    if ((int)zero_values_index_list[a] - (int)zero_values_index_list[a - 1] != 1)
                    {
                        this.available_move[1] = true;
                        this.available_move[3] = true;
                        return;
                    }
                }
                this.available_move[1] = true;
            }
            else
            {
                this.available_move[1] = true;
                this.available_move[3] = true;
            }
        }
        private void Review_Row_Mov(int row)
        {
            ArrayList zero_values_index_list = new ArrayList();
            for (int column = 0; column < this.board_size; column++)
            {
                if (this.board_matrix[row, column] > this.max_item)
                    this.max_item = this.board_matrix[row, column];
                if (column == 0 && this.board_matrix[row, column] != 0)
                    continue;
                if (this.board_matrix[row, column] == 0)
                {
                    zero_values_index_list.Add(column);
                    continue;
                }
                if (this.board_matrix[row, column] == this.board_matrix[row, column - 1])
                {
                    this.available_move[0] = true;
                    this.available_move[2] = true;
                    continue;
                }

            }
            if (zero_values_index_list.Count == 0 || zero_values_index_list.Count == this.board_size)
                return;
            else if (zero_values_index_list.Count == this.board_size - 1)
            {
                if ((int)zero_values_index_list[0] != 0)
                    this.available_move[0] = true;
                else if ((int)zero_values_index_list[zero_values_index_list.Count - 1] != this.board_size - 1)
                    this.available_move[2] = true;
                else
                {
                    this.available_move[0] = true;
                    this.available_move[2] = true;
                }
            }
            else if (zero_values_index_list.Count < this.board_size - 1 && (int)zero_values_index_list[0] == 0)
            {
                if (zero_values_index_list.Count == 2 && ((int)zero_values_index_list[1] - (int)zero_values_index_list[0] != 1))
                {
                    this.available_move[0] = true;
                    this.available_move[2] = true;
                    return;
                }
                for (int a = 1; a < zero_values_index_list.Count; a++)
                {
                    if ((int)zero_values_index_list[a] - (int)zero_values_index_list[a - 1] != 1)
                    {
                        this.available_move[0] = true;
                        this.available_move[2] = true;
                        return;
                    }
                }
                this.available_move[2] = true;
            }
            else if (zero_values_index_list.Count < this.board_size - 1 && (int)zero_values_index_list[zero_values_index_list.Count - 1] == this.board_size - 1)
            {
                if (zero_values_index_list.Count == 2 && ((int)zero_values_index_list[zero_values_index_list.Count - 1] - (int)zero_values_index_list[zero_values_index_list.Count - 2] != 1))
                {
                    this.available_move[0] = true;
                    this.available_move[2] = true;
                    return;
                }
                for (int a = zero_values_index_list.Count - 1; a > 0; a--)
                {
                    if ((int)zero_values_index_list[a] - (int)zero_values_index_list[a - 1] != 1)
                    {
                        this.available_move[0] = true;
                        this.available_move[2] = true;
                        return;
                    }
                }
                this.available_move[0] = true;
            }
            else
            {
                this.available_move[0] = true;
                this.available_move[2] = true;
            }
        }
        #endregion
        public bool SlideBoard(int direction)
        {
            Save_Previous_Board();
            if (direction == 0)                         //  Right
            {
                this.board_matrix = Rotate_Matrix(this.board_matrix, 1);
                Add_Cells();
                this.board_matrix = Rotate_Matrix(this.board_matrix, 3);
            }
            else if (direction == 1)                    //  Down
                Add_Cells();
            else if (direction == 2)                    //  Left
            {
                this.board_matrix = Rotate_Matrix(this.board_matrix, 3);
                Add_Cells();
                this.board_matrix = Rotate_Matrix(this.board_matrix, 1);
            }
            else if (direction == 3)                    //  Up
            {
                this.board_matrix = Rotate_Matrix(this.board_matrix, 2);
                Add_Cells();
                this.board_matrix = Rotate_Matrix(this.board_matrix, 2);
            }
            Exist_Zero_Value_Cell();
            Generate_Random_Number();
            Update_Max_Score();
            return Exist_Available_Move();
        }
        #region SlideBoard() Derivated Methods Implementation
        private void Add_Cells()
        {
            Stack<int> ValuesStack = new Stack<int>();
            for (int column = 0; column < this.board_size; column++)
            {
                ValuesStack.Clear();
                for (int row = 0; row < this.board_size; row++)
                {
                    if (!(this.board_matrix[row, column] == 0))
                    {
                        ValuesStack.Push(this.board_matrix[row, column]);
                    }
                }
                bool already_added = false;
                for (int row = this.board_matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (ValuesStack.Count == 0)
                    {
                        this.board_matrix[row, column] = 0;
                        continue;
                    }
                    else if (row == this.board_matrix.GetLength(0) - 1)
                    {
                        this.board_matrix[row, column] = ValuesStack.Pop();
                        continue;
                    }
                    else if (!already_added && this.board_matrix[row + 1, column] == ValuesStack.First<int>())
                    {
                        this.board_matrix[row + 1, column] = ValuesStack.Pop() * 2;
                        this.current_score += this.board_matrix[row + 1, column];
                        already_added = true;
                        row++;
                        continue;
                    }
                    else
                    {
                        this.board_matrix[row, column] = ValuesStack.Pop();
                        already_added = false;
                    }
                }
            }
        }
        private int[,] Rotate_Matrix(int[,] elems_matrix, int rotation_number)
        {
            if (rotation_number <= 0 || rotation_number % 4 == 0)
                return elems_matrix;
            else if (rotation_number % 2 == 0)
                return RotateMatrix_2(elems_matrix);
            else if (rotation_number == 1 || (rotation_number % 4) - 1 == 0)
                return RotateMatrix_1(elems_matrix);
            else
                return RotateMatrix_3(elems_matrix);
        }
        private int[,] RotateMatrix_1(int[,] elems_matrix)
        {
            int[,] newMatrix = new int[elems_matrix.GetLength(1), elems_matrix.GetLength(0)];
            for (int file = 0; file < newMatrix.GetLength(0); file++)
            {
                for (int column = 0; column < newMatrix.GetLength(1) / 2; column++)
                {
                    newMatrix[file, column] = elems_matrix[elems_matrix.GetLength(0) - 1 - column, file];
                    newMatrix[newMatrix.GetLength(0) - 1 - file, newMatrix.GetLength(1) - 1 - column] = elems_matrix[column, elems_matrix.GetLength(1) - 1 - file];
                }
            }
            if (newMatrix.GetLength(1) % 2 != 0)
            {
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    newMatrix[i, newMatrix.GetLength(1) / 2] = elems_matrix[elems_matrix.GetLength(0) / 2, i];
                }
            }
            return newMatrix;
        }
        private int[,] RotateMatrix_2(int[,] elems_matrix)
        {
            int files = elems_matrix.GetLength(0);
            int columns = elems_matrix.GetLength(1);
            int[,] newMatrix = new int[elems_matrix.GetLength(0), elems_matrix.GetLength(1)];
            for (int i = 0; i < files / 2; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newMatrix[i, j] = elems_matrix[files - 1 - i, columns - 1 - j];
                    newMatrix[files - 1 - i, columns - 1 - j] = elems_matrix[i, j];
                }
            }
            if (files % 2 == 1)
            {
                for (int j = 0; j < columns / 2; j++)
                {
                    newMatrix[(files / 2), j] = elems_matrix[(files / 2), columns - 1 - j];
                    newMatrix[(files / 2), columns - 1 - j] = elems_matrix[(files / 2), j];
                }
            }
            return newMatrix;
        }
        private int[,] RotateMatrix_3(int[,] elems_matrix)
        {
            int[,] newMatrix = new int[elems_matrix.GetLength(1), elems_matrix.GetLength(0)];
            for (int file = 0; file < newMatrix.GetLength(0); file++)
            {
                for (int column = 0; column < newMatrix.GetLength(1) / 2; column++)
                {
                    newMatrix[file, column] = elems_matrix[column, elems_matrix.GetLength(1) - 1 - file];
                    newMatrix[newMatrix.GetLength(0) - 1 - file, newMatrix.GetLength(1) - 1 - column] = elems_matrix[elems_matrix.GetLength(0) - 1 - column, file];
                }
            }
            return newMatrix;
        }
        #endregion
   
    }
}
