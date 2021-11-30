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
            string resultMessage;

            string firstNumber = firstBoxNumber.Text;
            string article = articleISBC.Text;
            string articleCRM = articleCardFromCRM.Text;
            string chip = chipName.Text;
            string fileName = chipName.Text;
            int countBoxes;

            if (int.TryParse(countOfBoxes.Text, out countBoxes))
            {
                Stickers.CreateSticker(fileName, firstNumber, article, articleCRM, chip, countBoxes);
            }

            if (countBoxes != 0 && firstNumber != string.Empty && int.TryParse(firstNumber, out int number) && number != 0)
            {
                resultMessage = $"Готово\nДокумент \"{fileName}\" успешно сохранён!";
            }
            else
            {
                resultMessage = "Что-то пошло не так. Проверьте введённые данные...";
            }

            MessageBox.Show(resultMessage);
        }
    }
}
