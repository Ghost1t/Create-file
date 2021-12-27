using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<int> numbers = new(); //Все числа
        List<char> allnum = new(); //Все цифры
        List<Units> inumbers = new();
        int k = 0;


        public Form1()
        {
            InitializeComponent();
        }

        void Button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Refresh();
            inumbers.Clear();
            inumbers.Add(new Units { Number_Name = "Нулей", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Единиц", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Двоек", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Троек", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Четвёрок", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Пятёрок", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Шестёрок", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Семёрок", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Восьмёрок", Number_Kol = 0 });
            inumbers.Add(new Units { Number_Name = "Девяток", Number_Kol = 0 });
            numbers.Clear();
            textBox2.Clear();
            allnum.Clear();
            float number0123456789 = 0; //Всего цифр

            int Kol = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i <= Kol - 1; i++) // Запись в коллекцию произвольных чисел.
            {
                int value = new Random().Next();
                numbers.Add(value);
                string value2 = value.ToString();
                for (int j = 0; j < value2.Length; j++)
                {
                    allnum.Add(value2[j]);
                }
            }


            for (int i = 0; i < numbers.Count; i++) // Запись коллекции  в textBox2.
            {

                textBox2.Text += numbers[i].ToString() + "\r\n";

            }
            for (int i = 0; i < allnum.Count; i++) // Запись коллекции  в textBox2.
            {
                switch (allnum[i])
                {
                    case '0':
                        inumbers[0].Number_Kol++;
                        break;

                    case '1':
                        inumbers[1].Number_Kol++;
                        break;

                    case '2':
                        inumbers[2].Number_Kol++;
                        break;

                    case '3':
                        inumbers[3].Number_Kol++;
                        break;

                    case '4':
                        inumbers[4].Number_Kol++;
                        break;

                    case '5':
                        inumbers[5].Number_Kol++;
                        break;

                    case '6':
                        inumbers[6].Number_Kol++;
                        break;

                    case '7':
                        inumbers[7].Number_Kol++;
                        break;

                    case '8':
                        inumbers[8].Number_Kol++;
                        break;

                    case '9':
                        inumbers[9].Number_Kol++;
                        break;
                }
                number0123456789++;
            }

            /*for (int i = 0; i <= 9; i++)
            {
                textBox2.Text += inumbers[i].Number_Name + ": " + inumbers[i].Number_Kol + "\r\n";
            }*/

            textBox2.Text += "\r\n" + "Всего цифр: " + number0123456789 + "\r\n";

            List<SolidBrush> My_color = new()
            {
                new SolidBrush(Color.Aqua),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.Green),
                new SolidBrush(Color.Gray),
                new SolidBrush(Color.Yellow),
                new SolidBrush(Color.DarkBlue),
                new SolidBrush(Color.DarkCyan),
                new SolidBrush(Color.DarkOliveGreen),
                new SolidBrush(Color.DarkOrange),
                new SolidBrush(Color.DarkGoldenrod),
                new SolidBrush(Color.DarkKhaki),
                new SolidBrush(Color.DarkMagenta)
            };
            float Start = 0;
            float Ppie = 360 / number0123456789;

            int p = 0;
            int r = 0;
            Label[] lbl = new Label[10];

            foreach (Units num in inumbers)
            {
                if (num.Number_Kol != 0)
                {
                    if(k > 0)
                    {
                        lbl[p].Dispose();
                    }    
                    lbl[p] = new Label();
                    lbl[p].Location = new Point(530, 20 + r * 30);
                    lbl[p].Size = new Size(100, 30);
                    lbl[p].Text = num.Number_Name + ": " + num.Number_Kol;
                    lbl[p].Parent = this;
                    this.Controls.Add(lbl[p]);
                    Graphics h = CreateGraphics();
                    h.FillRectangle(My_color[p], new Rectangle(520, 22 + r * 30, 10, 10));
                    h.DrawPie(new Pen(Color.White, 2), 308, 94, 200, 200, Start, Ppie * num.Number_Kol);
                    h.FillPie(My_color[p], 308, 94, 200, 200, Start, Ppie * num.Number_Kol); // заливка             
                    h.Dispose(); // Очистка памяти
                    Start += Ppie * num.Number_Kol;
                    r++;
                }
                p++;
            }
            k++;
            return;
        }


        void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"; // Расширение файла.
            saveFileDialog1.FilterIndex = 2; // Получает или задает индекс фильтра, выбранного в данный момент в диалоговом окне файла.
            saveFileDialog1.RestoreDirectory = true; // Восстанавливает ли диалоговое окно каталог в ранее выбранный каталог перед закрытием.

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog1.FileName, numbers.ConvertAll(x => x.ToString())); // Запись в файл "FileName" коллекции numbers.
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
