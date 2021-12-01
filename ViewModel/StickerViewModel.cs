using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using StickerGenerator_DocX.Command;
using StickerGenerator_DocX.Model;

namespace StickerGenerator_DocX.ViewModel
{
    //TODO
    public class StickerViewModel : INotifyPropertyChanged
    {
        private ICommand _clickCommand;
        private RelayCommand _relayCommand;

        public RelayCommand RelayCommand { get; set; }
        public ICommand ClickCommand { get; set; }

        public StickerViewModel()
        {
            RelayCommand = new RelayCommand(Click);
        }

        private void Click(object parameter)
        {
            //string firstNumber = firstBoxNumber.Text;
            //string article = articleCurrent.Text;
            //string articleCRM = articleCardFromCRM.Text;
            //string chip = chipName.Text;
            //string fileName = chipName.Text;
            //int countBoxes;

            //try
            //{
            //    if (int.TryParse(countOfBoxes.Text, out countBoxes) &&
            //        int.TryParse(firstNumber, out int number) &&
            //        countBoxes > 0 && number > 0)
            //    {
            //        Stickers.CreateSticker(fileName, number, article, articleCRM, chip, countBoxes);
            //        MessageBox.Show($"Готово\nДокумент \"{fileName}\" успешно сохранён!");
            //    }
            //    else
            //    {
            //        throw new InvalidOperationException("Что-то пошло не так. Проверьте введённые данные...");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
