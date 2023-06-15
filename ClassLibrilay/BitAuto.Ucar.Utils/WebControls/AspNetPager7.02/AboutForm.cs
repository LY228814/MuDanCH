using System;
using System.Windows.Forms;
using System.Reflection;

namespace BitAuto.Ucar.Utils.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public AboutForm()
        {
            //InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bitauto.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ucar.cn/");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            //label1.Text = "控件版本：7.0.2.0"; //+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
