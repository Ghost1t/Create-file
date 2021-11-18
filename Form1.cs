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
        private static readonly List<int> numbers = new();

        public Form1()
        {
            InitializeComponent();
        }

        void Button1_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            textBox2.Clear();

            int Kol = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i <= Kol-1; i++) // Запись в коллекцию произвольных чисел.
            {
                int value = new Random().Next();
                numbers.Add(value);
            }


            for (int i = 0; i < numbers.Count; i++) // Запись коллекции  в textBox2.
            {

                textBox2.Text += numbers[i].ToString() + "\r\n";

            }

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
    }
}
