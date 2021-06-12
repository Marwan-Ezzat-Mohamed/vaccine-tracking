using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    class Data
    {

        public static List<Admin> admins = new List<Admin>();
        public static string adminPassword = "admin";

        public static Admin currentAdmin;
        public static List<User> users = new List<User>();
        
        public static Dictionary<long,User> allUsers = new Dictionary<long, User>();
        public static User currentUser;
        public static void setIntialData()
        {
            DateTime bDate = new DateTime(2008, 3, 15);
            users = new List<User>(){
                new User("marwan", "1", 1,  "cairo", 'M',bDate , true),
                new User("joe", "1234", 123,  "giza", 'M', bDate, true),
                new User("mina", "1234", 123123123, "giza", 'M',    bDate, false),
                new User("khadiga", "1234", 123123123123,  "giza", 'f', bDate, true),
                new User("noran", "1234", 1231123123,  "giza", 'f', bDate, true)
            };
            users[0].firstDose = true;
            users[0].nextDoseDate = DateTime.Now.AddDays(30);
            users[1].firstDose = true;
        }
    }
}
