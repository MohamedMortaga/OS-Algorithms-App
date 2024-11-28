using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<int> LAllocation = new List<int>();
        List<string> LMax = new List<string>();
        List<string> LNeed = new List<string>();
        List<int> LAv = new List<int>();
        int stop = 0, p = 0;

        string y, v;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (p > 0)
                    {
                        p--;
                    }
                    break;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            richTextBox1.Clear();

            for (int i = 0; i < Convert.ToInt16(num); i++)
            {
                richTextBox1.AppendText("P" + Convert.ToString(i) + Environment.NewLine);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            string num = textBox2.Text;
            for (int i = 0; i < richTextBox1.Lines.Length - 1; i++)
            {

                LAllocation.Add(Convert.ToInt16(richTextBox2.Lines[i]));
                LMax.Add(richTextBox3.Lines[i]);

            }

            for (int i = 0; i < richTextBox1.Lines.Length - 1; i++)
            {
                int x = Convert.ToInt16(LMax[i]) - Convert.ToInt16(LAllocation[i]);
                string need = Convert.ToString(x);
                v = Convert.ToString(need);


                if (need.Length < Convert.ToInt16(num))
                {
                    count = Convert.ToInt16(num) - need.Length;
                    for (int j = 0; j < count; j++)
                    {
                        y = '0' + v;
                        v = y;
                    }
                    richTextBox4.AppendText(v + Environment.NewLine);
                    LNeed.Add(v);
                }
                else
                {
                    richTextBox4.AppendText(Convert.ToString(need) + Environment.NewLine);
                    LNeed.Add(need);
                }


            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < LAllocation.Count; y++)
            {

                stop += LAllocation[y];

            }
            stop += LAv[LAv.Count - 1];


            string num = textBox2.Text;
            List<int> Lresources1 = new List<int>(Convert.ToInt16(num));
            List<int> Lresources2 = new List<int>(Convert.ToInt16(num));


            while (Convert.ToInt16(richTextBox5.Lines[richTextBox5.Lines.Length - 1]) != stop)
            {

                for (int i = 0; i < richTextBox4.Lines.Length - 1; i++)
                {
                    string line2 = Convert.ToString(richTextBox4.Lines[i]);
                    string line1 = Convert.ToString(richTextBox5.Lines[richTextBox5.Lines.Length - 1]);
                    for (int g = 0; g < Convert.ToInt16(num); g++)
                    {
                        Lresources1.Add(Convert.ToInt16(line1.ToCharArray()[g]));
                        Lresources2.Add(Convert.ToInt16(line2.ToCharArray()[g]));
                    }

                    int count = 0;
                    for (int g = 0; g < Convert.ToInt16(num); g++)
                    {
                        if (Lresources1[g] > Lresources2[g])
                        {
                            count++;
                        }

                    }

                    if (count == Convert.ToInt16(num) - 1)
                    {
                        int Av = LAllocation[i] + LAv[LAv.Count - 1];
                        LAv.Add(Av);
                        richTextBox5.AppendText(Environment.NewLine + Convert.ToString(Av));
                    }

                }

                for (int k = 0; k < Convert.ToInt16(num); k++)
                {
                    Lresources2.RemoveAt(k);
                    Lresources1.RemoveAt(k);
                }
            }
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            p++;
            if (p == Convert.ToInt16(textBox2.Text))
            {
                for (int i = 0; i < richTextBox5.Lines.Length; i++)
                {
                    LAv.Add(Convert.ToInt16(richTextBox5.Lines[i]));

                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            LAv.Clear();
            LAllocation.Clear();
            LMax.Clear();
            LNeed.Clear();
            textBox1.Text = null;
            textBox2.Text = null;
            stop = 0;
            p = 0;
            y = null;
            v=null;
        }
    }
}
