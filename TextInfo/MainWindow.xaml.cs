using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace TextInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? textInFile = default;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                textInFile = File.ReadAllText(dialog.FileName);
                TextInput.Text = textInFile;
            }
        }
        static string SortString(string input, bool reverse) // Этот метод выполняет сортировку строки. Если true - по убыванию, иначе - по возрастанию
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            if (reverse)
                Array.Reverse(characters);
            return new string(characters);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Сортировка по возрастанию
        {
            if(textInFile is not null)
                textInFile = SortString(textInFile, false);
            TextInput.Text = textInFile;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Сортировка по убыванию
        {
            if (textInFile is not null)
                textInFile = SortString(textInFile, true);
            TextInput.Text = textInFile;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) 
        {
            if (textInFile is not null)
            {
                string[] textArray = textInFile.Split(new char[] { ' ' }); //разбиваем текст на слова (в массив строк)
                MessageBox.Show($"Количество символов в тексте: {textInFile.Length}" +
                    $"\nКоличество слов в тексте: {textArray.Length+1}");
            } else {MessageBox.Show("Необходимо выбрать файл, чтобы получить информацию"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // Найти элемент 
        {
            if (TextPole.Text is not null && textInFile.Contains(TextPole.Text))
                MessageBox.Show($"В тексте есть строка {TextPole.Text}");
            else MessageBox.Show($"В тексте НЕТ строки {TextPole.Text}");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (textInFile is not null)
            {
                Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "TXT Files (*.png)|*.txt"
                };
                if (save.ShowDialog() == true)
                {
                    File.WriteAllText(save.FileName, textInFile, Encoding.Default);
                    MessageBox.Show("Файл успешно сохранен!");
                }
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            textInFile = TextInput.Text;
        }
    }
}
