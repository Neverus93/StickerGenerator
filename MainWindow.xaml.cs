using System;
using System.Reflection;
using System.Windows;

namespace StickerGenerator_DocX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private string company = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;

        public MainWindow()
        {
            InitializeComponent();
            versionNumber.Content = $"Version: {version} \nProducted by {company}";
        }

        private void Generate_ButtonClick(object sender, RoutedEventArgs e)
        {
            string firstNumber = firstBoxNumber.Text;
            string article = articleCurrent.Text;
            string articleCRM = articleCardFromCRM.Text;
            string chip = chipName.Text;
            string fileName = chipName.Text;
            int countBoxes;

            try
            {
                if (int.TryParse(countOfBoxes.Text, out countBoxes) &&
                    int.TryParse(firstNumber, out int number) &&
                    countBoxes > 0 && number > 0)
                {
                    Stickers.CreateSticker(fileName, number, article, articleCRM, chip, countBoxes);
                    MessageBox.Show($"Готово\nДокумент \"{fileName}\" успешно сохранён!");
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
