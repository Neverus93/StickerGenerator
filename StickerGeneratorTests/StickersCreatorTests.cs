using NUnit.Framework;
using StickerGenerator_DocX.Model;
//using StickerGenerator_DocX.ViewModel;
using System.IO;

namespace StickerGeneratorTests
{
    public class StickersCreatorTests
    {
        [Test]
        public void CreateStickersTest()
        {
            string article = "000-00000";
            string articleCrm = "111-11111";
            string chipName = "OreonChokopai";
            int countBoxes = 3;
            int currentNumber = 45;

            StickerInfo sticker = new StickerInfo(article, articleCrm, chipName);

            try
            {
                StickersCreator.CreateStickers(sticker, countBoxes, currentNumber);
                Assert.Pass();
            }
            finally
            {

            }
        }
    }
}