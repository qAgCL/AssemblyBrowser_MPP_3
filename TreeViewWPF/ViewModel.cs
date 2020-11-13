using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using AssemblyInfoLib;
using System.Windows.Input;

namespace TreeViewWPF
{
    class ViewModel: INotifyPropertyChanged
    {

        private AssemblyInformation assemblyInformation = null;
        private IDialogService GetFileDialog;
        public ICommand LoadAssebmly { get { return new RelayCommand(obj => GetAsm()); }}

        public AssemblyInformation AssemblyInformation
        {
            get { return assemblyInformation; }
            set
            {
                assemblyInformation = value;
                OnPropertyChanged(nameof(AssemblyInformation));
            }
        }

        private void GetAsm()
        {
            if (GetFileDialog.OpenFileDialog())
            {
                AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
                Assembly assembly = Assembly.LoadFrom(GetFileDialog.FilePath);
                AssemblyInformation = assemblyBrowser.GetAssemblyInformation(assembly);
            }
        }

        public ViewModel()
        {
            GetFileDialog = new DefaultDialogService();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    }
}
