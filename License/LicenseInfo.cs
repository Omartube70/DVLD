using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDBussiensTier
{
    public partial class LicenseInfo : Form
    {
        public LicenseInfo(int LicenseID)
        {
            InitializeComponent();
            ctrDriverLicenseInfo1.LoadDateToCtr(LicenseID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
