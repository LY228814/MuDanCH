using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.Components.UcarBasicInfo
{
    /// <summary>
    /// 实体类UcarBasicInfoDS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UcarBasicInfoDS
    {
        #region UcarBasicInfoDS
        private int _ucarid = 0;
        private string _ucarserialnumber = string.Empty;
        private long _carid = 0;
        private int _userid = 0;
        private int _ucartype = 0;
        private string _color = string.Empty;
        private string _vincode = string.Empty;
        private DateTime _buycardate = DateTime.MinValue;
        private int _licenselocation = 0;
        private int _ucarlocation = 0;
        private int _drivingmileage = 0;
        private int _salewithlicense = -1;
        private int _cartype = 0;
        private int _maintainrecord = -1;
        private DateTime _examineexpiredate = DateTime.MinValue;
        private DateTime _insuranceexpiredate = DateTime.MinValue;
        private DateTime _tollexpiredate = DateTime.MinValue;
        private string _statedescription = string.Empty;
        private string _cardcode = string.Empty;
        private int _cardrangeid = 0;
        private int _source = 0;
        private DateTime _createtime = DateTime.MinValue;
        private DateTime _statusmodifytime = DateTime.MinValue;
        private int _ucarstatus = 3;
        private int _usertype = -1;
        private int _isauthenticated = -1;
        private int _SystemId = 1;
        /// <summary>
        /// 车源ID
        /// </summary>
        public int UcarID
        {
            set { _ucarid = value; }
            get { return _ucarid; }
        }
        /// <summary>
        /// 车源编号
        /// </summary>
        public string UcarSerialNumber
        {
            set { _ucarserialnumber = value; }
            get { return _ucarserialnumber; }
        }
        /// <summary>
        /// 车型ID
        /// </summary>
        public long CarID
        {
            set { _carid = value; }
            get { return _carid; }
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
        /// 车源类型
        /// </summary>
        public int UcarType
        {
            set { _ucartype = value; }
            get { return _ucartype; }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 车架号
        /// </summary>
        public string VinCode
        {
            set { _vincode = value; }
            get { return _vincode; }
        }
        /// <summary>
        /// 原始购车日期
        /// </summary>
        public DateTime BuyCarDate
        {
            set { _buycardate = value; }
            get { return _buycardate; }
        }
        /// <summary>
        /// 车牌所在地
        /// </summary>
        public int LicenseLocation
        {
            set { _licenselocation = value; }
            get { return _licenselocation; }
        }
        /// <summary>
        /// 车辆所在地
        /// </summary>
        public int UcarLocation
        {
            set { _ucarlocation = value; }
            get { return _ucarlocation; }
        }
        /// <summary>
        /// 行驶里程
        /// </summary>
        public int DrivingMileage
        {
            set { _drivingmileage = value; }
            get { return _drivingmileage; }
        }
        /// <summary>
        /// 是否带牌销售
        /// </summary>
        public int SaleWithLicense
        {
            set { _salewithlicense = value; }
            get { return _salewithlicense; }
        }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public int CarType
        {
            set { _cartype = value; }
            get { return _cartype; }
        }
        /// <summary>
        /// 是否提供维修保养记录
        /// </summary>
        public int MaintainRecord
        {
            set { _maintainrecord = value; }
            get { return _maintainrecord; }
        }
        /// <summary>
        /// 年审到期日
        /// </summary>
        public DateTime ExamineExpireDate
        {
            set { _examineexpiredate = value; }
            get { return _examineexpiredate; }
        }
        /// <summary>
        /// 保险到期日
        /// </summary>
        public DateTime InsuranceExpireDate
        {
            set { _insuranceexpiredate = value; }
            get { return _insuranceexpiredate; }
        }
        /// <summary>
        /// 养路费到期日
        /// </summary>
        public DateTime TollExpireDate
        {
            set { _tollexpiredate = value; }
            get { return _tollexpiredate; }
        }
        /// <summary>
        /// 车况描述
        /// </summary>
        public string StateDescription
        {
            set { _statedescription = value; }
            get { return _statedescription; }
        }
        /// <summary>
        /// 信息卡卡号
        /// </summary>
        public string CardCode
        {
            set { _cardcode = value; }
            get { return _cardcode; }
        }
        /// <summary>
        /// 卡号号段ID
        /// </summary>
        public int CardRangeID
        {
            set { _cardrangeid = value; }
            get { return _cardrangeid; }
        }
        /// <summary>
        /// 信息来源
        /// </summary>
        public int Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 状态更改时间
        /// </summary>
        public DateTime StatusModifyTime
        {
            set { _statusmodifytime = value; }
            get { return _statusmodifytime; }
        }
        /// <summary>
        /// 车源状态
        /// </summary>
        public int UcarStatus
        {
            set { _ucarstatus = value; }
            get { return _ucarstatus; }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 是否通过认证(用户上海通用等少数经销商)
        /// </summary>
        public int IsAuthenticated
        {
            set { _isauthenticated = value; }
            get { return _isauthenticated; }
        }
         /// <summary>
        /// 系统ID
        /// </summary>
        public int SystemId
        {
            set { _SystemId = value; }
            get { return _SystemId; }
        }
        #endregion
    }

    /// <summary>
    /// 实体类UcarRefitInfoDS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UcarRefitInfoDS
    {
        #region UcarRefitInfoDS
        private int _uriid = 0;
        private int _ucarid = 0;
        private string _stereo = string.Empty;
        private string _seat = string.Empty;
        private string _lighting = string.Empty;
        private string _tire = string.Empty;
        private string _chassis = string.Empty;
        private string _power = string.Empty;
        /// <summary>
        /// 改装信息ID
        /// </summary>
        public int UriID
        {
            set { _uriid = value; }
            get { return _uriid; }
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
        /// 音响系统
        /// </summary>
        public string Stereo
        {
            set { _stereo = value; }
            get { return _stereo; }
        }
        /// <summary>
        /// 座椅座套
        /// </summary>
        public string Seat
        {
            set { _seat = value; }
            get { return _seat; }
        }
        /// <summary>
        /// 灯光系统
        /// </summary>
        public string Lighting
        {
            set { _lighting = value; }
            get { return _lighting; }
        }
        /// <summary>
        /// 轮胎轮毂
        /// </summary>
        public string Tire
        {
            set { _tire = value; }
            get { return _tire; }
        }
        /// <summary>
        /// 底盘悬挂
        /// </summary>
        public string Chassis
        {
            set { _chassis = value; }
            get { return _chassis; }
        }
        /// <summary>
        /// 动力系统
        /// </summary>
        public string Power
        {
            set { _power = value; }
            get { return _power; }
        }
        #endregion
    }

    /// <summary>
    /// 实体类SaleIntendInfoDS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SaleIntendInfoDS
    {
        #region SaleIntendInfoDS
        private int _siiid = 0;
        private int _ucarid = 0;
        private decimal _intendsaleprice = 0;
        private int _candiscuss = -1;
        private int _transfernewcar = -1;
        private int _transfercarbrand1 = 0;
        private int _transfercarbrand2 = 0;
        private int _ucarvalidity = 0;
        private int _acceptdetection = -1;
        private int _isreasonable = -1;
        private int _openmobile = -1;
        /// <summary>
        /// 出售意向ID
        /// </summary>
        public int SiiID
        {
            set { _siiid = value; }
            get { return _siiid; }
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
        /// 欲出售价格
        /// </summary>
        public decimal IntendSalePrice
        {
            set { _intendsaleprice = value; }
            get { return _intendsaleprice; }
        }
        /// <summary>
        /// 是否可议
        /// </summary>
        public int CanDiscuss
        {
            set { _candiscuss = value; }
            get { return _candiscuss; }
        }
        /// <summary>
        /// 是否考虑置换新车
        /// </summary>
        public int TransferNewCar
        {
            set { _transfernewcar = value; }
            get { return _transfernewcar; }
        }
        /// <summary>
        /// 欲置换车系1
        /// </summary>
        public int TransferCarBrand1
        {
            set { _transfercarbrand1 = value; }
            get { return _transfercarbrand1; }
        }
        /// <summary>
        /// 欲置换车系2
        /// </summary>
        public int TransferCarBrand2
        {
            set { _transfercarbrand2 = value; }
            get { return _transfercarbrand2; }
        }
        /// <summary>
        /// 车源有效期
        /// </summary>
        public int UcarValidity
        {
            set { _ucarvalidity = value; }
            get { return _ucarvalidity; }
        }
        /// <summary>
        /// 是否接受送检
        /// </summary>
        public int AcceptDetection
        {
            set { _acceptdetection = value; }
            get { return _acceptdetection; }
        }
        /// <summary>
        /// 价格是否合理
        /// </summary>
        public int IsReasonable
        {
            set { _isreasonable = value; }
            get { return _isreasonable; }
        }
        /// <summary>
        /// 是否公开手机号
        /// </summary>
        public int OpenMobile
        {
            set { _openmobile = value; }
            get { return _openmobile; }
        }
        #endregion
    }

    /// <summary>
    /// 实体类UcarPictureInfoDS 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UcarPictureInfoDS
    {
        #region UcarPictureInfoDS
        private int _upiid = 0;
        private int _ucarid = 0;
        private string _picturepath = string.Empty;
        /// <summary>
        /// 图片信息ID
        /// </summary>
        public int UpiID
        {
            set { _upiid = value; }
            get { return _upiid; }
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
        /// 图片路径
        /// </summary>
        public string PicturePath
        {
            set { _picturepath = value; }
            get { return _picturepath; }
        }
        #endregion
    }
}
