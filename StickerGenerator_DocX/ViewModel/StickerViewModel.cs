using StickerGenerator_DocX.Command;
using StickerGenerator_DocX.Model;
using System;
using System.Windows;

namespace StickerGenerator_DocX.ViewModel
{
    public class StickerViewModel
    {
        public int CurrentNumber { get; set; }
        public RelayCommand RelayCommand { get; }
        public StickerInfo Sticker { get; set; }
        public int CountOfBoxes { get; set; }

        public StickerViewModel()
        {
            RelayCommand = new RelayCommand(Click);
            Sticker = new StickerInfo();
        }

        private void Click(object parameter)
        {
            try
            {
                if (CountOfBoxes > 0 && CurrentNumber > 0)
                {
                    StickersCreator.CreateStickers(Sticker, CountOfBoxes, CurrentNumber);
                    MessageBox.Show($"Готово\nДокумент \"{Sticker.ChipName}\" успешно сохранён!");
                }
                else
                {
                    throw new InvalidOperationException("Что-то пошло не так. Проверьте введённые данные...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }
    }
}
