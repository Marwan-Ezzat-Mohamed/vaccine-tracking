using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    public class User
    {
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string governorate { get; set; } = "";
        public long nationalID { get; set; } = 0;
        public char gender { get; set; } = 'N';

        public Nullable<DateTime> dateOfBirth { get; set; } = null;
        public int age { get; set; } = 0;
        public bool isActivated { get; set; } = true;
        public bool firstDose { get; set; } = false;
        public bool secondDose { get; set; } = false;
        public bool waitingList { get; set; } = false;

        public Nullable<DateTime> nextDoseDate { get; set; } = null;


        public User(string n, string pass, long id, string gov, char gen, DateTime dob)
        {
            name = n;
            password = pass;
            nationalID = id;
            governorate = gov;
            gender = gen;

            dateOfBirth = dob;
            age = int.Parse((DateTime.Now - dob).Days.ToString()) / 365;
            isActivated = true;


        }

        public User()
        {
        }


        //users can only edit/update their name, password, age, gender and governorate.
        public void edit(User newUser)
        {
            for (int i = 0; i < Data.users.Count; i++)
            {
                if (newUser.nationalID == Data.users[i].nationalID)
                {
                    Data.users[i] = newUser;
                    break;
                }

            }

        }

        public static void deleteUser(long id)
        {
            Data.users.Remove(id);
        }

        public static void deleteAllUsers()
        {
            Data.users.Clear();
        }

        //m7tageen ne3raf mn el user fel ui wa5ed kam dose 3shan ne3raf nsha8al elfunction

        public void vaccination(int ans, Nullable<DateTime> pickedDate)
        {
            if (isActivated)
            {
                nextDoseDate = pickedDate;
                if (ans == 1)
                {
                    firstDose = true;
                    secondDose = false;
                }
                else if (ans == 2)
                {
                    firstDose = true;
                    secondDose = true;
                }
                else
                {
                    firstDose = false;
                    secondDose = false;
                }
            }
            else
            {
                isActivated = false;
                firstDose = false;
                secondDose = false;

            }
        }

    }
}
