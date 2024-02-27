using lvl7_yana.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lvl7_yana.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Product.xaml
    /// </summary>
    public partial class Page_Product : Page
    {
        Product product;
        public Page_Product()
        {
            InitializeComponent();
            update();
            Sort.Items.Add("Название по алфавиту");
            Sort.Items.Add("Название против алфавита");
            Sort.Items.Add("По возрастанию цены");
            Sort.Items.Add("По убыванию цены");
            Sort.SelectedIndex = 1;

            List<ProductType> types = CoreModel.init().ProductTypes.ToList();
            Filt.ItemsSource = types;
            Filt.SelectedIndex = 0;
            types.Insert(0, new ProductType { Title = "Все типы" });

        }
        private void update()
        {
            IEnumerable<Product> products = CoreModel.init().Products.Include(p => p.ProductType).Where(p => p.Title.Contains(Poisk.Text) || p.MinCostForAgent.ToString().Contains(Poisk.Text));
            switch (Sort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.Title);
                    break;

                case 1: products = products.OrderByDescending(p => p.Title);
                    break;

                case 2:
                    products = products.OrderBy(p => p.MinCostForAgent);
                    break;

                case 3:
                    products = products.OrderByDescending(p => p.MinCostForAgent);
                    break;
            }
            if (Filt.SelectedIndex > 0)
                products = products.Where(p => p.ProductTypeId == (Filt.SelectedItem as ProductType).Id);

            LVProduct.ItemsSource = products.ToList(); 
        }

        private void Change(object sender, TextChangedEventArgs e) 
        { 

           update();

        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {

            update();

        }

        private void FiltChange(object sender, SelectionChangedEventArgs e)
        {

            update();

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProduct_Page(new Product()));
        }

        private void Button_DelClick(object sender, RoutedEventArgs e)
        {
            if (LVProduct.SelectedItems.Count > 1)
            {
                return;
            }

            Product prod = LVProduct.SelectedItem as Product;

            if (MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo ) == MessageBoxResult.Yes)
            {
                CoreModel.init().Products.Remove(prod);
                CoreModel.init().SaveChanges();
                update();

            }
        }

        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            Product productEdit = LVProduct.SelectedItem as Product;
            NavigationService.Navigate(new AddProduct_Page(productEdit));
        }

        private void AddProduct_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            update();
        }
    }
}
