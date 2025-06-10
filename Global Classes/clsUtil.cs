using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDBussiensTier.Global_Classes
{
    static public class clsUtil
    {
       static public string GetImageExtinon(string ImagePath)
        {
            return new FileInfo(ImagePath).Extension;
        }
        static public bool RemoveImageFile(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                return false;

            try
            {
                File.Delete(imagePath);
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
