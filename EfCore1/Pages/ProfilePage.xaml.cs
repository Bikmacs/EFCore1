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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private readonly ProfileService _profileService = new();
        private UserProfile? _userProfile;

        public ProfilePage()
        {
            InitializeComponent();
        }

        public ProfilePage(UserProfile userProfile)
        {
            InitializeComponent();
            _userProfile = userProfile;
            DataContext = _userProfile;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_userProfile != null)
            {
                if (_userProfile.Id == 0)
                {
                    _profileService.Add(_userProfile);
                }
                else
                {
                    _profileService.UpdateUser(_userProfile);
                }

                NavigationService.GoBack();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
