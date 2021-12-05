using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using StickerGenerator_DocX.Command;
using StickerGenerator_DocX.Model;

namespace StickerGenerator_DocX.ViewModel
{
    public class StickerViewModel : INotifyPropertyChanged
    {
        public int CurrentNumber { get; set; }
        public RelayCommand RelayCommand { get; }
        public StickerInfo Sticker { get; set; }
        public int CountOfBoxes { get; set; }

        public StickerViewModel()
        {
            RelayCommand = new RelayCommand(Click);
        }

        private void Click(object parameter)
        {
            try
            {
                if(CountOfBoxes > 0 && FirstNumber > 0)
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
