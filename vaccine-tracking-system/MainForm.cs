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
        //const string REDSTATUSCOLOR;
        //const string GREENSTATUSCOLOR;

        User currentUser;
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

            percentageOfWhoAppliedBar.Value = (int)((numberOfWhoAppliedForVaccination / (Data.users.Count)) * 100);

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
            percentageOfUnvaccinatedBar.Value = (int)((numberOfUnvaccinate / Data.users.Count) * 100);

        }

        void setPercentageOfWhoGotAtleastOneDosebar()
        {
            double numberOfOneDose = 0;
            foreach (User user in Data.users)
            {
                if (user.firstDose || user.secondDose || user.isVaccinated)
                {
                    numberOfOneDose++;
                }
            }
            percentageOfWhoGotAtleastOneDosebar.Value = (int)((numberOfOneDose / Data.users.Count) * 100);

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
            percentageOfWhoGotFullyVaccinatedBar.Value = (int)((numberOfOneDose / Data.users.Count) * 100);

        }


       
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setPercentageOfWhoGotFullyVaccinated();
            setPercentageOfUnvaccinated();
            setPercentageOfWhoAppliedForVaccination();
            setPercentageOfWhoGotAtleastOneDosebar();

            
            userBindingSource.DataSource = Data.users;


            recordsBtn.ForeColor = Color.White;
            aboutBtnAdmin.ForeColor = Color.White;
            yourInfoBtn.ForeColor = Color.White;
            aboutUserBtn.ForeColor = Color.White;

            recordsBtn.TextImageRelation = TextImageRelation.TextAboveImage;
            aboutBtnAdmin.TextImageRelation = TextImageRelation.TextAboveImage;
            yourInfoBtn.TextImageRelation = TextImageRelation.TextAboveImage;
            aboutUserBtn.TextImageRelation = TextImageRelation.TextAboveImage;
        }
        // @mina load user info

        void loadUserInfo()
        {
            double s;

            //numberOfDaysLeft.Text = (currentUser.nextDate - DateTime.Today).TotalDays.ToString();
            TimeSpan f = Data.currentUser.nextDate - DateTime.Today;
            Console.WriteLine(f.TotalDays);


        }

        // UI navigation buttons

        //admin
        private void statisticsBtn_Click(object sender, EventArgs e)
        {
            statisticsPanel.BringToFront();

            statisticsBtn.ForeColor = Color.FromArgb(10, 14, 79);
            statisticsBtn.TextImageRelation = TextImageRelation.Overlay;

            recordsBtn.ForeColor = Color.White;
            recordsBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            aboutBtnAdmin.ForeColor = Color.White;
            aboutBtnAdmin.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanel.BringToFront();

            recordsBtn.ForeColor = Color.FromArgb(10, 14, 79);
            recordsBtn.TextImageRelation = TextImageRelation.Overlay;

            statisticsBtn.ForeColor = Color.White;
            statisticsBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            aboutBtnAdmin.ForeColor = Color.White;
            aboutBtnAdmin.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        private void aboutBtnAdmin_Click(object sender, EventArgs e)
        {
            aboutAdminPanel.BringToFront();

            aboutBtnAdmin.ForeColor = Color.FromArgb(10, 14, 79);
            aboutBtnAdmin.TextImageRelation = TextImageRelation.Overlay;

            statisticsBtn.ForeColor = Color.White;
            statisticsBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            recordsBtn.ForeColor = Color.White;
            recordsBtn.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        //user

        private void statusBtn_Click(object sender, EventArgs e)
        {
            statusPanel.BringToFront();

            statusBtn.ForeColor = Color.FromArgb(10, 14, 79);
            statusBtn.TextImageRelation = TextImageRelation.Overlay;

            yourInfoBtn.ForeColor = Color.White;
            yourInfoBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            aboutUserBtn.ForeColor = Color.White;
            aboutUserBtn.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        private void yourInfoBtn_Click(object sender, EventArgs e)
        {
            yourInfoPanel.BringToFront();

            yourInfoBtn.ForeColor = Color.FromArgb(10, 14, 79);
            yourInfoBtn.TextImageRelation = TextImageRelation.Overlay;

            statusBtn.ForeColor = Color.White;
            statusBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            aboutUserBtn.ForeColor = Color.White;
            aboutUserBtn.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        private void aboutUserBtn_Click(object sender, EventArgs e)
        {
            aboutUserPanel.BringToFront();

            aboutUserBtn.ForeColor = Color.FromArgb(10, 14, 79);
            aboutUserBtn.TextImageRelation = TextImageRelation.Overlay;

            statusBtn.ForeColor = Color.White;
            statusBtn.TextImageRelation = TextImageRelation.TextAboveImage;

            yourInfoBtn.ForeColor = Color.White;
            yourInfoBtn.TextImageRelation = TextImageRelation.TextAboveImage;
        }

        //login & out

        private void logout_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            adminPanel.BringToFront();
        }

        private void loginBtn1_Click(object sender, EventArgs e)
        {
            userPanel.BringToFront();

        }
        //


        private void deleteUserBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to delete selected user?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                userBindingSource.RemoveCurrent();
            }
        }

        private void usersGridViewForAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = usersGridViewForAdmin.CurrentRow.Index;
            if (!Data.users[index].isVaccinated)
            {
                Data.users[index].nextDate = dateTimePicker1.Value;
                Data.users[index].date = Data.users[1].nextDate.ToShortDateString();
            }


        }
    }
}
