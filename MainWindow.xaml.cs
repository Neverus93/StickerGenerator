using System;
using System.Reflection;
using System.Windows;
using StickerGenerator_DocX.Model;

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
    }
}
