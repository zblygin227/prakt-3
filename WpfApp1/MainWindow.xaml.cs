using Lib_5;
using Libmas;
using Microsoft.Win32;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] arr;
        public MainWindow()
        {
            InitializeComponent();
            MasRowLenghtBox.Focus();
        }

        private void ShowTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Зблыгин Даниил\nДана матрица размера M × N. \nДля каждой строки матрицы с нечетным номером (1, 3, …) найти среднее арифметическое ее элементов. \nУсловный оператор не использовать. ");
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearArr_Click(object sender, RoutedEventArgs e)
        {
            ResBox.Clear();
            LibraryMas.ClearArray(ref arr);
            MasNums.ItemsSource = null;
            avgNums.ItemsSource = null;
            MasRowLenghtBox.Clear();
            MasColumnLenghtBox.Clear();
            MasRowLenghtBox.Focus();
        }

        private void UplArr_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog pfg = new OpenFileDialog();
            pfg.Filter = "Текстовые файлы | *.txt";
            pfg.FilterIndex = 1;
            if (pfg.ShowDialog() == true)
            {
                LibraryMas.UploadArray(ref arr, pfg.FileName);
                MasNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
        }

        private void SaveArr_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.Filter = "Текстовые файлы | *.txt";
            sfg.FilterIndex = 1;
            if (arr == null)
            {
                MessageBox.Show("Массив не может быть пустым!");
            }
            else if (sfg.ShowDialog() == true)
            {
                LibraryMas.SaveArray(arr, sfg.FileName);
            }
        }

        private void FillArrBut_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MasRowLenghtBox.Text, out int rows) && int.TryParse(MasColumnLenghtBox.Text, out int column))
            {
                arr = new int[rows, column];
                LibraryMas.FillArray(ref arr, 1, 10);
                MasNums.ItemsSource = VisualArray.ToDataTable(arr).DefaultView;
            }
            else
            {
                MessageBox.Show("Размер строк или размер столбцов не может быть пустым");
            }
        }

        private void ResBut_Click(object sender, RoutedEventArgs e)
        {
            if (arr != null || MasNums.ItemsSource != null)
            {
                ResBox.Text = $"{LibClass.AvgOfNumArr(arr, out float[] avgStr)}";
                avgNums.ItemsSource = VisualArray.ToDataTable(avgStr).DefaultView;
            }
            else
            {
                MessageBox.Show("Размер строк или размер столбцов не может быть пустым");
            }
        }
    }
}
