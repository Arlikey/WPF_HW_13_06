using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_HW_13_06
{
    /// <summary>
    /// Interaction logic for AdditionalTask2.xaml
    /// </summary>
    public partial class AdditionalTask2 : Window
    {
        public AdditionalTask2()
        {
            InitializeComponent();
            this.DataContext = new DataSource();
        }
        class DataSource : INotifyPropertyChanged
        {
            public BindingList<string> Strings { get; }
            public MainCommand AddCommand { get; set; }
            public MainCommand DeleteCommand { get; set; }

            private string _userString;

            public string UserString
            {
                get => _userString;
                set
                {
                    if (_userString != value)
                    {
                        _userString = value;
                        OnPropertyChanged();
                    }
                }
            }

            private string _selectedString;
            public DataSource()
            {
                Strings = new BindingList<string>();
                AddCommand = new MainCommand(_ =>
                {
                    Strings.Add(UserString);
                });
                DeleteCommand = new MainCommand(_ =>
                {
                    Strings.Remove(_selectedString);
                });
            }
            public string SelectedString
            {
                get => _selectedString;
                set
                {
                    if (_selectedString != value)
                    {
                        _selectedString = value;
                        OnPropertyChanged();
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
        public class MainCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;
            private Action<object?> action;
            public MainCommand(Action<object?> action)
            {
                this.action = action;
            }
            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => action?.Invoke(parameter);
        }
    }
}
