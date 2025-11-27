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
 
    public partial class MainPage : Page
    {
        public UserService service { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserListView.SelectedItem as User;
            if(selectedUser != null)
            {
                service.Delete(selectedUser);
            }
        }
        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserListView.SelectedItem as User;
            if(selectedUser != null)
            {
                NavigationService.Navigate(new EditPage(selectedUser));
            }
        }

   
    }
}
