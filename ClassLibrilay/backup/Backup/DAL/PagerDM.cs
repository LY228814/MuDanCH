using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using Ucar.WebControls;
using Ucar.BaseClass;

namespace Ucar.DAL
{
    public class PagerDM : BaseDM
    {
        private string m_SelectFields = ""; //查询字段，一般是select关键字后from关键字前的部分
        private string m_TableNames = ""; //查询表名，一般是from关键字后where关键字前的部分
        private string m_OrderField = ""; //排序字段，一般是order by关键字后的部分

        /// <summary>
        /// 绑定车辆检测GridView的方法(多表查询)
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="pager"></param>
        /// <param name="strWhere"></param>
        public void BindDetectionGridView(GridView gv, AspNetPager pager, string strWhere)
        {
            m_SelectFields = "SE_Car_Detection.*,case se_car_basic.secb_SaleCharacter when 0 then '收购' when 1 then '寄售' end as secb_SaleCharacter,SE_Car_Basic.secb_MaintainMileage,SE_Car_Basic.secb_StandardId as carId,SE_Car_Basic.secb_Mileage,SE_Car_Basic.sesb_VinCode";
            m_TableNames = "se_car_basic inner join SE_Car_Detection on se_car_basic.secb_Id=SE_Car_Detection.secb_id";
            m_OrderField = "secd_ChaDingMan";
            //m_SelectFields = "a.*, case TradeType when 0 then '未选' when 1 then '过户' when 2 then '转籍' end as ExType";
            //m_TableNames = "TranstarUcarTransfer a";
            //m_OrderField = "MessageTime";

            PagerBase.BindData(gv, pager, m_SelectFields, m_TableNames, strWhere, m_OrderField, OrderType.DESC, connectionString);
        }

        /// <summary>
        /// 绑定车辆检测项目GridView的方法(单表查询)
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="pager"></param>
        /// <param name="strWhere"></param>
        public void BindDetectionItemGridView(GridView gv, AspNetPager pager, string strWhere)
        {
            m_SelectFields = "*";
            m_TableNames = "UcarBasicInfo a";
            m_OrderField = "a.BuyCarDate desc,a.UcarID desc";

            PagerBase.BindDataWithNotInProc(gv, pager, m_SelectFields, m_TableNames, strWhere, "", m_OrderField, "UcarID", connectionString);
        }
    }
}
