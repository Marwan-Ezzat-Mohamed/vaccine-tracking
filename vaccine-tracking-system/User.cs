using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    class User
    {
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string governorate { get; set; } = "";
        public long nationalID { get; set; } = 0;
        public char gender { get; set; } = 'N';

		/// lazem date of birth 3ashan el age beyt8ayar 😐
        public int age { get; set; } = 0;
        public bool isVaccinated { get; set; } = false;
        public bool firstDose { get; set; } = false;
		public bool secondDose { get; set; } = false;
		public bool waitingList { get; set; } = false;
		public string date { get; set; } = "";
		public DateTime  nextDate { get; set; } =new DateTime(1111,11,11);


		public User(string n, string pass, long id, string gov, char gen, int a, bool isVac)
		{
			name = n;
			password = pass;
			nationalID = id;
			governorate = gov;
			gender = gen;

			age = a;
			isVaccinated = isVac;

			if(isVac)
			{
				date = "";
				nextDate = DateTime.Today;
			}
            else
            {
				date = "Waiting List";
				nextDate =new DateTime(1111,11,11);
				//nextDate =new DateTime(1515, 15, 15);
            }
		}
		
		
		//users can only edit/update their name, password, age, gender and governorate.
		public void edit(User newUser)
		{
			for(int i=0; i<Data.users.Count; i++)
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
			foreach (User x in Data.users)
			{
                if (x.nationalID == id) 
				{
					Data.users.Remove(x);
					break;
				}
			
			}
		}

		public static void deleteAllUsers()
		{
			foreach (User x in Data.users)
			{
			   Data.users.Remove(x);
			}
		}

		//m7tageen ne3raf mn el user fel ui wa5ed kam dose 3shan ne3raf nsha8al elfunction

		/*public void vaccination()
		{
			if (isVaccinated)
			{

				//yakhod el data mn el form
				int ans = 0;


				if (ans == 1)
				{
					firstDose = true;
					secondDose = false;
					waitingList = false;
				}
				else if (ans == 2)
				{
					firstDose = true;
					secondDose = true;
					waitingList = false;
				}
				else
				{

				}
			}
			else
			{
				isVaccinated = false;
				firstDose = false;
				secondDose = false;
				waitingList = true;
			}
		}*/

	}
}
