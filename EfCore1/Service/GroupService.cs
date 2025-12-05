using EfCore1.Data;
using EfCore1.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EfCore1.Service
{
    public class GroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<InterestGroup> Group { get; set; } = new();
        public ObservableCollection<UserInterestGroup> UserGroup { get; set; } = new();

        public int Commit() => _db.SaveChanges();   

        public void Add(InterestGroup group)
        {
            var _group = new InterestGroup
            {
                Id = group.Id,
                Title = group.Title,
                Description = group.Description                
            };
            _db.Add<InterestGroup>(_group);
            Commit();
            Group.Add(_group);
        }

        public void AddUserToGroup(User user, UserInterestGroup userGroup, InterestGroup group)
        {
            bool Exists = _db.UserGroup.Any(ug =>
                            ug.UserId == user.Id &&
                            ug.InterestGroupId == group.Id);

            if (Exists)
            {
                return;
            }

            var _groupUser = new UserInterestGroup
            {
                UserId = user.Id,
                InterestGroupId = group.Id,
                JoinedAt = userGroup.JoinedAt,
                IsModerator = userGroup.IsModerator,
                Title = group.Title
            };
            _db.UserGroup.Add(_groupUser);
            Commit();
            
        }

        public void GetAll()
        {
            var groups = _db.Groups
                .Include(c => c.UserGroup)
                .ThenInclude(cs => cs.User)
                .ToList();  

            Group.Clear();
            foreach(var group in groups)
            {
                Group.Add(group);
            };
        }

        public GroupService()
        {
            GetAll();
        }

        public void Remove(InterestGroup group)
        {
            _db.Remove<InterestGroup>(group);
            if (Commit() > 0)
                if (Group.Contains(group))
                    Group.Remove(group);
        }



    }
}
