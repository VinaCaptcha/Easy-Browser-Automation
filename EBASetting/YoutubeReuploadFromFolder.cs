using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design; // need to add references "System.Design"
using System.Drawing.Design; // for "UITypeEditor"
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EBASetting
{
    [Serializable]
    public class YoutubeReuploadFromFolder
    {
        #region Init Configs
        public YoutubeReuploadFromFolder()
        {
            TotalVideoUploadPerDay = 99;
            TranslateFrom = "English [en]";
            TranslateTo = "Spanish [es]";            
            MonitorDirectory = true;
            PrivacyScheduleTimeZone = "(GMT+0700) Krasnoyarsk";
            PrivacyScheduleTimeInDay = new string[] { "8:00 PM", "8:15 PM", "8:30 PM", "8:45 PM", "9:00 PM", "9:15 PM", "9:30 PM", "9:45 PM", "10:00 PM" };
            MonetizationOverlayAds = true;
            MonetizationSponsoredCards = true;
            MonetizationSkippableVideoAds = true;
            MonetizationNonSkippableVideoAds = true;
            MonetizationAdsBreaks = "01:30, 03:30, 05:30, 07:30, 09:30";
            VideoCategory = "People & Blogs";
            VideoAllowComments = true;
        }
        #endregion

        #region 01. General
        [Category("01. General")]
        [DisplayName("Total video upload per day?")]
        [Description("Là tổng số video được upload trên một ngày? Dùng để giới hạn chế số lượng video upload trên ngày, chỉnh 99 trở xuống để hạn chế chết spam.")]
        [DefaultValue(99)]
        public int TotalVideoUploadPerDay { set; get; }

        [Category("01. General")]
        [DisplayName("Delay minute upload video?")]
        [Description("Là thời gian chờ đợi khi upload video kế tiếp lên kênh, đơn vị tính là phút. Bằng 0 là upload video liền không phải chờ đợi.")]
        [DefaultValue(0)]
        public int DelayMinuteUploadVideo { set; get; }

        [Category("01. General")]
        [DisplayName("Delete video after upload complete?")]
        [Description("Có muốn xóa video ngay sau khi upload lên kênh thành công? Để giải phóng dung lượng lưu trữ của ổ đĩa máy tính.")]
        [DefaultValue(false)]
        public bool DeleteVideoAfterUploadComplete { set; get; }

        [Category("01. General")]
        [DisplayName("Translate From")]
        [Description("Dịch từ ngôn ngữ nào?")]
        [TypeConverter(typeof(LanguageSelector))]
        [DefaultValue("English [en]")]
        public string TranslateFrom { set; get; }

        [Category("01. General")]
        [DisplayName("Translate To")]
        [Description("Cần dịch sang ngôn ngữ nào?")]
        [TypeConverter(typeof(LanguageSelector))]
        [DefaultValue("Spanish [es]")]
        public string TranslateTo { set; get; }

        #endregion


        #region 02. Google Account
        [Category("02. Google Account")]
        [DisplayName("Username")]
        [Description("Nhập username hoặc gmail cũng được, dùng để login tự động vào google account.")]
        public string Username { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Password")]
        [PasswordPropertyText(true)]
        [Description("Mật khẩu, dùng để login tự động vào google account.")]
        public string Password { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Email Recover")]
        [Description("Là email khôi phục, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string EmailRecover { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Phone Recover")]
        [Description("Là số điện thoại khôi phục, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string PhoneRecover { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Secret Answer")]
        [Description("Là câu trả lời bí mật, không bắt buộc nhưng dùng để login tự động vào google account.")]
        public string SecretAnswer { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Channel Name Selected")]
        [Description("Là tên kênh được chọn để upload nếu bạn có nhiều kênh trong một gmail. Nếu để trống thì tool sẽ tự chọn kênh chính của gmail.")]
        public string ChannelNameSelected { set; get; }

        [Category("02. Google Account")]
        [DisplayName("Don't use Primary Channel")]
        [Description("Không sử dụng kênh chính để upload? Nếu đúng thì tool sẽ tự tìm kênh phụ để upload.")]
        [DefaultValue(false)]
        public bool DonotUsePrimaryChannel { set; get; }
        #endregion


        #region 03. Source Upload
        [Category("03. Source Upload")]
        [DisplayName("Source Directory Path")]
        [Description("Nhập đường dẫn thư mục nguồn cần upload hoặc click nút '...' để chọn thư mục từ máy tính.")]
        [Editor(typeof(FolderSelector), typeof(UITypeEditor))]
        public string SourceDirectoryPath { set; get; }

        [Category("03. Source Upload")]
        [DisplayName("Use video metadata json?")]
        [Description("Có sử dụng file json metadata của video trong thư mục nguồn này không?")]
        [DefaultValue(false)]
        public bool UseVideoMetadataJson { set; get; }

        [Category("03. Source Upload")]
        [DisplayName("Monitor Directory")]
        [Description("Theo dõi thư mục này, nếu phát hiện có video mới là tiến hành upload lên kênh.")]
        [DefaultValue(true)]
        public bool MonitorDirectory { set; get; }

        #endregion


        #region 04. Video Title
        [Category("04. Video Title")]
        [DisplayName("Find and Replace")]
        [Description("Tìm kiếm và thay thế chữ trong tiêu đề. Mỗi dòng là mỗi lần tìm kiếm và thay thế. Lưu ý cú pháp như sau: Chữ tìm kiếm => Chữ thay thế. Ví dụ: Bad Baby => Good Boy")]
        public string[] TitleFindAndReplace { set; get; }

        [Category("04. Video Title")]
        [DisplayName("Translator Used")]
        [Description("Có muốn dịch tiêu đề sang ngôn ngữ khác hay không?")]
        [DefaultValue(false)]
        public bool TitleTranslatorUsed { set; get; }
                
        [Category("04. Video Title")]
        [DisplayName("Add Prefix")]
        [Description("Thêm chữ ở đầu tiêu đề. Để trống là không cần thêm.")]
        public string TitleAddPrefix { set; get; }

        [Category("04. Video Title")]
        [DisplayName("Add Suffix")]
        [Description("Thêm chữ ở cuối tiêu đề. Để trống là không cần thêm.")]
        public string TitleAddSuffix { set; get; }
        #endregion


        #region 05. Video Thumbnail
        [Category("05. Video Thumbnail")]
        [DisplayName("Use image file of the same name video file?")]
        [Description("Có muốn sử dụng file image có cùng tên với file video để làm thumbnail không? Cái này file image phải được tạo sẵn và lưu cùng thư mục với file video mới dùng được.")]
        [DefaultValue(false)]
        public bool ThumbnailUseImageTheSameVideoFile { set; get; }

        [Category("05. Video Thumbnail")]
        [DisplayName("Get image of % video length?")]
        [Description("Nhập vào con số % của chiều dài video để lấy ra một tấm hình trong video làm Thumbnail. Bằng 0 là không sử dụng tính năng này. Ví dụ: 50")]
        [DefaultValue(0)]
        public int ThumbnailGetImageOfLength { set; get; }

        [Category("05. Video Thumbnail")]
        [DisplayName("Get random image in directory path")]
        [Description("Chọn đường dẫn tới thư mục chứa sẵn nhiều hình thumbnail. Tính năng này sẽ chọn ngẫu nhiên một tấm hình trong một thư mục này để làm thumbnail. Để trống là không sử dụng tính năng này.")]
        [Editor(typeof(FolderSelector), typeof(UITypeEditor))]
        public string ThumbnailGetImageFromDirectory { set; get; }

        [Category("05. Video Thumbnail")]
        [DisplayName("Image PNG overlay path")]
        [Description("Có muốn đè một tấm hình PNG lên Thumbnail thì chọn đường dẫn tới tấm hình PNG đó. Sử dụng để đóng Logo lên Thumbnail. Để trống là không sử dụng tính năng này.")]
        [Editor(typeof(FileSelector), typeof(UITypeEditor))]
        public string ThumbnailImagePNGOverlay { set; get; }

        #endregion


        #region 06. Video Description
        [Category("06. Video Description")]
        [DisplayName("Description")]
        [Description("Sử dụng nội dung này cho phần mô tả của video.")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string DescriptionDescription { set; get; }

        [Category("06. Video Description")]
        [DisplayName("Find and Replace")]
        [Description("Tìm kiếm và thay thế chữ trong tiêu đề. Mỗi dòng là mỗi lần tìm kiếm và thay thế. Lưu ý cú pháp như sau: Chữ tìm kiếm => Chữ thay thế. Ví dụ: Bad Baby => Good Boy")]
        public string[] DescriptionFindAndReplace { set; get; }

        [Category("06. Video Description")]
        [DisplayName("Translator Used")]
        [Description("Có muốn dịch phần mô tả sang ngôn ngữ khác hay không?")]
        [DefaultValue(false)]
        public bool DescriptionTranslatorUsed { set; get; }

        [Category("06. Video Description")]
        [DisplayName("Add Title as Prefix")]
        [Description("Có muốn tự động thêm tiêu đề vào đầu của phần mô tả video không?")]
        [DefaultValue(false)]
        public bool DescriptionAddTitleAsPrefix { set; get; }


        #endregion


        #region 07. Video Tags
        [Category("07. Video Tags")]
        [DisplayName("Tags")]
        [Description("Sử dụng nội dung này cho phần thẻ tag của video. Mỗi thẻ tag cách nhau bởi dấu phẩy hoặc nằm trong dấu ngoặc kép.")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string TagsTags { set; get; }

        [Category("07. Video Tags")]
        [DisplayName("Find and Replace")]
        [Description("Tìm kiếm và thay thế chữ trong tiêu đề. Mỗi dòng là mỗi lần tìm kiếm và thay thế. Lưu ý cú pháp như sau: Chữ tìm kiếm => Chữ thay thế. Ví dụ: Bad Baby => Good Boy")]
        public string[] TagsFindAndReplace { set; get; }

        [Category("07. Video Tags")]
        [DisplayName("Translator Used")]
        [Description("Có muốn dịch thẻ tag sang ngôn ngữ khác hay không?")]
        [DefaultValue(false)]
        public bool TagsTranslatorUsed { set; get; }

        [Category("07. Video Tags")]
        [DisplayName("Add more Tags from Title")]
        [Description("Có muốn tự động phân tích tìm thêm thẻ tag trong tiêu đề và thêm chúng vào video tags không?")]
        [DefaultValue(false)]
        public bool TagsAddMoreTagsFromTitle { set; get; }

        #endregion


        #region 08. Video Privacy
        [Category("08. Video Privacy")]
        [DisplayName("Privacy")]
        [Description("Chọn chế độ riêng tư cho video. Nếu muốn đặt lịch hẹn giờ công khai video thì buộc phải chọn là \"Scheduled\"")]
        [DefaultValue(PrivacyEnum.Public)]
        public PrivacyEnum PrivacyPrivacy { set; get; }

        [Category("08. Video Privacy")]
        [DisplayName("Schedule Day will be auto up")]
        [Description("Ngày tháng năm sẽ được tăng tự động bắt đầu vào ngày hiện tại, bạn không cần phải cài đặt.")]
        [ReadOnly(true)]
        public bool PrivacyScheduleDay { get { return true; } set { value = true; } }

        [Category("08. Video Privacy")]
        [DisplayName("Schedule Time Zone")]
        [Description("Chọn múi giờ cho việc đặt lịch hẹn giờ công khai video.")]
        [TypeConverter(typeof(TimeZoneSelector))]
        [DefaultValue("(GMT+0700) Krasnoyarsk")]
        public string PrivacyScheduleTimeZone { set; get; }

        [Category("08. Video Privacy")]
        [DisplayName("Schedule Time in Day")]
        [Description("Chọn các mốc thời gian trong ngày để công khai video. Mỗi dòng là một mốc thời gian. Bắt buộc có cú pháp như ví dụ sau: 5:00 AM, 5:15 AM, 5:30 AM, 5:45 AM và 5:00 PM, 5:15 PM, 5:30 PM, 5:45 PM. Chỉ được phép cách nhau 15 phút.")]
        public string[] PrivacyScheduleTimeInDay { set; get; }


        #endregion


        #region 09. Video Monetization
        [Category("09. Video Monetization")]
        [DisplayName("Monetization")]
        [Description("Bật kiếm tiền cho video hay là không bật?")]
        [DefaultValue(false)]
        public bool MonetizationTurnOn { set; get; }

        [Category("09. Video Monetization")]
        [DisplayName("Overlay ads checked")]
        [Description("Bật loại quảng cáo 'Overlay ads' hay không? Điều kiện video phải được bật kiếm tiền.")]
        [DefaultValue(true)]
        public bool MonetizationOverlayAds { set; get; }

        [Category("09. Video Monetization")]
        [DisplayName("Sponsored cards checked")]
        [Description("Bật loại quảng cáo 'Sponsored cards' hay không? Điều kiện video phải được bật kiếm tiền.")]
        [DefaultValue(true)]
        public bool MonetizationSponsoredCards { set; get; }

        [Category("09. Video Monetization")]
        [DisplayName("Skippable video ads checked")]
        [Description("Bật loại quảng cáo 'Skippable video ads' hay không? Điều kiện video phải được bật kiếm tiền.")]
        [DefaultValue(true)]
        public bool MonetizationSkippableVideoAds { set; get; }

        [Category("09. Video Monetization")]
        [DisplayName("Non-skippable video ads checked")]
        [Description("Bật loại quảng cáo 'Non-skippable video ads' hay không? Điều kiện video phải được bật kiếm tiền và kênh phải đang ở trong Network.")]
        [DefaultValue(true)]
        public bool MonetizationNonSkippableVideoAds { set; get; }

        [Category("09. Video Monetization")]
        [DisplayName("Set Ads Breaks")]
        [Description("Cài đặt thời gian đặt quảng cáo, dành cho video từ 10 phút trở lên. Ví dụ: 01:30, 03:30, 05:30, 07:30, 09:30, 11:30")]        
        [DefaultValue("01:30, 03:30, 05:30, 07:30, 09:30")]
        public string MonetizationAdsBreaks { set; get; }

        #endregion


        #region 10. Video Advanced
        [Category("10. Video Advanced")]
        [DisplayName("Category of Video")]
        [Description("Chọn Danh Mục cho video. Mặc định là 'People & Blogs'.")]
        [TypeConverter(typeof(CategorySelector))]
        [DefaultValue("People & Blogs")]
        public string VideoCategory { set; get; }

        [Category("10. Video Advanced")]
        [DisplayName("Allow Comments")]
        [Description("Cho phép người xem comment dưới video. Nếu re-upload kids real life thì nên tắt comment để tránh bị report cộng đồng vì comment tục tiểu.")]
        [DefaultValue(true)]
        public bool VideoAllowComments { set; get; }

        [Category("10. Video Advanced")]
        [DisplayName("Enable age restriction")]
        [Description("Bật giới hạn độ tuổi cho video này, dành cho video có nội dung 18+.")]
        [DefaultValue(false)]
        public bool VideoAgeRestricted { set; get; }

        

        #endregion
    }

    public enum PrivacyEnum
    {
        Public,
        Unlisted,
        Private,
        Scheduled
    }

    public class FolderSelector : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null)
            {
                Form fm = new Form();
                fm.StartPosition = FormStartPosition.CenterParent;
                svc.ShowDialog(fm);
                // update etc
                value = "hello abc";
            }
            return value;
        }
    }

    public class FileSelector : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null)
            {
                Form fm = new Form();
                fm.StartPosition = FormStartPosition.CenterParent;
                svc.ShowDialog(fm);
                // update etc
                value = "hello file abc";
            }
            return value;
        }
    }

    public class LanguageSelector : TypeConverter
    {
        public override bool
        GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // display drop
        }
        public override bool
        GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
        public override StandardValuesCollection
        GetStandardValues(ITypeDescriptorContext context)
        {
            // can look at context to build list, if necessary
            return new StandardValuesCollection(new string[] { "Afrikaans [af]", "Arabic [ar]", "Bangla [bn-BD]", "Bosnian [bs-Latn]", "Bulgarian [bg]", "Cantonese Traditional [yue]", "Catalan [ca]", "Chinese Simplified [zh-CHS]", "Chinese Traditional [zh-CHT]", "Croatian [hr]", "Czech [cs]", "Danish [da]", "Dutch [nl]", "English [en]", "Estonian [et]", "Fijian [fj]", "Filipino [fil]", "Finnish [fi]", "French [fr]", "German [de]", "Greek [el]", "Haitian Creole [ht]", "Hebrew [he]", "Hindi [hi]", "Hmong Daw [mww]", "Hungarian [hu]", "Icelandic [is]", "Indonesian [id]", "Italian [it]", "Japanese [ja]", "Klingon [tlh]", "Klingon plqaD [tlh-Qaak]", "Korean [ko]", "Latvian [lv]", "Lithuanian [lt]", "Malagasy [mg]", "Malay [ms]", "Maltese [mt]", "Norwegian [no]", "Persian [fa]", "Polish [pl]", "Portuguese [pt]", "Querétaro Otomi [otq]", "Romanian [ro]", "Russian [ru]", "Samoan [sm]", "Serbian Cyrillic [sr-Cyrl]", "Serbian Latin [sr-Latn]", "Slovak [sk]", "Slovenian [sl]", "Spanish [es]", "Swahili [sw]", "Swedish [sv]", "Tahitian [ty]", "Tamil [ta]", "Thai [th]", "Tongan [to]", "Turkish [tr]", "Ukrainian [uk]", "Urdu [ur]", "Vietnamese [vi]", "Welsh [cy]", "Yucatec Maya [yua]" });
        }
        
    }

    public class TimeZoneSelector : TypeConverter
    {
        public override bool
        GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // display drop
        }
        public override bool
        GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
        public override StandardValuesCollection
        GetStandardValues(ITypeDescriptorContext context)
        {
            // can look at context to build list, if necessary
            return new StandardValuesCollection(new string[] { "(GMT-1000) Honolulu", "(GMT-0800) Anchorage", "(GMT-0800) Juneau", "(GMT-0700) Hermosillo", "(GMT-0700) Los Angeles", "(GMT-0700) Phoenix", "(GMT-0700) Tijuana", "(GMT-0700) Vancouver", "(GMT-0600) Denver", "(GMT-0600) Easter", "(GMT-0600) Edmonton", "(GMT-0500) Bogota", "(GMT-0500) Chicago", "(GMT-0500) Mexico City", "(GMT-0500) Rio Branco", "(GMT-0500) Winnipeg", "(GMT-0400) Detroit", "(GMT-0400) Manaus", "(GMT-0400) Montreal", "(GMT-0400) New York", "(GMT-0400) Santiago", "(GMT-0400) Toronto", "(GMT-0300) Bahia", "(GMT-0300) Belem", "(GMT-0300) Buenos Aires", "(GMT-0300) Halifax", "(GMT-0300) Recife", "(GMT-0300) Sao Paulo", "(GMT-0230) St. John’s", "(GMT-0200) Noronha", "(GMT+0100) Algiers", "(GMT+0100) Canary", "(GMT+0100) Casablanca", "(GMT+0100) Dublin", "(GMT+0100) Lagos", "(GMT+0100) London", "(GMT+0100) Tunis", "(GMT+0200) Amsterdam", "(GMT+0200) Berlin", "(GMT+0200) Brussels", "(GMT+0200) Budapest", "(GMT+0200) Cairo", "(GMT+0200) Johannesburg", "(GMT+0200) Kaliningrad", "(GMT+0200) Madrid", "(GMT+0200) Paris", "(GMT+0200) Prague", "(GMT+0200) Rome", "(GMT+0200) Stockholm", "(GMT+0200) Warsaw", "(GMT+0300) Aden", "(GMT+0300) Amman", "(GMT+0300) Jerusalem", "(GMT+0300) Kampala", "(GMT+0300) Moscow", "(GMT+0300) Nairobi", "(GMT+0300) Riyadh", "(GMT+0300) Volgograd", "(GMT+0500) Yekaterinburg", "(GMT+0530) Kolkata", "(GMT+0600) Omsk", "(GMT+0700) Krasnoyarsk", "(GMT+0700) Novosibirsk", "(GMT+0800) Hong Kong", "(GMT+0800) Irkutsk", "(GMT+0800) Manila", "(GMT+0800) Perth", "(GMT+0800) Singapore", "(GMT+0800) Taipei", "(GMT+0845) Eucla", "(GMT+0900) Seoul", "(GMT+0900) Tokyo", "(GMT+0900) Yakutsk", "(GMT+0930) Adelaide", "(GMT+0930) Darwin", "(GMT+1000) Brisbane", "(GMT+1000) Hobart", "(GMT+1000) Melbourne", "(GMT+1000) Sydney", "(GMT+1000) Vladivostok", "(GMT+1100) Sakhalin", "(GMT+1200) Auckland", "(GMT+1200) Kamchatka", "(GMT+1245) Chatham" });
        }

    }

    public class CategorySelector : TypeConverter
    {
        public override bool
        GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // display drop
        }
        public override bool
        GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
        public override StandardValuesCollection
        GetStandardValues(ITypeDescriptorContext context)
        {
            // can look at context to build list, if necessary
            return new StandardValuesCollection(new string[] { "Film & Animation", "Autos & Vehicles", "Music", "Pets & Animals", "Sports", "Travel & Events", "Gaming", "People & Blogs", "Comedy", "Entertainment", "News & Politics", "Howto & Style", "Education", "Science & Technology", "Nonprofits & Activism" });
        }

    }
}
