using System;
using System.IO;
using Xceed.Words.NET;

namespace StickerGenerator_DocX.Model
{
    public class StickersCreator
    {
        #region Private Members
        private const string DocumentSampleResourcesDirectory = "Templates";
        private const string DocumentSampleOutputDirectory = "Documents";
        private const string StickerTemplate = "StickerTemplate.docx";
        #endregion

        #region Public Methods
        public void CreateStickers(StickerInfo sticker, int countBoxes, int currentNumber)
        {
            string stickerPath = Path.Combine(DocumentSampleResourcesDirectory, StickerTemplate);
            string outputFileNamePath = Path.Combine(DocumentSampleOutputDirectory, sticker.ChipName);

            using (DocX document = DocX.Load(stickerPath))
            {
                using (DocX outputDocument = DocX.Load(stickerPath))
                {
                    for (int i = 0; i < countBoxes; i++)
                    {
                        document.ReplaceText("{firstNumber}", Convert.ToString(currentNumber++));
                        document.ReplaceText("{article}", sticker.Article);
                        document.ReplaceText("{articleCRM}", sticker.ArticleCRM);
                        document.ReplaceText("{chip}", sticker.ChipName);
                        document.ReplaceText("{date}", DateTime.Now.ToString("dd/MM/yyyy"));

                        if (i < countBoxes - 1)
                        {
                            document.InsertDocument(outputDocument);
                        }
                    }
                    if (!Directory.Exists(DocumentSampleOutputDirectory))
                    {
                        Directory.CreateDirectory(DocumentSampleOutputDirectory);
                    }
                    document.SaveAs(outputFileNamePath);
                }
            }
        }
        #endregion
    }
}
