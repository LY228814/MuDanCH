using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// 对字符串进行处理的功能类
    /// </summary>
    public class StringHelper
    {
        #region 获取字符串的实际字节长度的方法
        /// <summary>
        /// 获取字符串的实际字节长度的方法
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>实际长度</returns>
        public static int GetByteLength(string s)
        {
            return Encoding.Default.GetByteCount(s);
        }
        #endregion

        #region 按字节数截取字符串的方法
        /// <summary>
        /// 按字节数截取字符串的方法
        /// </summary>
        /// <param name="s">要截取的字符串</param>
        /// <param name="bytes">要截取的字节数</param>
        /// <param name="needEndDot">是否需要结尾的省略号</param>
        /// <returns>截取后的字符串</returns>
        public static string SubStringByBytes(string s, int bytes, bool needEndDot)
        {
            string temp = string.Empty;
            if (GetByteLength(s) <= bytes)//如果长度比需要的长度n小,返回原字符串
            {
                return s;
            }
            else
            {
                int t = 0;
                char[] q = s.ToCharArray();
                for (int i = 0; i < q.Length && t < bytes; i++)
                {
                    if ((int)q[i] > 127)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t++;
                    }
                }
                if (needEndDot)
                {
                    temp += "...";
                }
                return temp;
            }
        }
        #endregion

        #region 转换字符串编码的方法
        /// <summary>
        /// 转换字符串编码的方法
        /// </summary>
        /// <param name="dstEncoding">转换后的编码格式</param>
        /// <param name="s">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertEncoding(Encoding dstEncoding, string s)
        {
            return ConvertEncoding(Encoding.Default, dstEncoding, s);
        }
        /// <summary>
        /// 转换字符串编码的方法
        /// </summary>
        /// <param name="srcEncoding">转换前的编码格式</param>
        /// <param name="dstEncoding">转换后的编码格式</param>
        /// <param name="s">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertEncoding(Encoding srcEncoding, Encoding dstEncoding, string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            bytes = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return Encoding.Default.GetString(bytes);
        }
        #endregion

        #region 将全角字符串转成半角字符串的方法
        /// <summary>
        /// 将全角字符串转成半角字符串的方法
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>半角字符串</returns>
        public static string ConvertDbcToSbcString(string s)
        {
            StringBuilder sb = new StringBuilder();
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                sb.Append(ConvertDbcToSbcChar(c[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region 将全角字符转成半角字符的方法
        /// <summary>
        /// 将全角字符转成半角字符的方法
        /// </summary>
        /// <param name="c">转换前的字符</param>
        /// <returns>半角字符</returns>
        private static char ConvertDbcToSbcChar(char c)
        {
            //得到c的编码
            byte[] bytes = Encoding.Unicode.GetBytes(c.ToString());

            int H = Convert.ToInt32(bytes[1]);
            int L = Convert.ToInt32(bytes[0]);

            //得到unicode编码
            int value = H * 256 + L;

            //是全角
            if (value >= 65281 && value <= 65374)
            {
                int halfvalue = value - 65248;//65248是全半角间的差值。
                byte halfL = Convert.ToByte(halfvalue);

                bytes[0] = halfL;
                bytes[1] = 0;
            }
            else if (value == 12288)
            {
                int halfvalue = 32;
                byte halfL = Convert.ToByte(halfvalue);

                bytes[0] = halfL;
                bytes[1] = 0;
            }
            else
            {
                return c;
            }

            //将bytes转换成字符
            string ret = Encoding.Unicode.GetString(bytes);

            return Convert.ToChar(ret);
        }
        #endregion

        #region 根据正则表达式替换字符串内容的方法
        /// <summary>
        /// 根据正则表达式替换字符串内容的方法
        /// </summary>
        /// <param name="s">要进行替换的字符串</param>
        /// <param name="regExp">替换部分的正则表达式</param>
        /// <param name="replacement">替换的内容</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>替换后的字符串</returns>
        public static string Replace(string s, string regExp, string replacement, bool ignoreCase)
        {
            Regex regex = null;
            if (ignoreCase)
            {
                regex = new Regex(regExp, RegexOptions.IgnoreCase);
            }
            else
            {
                regex = new Regex(regExp);
            }
            return regex.Replace(s, replacement);
        }
        #endregion

        #region 判断字符串是否匹配正则表达式的方法
        /// <summary>
        /// 判断字符串是否匹配正则表达式的方法
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="regExp">正则表达式</param>
        /// <returns>判断结果：true-是，false-否</returns>
        public static bool IsMatchRegularExpression(string s, string regExp)
        {
            Regex regex = new Regex(regExp);
            return regex.IsMatch(s);
        }
        #endregion

        #region 获取字符串首字母的方法
        /// <summary>
        /// 获取字符串首字母的方法
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>首字母</returns>
        public static string GetFirstCharPY(string s)
        {
            s = s.Substring(0, 1);
            if (Convert.ToChar(s) >= 0 && Convert.ToChar(s) < 256)
            {
                return s;
            }
            else
            {
                byte[] unicodeBytes = Encoding.Unicode.GetBytes(s);
                byte[] gb2312Bytes = Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding("gb2312"), unicodeBytes);
                return GetPYByCode(Convert.ToInt32(string.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[0]) - 160)
                     + string.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[1]) - 160)));
            }
        }
        #endregion

        #region 根据区位码获取首字母的方法
        /// <summary>
        /// 根据区位码获取首字母的方法
        /// </summary>
        /// <param name="gbCode">区位码</param>
        /// <returns>首字母</returns>
        private static string GetPYByCode(int gbCode)
        {
            if (gbCode >= 1601 && gbCode < 1637) return "A";
            if (gbCode >= 1637 && gbCode < 1833) return "B";
            if (gbCode >= 1833 && gbCode < 2078) return "C";
            if (gbCode >= 2078 && gbCode < 2274) return "D";
            if (gbCode >= 2274 && gbCode < 2302) return "E";
            if (gbCode >= 2302 && gbCode < 2433) return "F";
            if (gbCode >= 2433 && gbCode < 2594) return "G";
            if (gbCode >= 2594 && gbCode < 2787) return "H";
            if (gbCode >= 2787 && gbCode < 3106) return "J";
            if (gbCode >= 3106 && gbCode < 3212) return "K";
            if (gbCode >= 3212 && gbCode < 3472) return "L";
            if (gbCode >= 3472 && gbCode < 3635) return "M";
            if (gbCode >= 3635 && gbCode < 3722) return "N";
            if (gbCode >= 3722 && gbCode < 3730) return "O";
            if (gbCode >= 3730 && gbCode < 3858) return "P";
            if (gbCode >= 3858 && gbCode < 4027) return "Q";
            if (gbCode >= 4027 && gbCode < 4086) return "R";
            if (gbCode >= 4086 && gbCode < 4390) return "S";
            if (gbCode >= 4390 && gbCode < 4558) return "T";
            if (gbCode >= 4558 && gbCode < 4684) return "W";
            if (gbCode >= 4684 && gbCode < 4925) return "X";
            if (gbCode >= 4925 && gbCode < 5249) return "Y";
            if (gbCode >= 5249 && gbCode <= 5589) return "Z";
            if (gbCode >= 5601 && gbCode <= 8794)
            {
                string codeData = "CJWGNSPGCENEGYPBTWXZDXYKYGTPJNMJQMBSGZSCYJSYYFPGGBZGYDYWJKGALJSWKBJQHYJWPDZLSGMR" 
			        + "YBYWWCCGZNKYDGTTNGJEYEKZYDCJNMCYLQLYPYQBQRPZSLWBDGKJFYXJWCLTBNCXJJJJCXDTQSQZYCDXXHGCKBPHFFSS" 
			        + "PYBGMXJBBYGLBHLSSMZMPJHSOJNGHDZCDKLGJHSGQZHXQGKEZZWYMCSCJNYETXADZPMDSSMZJJQJYZCJJFWQJBDZBJGD" 
			        + "NZCBWHGXHQKMWFBPBQDTJJZKQHYLCGXFPTYJYYZPSJLFCHMQSHGMMXSXJPKDCMBBQBEFSJWHWWGCKPYLQBGLDLCCTNMA" 
			        + "EDDKSJNGKCSGXLHZAYBDBTSDKDYLHGYMYLCXPYCJNDQJWXQXFYYFJLEJBZRWCCQHQCSBZKYMGPLBMCRQCFLNYMYQMSQT" 
			        + "RBCJTHZTQFRXCHXMCJCJLXQGJMSHZKBSWXEMDLCKFSYDSGLYCJJSSJNQBJCTYHBFTDCYJDGWYGHQFRXWCKQKXEBPDJPX" 
			        + "JQSRMEBWGJLBJSLYYSMDXLCLQKXLHTJRJJMBJHXHWYWCBHTRXXGLHJHFBMGYKLDYXZPPLGGPMTCBBAJJZYLJTYANJGBJ" 
			        + "FLQGDZYQCAXBKCLECJSZNSLYZHLXLZCGHBXZHZNYTDSBCJKDLZAYFFYDLABBGQSZKGGLDNDNYSKJSHDLXXBCGHXYGGDJ" 
			        + "MMZNGMMCCGWZSZXSJBZNMLZDTHCQYDBDLLSCDDNLKJYHJSYCJLKOHQASDHNHCSGAEHDAASHTCPLCPQYBSDMPJLPCJAQL" 
			        + "CDHJJASPRCHNGJNLHLYYQYHWZPNCCGWWMZFFJQQQQXXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMCSJZLDBNDCFC" 
			        + "XYHLSCHYCJQPPQAGMNYXPFRKSSBJLYXYJJGLNSCMHCWWMNZJJLHMHCHSYPPTTXRYCSXBYHCSMXJSXNBWGPXXTAYBGAJC" 
			        + "XLYPDCCWQOCWKCCSBNHCPDYZNBCYYTYCKSKYBSQKKYTQQXFCWCHCWKELCQBSQYJQCCLMTHSYWHMKTLKJLYCHWHEQJHTJ" 
			        + "HPPQPQSCFYMMCMGBMHGLGSLLYSDLLLJPCHMJHWLJCYHZJXHDXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSDYMJSHXPJXOM" 
			        + "YQKNMYBLRTHBCFTPMGYXLCHLHLZYLXGSSSSCCLSLDCLEPBHSHXYYFHBMGDFYCNJQWLQHJJCYWJZTEJJDHFBLQXTQKWHD" 
			        + "CHQXAGTLXLJXMSLJHDZKZJECXJCJNMBBJCSFYWKBJZGHYSDCPQYRSLJPCLPWXSDWEJBJCBCNAYTMGMBAPCLYQBCLZXCB" 
			        + "NMSGGFNZJJBZSFQYNDXHPCQKZCZWALSBCCJXPOZGWKYBSGXFCFCDKHJBSTLQFSGDSLQWZKXTMHSBGZHJCRGLYJBPMLJS" 
			        + "XLCJQQHZMJCZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCWCJMYHXNATJHYCCXZPCQLBZWWWTWBQCMLBMYNJCCCXBBSNZZL" 
			        + "JPLJXYZTZLGCLDCKLYRZZGQTGJHHGJLJAXFGFJZSLCFDQZLCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCCZH" 
			        + "GYJDJQQLZXJYLDLBCYAMCSTYLBDJBYREGKLZDZHLDSZCHZNWCZCLLWJQJJJKDGJCOLBBZPPGLGHTGZCYGEZMYCNQCYCY" 
			        + "HBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKJSBGBMMCJSSCLPQPDXCDYYKYPCJDDYYGYWCHJRTGCNYQL" 
			        + "DKLJCZZGZCCJGDYKSGPZMDLCPHNJAFYZDJCNMWESCSGLBTZCGMSDLLYXQSXSBLJSBBSGGHFJLWPMZJNLYYWDQSHZXTYY" 
			        + "WHMCYHYWDBXBTLMSWYYFSBJCBDXXLHJHFPSXZQHFZMQCZTQCXZXRDKDJHNNYZQQFNQDMMGNYDXMJGDHCDYCBFFALLZTD" 
			        + "LTFKMXQZDNGEQDBDCZJDXBZGSQQDDJCMBKXFFXMKDMCSYCHZCMLJDJYNHPRSJMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJJ" 
			        + "GYPZLTCSMCNBTJBHFKDHBYZGKPBBYMTDLSXSBNPDKLEYCJNYCDYKZDDHQGSDZSCTARLLTKZLGECLLKJLJJAQNBDGGGHF" 
			        + "JTZQJSECSHALQFMMGJNLYJBBTMLYCXDCJPLDLPCQDHSYCBZSCKBZMSLJFLHRBJSNBRGJHXPDGDJYBZGDLGCSEZGXLBLG" 
			        + "YXTWMABCHECMWYJYZLLJJSHLGNDJLSLYGKDZPZXJYYZLPCXSZFGWYYDLYHCLJSCMBJHBLYJLYCBLYDPDQYSXKTBYTDKD" 
			        + "XJYPCNRJMFDJGKLCCJBCTBJDDBBLBLCDQRPPXJCGLZCSHLTOLJNMDDDLNGKAQAKGJGYHHEZNMSHRPHQQJCHGMFPRXCJG" 
			        + "DYCHGHLYRZQLCNGJNZSQDKQJYMSZSWLCFQJQXGBGGXMDJWLMCRNFKKFSYYLJBMQAMMMYCCTBSHCPTXXZZSMPHFSHMCLM" 
			        + "LDJFYQXSDYJDJJZZHQPDSZGLSSJBCKBXYQZJSGPSXJZQZNQTBDKWXJKHHGFLBCSMDLDGDZDBLZKYCQNNCSYBZBFGLZZX" 
			        + "SWMSCCMQNJQSBDQSJTXXMBLDXCCLZSHZCXRQJGJYLXZFJPHYMZQQYDFQJJLCZNZJCDGZYGCDXMZYSCTLKPHTXHTLBJXJ" 
			        + "LXSCDQCCBBQJFQZFSLTJBTKQBSXJJLJCHCZDBZJDCZJCCPRNLQCGPFCZLCLCXZDMXMPHGSGZGSZZQJXLWTJPFSYASLCJ" 
			        + "BTCKWCWMYTCSJJLJCQLWZMALBXYFBPNLSCHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBSAQDGYLBXMMYGSZLDYD" 
			        + "JMJJRGBJGKGDHGKBLGKBDMBYLXWCXYTTYBKMRJJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";

                int pos = (Convert.ToInt16(gbCode.ToString().Substring(0, 2)) - 56) * 94 
                    + Convert.ToInt16(gbCode.ToString().Substring(gbCode.ToString().Length - 2, 2));
                return codeData.Substring(pos - 1, 1);
            }
            return " ";
        }
        #endregion
    }

    /// <summary>
    /// 存放正则表达式的类
    /// </summary>
    public class RegularExpression
    {
        /// <summary>
        /// 座机号的正则表达式
        /// </summary>
        public static string TelephoneNumber = "^(0\\d{2,3})?-?(\\d{7,8})(-\\d{3,6})?$";

        /// <summary>
        /// 手机号的正则表达式
        /// </summary>
        public static string MobilePhoneNumber = "^0{0,1}1[3,5,8]{1}[0-9]{9}$";

        /// <summary>
        /// 身份证号的正则表达式
        /// </summary>
        public static string IDCard = "^[0-9]{17}[x,X,y,Y0-9]{1}$|^[0-9]{15}$";

        /// <summary>
        /// 邮政编码的正则表达式
        /// </summary>
        public static string PostCode = "^\\d{6}$";

        /// <summary>
        /// 电子邮件地址的正则表达式
        /// </summary>
        public static string Email = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";
    }
}
