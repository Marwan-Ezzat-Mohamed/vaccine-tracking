using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace vaccine_tracking_system
{
    public partial class MainForm : Form
    {
        Color REDSTATUSCOLOR = Color.Red;
        Color GREENSTATUSCOLOR = Color.Green;
        const long EGYPTPOPULATION = 100;
        const int MINAGETOTAKEDOSE = 18;
        const int DAYSBEFORENEXTDOSE = 30;



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        //for rounded form corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );


        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void setAdminDataInUI()
        {
            //updates the statisctics

            loadCharts();
            setPercentageOfWhoGotFullyVaccinated();
            setPercentageOfUnvaccinated();
            setPercentageOfWhoAppliedForVaccination();
            setPercentageOfWhoGotAtleastOneDosebar();


            //update the hello label
            label3.Text = "Hello, Admin";

            //updates the table for admin every time they login
            usersGridViewForAdmin.DataSource = Data.users.Select(item => item.Value).ToList();


        }

        private void setUserDataInUI()
        {
            User user = Data.currentUser;
            if (user.nextDoseDate <= DateTime.Now)
            {
                if (!user.firstDose)
                {
                    user.waitingList = false;
                    user.firstDose = true;
                    user.nextDoseDate = DateTime.Now.AddDays(DAYSBEFORENEXTDOSE);
                }
                else
                {
                    user.waitingList = false;
                    user.firstDose = true;
                    user.secondDose = true;
                    user.isActivated = true;
                    user.nextDoseDate = null;
                }
            }

            setDaysLeft(user);
            //update the hello label
            label15.Text = $"Hello, {user.name}";

            //updates the status page 
            firstDoseStatusLabel.Text = user.firstDose ? "Taken" : "Not taken";
            firstDoseStatusLabel.ForeColor = user.firstDose ? GREENSTATUSCOLOR : REDSTATUSCOLOR;
            secondDoseStatusLabel.Text = user.secondDose ? "Taken" : "Not taken";
            secondDoseStatusLabel.ForeColor = user.secondDose ? GREENSTATUSCOLOR : REDSTATUSCOLOR;

        }


        public void loadCharts()
        {
            //18-30
            //30-70
            //70 and up
            int limit30 = 0, limit70 = 0, limit70up = 0,
                males = 0, females = 0;


            foreach (KeyValuePair<long, User> entry in Data.users)
            {
                if (entry.Value.age <= 30)
                {
                    limit30++;
                }
                else if (entry.Value.age > 30 && entry.Value.age <= 70)
                {
                    limit70++;
                }
                else if (entry.Value.age > 70)
                {
                    limit70up++;
                }


                if (entry.Value.gender == 'm')
                {
                    males++;
                }
                else
                {
                    females++;
                }

            }

            ageChart.Series["Age Groups"].Points.AddXY("18 to 30", limit30);
            ageChart.Series["Age Groups"].Points.AddXY("30 to 70", limit70);
            ageChart.Series["Age Groups"].Points.AddXY("70 and up", limit70up);
            genderChart.Series["Gender Groups"].Points.AddXY("Males", males);
            genderChart.Series["Gender Groups"].Points.AddXY("Females", females);
        }
        void setPercentageOfUnvaccinated()
        {
            double numberOfUnvaccinate = 0;

            foreach (KeyValuePair<long, User> entry in Data.users)
            {
                if (!entry.Value.secondDose)
                {
                    numberOfUnvaccinate++;
                }
            }
            percentageOfUnvaccinatedBar.Value = (int)((numberOfUnvaccinate / Data.users.Count) * 100);
            NonvaccinatedLbl.Text = ((int)((numberOfUnvaccinate / Data.users.Count) * 100)).ToString() + "%";
        }
        void setPercentageOfWhoGotAtleastOneDosebar()
        {
            double numberOfOneDose = 0;
            foreach (KeyValuePair<long, User> entry in Data.users)
            {
                if (entry.Value.firstDose)
                {
                    numberOfOneDose++;
                }
            }
            percentageOfWhoGotAtleastOneDosebar.Value = (int)((numberOfOneDose / Data.users.Count) * 100);
            OneDoseReceiversLbl.Text = ((int)((numberOfOneDose / Data.users.Count) * 100)).ToString() + "%";
        }
        void setPercentageOfWhoGotFullyVaccinated()
        {
            double numberOfVaccinate = 0;
            foreach (KeyValuePair<long, User> entry in Data.users)
            {
                if (entry.Value.secondDose)
                {
                    numberOfVaccinate++;
                }
            }
            percentageOfWhoGotFullyVaccinatedBar.Value = (int)((numberOfVaccinate / Data.users.Count) * 100);
            FullyVaccinatedLbl.Text = ((int)((numberOfVaccinate / Data.users.Count) * 100)).ToString() + "%";
        }
        void setPercentageOfWhoAppliedForVaccination()
        {

            percentageOfWhoAppliedBar.Value = (int)(((Data.users.Count * 100) / (EGYPTPOPULATION)));
            AppliedLbl.Text = ((int)(((Data.users.Count * 100) / (EGYPTPOPULATION)))).ToString() + "%";
        }

        void setGovernoratesInCombobox()
        {
            comboBox1.Items.Add("Alexandria");
            comboBox1.Items.Add("Assiut");
            comboBox1.Items.Add("Aswan");
            comboBox1.Items.Add("Beheira");
            comboBox1.Items.Add("Bani Suef");
            comboBox1.Items.Add("Cairo");
            comboBox1.Items.Add("Daqahliya");
            comboBox1.Items.Add("Damietta");
            comboBox1.Items.Add("Fayyoum");
            comboBox1.Items.Add("Gharbiya");
            comboBox1.Items.Add("Giza");
            comboBox1.Items.Add("Helwan");
            comboBox1.Items.Add("Ismailia");
            comboBox1.Items.Add("Kafr El Sheikh");
            comboBox1.Items.Add("Luxor");
            comboBox1.Items.Add("Marsa Matrouh");
            comboBox1.Items.Add("Minya");
            comboBox1.Items.Add("Monofiya");
            comboBox1.Items.Add("New Valley");
            comboBox1.Items.Add("North Sinai");
            comboBox1.Items.Add("Port Said");
            comboBox1.Items.Add("Qalioubiya");
            comboBox1.Items.Add("Qena");
            comboBox1.Items.Add("Red Sea");
            comboBox1.Items.Add("Sharqiya");
            comboBox1.Items.Add("Sohag");
            comboBox1.Items.Add("South Sinai");
            comboBox1.Items.Add("Suez");
            comboBox1.Items.Add("Tanta");


            comboBox2.Items.Add("Alexandria");
            comboBox2.Items.Add("Assiut");
            comboBox2.Items.Add("Aswan");
            comboBox2.Items.Add("Beheira");
            comboBox2.Items.Add("Bani Suef");
            comboBox2.Items.Add("Cairo");
            comboBox2.Items.Add("Daqahliya");
            comboBox2.Items.Add("Damietta");
            comboBox2.Items.Add("Fayyoum");
            comboBox2.Items.Add("Gharbiya");
            comboBox2.Items.Add("Giza");
            comboBox2.Items.Add("Helwan");
            comboBox2.Items.Add("Ismailia");
            comboBox2.Items.Add("Kafr El Sheikh");
            comboBox2.Items.Add("Luxor");
            comboBox2.Items.Add("Marsa Matrouh");
            comboBox2.Items.Add("Minya");
            comboBox2.Items.Add("Monofiya");
            comboBox2.Items.Add("New Valley");
            comboBox2.Items.Add("North Sinai");
            comboBox2.Items.Add("Port Said");
            comboBox2.Items.Add("Qalioubiya");
            comboBox2.Items.Add("Qena");
            comboBox2.Items.Add("Red Sea");
            comboBox2.Items.Add("Sharqiya");
            comboBox2.Items.Add("Sohag");
            comboBox2.Items.Add("South Sinai");
            comboBox2.Items.Add("Suez");
            comboBox2.Items.Add("Tanta");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            setGovernoratesInCombobox();
            numberDosesComboBox.Items.Add("Zero Doses");
            numberDosesComboBox.Items.Add("One Dose");
            numberDosesComboBox.Items.Add("Two Doses");

            dateTimePicker1.Enabled = false;
            //DOBPicker.MaxDate = DateTime.Now.AddYears(-MINAGETOTAKEDOSE);
            userBindingSource.DataSource = Data.users.Select(item => item.Value).ToList();


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
            updateDataInYourInfo();

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

            long inputId = Convert.ToInt64(natID_login.Text);
            string inputPassword = pass_login.Text;
            try
            {
                User user = Data.users[inputId];
                if (user.password == inputPassword)
                {
                    if (user.isActivated)
                    {
                        Data.currentUser = user;
                        setUserDataInUI();
                        userPanel.BringToFront();
                        label15.Text = $"Hello, {user.name}";
                    }
                    else
                    {
                        MessageBox.Show("Please sign up to reactivate your account");
                    }
                }
                else throw new Exception();

            }
            catch (Exception)
            {
                MessageBox.Show("invalid national ID or password. try again.");
            }


        }





        private void usersGridViewForAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usersGridViewForAdmin.Columns[e.ColumnIndex].Name == "Delete")
            {
                string username = usersGridViewForAdmin.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show($"Are you sure you want to delete user: {username} ?", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    userBindingSource.RemoveCurrent();
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            //input validation 


            if (int.TryParse(name_txt.Text, out _))
            {
                MessageBox.Show("name must have no numbers in it");
                return;
            }

            if (comboBox1.SelectedItem != null && int.TryParse(comboBox1.SelectedItem.ToString(), out _))
            {
                MessageBox.Show("governorate must have no numbers in it");
                return;
            }

            if (numberDosesComboBox.Text == "")
            {
                MessageBox.Show("Please choose a vaccination status.", "VACC ERROR!");
                return;
            }

            if (ID_txt.TextLength != 1)
            {
                MessageBox.Show("National ID should be 13 numbers.", "ERROR!");
                return;
            }

            if (password_txt.TextLength < 1)
            {
                MessageBox.Show("Password must be 8 or more characters.", "WEAK PASSWORD!");
                return;
            }
            if (!RBMale.Checked && !RBFemale.Checked)
            {
                MessageBox.Show("You must select a gender", "ERROR!");
                return;
            }
            if (DOBPicker.Value.ToString() == "")
            {
                MessageBox.Show("You must select a date of birth", "ERROR!");
                return;
            }


            User newUser = new User();

            //checks for empty fields
            try
            {
                Char gender = new char();
                if (RBMale.Checked == true)
                {
                    gender = 'm';
                }
                else if (RBFemale.Checked == true)
                {
                    gender = 'f';
                }


                //DateTime bDate = new DateTime(2008, 3, 15);
                newUser = new User(name_txt.Text, password_txt.Text,
                Convert.ToInt64(ID_txt.Text), comboBox1.SelectedItem.ToString(),
                gender, DOBPicker.Value);



            }
            catch (Exception)
            {
                MessageBox.Show("please fill all fields");
                return;
            }

            //set the number of doses for the user
            if (numberDosesComboBox.SelectedIndex == 0)
            {
                newUser.waitingList = true;
                newUser.vaccination(0, null);
            }
            else if (numberDosesComboBox.SelectedIndex == 1)
            {
                newUser.vaccination(1, dateTimePicker1.Value.AddDays(DAYSBEFORENEXTDOSE));
            }
            else if (numberDosesComboBox.SelectedIndex == 2)
            {
                newUser.vaccination(2, null);
            }
            setDaysLeft(newUser);
            bool isActivated;
            try
            {
                isActivated = Data.users[newUser.nationalID].isActivated;
            }
            catch
            {
                Data.users.Add(newUser.nationalID, newUser);
                MessageBox.Show("Signed up successfully!");
                return;
            }

            if (!isActivated)
            {
                MessageBox.Show("Account reactivated successfully!");

                Data.users[newUser.nationalID].name = newUser.name;
                Data.users[newUser.nationalID].governorate = newUser.governorate;
                Data.users[newUser.nationalID].dateOfBirth = newUser.dateOfBirth;
                Data.users[newUser.nationalID].gender = newUser.gender;
                Data.users[newUser.nationalID].password = newUser.password;
                Data.users[newUser.nationalID].isActivated = true;
                panel2.BringToFront();

            }
            else
            {
                MessageBox.Show("Account already exists!");
                return;
            }

        }

        private void setDaysLeft(User user)
        {
            if (user.waitingList)
            {
                label11.Text = "";
                numberOfDaysLeft.Text = "You are in the waiting list";
                progressBar1.Hide();
                return;
            }


            if (user.secondDose)
            {
                label11.Text = "";
                numberOfDaysLeft.Text = "You are Vaccinated!";
                progressBar1.Hide();
                return;
            }
            progressBar1.Show();
            string dose = !user.firstDose ? "first" : "second";
            label11.Text = $"Days left untill the {dose } shot";

            int daysLeft = Math.Max(1, (user.nextDoseDate.Value - DateTime.Now).Days);
            Console.WriteLine(user.nextDoseDate.Value);
            ///-------------------still needs fixing---------------------//
            ///progressBar1.Maximum=
            numberOfDaysLeft.Text = Math.Max(1, daysLeft).ToString();
            progressBar1.Maximum = DAYSBEFORENEXTDOSE;
            progressBar1.Value = Math.Abs(DAYSBEFORENEXTDOSE - daysLeft);

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
                Data.currentUser.name = NameTB.Text;
                Data.currentUser.password = newpass_txt.Text;

                Data.currentUser.governorate = comboBox2.SelectedItem.ToString();


                if (MaleRB.Checked)
                {
                    Data.currentUser.gender = 'm';
                }
                else if (FemaleRB.Checked)
                {
                    Data.currentUser.gender = 'f';
                }

                Data.currentUser.dateOfBirth = DOBPicker.Value;

                MessageBox.Show("Updated Successfully!");



            }
            else
                MessageBox.Show("Password must be at least 8 characters.", "WEAK PASSWORD!");
        }


        public void updateDataInYourInfo()
        {
            NameTB.Text = Data.currentUser.name;
            newpass_txt.Text = Data.currentUser.password;
            nationalIDTB.Text = Data.currentUser.nationalID.ToString();
            comboBox2.Text = Data.currentUser.governorate;


            if (Data.currentUser.gender == 'm')
            {
                MaleRB.Checked = true;
            }
            else
            {
                FemaleRB.Checked = true;
            }

            DOBPicker.Value = Data.currentUser.dateOfBirth.Value;


            if (Data.currentUser.secondDose)
            {
                NoDTxt.Text = "Two doses";
            }
            else if (Data.currentUser.firstDose)
            {
                NoDTxt.Text = "One dose";
            }
            else
            {
                NoDTxt.Text = "None";
            }
            if (Data.currentUser.nextDoseDate != null)
            {
                DoDTxt.Text = Data.currentUser.nextDoseDate.Value.ToString();
            }


        }
        /* public void updateListInRecords()
         {
             string columns = "{0, -30}\t{1, -20}\t{2, -40}\t{3, -5}\t{4, -5}\t{5, -30}\t{6, -30}";
             foreach (KeyValuePair<long, User> entry in Data.users)
             {

                     recordsList.Items.Add(string.Format(columns,
                     entry.Value.name,
                     entry.Value.governorate,
                     entry.Value.nationalID,
                     entry.Value.gender,
                     entry.Value.age,
                     entry.Value.firstDose,
                     entry.Value.secondDose));


             }
         }*/


        private void deleteUser_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your record?",
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Data.currentUser.isActivated = false;
                //User.deleteUser(Data.currentUser.nationalID);
                MessageBox.Show("deleted successfully!");

                mainPanel.BringToFront();
            }
        }

        private void deleteAllUsersButton_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to delete selected user(s)?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < usersGridViewForAdmin.SelectedRows.Count; i++)
                {

                    long id = long.Parse(usersGridViewForAdmin.SelectedRows[i].Cells[2].Value.ToString());
                    User.deleteUser(id);

                }
                usersGridViewForAdmin.DataSource = Data.users.Select(item => item.Value).ToList();
                usersGridViewForAdmin.Update();
                usersGridViewForAdmin.Refresh();
            }
        }





        private void numberDosesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (numberDosesComboBox.SelectedIndex == 2)
            {

                dateTimePicker1.Enabled = false;
            }
            else if (numberDosesComboBox.SelectedIndex == 0)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker1.MaxDate = DateTime.Now.AddDays(DAYSBEFORENEXTDOSE);
                dateTimePicker1.MinDate = DateTime.Now;
            }
            else if (numberDosesComboBox.SelectedIndex == 1)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker1.MinDate = DateTime.Now.AddDays(-DAYSBEFORENEXTDOSE);
                dateTimePicker1.MaxDate = DateTime.Now;
                Console.WriteLine(DateTime.Now);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            //get the id from the selected row in the table from cell number 3
            int id = int.Parse(usersGridViewForAdmin.SelectedRows[0].Cells[2].Value.ToString());

            //set the user's next Dose date to the selected date by the admin
            Data.users[id].nextDoseDate = dateTimePicker2.Value;
            //remove user from waiting list
            Data.users[id].waitingList = false;
            //update the table with the new date;
            usersGridViewForAdmin.Update();
            usersGridViewForAdmin.Refresh();
        }

        /* private void deleteAll_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Are you sure you want to delete all users?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 Data.users.Clear();
                 usersGridViewForAdmin.DataSource = new List<User>();
                 usersGridViewForAdmin.Update();
                 usersGridViewForAdmin.Refresh();
             }
         }*/



        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usersGridViewForAdmin_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
