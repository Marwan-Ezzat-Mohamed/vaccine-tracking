using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccine_tracking_system
{
    class User
    {
		public string name;
		public string password;
		public string governorate;
		public long nationalID;
		public char gender;
		public int age;
		public bool isVaccinated;
		public bool firstDose;
		public bool secondDose;
		public bool waitingList;

		public User(string n, string pass, long id, string gov, char gen, int a, bool isVac)
		{
			name = n;
			password = pass;
			nationalID = id;
			governorate = gov;
			gender = gen;
			age = a;
			isVaccinated = isVac;

		}
		
		public void display(){}
		
		public void edit(long id){}

		public void deleteUser(long id)
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
