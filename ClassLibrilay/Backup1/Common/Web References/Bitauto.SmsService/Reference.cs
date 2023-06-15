﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.1433
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.1433 版自动生成。
// 
#pragma warning disable 1591

namespace KangHui.Common.Bitauto.SmsService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback UcarSendNowOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewSendMsgByTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewSendMsgNowByDataSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback NewSendMsgNowOperationCompleted;
        
        private System.Threading.SendOrPostCallback UcarReceiveOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetReceiveMsgOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetReceiveMsgByTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetResultOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService() {
            this.Url = global::KangHui.Common.Properties.Settings.Default.Ucar_Common_Bitauto_SmsService_WebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event UcarSendNowCompletedEventHandler UcarSendNowCompleted;
        
        /// <remarks/>
        public event NewSendMsgByTimeCompletedEventHandler NewSendMsgByTimeCompleted;
        
        /// <remarks/>
        public event NewSendMsgNowByDataSetCompletedEventHandler NewSendMsgNowByDataSetCompleted;
        
        /// <remarks/>
        public event NewSendMsgNowCompletedEventHandler NewSendMsgNowCompleted;
        
        /// <remarks/>
        public event UcarReceiveCompletedEventHandler UcarReceiveCompleted;
        
        /// <remarks/>
        public event GetReceiveMsgCompletedEventHandler GetReceiveMsgCompleted;
        
        /// <remarks/>
        public event GetReceiveMsgByTimeCompletedEventHandler GetReceiveMsgByTimeCompleted;
        
        /// <remarks/>
        public event GetResultCompletedEventHandler GetResultCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UcarSendNow", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UcarSendNow(string account, string password, string phonelist, string msg, string num) {
            object[] results = this.Invoke("UcarSendNow", new object[] {
                        account,
                        password,
                        phonelist,
                        msg,
                        num});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UcarSendNowAsync(string account, string password, string phonelist, string msg, string num) {
            this.UcarSendNowAsync(account, password, phonelist, msg, num, null);
        }
        
        /// <remarks/>
        public void UcarSendNowAsync(string account, string password, string phonelist, string msg, string num, object userState) {
            if ((this.UcarSendNowOperationCompleted == null)) {
                this.UcarSendNowOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUcarSendNowOperationCompleted);
            }
            this.InvokeAsync("UcarSendNow", new object[] {
                        account,
                        password,
                        phonelist,
                        msg,
                        num}, this.UcarSendNowOperationCompleted, userState);
        }
        
        private void OnUcarSendNowOperationCompleted(object arg) {
            if ((this.UcarSendNowCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UcarSendNowCompleted(this, new UcarSendNowCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NewSendMsgByTime", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int NewSendMsgByTime(string account, string password, string phonelist, string msg, System.DateTime SendTime) {
            object[] results = this.Invoke("NewSendMsgByTime", new object[] {
                        account,
                        password,
                        phonelist,
                        msg,
                        SendTime});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void NewSendMsgByTimeAsync(string account, string password, string phonelist, string msg, System.DateTime SendTime) {
            this.NewSendMsgByTimeAsync(account, password, phonelist, msg, SendTime, null);
        }
        
        /// <remarks/>
        public void NewSendMsgByTimeAsync(string account, string password, string phonelist, string msg, System.DateTime SendTime, object userState) {
            if ((this.NewSendMsgByTimeOperationCompleted == null)) {
                this.NewSendMsgByTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewSendMsgByTimeOperationCompleted);
            }
            this.InvokeAsync("NewSendMsgByTime", new object[] {
                        account,
                        password,
                        phonelist,
                        msg,
                        SendTime}, this.NewSendMsgByTimeOperationCompleted, userState);
        }
        
        private void OnNewSendMsgByTimeOperationCompleted(object arg) {
            if ((this.NewSendMsgByTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewSendMsgByTimeCompleted(this, new NewSendMsgByTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NewSendMsgNowByDataSet", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet NewSendMsgNowByDataSet(string account, string password, System.Data.DataSet phonemsg) {
            object[] results = this.Invoke("NewSendMsgNowByDataSet", new object[] {
                        account,
                        password,
                        phonemsg});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void NewSendMsgNowByDataSetAsync(string account, string password, System.Data.DataSet phonemsg) {
            this.NewSendMsgNowByDataSetAsync(account, password, phonemsg, null);
        }
        
        /// <remarks/>
        public void NewSendMsgNowByDataSetAsync(string account, string password, System.Data.DataSet phonemsg, object userState) {
            if ((this.NewSendMsgNowByDataSetOperationCompleted == null)) {
                this.NewSendMsgNowByDataSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewSendMsgNowByDataSetOperationCompleted);
            }
            this.InvokeAsync("NewSendMsgNowByDataSet", new object[] {
                        account,
                        password,
                        phonemsg}, this.NewSendMsgNowByDataSetOperationCompleted, userState);
        }
        
        private void OnNewSendMsgNowByDataSetOperationCompleted(object arg) {
            if ((this.NewSendMsgNowByDataSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewSendMsgNowByDataSetCompleted(this, new NewSendMsgNowByDataSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NewSendMsgNow", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int NewSendMsgNow(string account, string password, string phonelist, string msg) {
            object[] results = this.Invoke("NewSendMsgNow", new object[] {
                        account,
                        password,
                        phonelist,
                        msg});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void NewSendMsgNowAsync(string account, string password, string phonelist, string msg) {
            this.NewSendMsgNowAsync(account, password, phonelist, msg, null);
        }
        
        /// <remarks/>
        public void NewSendMsgNowAsync(string account, string password, string phonelist, string msg, object userState) {
            if ((this.NewSendMsgNowOperationCompleted == null)) {
                this.NewSendMsgNowOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNewSendMsgNowOperationCompleted);
            }
            this.InvokeAsync("NewSendMsgNow", new object[] {
                        account,
                        password,
                        phonelist,
                        msg}, this.NewSendMsgNowOperationCompleted, userState);
        }
        
        private void OnNewSendMsgNowOperationCompleted(object arg) {
            if ((this.NewSendMsgNowCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NewSendMsgNowCompleted(this, new NewSendMsgNowCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UcarReceive", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet UcarReceive(string account, string password) {
            object[] results = this.Invoke("UcarReceive", new object[] {
                        account,
                        password});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void UcarReceiveAsync(string account, string password) {
            this.UcarReceiveAsync(account, password, null);
        }
        
        /// <remarks/>
        public void UcarReceiveAsync(string account, string password, object userState) {
            if ((this.UcarReceiveOperationCompleted == null)) {
                this.UcarReceiveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUcarReceiveOperationCompleted);
            }
            this.InvokeAsync("UcarReceive", new object[] {
                        account,
                        password}, this.UcarReceiveOperationCompleted, userState);
        }
        
        private void OnUcarReceiveOperationCompleted(object arg) {
            if ((this.UcarReceiveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UcarReceiveCompleted(this, new UcarReceiveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetReceiveMsg", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetReceiveMsg(string account, string password) {
            object[] results = this.Invoke("GetReceiveMsg", new object[] {
                        account,
                        password});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetReceiveMsgAsync(string account, string password) {
            this.GetReceiveMsgAsync(account, password, null);
        }
        
        /// <remarks/>
        public void GetReceiveMsgAsync(string account, string password, object userState) {
            if ((this.GetReceiveMsgOperationCompleted == null)) {
                this.GetReceiveMsgOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetReceiveMsgOperationCompleted);
            }
            this.InvokeAsync("GetReceiveMsg", new object[] {
                        account,
                        password}, this.GetReceiveMsgOperationCompleted, userState);
        }
        
        private void OnGetReceiveMsgOperationCompleted(object arg) {
            if ((this.GetReceiveMsgCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetReceiveMsgCompleted(this, new GetReceiveMsgCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetReceiveMsgByTime", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetReceiveMsgByTime(string account, string password, System.DateTime starttime, System.DateTime endtime) {
            object[] results = this.Invoke("GetReceiveMsgByTime", new object[] {
                        account,
                        password,
                        starttime,
                        endtime});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetReceiveMsgByTimeAsync(string account, string password, System.DateTime starttime, System.DateTime endtime) {
            this.GetReceiveMsgByTimeAsync(account, password, starttime, endtime, null);
        }
        
        /// <remarks/>
        public void GetReceiveMsgByTimeAsync(string account, string password, System.DateTime starttime, System.DateTime endtime, object userState) {
            if ((this.GetReceiveMsgByTimeOperationCompleted == null)) {
                this.GetReceiveMsgByTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetReceiveMsgByTimeOperationCompleted);
            }
            this.InvokeAsync("GetReceiveMsgByTime", new object[] {
                        account,
                        password,
                        starttime,
                        endtime}, this.GetReceiveMsgByTimeOperationCompleted, userState);
        }
        
        private void OnGetReceiveMsgByTimeOperationCompleted(object arg) {
            if ((this.GetReceiveMsgByTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetReceiveMsgByTimeCompleted(this, new GetReceiveMsgByTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetResult", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetResult(string account, string password) {
            object[] results = this.Invoke("GetResult", new object[] {
                        account,
                        password});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetResultAsync(string account, string password) {
            this.GetResultAsync(account, password, null);
        }
        
        /// <remarks/>
        public void GetResultAsync(string account, string password, object userState) {
            if ((this.GetResultOperationCompleted == null)) {
                this.GetResultOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetResultOperationCompleted);
            }
            this.InvokeAsync("GetResult", new object[] {
                        account,
                        password}, this.GetResultOperationCompleted, userState);
        }
        
        private void OnGetResultOperationCompleted(object arg) {
            if ((this.GetResultCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetResultCompleted(this, new GetResultCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void UcarSendNowCompletedEventHandler(object sender, UcarSendNowCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UcarSendNowCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UcarSendNowCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void NewSendMsgByTimeCompletedEventHandler(object sender, NewSendMsgByTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewSendMsgByTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewSendMsgByTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void NewSendMsgNowByDataSetCompletedEventHandler(object sender, NewSendMsgNowByDataSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewSendMsgNowByDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewSendMsgNowByDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void NewSendMsgNowCompletedEventHandler(object sender, NewSendMsgNowCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NewSendMsgNowCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NewSendMsgNowCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void UcarReceiveCompletedEventHandler(object sender, UcarReceiveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UcarReceiveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UcarReceiveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetReceiveMsgCompletedEventHandler(object sender, GetReceiveMsgCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetReceiveMsgCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetReceiveMsgCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetReceiveMsgByTimeCompletedEventHandler(object sender, GetReceiveMsgByTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetReceiveMsgByTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetReceiveMsgByTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    public delegate void GetResultCompletedEventHandler(object sender, GetResultCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetResultCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetResultCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591