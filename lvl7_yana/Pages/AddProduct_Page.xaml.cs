using lvl7_yana.DbModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddProduct_Page.xaml
    /// </summary>
    public partial class AddProduct_Page : Page
    {
        Product product;

        public AddProduct_Page(Product prod)
        {
            InitializeComponent();
            this.product = prod;
            DataContext = product;
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (product.Id == 0)
            {
                CoreModel.init().Products.Add(product);
            }

            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
        }

        private void AddServices_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (product.Id != 0)
            {
                CoreModel.init().Entry(product).Reload();
            }
        }

        private void imageEditClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All Files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                //product.Image = File.ReadAllBytes(openFile.FileName); blob

                product.Image = "\\Resources\\Товар_import\\" + new FileInfo(openFile.FileName).Name;
            }
        }
    }
}
