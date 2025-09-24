
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Security.RightsManagement;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibMas //сохранить, открыть, заполнить, очистить
{

    public class Class1
    {
        public static void InitMas(out int[] mas, int column)
        {
            mas = new int[column];
            Random random = new Random();
            for (int i = 0; i < column; i++) mas[i] = random.Next(-10, 11);
        }

        
        
        public static void SaveDialog(int [] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
            
        }
        public static int[] OpenDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            int[] mas=default!;
            if (open.ShowDialog() == true) 
                                           
            {
                StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                mas=new int[len];
                for (int i = 0; i < len; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
            }
            return mas;
        }
        


    }
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}


