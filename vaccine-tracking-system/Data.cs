using System;
using System.Collections.Generic;

namespace vaccine_tracking_system
{
    class Data
    {

        public static List<Admin> admins = new List<Admin>();
        public static string adminPassword = "admin";

        public static Admin currentAdmin;


        public static SortedDictionary<long, User> users = new SortedDictionary<long, User>();

       



        public static User currentUser;
        public static void setIntialData()
        {
            DateTime bDate = new DateTime(2008, 3, 15);
            users.Add(123, new User("joe", "1234", 123, "giza", 'M', bDate, true));
            users.Add(1, new User("marwan", "1", 1, "cairo", 'M', bDate, true));
            users.Add(123123123, new User("mina", "1234", 123123123, "giza", 'M', bDate, false));
            users.Add(123123123123, new User("khadiga", "1234", 123123123123, "giza", 'f', bDate, true));
            users.Add(1231123123, new User("noran", "1234", 1231123123, "giza", 'f', bDate, true));

            
        }
    }
}
