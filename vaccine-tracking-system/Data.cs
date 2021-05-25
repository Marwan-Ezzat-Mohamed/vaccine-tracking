using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    class Data
    {

        public static List<Admin> adimns = new List<Admin>();
        public static Admin currentAdmin;
        //public static List<User> users = new List<User>();
        //public static User currentUser;
        public static void setIntialData()
        {
            // users = new List<User>(){
            //    new User("marwan", "1234", 123123, "egypt", "cairo", 'M', 19, true),
            //    new User("joe", "1234", 123, "egypt", "giza", 'M', 19, false),
            //    new User("mina", "1234", 123123123, "egypt", "giza", 'M', 19, false),
            //    new User("khadiga", "1234", 123123123123, "egypt", "giza", 'f', 19, true),
            //    new User("noran", "1234", 1231123123, "egypt", "giza", 'f', 19, true)
            //};

            adimns = new List<Admin>(){
                new Admin("1234", 1234)
                
            };

        }
    }
}
