using System;
using System.Windows.Forms;
using System.IO;

namespace notepad_sharp
{
    public partial class Form1 : Form
    {
        public string fpath;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Python files(*.py)|*.py|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|Python files(*.py)|*.py|All files(*.*)|*.*";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            fpath = openFileDialog1.FileName;
            textBox1.Text = File.ReadAllText(fpath);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fpath = saveFileDialog1.FileName;
            File.WriteAllText(fpath, textBox1.Text);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fattr = new FileInfo(fpath);
                if (fattr.Extension == "py")
                {
                    System.Diagnostics.Process.Start("CMD.exe", "/k " + $"python {fpath}");
                }
                else
                {
                    MessageBox.Show("Selected file isn't .py", "Attention!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select file!", "Attention!");
            }
        }
    }
}
