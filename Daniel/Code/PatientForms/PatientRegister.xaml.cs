namespace PS_Hospital_System_Project_2019
{
    using Newtonsoft.Json.Linq;
    using PS_Hospital_System_Project_2019.SystemClases;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Input;
    using MessageBox = PS_Hospital_System_Project_2019.SystemClases.MessageBox;
    public partial class PatientRegister : Window
    {
        public User User { set; get; }

        public PatientRegister(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            this.User = user;
        }
        private void POSTPatientRequest(string BasicAuthentication, JObject Patient)
        {
            var newCreatedUser = HttpRequest.Of("https://localhost:44348/api/patients", RequestType.POST)
                .BasicAuthentication(BasicAuthentication)
                .BodyData(Patient)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<NewCreatedUser>();
            if (newCreatedUser != null)
            {
                MessageBox.ShowMessageBoxInfo("Patient Registration Info", $"Username:{newCreatedUser.Username}\nPassword:{newCreatedUser.Password}");
            }
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
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private bool ValidatePatientEGN()
        {
            if (Egn.Text.ToString().Length != 10)
            {
                MessageBox.ShowMessageBoxError("Wrong Data Input", "The Doctor's EGN should be excatly 10 digits!");
                return false;
            }

            else if (!Egn.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's EGN should contains only digts!");
                return false;
            }
            return true;
        }
        private bool ValidatePatientAge()
        {
            if (Age.Text.Length > 3 || Age.Text.Length < 1)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Age cannot be more that 3 or less than 1 digits!");
                return false;
            }
            else if (!Age.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Age can contain only digits!");
                return false;
            }
            return true;
        }
        private bool ValidatePatientFirstName()
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
        private bool ValidatePatientMiddleName()
        {
            if (MiddleName.Text.Length == 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name is required field and cannot be empty!");
                return false;
            }
            else if (MiddleName.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidatePatientLastName()
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
        private bool ValidatePatientAddress()
        {
            if (Address.Text.ToString().Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's Address cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidatePatientMobilePhone()
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
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidatePatientFirstName())
                return;
            else if (!ValidatePatientMiddleName())
                return;
            else if (!ValidatePatientLastName())
                return;
            else if (!ValidatePatientAge())
                return;
            else if (!ValidatePatientEGN())
                return;
            else if (!ValidatePatientAddress())
                return;
            else if (!ValidatePatientMobilePhone())
                return;
            else
            {
                POSTPatientRequest(User.AuthenticationCredentials, new JObjectBuilder().With(patient => patient.Name = this.Name.Text)
                                                                                        .With(patient => patient.MiddleName = this.MiddleName.Text)
                                                                                        .With(patient => patient.FamilyName = this.FamilyName.Text)
                                                                                        .With(patient => patient.Egn = this.Egn.Text)
                                                                                        .With(patient => patient.Address = this.Address.Text)
                                                                                        .With(patient => patient.Age = int.Parse(this.Age.Text))
                                                                                        .With(patient => patient.MobilePhone = this.MobilePhone.Text)
                                                                                        .Build());
                this.Close();
            }
        }
        private void EGN_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientEGN();
        }
        private void MiddleName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientMiddleName();
        }
        private void LastName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientLastName();
        }
        private void Age_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientAge();
        }
        private void MobilePhone_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientMobilePhone();
        }
        private void FirstName_LostFocus_1(object sender, RoutedEventArgs e)
        {
            ValidatePatientFirstName();
        }
    }
}
