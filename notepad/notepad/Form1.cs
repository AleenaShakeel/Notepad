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

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.copyToolStripMenuItem.Enabled = true;
            this.pasteToolStripMenuItem.Enabled = true;
            this.findNextToolStripMenuItem.Enabled = true;
            this.pasteToolStripMenuItem.Enabled = true;
            this.deleteToolStripMenuItem.Enabled = true;
            this.findToolStripMenuItem.Enabled = true;
            this.goToToolStripMenuItem.Enabled = true;
            this.copyToolStripMenuItem1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Notepad By Aleena";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.textBox1.ScrollBars = ScrollBars.Both;
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.copyToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.C;
            this.pasteToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.P;
            this.deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            this.findToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.findNextToolStripMenuItem.ShortcutKeys = Keys.F3;
            this.replaceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.H;
            this.goToToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            this.selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            this.timeDateToolStripMenuItem.ShortcutKeys = Keys.F5;
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.opemToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            this.copyToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Enabled = false;
            this.findNextToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Enabled = false;
            this.findToolStripMenuItem.Enabled = false;
            this.goToToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem1.Enabled = false;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Clear();
            }
            else
            {
               DialogResult dry = MessageBox.Show("Do you want to save changes to " + this.Text + "?","Notepad", MessageBoxButtons.YesNoCancel);
               if (dry == DialogResult.Yes)
               {
                   saveFileDialog1.Filter = "savefile *.txt|*.txt";
                   DialogResult dr = this.saveFileDialog1.ShowDialog();
                   if (dr == DialogResult.OK)
                   {
                       string sname = saveFileDialog1.FileName;
                       File.WriteAllText(sname, this.textBox1.Text);
                       this.textBox1.BackColor = Color.White;
                       textBox1.Clear();
                   }
               }
               else if (dry == DialogResult.No)
               {
                   this.textBox1.BackColor = Color.White;
                   textBox1.Clear();
               }
            }
        }

        private void wordwrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordwrapToolStripMenuItem.Checked == false)
            {
                this.wordwrapToolStripMenuItem.Checked = true;
                this.textBox1.WordWrap = true;
            }
            else if (wordwrapToolStripMenuItem.Checked == true)
            {
                this.wordwrapToolStripMenuItem.Checked = false;
                this.textBox1.WordWrap = false;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Undo();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2=new Form2(textBox1.Text);
            frm2.ShowDialog();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += System.DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.Font = this.fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.textBox1.ForeColor = this.colorDialog1.Color;
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(textBox1.Text);
            frm3.frm1 = this;
            frm3.ShowDialog();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void opemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "filetext *.txt|*.txt ";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fname = openFileDialog1.FileName;
                this.textBox1.Text = File.ReadAllText(fname);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "savefile *.txt|*.txt";
            DialogResult dr = this.saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string sname = saveFileDialog1.FileName;
                File.WriteAllText(sname, this.textBox1.Text);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to change your " + this.Text + " color?", "Color Selection", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DialogResult clr = this.colorDialog1.ShowDialog();
                if (clr == DialogResult.OK)
                {
                    this.textBox1.BackColor = colorDialog1.Color;
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text == "")
            {
                Application.Exit();
            }
            else
            {
                DialogResult dry = MessageBox.Show("Do you want to save changes to " + this.Text + "?", "Notepad", MessageBoxButtons.YesNoCancel);
                if (dry == DialogResult.Yes)
                {
                    saveFileDialog1.Filter = "savefile *.txt|*.txt";
                    DialogResult dr = this.saveFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        string sname = saveFileDialog1.FileName;
                        File.WriteAllText(sname, this.textBox1.Text);
                        this.textBox1.BackColor = Color.White;
                        textBox1.Clear();
                    }
                }
                else if (dry == DialogResult.No)
                {
                    this.textBox1.BackColor = Color.White;
                    textBox1.Clear();
                }
            }
        }
    }
}
