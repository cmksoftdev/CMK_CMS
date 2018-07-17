using CMK.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMK_WebSiteDeveloperStudio.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public CommandMethodReflectionProvider com { get; protected set; }

        public class Property<T>
        {
            T privateField;
            ViewModelBase vm;
            string name;

            public Property(ViewModelBase vm, string name)
            {
                this.vm = vm;
                this.name = name;
            }

            public T P
            {
                get
                {
                    return privateField;
                }
                set
                {
                    privateField = value;
                    vm.OnPropertyChanged(name);
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
