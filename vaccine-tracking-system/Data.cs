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
            users = new List<User>(){
                new User("marwan", "1", 1,  "cairo", 'M', 19, true),
                new User("joe", "1234", 123,  "giza", 'M', 19, false),
                new User("mina", "1234", 123123123, "giza", 'M', 19, false),
                new User("khadiga", "1234", 123123123123,  "giza", 'f', 19, true),
                new User("noran", "1234", 1231123123,  "giza", 'f', 19, true)
            };
            users[0].firstDose = true;
            users[0].nextDoseDate = DateTime.Now.AddDays(10);

        }
    }
}
