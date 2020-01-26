using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Wilson
{
    public partial class DisplayQuote : Form
    {
        public DisplayQuote(ref Form Caller)
        {
            InitializeComponent();
            this.Caller = Caller;
        }


        private Form Caller;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Caller.Show();
            this.Close();
        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            Caller.Show();
        }
    }
}
