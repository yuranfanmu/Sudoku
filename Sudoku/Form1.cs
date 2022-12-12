using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        Label[,] field;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.Width = 330;
            this.Height = 350;
            createField();
            startNumbers();
            transpose();
            changeColumns(0, 1);
            //shuffle();
        }

        private void shuffle()
        {
            Random r = new Random();
            Random r1 = new Random();
            for (int i = 0; i < 100; i++)
            {
                switch (r.Next(1,5))
                {
                    case 1:
                        transpose();
                        Console.WriteLine("transpose");
                        break;
                    case 2:
                        int a = r1.Next(0, 8);
                        int b;
                        do
                        {
                            b = r1.Next(a/3 * 3, a / 3 * 3 + 2);
                        }
                        while (a == b);
                        changeRows(a, b);
                        Console.WriteLine("row");
                        break;
                    case 3:
                        int c = r1.Next(0, 8);
                        int d;
                        do
                        {
                            d = r1.Next(c / 3 * 3, c / 3 * 3 + 2);
                        }
                        while (c == d);
                        changeColumns(c, d);
                        Console.WriteLine("column");
                        break;
                    default:
                        Console.WriteLine("LOL");
                        break;
                }
            }
        }

        private void createField()
        {
            field = new Label[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    field[i, j] = new Label();
                    field[i, j].BackColor = Color.White;
                    field[i, j].Location = new Point(10 + 32 * i + i/3 * 2, 10 + 32 * j + j/3 *2);
                    field[i, j].Width = 30;
                    field[i, j].Height = 30;
                    field[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(field[i, j]);
                }
        }

        private void startNumbers()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    field[i, j].Text = ((i * 3 + i / 3 + j)%9 + 1).ToString();
        }
        private void transpose()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (i < j)
                    {
                        field[i, j].Text = (Convert.ToInt32(field[i,j].Text) + Convert.ToInt32(field[j, i].Text)).ToString();
                        field[j, i].Text = (Convert.ToInt32(field[i, j].Text) - Convert.ToInt32(field[j, i].Text)).ToString();
                        field[i, j].Text = (Convert.ToInt32(field[i, j].Text) - Convert.ToInt32(field[j, i].Text)).ToString();
                    }
                        
                }
        }
        private void changeRows(int a, int b)
        {
            for (int i = 0; i < 9; i++)
            {
                field[i, a].Text = (Convert.ToInt32(field[i, a].Text) + Convert.ToInt32(field[i, b].Text)).ToString();
                field[i, b].Text = (Convert.ToInt32(field[i, a].Text) - Convert.ToInt32(field[i, b].Text)).ToString();
                field[i, a].Text = (Convert.ToInt32(field[i, a].Text) - Convert.ToInt32(field[i, b].Text)).ToString();
            }
        }
        private void changeColumns(int a, int b)
        {
            for (int i = 0; i < 9; i++)
            {
                field[a, i].Text = (Convert.ToInt32(field[a, i].Text) + Convert.ToInt32(field[b, i].Text)).ToString();
                field[b, i].Text = (Convert.ToInt32(field[a, i].Text) - Convert.ToInt32(field[b, i].Text)).ToString();
                field[a, i].Text = (Convert.ToInt32(field[a, i].Text) - Convert.ToInt32(field[b, i].Text)).ToString();
            }
        }
        private void changeNumbers()
        {
            Random r = new Random();
            int[] number = new int[9];
            for (int i = 0; i < 9; i++)
            {

            }
        }
    }
}
