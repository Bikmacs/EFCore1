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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private readonly UserService _userService = new();
        private User? _user;

        public EditPage()
        {
            InitializeComponent();
        }

        public EditPage(User user) 
        {
            InitializeComponent();
            _user = user;
            DataContext = _user;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                _userService.UpdateUser(_user);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditProfile(object sender, RoutedEventArgs e)
        {
            if (_user == null) return;
            if (_user.UserProfile == null)
            {
                var newProfile = new UserProfile
                {
                    UserId = _user.Id  
                };

                NavigationService.Navigate(new ProfilePage(newProfile));
            }
            else
            {
                NavigationService.Navigate(new ProfilePage(_user.UserProfile));
            }
        }
    }
}
