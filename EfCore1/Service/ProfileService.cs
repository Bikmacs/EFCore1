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
    public class ProfileService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<UserProfile> Profiles { get; set; } = new();

        public void GetAll()
        {
            var roles = _db.UserProfiles.ToList();
            Profiles.Clear();
            foreach (var role in roles)
            {
                Profiles.Add(role);
            }
        }

        public int Commit() => _db.SaveChanges();

        public ProfileService()
        {
            GetAll();
        }

        public void Add(UserProfile userProfile)
        {
            var _userProfile = new UserProfile
            {
                AvatarUrl = userProfile.AvatarUrl,
                Phone = userProfile.Phone,
                Birthday = userProfile.Birthday,
                Bio = userProfile.Bio,
                UserId = userProfile.UserId
            };

            _db.Add<UserProfile>(_userProfile);
            Commit();
            Profiles.Add(_userProfile);
        }
        public void Remove(UserProfile userProfile)
        {
            _db.Remove<UserProfile>(userProfile);
            if (Commit() > 0)
                if (Profiles.Contains(userProfile))
                    Profiles.Remove(userProfile);
        }

        public void UpdateUser(UserProfile userProfile)
        {
            var existingUserProfile = _db.UserProfiles.Find(userProfile.Id);
            if (existingUserProfile != null)
            {
                existingUserProfile.AvatarUrl = userProfile.AvatarUrl;
                existingUserProfile.Phone = userProfile.Phone;
                existingUserProfile.Birthday = userProfile.Birthday;
                existingUserProfile.Bio = userProfile.Bio;
                _db.SaveChanges();
            }
        }
    }
}
