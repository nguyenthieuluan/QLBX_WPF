using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBX
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string kq { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            kq = "xoa";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kq = "thanhtoan";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kq = "thoat";
            this.Close();
        }
    }
}
