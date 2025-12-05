using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore1.models
{
    public class InterestGroup: ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private ObservableCollection<UserInterestGroup> _userGroup;
        public ObservableCollection<UserInterestGroup> UserGroup
        {
            get => _userGroup;
            set => SetProperty(ref _userGroup, value);
        }

    }
}
