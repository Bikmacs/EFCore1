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
using static System.Net.Mime.MediaTypeNames;

namespace EfCore1.Service
{
    public class RoleService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<Role> Roles { get; set; } = new();

        public void GetAll()
        {
            var roles = _db.Roles.ToList();
            Roles.Clear();
            foreach (var role in roles)
            {
                Roles.Add(role);
            }
        }

        public int Commit() => _db.SaveChanges();

        public RoleService()
        {
            GetAll();
        }

        public void Add(Role role)
        {
            var _userRole = new Role
            {
                Title = role.Title
            };

            _db.Add<Role>(_userRole);
            Commit();   
            Roles.Add(_userRole);
        }

        public Role? GetRoleByName(string title)
        {
            return _db.Roles
                .Include(r => r.Users) 
                .FirstOrDefault(r => r.Title == title);
        }

        public void Remove(Role role)
        {
            _db.Remove<Role>(role);
            if(Commit() > 0)
                if(Roles.Contains(role))
                    Roles.Remove(role);
        }

        public void LoadRelation(Role role, string relation)
        {
            var entry = _db.Entry(role);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
            if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}
