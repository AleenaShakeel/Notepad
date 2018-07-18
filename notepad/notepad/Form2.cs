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
    public partial class Form2 : Form
    {
        string txt;
        public Form2(string text)
        {
            txt = text;
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.button1;
            this.Text = "Find";
            this.button1.Text = "Find";
            this.button1.Enabled = false;
            this.button2.Text = "Cancel";
            this.label1.Text = "Find What:";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CancelButton = this.button2;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt.Contains( this.textBox1.Text) )
            {
                MessageBox.Show("Find It","Finder",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Not Found","Finder",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
