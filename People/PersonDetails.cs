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
    public partial class PersonDetails : Form
    {
        public PersonDetails(int PersonID)
        {
            InitializeComponent();
            ctrPersonDetails1.PersonID = PersonID;
            ctrPersonDetails1.LoadPersonDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
