using System.Windows.Forms;

namespace BitAuto.Ucar.Utils.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SPHelpForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SPHelpForm()
        {
            InitializeComponent();
        }

        private void SPHelpForm_Load(object sender, System.EventArgs e)
        {
            textBox1.Select(0, 0);
        }
    }
}
