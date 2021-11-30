using System;
using System.IO;
using Xceed.Words.NET;

namespace StickerGenerator_DocX
{
    public class Stickers
    {
        #region Private Members
        private static readonly string DocumentSampleResourcesDirectory = "Templates";
        private static readonly string DocumentSampleOutputDirectory = "Documents";
        #endregion

        #region Constructors
        public Stickers()
        {
            if (!Directory.Exists(DocumentSampleOutputDirectory))
            {
                Directory.CreateDirectory(DocumentSampleOutputDirectory);
            }
        }
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
        public static void CreateSticker(string fileName, string number, string article, string articleCRM, string chip, int countBoxes)
        {
            // Файл, в который будет производиться добавление модифицированного шаблона
            using (DocX document = DocX.Create(DocumentSampleOutputDirectory + $"\\{fileName}"))
            {
                using (DocX appendDocument = DocX.Load(DocumentSampleResourcesDirectory + "\\StickerTemplate.dotx"))
                {
                    if (int.TryParse(number, out int count))
                    {
                        document.ApplyTemplate(DocumentSampleResourcesDirectory + "\\StickerTemplate.dotx");
                        for (int i = 0; i < countBoxes; i++)
                        {
                            document.ReplaceText("[firstNumber]", Convert.ToString(count) + "\n");
                            document.ReplaceText("[article]", article);
                            document.ReplaceText("[articleCRM]", articleCRM);
                            document.ReplaceText("[chip]", chip);
                            document.ReplaceText("[data]", DateTime.Now.ToString("dd/MM/yyyy"));

                            if (i < countBoxes - 1)
                                document.InsertDocument(appendDocument);

                            count++;
                        }
                        document.Save();
                    }
                }
            }
        }
        #endregion
    }
}
