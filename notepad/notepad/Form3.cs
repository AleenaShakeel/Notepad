using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form3 : Form
    {
        public Form1 frm1;
        string txt;
        public Form3(string text)
        {
            //frm1 = ff1;
            txt = text;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "Replace";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.label1.Text = "Find What:";
            this.label2.Text = "Replace With:";
            this.button1.Text = "Replace";
            this.button2.Text = "Clear";
            this.button3.Text = "Cancel";
            this.button1.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.AcceptButton = this.button1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frm1.textBox1.Text=ff1.textBox1.Text.Replace(ff1.textBox1.Text,frm1.te
            if (txt.Contains(this.textBox1.Text))
            {
                txt = txt.Replace(this.textBox1.Text, this.textBox2.Text);
                frm1.textBox1.Text = txt;
            }
            else
            {
                MessageBox.Show("Word not found", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
