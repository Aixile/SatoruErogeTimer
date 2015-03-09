using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatoruErogeTimer
{
    public partial class QueryForm : Form
    {
        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        public QueryForm()
        {
            InitializeComponent();
			//Fix form size
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            
        }
        public string str;
        private void button1_Click(object sender, EventArgs e)
        {
            str = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.Flag;
        }
    }
}
