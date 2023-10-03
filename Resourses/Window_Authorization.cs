using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace DeliveryApp.Resourses
{
    
    public partial class Window_Authorization : Form
    {
        protected string password = "689607104D03A2D153B5D017AB78DB82";
        public Window_Authorization()
        {
            InitializeComponent();
        }

        private void Button_CheckAuthData_Click(object sender, EventArgs e)
        {
            string writtenDataHash = Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(TextBox_Login.Text + TextBox_Password.Text)));
            if(writtenDataHash == password)
            {
                FindForm().Visible = false;
                FindForm().Enabled = false;

            }
        }
    }
}
