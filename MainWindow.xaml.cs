using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace WPF_HW_13_06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductViewModel productViewModel;
        public MainWindow()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
            DataContext = productViewModel;
        }

        private void cartButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Вы купили продуктов на сумму: {productViewModel.ProductsPrice}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (sender as Button).Tag as Product;
            if(selectedProduct.Count <= 0)
            {
                return;
            }
            if (selectedProduct != null)
            {
                productViewModel.ProductsPrice += selectedProduct.Price;
                productViewModel.ProductsCount++;
                selectedProduct.Count--;
            }
        }
    }
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                if(_products != value)
                {
                    _products = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _productsCount;
        public int ProductsCount
        {
            get => _productsCount;
            set
            {
                if(_productsCount != value)
                {
                    _productsCount = value;
                    OnPropertyChanged();
                }
            }
        }
        private decimal _productsPrice;
        public decimal ProductsPrice
        {
            get => _productsPrice;
            set
            {
                if (_productsPrice != value)
                {
                    _productsPrice = value;
                    OnPropertyChanged();
                }
            }
        }
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product(){Name="Strawberry", Count=30, Price=0.99m, Image="Images/strawberry.png"},
                new Product(){Name="Pineapple", Count=5, Price=4.99m, Image="Images/pineapple.png"}
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private decimal _price;
        private int _count;
        private string _image;
        public string Name 
        {
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            } 
        }
        public decimal Price 
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Count 
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Image 
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}