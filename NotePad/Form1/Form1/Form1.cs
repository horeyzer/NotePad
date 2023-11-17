using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Font1 : Form
    {
        public Font1()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = textBox1.Text.Length.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible)
            { statusStrip1.Visible = false; }
            else
            { statusStrip1.Visible = true; }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                fontDialog1.ShowDialog();
                textBox1.Font = fontDialog1.Font;
            }
            catch
            {
                textBox1.Font = fontDialog1.Font;
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.ForeColor = colorDialog1.Color;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.No;
            dr = MessageBox.Show("Are you sure?",
                                    "MESSAGE",
                                    MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                textBox1.Text = "";
            }
            else
            {
                //do smth else myself
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();

                FileStream fs = new FileStream(openFileDialog1.FileName,
                                                FileMode.Open,
                                                FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    textBox1.Text += sr.ReadLine();
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                                   FileMode.Create,
                                                   FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(textBox1.Text);
                sr.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Test");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }
    }
}
