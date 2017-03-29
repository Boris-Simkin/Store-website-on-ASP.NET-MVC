using DAL.DB;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IRepository<User>
    {
        //Salting & encrypting the password
        string EncryptPass(string password)
        {
            Hashing hashing = new Hashing();
            //Creating random salt
            string salt = hashing.GenerateSalt();
            //Hashing the password with the salt
            return salt + hashing.HashPassword(password, salt); 
        }

        public List<User> List
        {
            get
            {
                var users = new List<User>();
                using (var context = new EShopEntities())
                {
                    users = context.Users.ToList();
                }
                return users;
            }
        }

        public User Find(string id)
        {
            User user;
            using (var context = new EShopEntities())
            {
                //Searching for user with same id
                user = context.Users.FirstOrDefault(u => u.Id == id);
            }
            //Do not return password
            user.Password = string.Empty;
            return user;
        }

        //public User FindByUserName(string username)
        //{
        //    User user;
        //    using (var context = new EShopEntities())
        //    {
        //        //Searching for user with same username
        //        user = context.Users.FirstOrDefault(u => u.Id == username);
        //    }
        //    return user;
        //}

        public bool Login(string username, string password)
        {
            User user;
            using (var context = new EShopEntities())
            {
                //Searching for user with same username
                user = context.Users.FirstOrDefault(u => u.Id == username);
            }
            //Username not found case
            if (user == null) return false;
            //Retrieving the salt from the string
            string salt = user.Password.Substring(0, 16);
            //Retrieving the pass from the string
            string dbPass = user.Password.Substring(16);
            Hashing hashing = new Hashing();
            //Comparing user hashed password with the database password
            return hashing.HashPassword(password, salt) == dbPass;
        }

        public void Update(User newUser)
        {
            //Replacing the plain password with the encrypted
            newUser.Password = EncryptPass(newUser.Password);
            using (var context = new EShopEntities())
            {
                var user = context.Users.First(u => u.Id == newUser.Id);
                //Update row
                context.Entry(user).CurrentValues.SetValues(newUser);
                context.SaveChanges();
            }

        }

        public bool TryRegister(User user)
        {
            //Replacing the plain password with the encrypted
            user.Password = EncryptPass(user.Password);
            using (var context = new EShopEntities())
            {
                var isExist = context.Users.Any(u => u.Id == user.Id);
                if (isExist) return false;
                context.Users.Add(user);
                context.SaveChanges();
            }

            return true;
        }
    }
}
