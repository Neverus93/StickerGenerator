namespace StickerGenerator_DocX.Model
{
    public class StickerInfo
    {
        public string Article { get; set; }
        public string ArticleCRM { get; set; }
        public string ChipName { get; set; }

        public StickerInfo()
        {

        }

        public StickerInfo(string article, string articleCRM, string chipName)
        {
            Article = article;
            ArticleCRM = articleCRM;
            ChipName = chipName;
        }
    }
}
