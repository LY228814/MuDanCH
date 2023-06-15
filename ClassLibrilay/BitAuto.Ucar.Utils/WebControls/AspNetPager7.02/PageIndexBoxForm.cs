using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BitAuto.Ucar.Utils.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PageIndexBoxForm : Form
    {
        ShowPageIndexBox showIndexBox;

        /// <summary>
        /// 
        /// </summary>
        public ShowPageIndexBox ShowIndexBox
        {
            get { return showIndexBox; }
            set { showIndexBox = value; }
        }

        int threshold;

        /// <summary>
        /// 
        /// </summary>
        public int Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        PageIndexBoxType boxType;

        /// <summary>
        /// 
        /// </summary>
        public PageIndexBoxType BoxType
        {
            get { return boxType; }
            set { boxType = value; }
        }

        string textBeforeBox;

        /// <summary>
        /// 
        /// </summary>
        public string TextBeforeBox
        {
            get { return textBeforeBox; }
            set { textBeforeBox = value; }
        }

        string textAfterBox;

        /// <summary>
        /// 
        /// </summary>
        public string TextAfterBox
        {
            get { return textAfterBox; }
            set { textAfterBox = value; }
        }

        string submitButtonText;

        /// <summary>
        /// 
        /// </summary>
        public string SubmitButtonText
        {
            get { return submitButtonText; }
            set { submitButtonText = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showBox"></param>
        /// <param name="threshold"></param>
        /// <param name="boxType"></param>
        /// <param name="txtBefore"></param>
        /// <param name="txtAfter"></param>
        /// <param name="btnText"></param>
        public PageIndexBoxForm(ShowPageIndexBox showBox,int threshold,PageIndexBoxType boxType,string txtBefore,string txtAfter,string btnText)
        {
            InitializeComponent();
            showIndexBox = showBox;
            this.threshold = threshold;
            this.boxType = boxType;
            textBeforeBox = txtBefore;
            textAfterBox = txtAfter;
            submitButtonText = btnText;
        }

        private void PageIndexBoxForm_Load(object sender, EventArgs e)
        {
            num_threshold.Value = threshold;
            cmb_boxtype.SelectedIndex = (boxType == PageIndexBoxType.DropDownList) ? 1 : 0;
            switch (showIndexBox)
            {
                case ShowPageIndexBox.Always:
                    rb_always.Checked = true;
                    num_threshold.Enabled = false;
                    break;
                case ShowPageIndexBox.Never:
                    rb_never.Checked = true;
                    tb_btntxt.Enabled=tb_textaft.Enabled=tb_textbf.Enabled=num_threshold.Enabled = cmb_boxtype.Enabled = false;
                    break;
                default:
                    rb_auto.Checked = true;
                    break;
            }

        }

        private void RblCheckedChanged(object sender, EventArgs e)
        {
            if (rb_never.Checked)
            {
                tb_btntxt.Enabled = tb_textaft.Enabled = tb_textbf.Enabled = num_threshold.Enabled = cmb_boxtype.Enabled = false;
            }
            else if (rb_always.Checked)
            {
                num_threshold.Enabled = false;
                cmb_boxtype.Enabled = tb_textaft.Enabled = tb_textbf.Enabled = true;
                tb_btntxt.Enabled = cmb_boxtype.SelectedIndex == 0;                    
            }
            else
            {
                tb_textaft.Enabled = tb_textbf.Enabled = num_threshold.Enabled = cmb_boxtype.Enabled = true;
                tb_btntxt.Enabled = cmb_boxtype.SelectedIndex == 0;                   
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (rb_never.Checked)
                showIndexBox = ShowPageIndexBox.Never;
            else if (rb_always.Checked)
            {
                showIndexBox = ShowPageIndexBox.Always;
                boxType = (PageIndexBoxType)cmb_boxtype.SelectedIndex;
                textAfterBox = tb_textaft.Text;
                textBeforeBox = tb_textbf.Text;
                submitButtonText = tb_btntxt.Text;
            }
            else
            {
                showIndexBox = ShowPageIndexBox.Always;
                threshold = (int)num_threshold.Value;
                boxType = (PageIndexBoxType)cmb_boxtype.SelectedIndex;
                textAfterBox = tb_textaft.Text;
                textBeforeBox = tb_textbf.Text;
                submitButtonText = tb_btntxt.Text;
            }
        }

        private void cmb_boxtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_btntxt.Enabled=cmb_boxtype.SelectedIndex == 0;
        }
    }
}
