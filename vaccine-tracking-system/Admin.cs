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

        public void deleteRecord(long id)
        {
            foreach (Admin admin in Data.adimns)
            {
                if (admin.nationalID == id)
                {
                    Data.adimns.Remove(admin);
                    break;
                }

            }
        }

        public void deleteAllRecords()
        {
            Data.adimns.Clear();
        }
    }
}
