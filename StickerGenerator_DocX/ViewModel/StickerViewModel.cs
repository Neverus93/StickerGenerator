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
        private string _article;
        private string _articleCrm;
        private string _chipName;
        private int _firstNumber;
        private int _countOfBoxes;

        public RelayCommand RelayCommand { get; set; }
        public ICommand ClickCommand { get; set; }

        public int FirstNumber
        {
            get
            {
                return _firstNumber;
            }
            set
            {
                _firstNumber = value;
                OnPropertyChanged("RelayCommand");
            }
        }
        public string Article
        {
            get
            {
                return _article;
            }
            set
            {
                _article = value;
                OnPropertyChanged("RelayCommand");
            }
        }
        public string ArticleCrm
        {
            get
            {
                return _articleCrm;
            }
            set
            {
                _articleCrm = value;
                OnPropertyChanged("RelayCommand");
            }
        }
        public string ChipName
        {
            get
            {
                return _chipName;
            }
            set
            {
                _chipName = value;
                OnPropertyChanged("RelayCommand");
            }
        }
        public string FileName
        {
            get
            {
                return _chipName;
            }
            set
            {
                _chipName = value;
                OnPropertyChanged("RelayCommand");
            }
        }
        public int CountOfBoxes
        {
            get
            {
                return _countOfBoxes;
            }
            set
            {
                _countOfBoxes = value;
                OnPropertyChanged("RelayCommand");
            }
        }
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
                    Stickers.CreateSticker(FileName, FirstNumber, Article, ArticleCrm, ChipName, CountOfBoxes);
                    MessageBox.Show($"Готово\nДокумент \"{FileName}\" успешно сохранён!");
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
