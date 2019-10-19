namespace Nyss.Data.Models
{
    public class LocalizedTemplate
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public int ApplicationLanguageId { get; set; }
        public virtual ApplicationLanguage ApplicationLanguage { get; set; }
    }
}
