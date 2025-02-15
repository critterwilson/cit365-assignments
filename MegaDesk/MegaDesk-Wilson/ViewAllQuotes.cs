﻿using System;
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
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes(ref Form caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Caller.Show();
            this.Close();
        }

        public Form Caller { get; }

        private void ViewAllQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Caller.Show();
        }
    }
}
