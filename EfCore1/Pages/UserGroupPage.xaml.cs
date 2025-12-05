using EfCore1.models;
using EfCore1.Service;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EfCore1.Pages
{
    public partial class UserGroupPage : Page
    {
        public GroupService Service { get; set; } = new();
        public UserInterestGroup UserGroup { get; set; } = new();
        public User User { get; set; }

        public UserGroupPage(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var selectedGroup = GroupListView.SelectedItem as InterestGroup;

            if (selectedGroup == null)
            {
                MessageBox.Show("Пожалуйста, выберите группу из списка!");
                return;
            }

            Service.AddUserToGroup(User, UserGroup, selectedGroup);

            MessageBox.Show($"Пользователь добавлен в группу {selectedGroup.Title}!");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}