using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;

namespace TreeViewWPF
{

        public class DefaultDialogService : IDialogService
        {
            public string FilePath { get; set; }

            public bool OpenFileDialog()
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Lib files (*.dll)|*.dll|Exe files (*.exe*)|*.exe*";
                if (openFileDialog.ShowDialog() == true)
                {
                    FilePath = openFileDialog.FileName;
                    return true;
                }
                return false;
            }
        }
    

    public interface IDialogService
    {
        string FilePath { get; set; }   // путь к выбранному файлу
        bool OpenFileDialog();  // открытие файла
    }
}
