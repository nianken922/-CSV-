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

namespace CSV
{
    public partial class Form1 : Form
    {
        int r;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            for(int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    r = Mutiply(i, j);
                    textBox1.Text += i + "*" + j + "=," + r+",,";
                    if (j == 9)
                    {
                        textBox1.Text += Environment.NewLine;
                    }
                }
             }
        }
        private void btnStart2_Click(object sender, EventArgs e)
        {
            for(int i = 1; i <= 9; i++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    r = Mutiply(i, k);
                    textBox1.Text += k + "*" + i + "=," + r + ",,";
                    if (k == 9)
                    {
                        textBox1.Text += Environment.NewLine;
                    }
                }
            }
        }

        private static int Mutiply(int i, int j)
        {
            int r;
            {
                r = i * j;
            }
            return r;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(File.Create(saveFile.FileName));//第二種方式
                writer.Write(textBox1.Text);
                writer.Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
          
           
            OpenFileDialog dialog = new OpenFileDialog();//選擇路徑
            dialog.Title = "open title";
            dialog.Filter="Text Files(*.txt)|*.txt|all files(*.*)|*.*";
            string file="";
            int size;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(File.OpenRead(dialog.FileName));
                textBox1.Text += reader.ReadToEnd();
                reader.Dispose();

                file = dialog.FileName;
                string text = File.ReadAllText(file);//顯示完整路徑
                size = text.Length;
                textBox2.Text = file;//顯示完整路徑
                
                //string[] readtext2= File.ReadAllLines(file, Encoding.Default);
                //foreach (string q in readtext2)
                //{
                //    textBox1.Text += q + "\r\n";
                //}//相對路徑存取方式        
            }
          
        }

       
    }
}
