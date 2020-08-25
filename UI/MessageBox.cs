using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MessageBox : Form
    {
        public MessageBox(string Message)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            this.textBox2.Text = Message;
        }

        private void panelAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAll_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }

        private void panelMessage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
