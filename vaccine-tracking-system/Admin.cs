using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    class Admin
    {

        public long nationalID;
        public string password;

        public Admin(string pass, long id)
        {
            password = pass;
            nationalID = id;

        }

       

        //public void deleteUserRecord(long id)
        //{
        //    foreach (User user in Data.users)
        //    {
        //        if (user.nationalID == id)
        //        {
        //            Data.users.Remove(user);
        //            break;
        //        }

        //    }
        //}

        //public void deleteAllRecords()
        //{
        //    Data.users.Clear();
        //}
    }
}
