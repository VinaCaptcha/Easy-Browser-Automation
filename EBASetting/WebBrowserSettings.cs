using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design; // need to add references "System.Design"
using System.Drawing.Design; // for "UITypeEditor"
using System.Linq;
using System.Text;

namespace EBASetting
{
    public class WebBrowserSettings
    {
        #region Init
        public WebBrowserSettings()
        {

        }
        #endregion
        
        #region 01. General
        [Category("01. General")]
        [DisplayName("User-Agent")]
        [Description("Thông tin User-Agent của trình duyệt web.")]
        public string UserAgent { set; get; }

        [Category("01. General")]
        [DisplayName("Password")]
        [PasswordPropertyText(true)]
        [Description("Mật khẩu, dùng để login tự động vào google account.")]
        public string Password { set; get; }

        [Category("01. General")]
        [DisplayName("Email Recover")]
        [Description("Là email khôi phục, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string EmailRecover { set; get; }

        [Category("01. General")]
        [DisplayName("Phone Recover")]
        [Description("Là số điện thoại khôi phục, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string PhoneRecover { set; get; }

        [Category("01. General")]
        [DisplayName("Secret Answer")]
        [Description("Là câu trả lời bí mật, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string SecretAnswer { set; get; }

        [Category("02. Youtube Channel")]
        [DisplayName("Channel Name Selected")]
        [Description("Là tên kênh được chọn để upload nếu bạn có nhiều kênh trong một gmail. Nếu để trống thì tool sẽ tự chọn kênh chính của gmail.")]
        public string ChannelNameSelected { set; get; }

        [Category("02. Youtube Channel")]
        [DisplayName("Don't use Primary Channel")]
        [Description("Không sử dụng kênh chính để upload? Nếu đúng thì tool sẽ tự tìm kênh phụ để upload.")]
        [DefaultValue(false)]
        public bool DonotUsePrimaryChannel { set; get; }
        #endregion
    }
}
