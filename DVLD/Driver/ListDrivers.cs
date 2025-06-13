using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drving_VehicleBusinessTier;

namespace DVLDBussiensTier
{
    public partial class ListDrivers : Form
    {
        public ListDrivers()
        {
            InitializeComponent();
        }


        private DataTable _dtAllDrivers;

        private void cbColumName_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cbColumName.SelectedItem.ToString() == "None")
                {
                    txtFilterBy.Visible = false;
                    txtFilterBy.Text = "";
                }
                else
                {
                    txtFilterBy.Visible = true;
                    txtFilterBy.Text = "";
                }
            }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbColumName.SelectedItem.ToString() == "Driver ID" || cbColumName.SelectedItem.ToString() == "Person ID")
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

            }
            else
            {
                e.Handled = false;

            }
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFilterBy.Text == "")
            {
                ListDrivers_Load(null,null);
                return;
            }

            switch (cbColumName.SelectedItem.ToString())
            {
                case "National No.":
                    _dtAllDrivers.DefaultView.RowFilter = "[National No.] LIKE '" + txtFilterBy.Text + "%'";
                    break;

                case "Full Name":
                    _dtAllDrivers.DefaultView.RowFilter = "[Full Name] LIKE '" + txtFilterBy.Text + "%'";
                    break;

                case "Driver ID":
                    _dtAllDrivers.DefaultView.RowFilter = "[Driver ID] = " + txtFilterBy.Text + "";
                    break;


                case "Person ID":
                    _dtAllDrivers.DefaultView.RowFilter = "[Person ID] = " + txtFilterBy.Text + "";
                    break;
            }

            lblRecords.Text = dgvDrivers.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListDrivers_Load(object sender, EventArgs e)
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;
            lblRecords.Text = dgvDrivers.RowCount.ToString();
        }
    }
}





