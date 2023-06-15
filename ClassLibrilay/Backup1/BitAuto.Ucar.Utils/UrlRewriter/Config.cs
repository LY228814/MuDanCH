using System;
using System.Configuration;
using System.Collections;

namespace KangHui.JianHui.Utils.UrlRewriter
{
    // Define a custom section containing a simple element and a collection of the same element.
    // It uses two custom types: RewriteUrlCollection and RewriteUrl.
    /// <summary>
    /// 
    /// </summary>
    public class RewriteUrlConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RewriteUrlSection GetConfig()
        {
            return (RewriteUrlSection)System.Configuration.ConfigurationManager.GetSection("urlRewriter");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RewriteUrlSection : ConfigurationSection
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("rewriteUrls", IsDefaultCollection = false)]
        public RewriteUrlCollection RewriteUrls
        {
            get
            {
                return (RewriteUrlCollection)this["rewriteUrls"];
            }
        }
    }

    // Define the RewriteUrlCollection that contains RewriteUrl elements.
    /// <summary>
    /// 
    /// </summary>
    public class RewriteUrlCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new RewriteUrl();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((RewriteUrl)element).VirtualUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public RewriteUrl this[int index]
        {
            get
            {
                return (RewriteUrl)BaseGet(index);
            }
        }
    }

    // Define the RewriteUrl.
    /// <summary>
    /// 
    /// </summary>
    public class RewriteUrl : ConfigurationElement
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("virtualUrl", IsRequired = true)]
        public string VirtualUrl
        {
            get
            {
                return (string)this["virtualUrl"];
            }
            set
            {
                this["virtualUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty("destinationUrl", IsRequired = true)]
        public string DestinationUrl
        {
            get
            {
                return (string)this["destinationUrl"];
            }
            set
            {
                this["destinationUrl"] = value;
            }
        }
    }
}
