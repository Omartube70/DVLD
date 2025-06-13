using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDBussiensTier.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LocalApplicationId = 0;

        public frmLocalDrivingLicenseApplicationInfo(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationId = LocalApplicationID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if(_LocalApplicationId != -1)
            {
                ctrlApplicationBasicInfo1.LoadLocalApplicationInfo(_LocalApplicationId);
            }
        }
    }
}
