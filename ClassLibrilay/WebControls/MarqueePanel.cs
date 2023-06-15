using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KangHui.WebControls
{
    [Description("可以实现连续无缝滚动效果的容器控件")]
    [ToolboxData("<{0}:MarqueePanel runat=\"server\"></{0}:MarqueePanel>")]
    public class MarqueePanel : WebControl, INamingContainer
    {
        private string innerHtml;
        private Unit width = Unit.Percentage(100);
        private Unit height = Unit.Pixel(100);
        private int speed = 30;
        private eMarqueeDerection direction = eMarqueeDerection.Left;

        #region 自定义属性
        [Browsable(false)]
        [Category("自定义属性")]
        [DefaultValue("")]
        [Description("可滚动内容的HTML代码")]
        public string InnerHtml
        {
            get { return innerHtml; }
            set { innerHtml = value; }
        }

        [Category("自定义属性")]
        [DefaultValue(typeof(Unit), "100%")]
        [Description("控件的宽度")]
        public override Unit Width
        {
            get { return width; }
            set { width = value; }
        }

        [Category("自定义属性")]
        [DefaultValue(typeof(Unit), "100px")]
        [Description("控件的高度")]
        public override Unit Height
        {
            get { return height; }
            set { height = value; }
        }

        [Category("自定义属性")]
        [DefaultValue(30)]
        [Description("移动的速度")]
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        [Category("自定义属性")]
        [DefaultValue(eMarqueeDerection.Left)]
        [Description("移动的方向")]
        public eMarqueeDerection MarqueeDirection
        {
            get { return direction; }
            set { direction = value; }
        }
        #endregion

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
    var MyMar = setInterval(Marquee,speed);
    MarqueeDiv.onmouseover = function() { clearInterval(MyMar); }
    MarqueeDiv.onmouseout = function() { MyMar = setInterval(Marquee,speed); }
</script>";
            #endregion

            if (MarqueeDirection == eMarqueeDerection.Left || MarqueeDirection == eMarqueeDerection.Right)
            {
                output.Write(horizontalContent);
            }
            else if (MarqueeDirection == eMarqueeDerection.Up || MarqueeDirection == eMarqueeDerection.Down)
            {
                output.Write(verticalContent);
            }
            output.Write(scriptContent);
        }
    }

    public enum eMarqueeDerection
    {
        Up    = 1,
        Down,
        Left,
        Right
    }
}
