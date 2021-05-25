using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vaccine_tracking_system
{
    public partial class MainForm : Form
    {
        void setPercentageOfWhoAppliedForVaccination()
        {
            double numberOfWhoAppliedForVaccination = 0;
            foreach (User user in Data.users)
            {
                if (user.waitingList || user.isVaccinated)
                {
                    numberOfWhoAppliedForVaccination++;
                }
            }

            //percentageOfWhoAppliedBar..Value = (numberOfUnvaccinate / users.size()) * 100;

        }



        void setPercentageOfUnvaccinated()
        {
            double numberOfUnvaccinate = 0;

            foreach (User user in Data.users)
            {
                if (!user.isVaccinated)
                {
                    numberOfUnvaccinate++;
                }
            }
            //percentageOfUnvaccinatedBar->Value = (numberOfUnvaccinate / users.size()) * 100;

        }

        void setPercentageOfWhoGotAtleastOneDosebar()
        {
            double numberOfOneDose = 0;
            foreach (User user in Data.users)
            {
                if (user.firstDose)
                {
                    numberOfOneDose++;
                }
            }
            //percentageOfWhoGotAtleastOneDosebar->Value = (numberOfOneDose / users.size()) * 100;

        }



        void setPercentageOfWhoGotFullyVaccinated()
        {
            double numberOfOneDose = 0;
            foreach (User user in Data.users)
            {
                if (user.secondDose || user.isVaccinated)
                {
                    numberOfOneDose++;
                }
            }
            //percentageOfWhoGotFullyVaccinatedBar->Value = (numberOfOneDose / users.size()) * 100;

        }


        public MainForm()
        {
            InitializeComponent();
        }
    }
}
