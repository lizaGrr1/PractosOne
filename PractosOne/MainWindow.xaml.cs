using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_9;
using LibMas;
using Microsoft.Win32;


namespace PractosOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas;
        DataTable dataTable;
        private void miInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вариант 9 \r\nВвести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран. \r\nРаботу выполнил");
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            int summ = ProductCalculator.ProductMas(mas);
            tbSumm.Text = summ.ToString();
        }
        private void Refresh()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbKol.Clear();
            tbSumm.Clear();
            dataTable.Clear();
            dataTable.Columns.Clear();
            Refresh();
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            Class1.SaveDialog(mas);
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            mas = Class1.OpenDialog();
            dataTable=VisualArray.ToDataTable(mas);
            dataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {  
            int kol = Convert.ToInt32(tbKol.Text);
            Class1.InitMas(out mas, kol);
            dataTable= VisualArray.ToDataTable(mas);
            dataGrid.ItemsSource=dataTable.DefaultView;
        }


        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }
    }
}