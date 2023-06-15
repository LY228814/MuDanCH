using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KangHui.JianHui.Utils.WebControls
{
    /// <summary>
    /// 可以实现连续无缝滚动效果的容器控件
    /// </summary>
    [Description("可以实现连续无缝滚动效果的容器控件")]
    [Designer(typeof(MarqueePanelDesigner))]
    [ToolboxData("<{0}:MarqueePanel runat=\"server\"></{0}:MarqueePanel>")]
    public class MarqueePanel : WebControl, INamingContainer
    {
        private string innerHtml;
        private Unit width = Unit.Pixel(100);
        private Unit height = Unit.Pixel(50);
        private int speed = 30;
        private MarqueeDirection direction = MarqueeDirection.Left;

        #region 自定义属性
        /// <summary>
        /// 滚动内容的HTML代码
        /// </summary>
        [Browsable(false)]
        [Category("自定义属性")]
        [DefaultValue("")]
        [Description("滚动内容的HTML代码")]
        public string InnerHtml
        {
            get { return innerHtml; }
            set { innerHtml = value; }
        }

        /// <summary>
        /// 控件的宽度
        /// </summary>
        [Category("自定义属性")]
        [DefaultValue(typeof(Unit), "100px")]
        [Description("控件的宽度")]
        public override Unit Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// 控件的高度
        /// </summary>
        [Category("自定义属性")]
        [DefaultValue(typeof(Unit), "50px")]
        [Description("控件的高度")]
        public override Unit Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 移动的速度，值越大速度越慢
        /// </summary>
        [Category("自定义属性")]
        [DefaultValue(30)]
        [Description("移动的速度，值越大速度越慢")]
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// 内容移动的方向
        /// </summary>
        [Category("自定义属性")]
        [DefaultValue(MarqueeDirection.Left)]
        [Description("内容移动的方向")]
        public MarqueeDirection MarqueeDirection
        {
            get { return direction; }
            set { direction = value; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            #region horizontalContent
            string horizontalContent = @"
<div id='MarqueeDiv' style='overflow: hidden; width: " + Width + @"; height: " + height + @"'>
    <table align='left' cellpadding='0' cellspacing='0' border='0'>
        <tr>
            <td id='MarqueeTd1' valign='top'>
                " + InnerHtml + @"
            </td>
            <td id='MarqueeTd2' valign='top'>
            </td>
        </tr>
    </table>
</div>";
            #endregion

            #region verticalContent
            string verticalContent = @"
<div id='MarqueeDiv' style='overflow:hidden; width: " + Width + @"; height: " + height + @"'>
    <div id='MarqueeTd1'>
        " + InnerHtml + @"
    </div>
    <div id='MarqueeTd2'></div>
</div>";
            #endregion

            #region scriptContent
            string scriptContent = @"
<script language='javascript'>
    var speed = " + Speed + @";
    var direction = " + (int)MarqueeDirection + @";
    var MarqueeTd1 = document.getElementById('MarqueeTd1');
    var MarqueeTd2 = document.getElementById('MarqueeTd2');
    var MarqueeDiv = document.getElementById('MarqueeDiv');
    MarqueeTd2.innerHTML = MarqueeTd1.innerHTML;
    if (direction == 2)
    {
        MarqueeDiv.scrollTop = MarqueeDiv.scrollHeight;
    }
    else if (direction == 4)
    {
        MarqueeDiv.scrollLeft = MarqueeDiv.scrollWidth;
    }
    function Marquee()
    {
        if (direction == 1)
        {
            if(MarqueeTd2.offsetTop - MarqueeDiv.scrollTop <= 0)
            {
                MarqueeDiv.scrollTop -= MarqueeTd1.offsetHeight;
            }
            else
            {
                MarqueeDiv.scrollTop++;
            }
        }
        else if (direction == 2)
        {
            if(MarqueeTd1.offsetTop - MarqueeDiv.scrollTop >= 0)
            {
                MarqueeDiv.scrollTop += MarqueeTd2.offsetHeight;
            }
            else
            {
                MarqueeDiv.scrollTop--;
            }
        }
        else if (direction == 3)
        {
            if(MarqueeTd2.offsetWidth - MarqueeDiv.scrollLeft <= 0)
            {
                MarqueeDiv.scrollLeft -= MarqueeTd1.offsetWidth;
            }
            else
            {
                MarqueeDiv.scrollLeft++;
            }
        }
        else if (direction == 4)
        {
            if(MarqueeDiv.scrollLeft <= 0)
            {
                MarqueeDiv.scrollLeft += MarqueeTd2.offsetWidth;
            }
            else
            {
                MarqueeDiv.scrollLeft--;
            }
        }
    }
    var MyMar = setInterval(Marquee, speed);
    MarqueeDiv.onmouseover = function() { clearInterval(MyMar); }
    MarqueeDiv.onmouseout = function() { MyMar = setInterval(Marquee, speed); }
</script>";
            #endregion

            if (MarqueeDirection == MarqueeDirection.Left || MarqueeDirection == MarqueeDirection.Right)
            {
                output.Write(horizontalContent);
            }
            else if (MarqueeDirection == MarqueeDirection.Up || MarqueeDirection == MarqueeDirection.Down)
            {
                output.Write(verticalContent);
            }
            output.Write(scriptContent);
        }
    }

    /// <summary>
    /// 内容移动的方向的枚举
    /// </summary>
    public enum MarqueeDirection
    {
        /// <summary>
        /// 向上
        /// </summary>
        Up = 1,

        /// <summary>
        /// 向下
        /// </summary>
        Down,

        /// <summary>
        /// 向左
        /// </summary>
        Left,

        /// <summary>
        /// 向右
        /// </summary>
        Right
    }
}
