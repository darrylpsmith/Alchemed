using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsultWill
{
    public partial class Comments : Form
    {

        public string Comment
        {
            get
            {
                return txtComments.Text;
            }
            set
            {
                txtComments.Text = value;
            }

        }
        public Comments()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.BackColor;
        }
    }
}
