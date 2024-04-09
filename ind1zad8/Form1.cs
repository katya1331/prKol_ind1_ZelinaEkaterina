using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.IO.File;
using System.IO;

namespace ind1zad8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string path = textBox1.Text;
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string formula = ReadAllText(path);
                    int result = Formula(formula);
                    listBox1.Items.Add ("Значение формулы: " + result);
                }
            }
            else { MessageBox.Show("File don't exist!"); textBox1.Clear(); }
        }
        public static int Formula(string formula)
        {
            Stack<int> stack = new Stack<int>();
            string[] bt = formula.Split(new char[] { ')','(',',','|'},StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var b in bt.Reverse() )
            {
                if (b =="M")
                {
                    int max = stack.Pop();
                    int min = stack.Pop();
                    stack.Push(Math.Max(max, min));
                }else if(b == "m")
                {
                    int max = stack.Pop();
                    int min = stack.Pop();
                    stack.Push(Math.Min(max, min));
                }else
                {
                    stack.Push(Convert.ToInt32(b));
                }
            }
            return stack.Pop();
        }
    }
}
