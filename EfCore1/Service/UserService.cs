using EfCore1.Data;
using EfCore1.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore1.Service
{
    public class UserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<User> Users { get; set; } = new();

        public int Commit() => _db.SaveChanges();

        public UserService()
        {
            GetAll();
        }

        public void GetAll()
        {
            var users = _db.Users.ToList();
            Users.Clear();
            foreach (var u in users) Users.Add(u);
        }

        public void Add(User user)
        {
            user.CreateAt = DateTime.Now;
            _db.Users.Add(user);
            _db.SaveChanges();
            Users.Add(user);
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
            Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _db.Users.Find(user.Id);
            if(existingUser != null)
            {
                existingUser.Login = user.Login;
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                _db.SaveChanges();
            }
        }

        public void Update()
        {
            Commit();
        }
    }
}
