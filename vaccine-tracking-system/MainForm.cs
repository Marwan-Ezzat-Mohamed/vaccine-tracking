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
            setDaysLeft(user);
            //update the hello label
            label15.Text = $"Hello, {user.name}";

            //updates the status page 
            firstDoseStatusLabel.Text = user.firstDose ? "Taken" : "Not taken";
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



            numberDosesComboBox.Items.Add("Zero Doses");
            numberDosesComboBox.Items.Add("One Dose");
            numberDosesComboBox.Items.Add("Two Doses");


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
            if (pass_login.Text == Data.adminPassword)
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
                if (Convert.ToInt64(natID_login.Text) == user.nationalID && pass_login.Text.Equals(user.password))
                {
                    Data.currentUser = user;
                    setUserDataInUI();
                    userPanel.BringToFront();
                    label15.Text = $"Hello, {user.name}";
                    founduser = true;

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

            //input validation 
            if (!int.TryParse(age_txt.Text,out _))
            {
                MessageBox.Show("age must be a number");
                return;
            }

            if (int.TryParse(name_txt.Text, out _))
            {
                MessageBox.Show("name must have no numbers in it");
                return;
            }

            if (int.TryParse(gov_txt.Text, out _))
            {
                MessageBox.Show("governorate must have no numbers in it");
                return;
            }

            if (numberDosesComboBox.Text == "")
            {
                MessageBox.Show("Please choose a vaccination status.", "VACC ERROR!");
                return;
            }

            if (ID_txt.TextLength != 13)
            {
                MessageBox.Show("National ID should be 13 numbers.", "ERROR!");
                return;
            }

            if (password_txt.TextLength < 8)
            {
                MessageBox.Show("Password must be 8 or more characters.", "WEAK PASSWORD!");
                return;
            }

            if (!(gender_txt.Text.Equals("M") || gender_txt.Text.Equals("m") || gender_txt.Text.Equals("f") || gender_txt.Text.Equals("F")))
            {
                MessageBox.Show("please enter 'F'/'f' for female or 'M'/m' for male.", "INVALID INPUT!");
                return;
            }
            


            bool isVaccinated = true;
            User newUser= new User();
            if (numberDosesComboBox.SelectedIndex == 0) isVaccinated = false;
            //checks for empty fields
            try
            {
             newUser = new User(name_txt.Text, password_txt.Text, Convert.ToInt64(ID_txt.Text), gov_txt.Text, Convert.ToChar(gender_txt.Text), Convert.ToInt32(age_txt.Text), isVaccinated);

            }
            catch(Exception)
            {
                MessageBox.Show("please fill all fields");
                return;
            }

            //set the number of doses for the user
            if (numberDosesComboBox.SelectedIndex == 0)
            {
                newUser.vaccination(0, dateTimePicker1.Value);
            }
            else if (numberDosesComboBox.SelectedIndex == 1)
            {
                newUser.vaccination(1, dateTimePicker1.Value.AddDays(30));
            }
            else if (numberDosesComboBox.SelectedIndex == 2)
            {
                newUser.vaccination(2, null);
            }
            setDaysLeft(newUser);

            Data.users.Add(newUser);

        }

        private void setDaysLeft(User user)
        {
            int daysLeft = Math.Max(1, (user.nextDoseDate.Value - DateTime.Now).Days);
            Console.WriteLine(user.nextDoseDate.Value);
            numberOfDaysLeft.Text = Math.Max(1, daysLeft).ToString();
            progressBar1.Value = 30 - daysLeft;
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
            if (newpass_txt.TextLength >= 8)
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

            else
                MessageBox.Show("Password must be 8 or more characters.", "WEAK PASSWORD!");
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





        private void numberDosesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dateTimePicker1 = new DateTimePicker();
            if (numberDosesComboBox.SelectedIndex == 2)
            {

                dateTimePicker1.Enabled = false;
            }
            else if (numberDosesComboBox.SelectedIndex == 0)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker1.MaxDate = DateTime.Now.AddDays(30);
                dateTimePicker1.MinDate = DateTime.Now;
            }
            else if (numberDosesComboBox.SelectedIndex == 1)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker1.MinDate = DateTime.Now.AddDays(-30);
                dateTimePicker1.MaxDate = DateTime.Now;
                Console.WriteLine(DateTime.Now);
            }
        }
    }
}
