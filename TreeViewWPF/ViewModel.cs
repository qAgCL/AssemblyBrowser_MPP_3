using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using AssemblyInfoLib;

namespace TreeViewWPF
{
    class ViewModel: INotifyPropertyChanged
    {

        private AssemblyInformation assemblyInformation = null;

        public AssemblyInformation AssemblyInformation
        {
            get { return assemblyInformation; }
            set
            {
                assemblyInformation = value;
                OnPropertyChanged(nameof(AssemblyInformation));
            }
        }

        public ViewModel()
        {
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
            AssemblyInformation = assemblyBrowser.GetAssemblyInformation(Assembly.GetExecutingAssembly());
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
