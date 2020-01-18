namespace PS_Hospital_System_Project_2019
{
    using Newtonsoft.Json.Linq;
    using PS_Hospital_System_Project_2019.SystemClases;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Input;
    using MessageBox = PS_Hospital_System_Project_2019.SystemClases.MessageBox;
    public partial class DoctorRegister : Window

    {
        User User { get; set; }

        public DoctorRegister(User User)
        {
            InitializeComponent();
            this.DataContext = this;
            this.User = User;

        }
        private void POSTDoctorRequest(string BasicAuthentication, JObject Doctor)
        {
            var createdUser = HttpRequest.Of("https://localhost:44348/api/doctors", RequestType.POST)
                  .BasicAuthentication(BasicAuthentication)
                  .BodyData(Doctor)
                  .OnError(MessageBox.ShowMessageBoxError("Wrong Data Input", ""))
                  .Execute()
                  .DeserializeBody<NewCreatedUser>();
            if (createdUser != null)
            {
                MessageBox.ShowMessageBoxInfo("Doctor Registration Info", $"Username:{createdUser.Username}\nPassword:{createdUser.Password}");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private bool ValidateDoctorEGN()
        {
            if (Egn.Text.ToString().Length != 10)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's EGN should be excatly 10 digits!");
                return false;
            }

            else if (!Egn.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's EGN should contains only digts!");
                return false;
            }
            return true;

        }
        private bool ValidateDoctorSpecialization()
        {
            if (Specialization.Text.ToString().Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's Specialization cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateDoctorAddress()
        {
            if (Address.Text.ToString().Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's Address cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateDoctorPhone()
        {
            if (MobilePhone.Text.Length != 10)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Mobile Phone cannot be more or less than 10 digits!");
                return false;
            }
            else if (!MobilePhone.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Mobile Phone can contain only digits!");
                return false;
            }
            return true;
        }
        private bool ValidateDoctorFirstName()
        {
            if (Name.Text.Length == 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The First Name is required field and cannot be empty!");
                return false;
            }
            else if (Name.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The First Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateDoctorMiddleName()
        {
            if (MiddleName.Text.Length == 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name is required field and cannot be empty!");
                return false;
            }
            else if (MiddleName.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageForm MessageForm = new MessageForm("Wrong Data Input", "The Middle Name cannot contain digits!");
                MessageForm.ShowDialog();
                return false;
            }
            return true;
        }
        private bool ValidateDoctorLastName()
        {

            if (FamilyName.Text.Length == 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Last Name is required field and cannot be empty!");
                return false;
            }
            else if (FamilyName.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Last Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private void EGN_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorEGN();
        }

        private void MobilePhone_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorPhone();
        }

        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorFirstName();
        }

        private void SecondName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorMiddleName();
        }

        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorLastName();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateDoctorFirstName())
                return;
            else if (!ValidateDoctorMiddleName())
                return;
            else if (!ValidateDoctorLastName())
                return;
            else if (!ValidateDoctorPhone())
                return;
            else if (!ValidateDoctorEGN())
                return;
            else if (!ValidateDoctorAddress())
                return;
            else if (!ValidateDoctorSpecialization())
                return;
            else
            {
                POSTDoctorRequest(User.AuthenticationCredentials, new JObjectBuilder().With(doctor => doctor.Name = this.Name.Text)
                                                                                        .With(doctor => doctor.MiddleName = this.MiddleName.Text)
                                                                                        .With(doctor => doctor.FamilyName = this.FamilyName.Text)
                                                                                        .With(doctor => doctor.Egn = this.Egn.Text)
                                                                                        .With(doctor => doctor.MobilePhone = this.MobilePhone.Text)
                                                                                        .With(doctor => doctor.Address = this.Address.Text)
                                                                                        .With(doctor => doctor.Specialization = this.Specialization.Text)
                                                                                        .Build());
                this.Close();
            }
        }
    }
}
