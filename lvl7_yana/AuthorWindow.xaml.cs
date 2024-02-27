using lvl7_yana.DbModel;
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
using System.Windows.Shapes;

namespace lvl7_yana
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == null || tbPassword.Text == null)
            {
                MessageBox.Show("Заполните данные для авторизации");
            }
            else
            {
                Product product = CoreModel.init().Products.FirstOrDefault(p => p.ArticleNumber == tbLogin.Text && Convert.ToString(p.ProductionPersonCount) == tbPassword.Text);

                if (product.Title == "Кресло 12М Классика")
                {
                    MainWindow windowAdmin = new MainWindow();
                    windowAdmin.Show();
                    Hide();

                }
                else if (product.Title == "Кресло 50М Модерн")
                {
                    User_window windowAdmin = new User_window();
                    windowAdmin.Show();
                    Hide();

                }
            }
        }
    }
}
