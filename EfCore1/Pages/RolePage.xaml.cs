using EfCore1.models;
using EfCore1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        Role _role = new Role();
        RoleService service = new();
        bool IsEdit = false;

        public RolePage(Role? role = null)
        {
            InitializeComponent();

            if (role != null)
            {
                service.LoadRelation(role, "Users");
                _role = role;
                IsEdit = true;
            }
            DataContext = _role;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_role);
            back(sender, e);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}
