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
        Color REDSTATUSCOLOR = Color.Red;
        Color GREENSTATUSCOLOR = Color.Green;

        User currentUser;

        private void setAdminDataInUI()
        {
            //updates the statisctics
            setPercentageOfWhoGotFullyVaccinated();
            setPercentageOfUnvaccinated();
            setPercentageOfWhoAppliedForVaccination();
            setPercentageOfWhoGotAtleastOneDosebar();

            //update the hello label
            label3.Text = "Hello, Admin";
            
            //updates the table for admin every time they login
            usersGridViewForAdmin.DataSource = Data.users;
           
           
        }

        private void setUserDataInUI()
        {
            User user = Data.currentUser;
            //update the hello label
            label15.Text = $"Hello, {user.name}";

            //updates the status page 
            firstDoseStatusLabel.Text = user.firstDose ? "Taken": "Not taken";
            firstDoseStatusLabel.ForeColor = user.firstDose ? GREENSTATUSCOLOR : REDSTATUSCOLOR;
            secondDoseStatusLabel.Text = user.secondDose ? "Taken" : "Not taken";
            secondDoseStatusLabel.ForeColor = user.secondDose ? GREENSTATUSCOLOR : REDSTATUSCOLOR;

        }

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

        }

        private void loginBtn1_Click(object sender, EventArgs e)
        {
            if(pass_login.Text==Data.adminPassword)
            {
                setAdminDataInUI();
                adminPanel.BringToFront();
                return;
            }
            if (natID_login.Text == "" || pass_login.Text == "")
            {
                MessageBox.Show("please fill all the fields.");
                return;

            }
           
            bool founduser = false;
            foreach (User user in Data.users)
            {
                if ( Convert.ToInt64(natID_login.Text) == user.nationalID && pass_login.Text.Equals(user.password))
                {
                    Data.currentUser = user;
                    setUserDataInUI();
                    userPanel.BringToFront();
                    label15.Text = $"Hello, {user.name}";
                    founduser = true;
                    //w b3deen yroo7 3l panel elly ba3daha ayan kanet ba2a
                }
            }
            if (!founduser)
            {
                MessageBox.Show("invalid national ID or password. try again.");
            }

        }

       

        

        private void usersGridViewForAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usersGridViewForAdmin.Columns[e.ColumnIndex].Name == "Delete")
            {
                string username = usersGridViewForAdmin.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete user: {username} ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    userBindingSource.RemoveCurrent();
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool v = false;
            if (radio_v.Checked)
            {
                v = true;
            }
            User newUser = new User(name_txt.Text, password_txt.Text, Convert.ToInt64(ID_txt.Text), gov_txt.Text, Convert.ToChar(gender_txt.Text), Convert.ToInt32(age_txt.Text), v);
            if (v)
            {
                if (radio_1d.Checked)
                {
                    newUser.vaccination(1);
                }
                else if (radio_2d.Checked)
                {
                    newUser.vaccination(2);
                }
            }
            else
            {
                newUser.vaccination(0);
            }
            Data.users.Add(newUser);
        }

        private void radio_v_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radio_v_CheckedChanged_1(object sender, EventArgs e)
        {
            radio_1d.Enabled = true;
            radio_2d.Enabled = true;
        }

        

        private void delete_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {
            signUpPanel.BringToFront();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

       

        


        private void edit_btn_Click(object sender, EventArgs e)
        {
            if (Data.currentUser.password.Equals(oldPass_txt.Text))
            {
                Data.currentUser.password = newpass_txt.Text;
                Data.currentUser.governorate = newGov_txt.Text;
                MessageBox.Show("User edited.");

            }
            else
            {

                MessageBox.Show("old password doesn't match.");
            }
        }

       

        private void deleteUser_btn_Click(object sender, EventArgs e)
        {
            if (Data.currentUser.password.Equals(deleteUser_txt.Text))
            {

                User.deleteUser(Data.currentUser.nationalID);
                MessageBox.Show("User deleted.");
                mainPanel.BringToFront();
            }
            else
            {
                MessageBox.Show("invalid password.");
            };
        }

        private void deleteAllUsersButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to all users?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                userBindingSource.Clear();
                User.deleteAllUsers();
            }
        }
    }
}
