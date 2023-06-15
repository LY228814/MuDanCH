using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.Components.UcarQuote
{
    /// <summary>
    /// 实体类UcarQuoteDS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class UcarQuoteDS
    {
        #region UcarQuoteDS
        private int _uqid = 0;
        private int _ucarid = 0;
        private int _userid = 0;
        private int _usertype = 0;
        private int _quotetype = 0;
        private string _quotermobile = string.Empty;
        private decimal _quoteamount = 0;
        private string _quotereason = string.Empty;
        private DateTime _quotetime = DateTime.MinValue;
        private int _quotestatus = 0;
        private int _candiscuss = -1;
        /// <summary>
        /// 报价ID
        /// </summary>
        public int UqID
        {
            set { _uqid = value; }
            get { return _uqid; }
        }
        /// <summary>
        /// 车源ID
        /// </summary>
        public int UcarID
        {
            set { _ucarid = value; }
            get { return _ucarid; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户类型 1-个人用户 2-车商通用户 3-改版前的企业用户 4-改版前的匿名用户
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 报价类型 1-优卡报价 2-短信报价 3-车商通报价
        /// </summary>
        public int QuoteType
        {
            set { _quotetype = value; }
            get { return _quotetype; }
        }
        /// <summary>
        /// 报价人手机号
        /// </summary>
        public string QuoterMobile
        {
            set { _quotermobile = value; }
            get { return _quotermobile; }
        }
        /// <summary>
        /// 报价金额
        /// </summary>
        public decimal QuoteAmount
        {
            set { _quoteamount = value; }
            get { return _quoteamount; }
        }
        /// <summary>
        /// 报价原因
        /// </summary>
        public string QuoteReason
        {
            set { _quotereason = value; }
            get { return _quotereason; }
        }
        /// <summary>
        /// 报价时间
        /// </summary>
        public DateTime QuoteTime
        {
            set { _quotetime = value; }
            get { return _quotetime; }
        }
        /// <summary>
        /// 报价状态
        /// </summary>
        public int QuoteStatus
        {
            set { _quotestatus = value; }
            get { return _quotestatus; }
        }
        /// <summary>
        /// 是否可议
        /// </summary>
        public int CanDiscuss
        {
            set { _candiscuss = value; }
            get { return _candiscuss; }
        }
        #endregion Model
    }
}
