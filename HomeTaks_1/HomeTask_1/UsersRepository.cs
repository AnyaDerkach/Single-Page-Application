using HomeTask_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomeTask_1
{
    public class UsersRepository
    {
        public static UserDBContext context;
        private static UsersRepository repo = new UsersRepository();


        public static UsersRepository Current
        {
            get
            {
                return repo;
            }
        }

        public UsersRepository()
        {
            context = new UserDBContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        public  List<User> GetAll()
        {
            return context.Users.ToList();
        }


        public int GetSize()
        {
            return context.Users.Count();
        }

        public User Get(int id)
        {
            return context.Users.Where(r => r.Id == id).FirstOrDefault();
        }

        public User Add(User item)
        {
            item.Id = context.Users.Count<User>()+1;
            context.Users.Add(item);
            context.SaveChanges();
            return item;
        }

  
        public void Remove(int id)
        {
            User item = Get(id);
            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
               @ System.Diagnostics.Debug.WriteLine(id);
        }

        public bool Update(User item)
        {
            User storedItem = Get(item.Id);
            if (storedItem != null)
            {
                storedItem.UserName = item.UserName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
