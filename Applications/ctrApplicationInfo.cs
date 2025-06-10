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
using DVLDBussiensTier.Applications;

namespace DVLDBussiensTier.Tests1
{
    public partial class ctrApplicationInfo : UserControl
    {
        public ctrApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadDateToCtr(int ApplicationID)
        {

            clsApplication ApplicationInfo = clsApplication.FindByApplicationID(ApplicationID);

            if(ApplicationInfo == null)
            {
                MessageBox.Show($"Not Found Application was Is {ApplicationID}" , "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = ApplicationInfo.ApplicationID.ToString();
            lblStatus.Text = ApplicationInfo.ApplicationStatus.ToString();
            lblFess.Text = ApplicationInfo.PaidFees.ToString();
            lblType.Text = ApplicationInfo.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicant.Text = ApplicationInfo.ApplicationPersonInfo.FullName;
            lblDate.Text = ApplicationInfo.ApplicationDate.ToString();
            lblStatusDate.Text = ApplicationInfo.LastStatusDate.ToString();
            lblCretedBy.Text = ApplicationInfo.CreatedByUserInfo.UserName;
        }

    }
}





