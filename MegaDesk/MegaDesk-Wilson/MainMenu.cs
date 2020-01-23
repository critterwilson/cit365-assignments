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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            me = this;
        }

        private void btnAddQuote_Click(object sender, EventArgs e)
        {
            AddQuote NewQuote = new AddQuote(ref me);
            Hide();
            NewQuote.Show();
        }

        private void btnDisplayQuote_Click(object sender, EventArgs e)
        {
            DisplayQuote Display = new DisplayQuote(ref me);
            Hide();
            Display.Show();
        }


        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            ViewAllQuotes ViewQuotes = new ViewAllQuotes(ref me);
            Hide();
            ViewQuotes.Show();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            SearchQuotes Search = new SearchQuotes(ref me);
            Hide();
            Search.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        public Form me;

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
