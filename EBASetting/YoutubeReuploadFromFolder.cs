using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design; // need to add references "System.Design"
using System.Drawing.Design; // for "UITypeEditor"
using System.Linq;
using System.Text;

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
        [DefaultValue(YoutubePrivacyEnum.Public)]
        public YoutubePrivacyEnum PrivacyPrivacy { set; get; }

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
        [TypeConverter(typeof(YoutubeCategorySelector))]
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

}
