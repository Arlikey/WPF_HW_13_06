using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AdditionalTask1.xaml
    /// </summary>
    public partial class AdditionalTask1 : Window
    {
        private WeatherViewModel weatherViewModel;
        public AdditionalTask1()
        {
            InitializeComponent();
            weatherViewModel = new WeatherViewModel();
            DataContext = weatherViewModel;

        }

    }

    public class WeatherViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _cities;
        private string _selectedCity;
        private WeatherInfo _weatherInfo;

        public WeatherViewModel()
        {
            Cities = new ObservableCollection<string> { "Одесса", "Киев" };
            WeatherInfo = new WeatherInfo();
        }

        public ObservableCollection<string> Cities
        {
            get => _cities;
            set
            {
                if (_cities != value)
                {
                    _cities = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged();
                    UpdateWeatherInfo();
                }
            }
        }
        public WeatherInfo WeatherInfo
        {
            get => _weatherInfo;
            set
            {
                if (_weatherInfo != value)
                {
                    _weatherInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateWeatherInfo()
        {
            if (_selectedCity == "Одесса")
            {
                WeatherInfo = new WeatherInfo { Temperature = "32°C", Condition = "Ясно" };
            }
            else if (_selectedCity == "Киев")
            {
                WeatherInfo = new WeatherInfo { Temperature = "28°C", Condition = "Облачно" };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class WeatherInfo : INotifyPropertyChanged
    {
        private string _temperature;
        private string _condition;

        public string Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Condition
        {
            get => _condition;
            set
            {
                if (_condition != value)
                {
                    _condition = value;
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
}
