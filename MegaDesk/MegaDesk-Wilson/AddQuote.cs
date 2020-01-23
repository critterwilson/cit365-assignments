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
    public partial class AddQuote : Form
    {
        public AddQuote(ref Form caller)
        {
            InitializeComponent();
            // Indicate who called this form (Main Menu)
            this.Caller = caller;

            // Link the enums to the drop down
            List<SurfaceMaterial> materials =
                Enum.GetValues(typeof(SurfaceMaterial))
                .Cast<SurfaceMaterial>()
                .ToList();

            List<RushType> shipping =
                Enum.GetValues(typeof(RushType))
                .Cast<RushType>()
                .ToList();

            // Start our drop downs with blank selection
            dropMaterial.DataSource = materials;
            dropShipping.DataSource = shipping;

            dropMaterial.SelectedIndex = -1;
            dropShipping.SelectedIndex = -1;
        }

        public Form Caller { get; }

        private void txtDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Caller.Show();
        }

        private void AddQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Caller.Show();
        }
    }
}
