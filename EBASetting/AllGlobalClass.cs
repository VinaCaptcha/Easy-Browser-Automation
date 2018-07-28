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
    public enum YoutubePrivacyEnum
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

    public class YoutubeCategorySelector : TypeConverter
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
