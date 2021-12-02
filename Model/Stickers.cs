using System;
using System.IO;
using Xceed.Words.NET;

namespace StickerGenerator_DocX.Model
{
    public static class Stickers
    {
        #region Private Members
        private const string DocumentSampleResourcesDirectory = "Templates";
        private const string DocumentSampleOutputDirectory = "Documents";

        private const string StickerTemplate = "StickerTemplate.docx";
        #endregion

        #region Public Methods
        /// <summary>
        /// Функция, которая создаёт файл с этикетками на основании шаблона StickerTemplate и сохраняет его
        /// </summary>
        /// <param name="fileName">Имя файла, основанное на названии чипа, этикетки на которые делает пользователь</param>
        /// <param name="number">Номер первой коробки с чипами</param>
        /// <param name="article">Артикул чипа общий</param>
        /// <param name="articleCRM">Артикул чипа из системы CRM</param>
        /// <param name="chip">Название чипа, этикетку на который делает пользователь</param>
        /// <param name="countBoxes">Количество коробок с чипами</param>
        public static void CreateSticker(string fileName, int number, string article, string articleCRM, string chip, int countBoxes)
        {
            string stickerPath = Path.Combine(DocumentSampleResourcesDirectory, StickerTemplate);
            string outputFileNamePath = Path.Combine(DocumentSampleOutputDirectory, fileName);

            using (DocX document = DocX.Load(stickerPath))
            {
                using (DocX outputDocument = DocX.Load(stickerPath))
                {
                    for (int i = 0; i < countBoxes; i++)
                    {
                        outputDocument.ReplaceText("{firstNumber}", Convert.ToString(number) + "\n");
                        outputDocument.ReplaceText("{article}", article);
                        outputDocument.ReplaceText("{articleCRM}", articleCRM);
                        outputDocument.ReplaceText("{chip}", chip);
                        outputDocument.ReplaceText("{date}", DateTime.Now.ToString("dd/MM/yyyy"));

                        if (i < countBoxes - 1)
                        {
                            outputDocument.InsertDocument(document);
                        }
                        number++;
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
