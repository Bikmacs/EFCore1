using EfCore1.models;
using EfCore1.Service;
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

namespace EfCore1.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        private UserService _userService = new();
        public User _user = new();
        public UserFormPage()
        {
            InitializeComponent();
            DataContext = _user;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _userService.Add(_user);
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
