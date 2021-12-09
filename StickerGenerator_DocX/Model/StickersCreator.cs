using System;
using System.IO;
using Xceed.Words.NET;

namespace StickerGenerator_DocX.Model
{
    public static class StickersCreator
    {
        #region Private Members
        private const string DocumentSampleResourcesDirectory = "Templates";
        private const string DocumentSampleOutputDirectory = "Documents";
        private const string StickerTemplate = "StickerTemplate.docx";
        #endregion

        #region Public Methods
        public static void CreateStickers(StickerInfo sticker, int countBoxes, int currentNumber)
        {
            string stickerPath = Path.Combine(DocumentSampleResourcesDirectory, StickerTemplate);
            string outputFileNamePath = Path.Combine(DocumentSampleOutputDirectory, sticker.ChipName);

            using (DocX document = DocX.Load(stickerPath))
            {
                using (DocX outputDocument = DocX.Load(stickerPath))
                {
                    for (int i = 0; i < countBoxes; i++)
                    {
                        outputDocument.ReplaceText("{firstNumber}", Convert.ToString(currentNumber++) + "\n");
                        outputDocument.ReplaceText("{article}", sticker.Article);
                        outputDocument.ReplaceText("{articleCRM}", sticker.ArticleCRM);
                        outputDocument.ReplaceText("{chip}", sticker.ChipName);
                        outputDocument.ReplaceText("{date}", DateTime.Now.ToString("dd/MM/yyyy"));

                        if (i < countBoxes - 1)
                        {
                            outputDocument.InsertDocument(document);
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
