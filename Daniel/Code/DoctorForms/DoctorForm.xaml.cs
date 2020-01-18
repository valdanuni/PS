using PS_Hospital_System_Project_2019.SystemClases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = PS_Hospital_System_Project_2019.SystemClases.MessageBox;

namespace PS_Hospital_System_Project_2019
{

    public partial class DoctorForm : Window
    {
        public Doctor Doctor { get; set; }
        public ObservableCollection<Visit> VisitList { get; set; }
        public ObservableCollection<Reservation> ReservationList { get; set; }
        public User User { get; set; }
        public string InfoIcon { get; set; }
        public DoctorForm(User User)
        {
            InitializeComponent();
            this.DataContext = this;
            this.User = User;
            Doctor = GETDoctorInfoRequest(this.User.Guid, this.User.AuthenticationCredentials);
        }
        private Doctor GETDoctorInfoRequest(string param, string BasicAuthentication)
        {
            return HttpRequest.Of($"https://localhost:44348/api/doctors/{param}", RequestType.GET)
              .BasicAuthentication(BasicAuthentication)
              .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
              .Execute()
              .DeserializeBody<Doctor>();
        }
        private ObservableCollection<Reservation> GETDoctorReservationsRequest(string BasicAuthentication)
        {
            ReservationList = HttpRequest.Of($"https://localhost:44348/api/reservations", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Reservation>>();
            return ReservationList;
        }
        private ObservableCollection<Visit> GETDoctorVisitsRequest(string BasicAuthentication)
        {
            VisitList = HttpRequest.Of($"https://localhost:44348/api/visits", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Visit>>();
            return VisitList;
        }
        private void PUTDoctorInfoRequest(string param, string BasicAuthentication)
        {
            var response = HttpRequest.Of($"https://localhost:44348/api/doctors/{param}", RequestType.PUT)
                 .BasicAuthentication(BasicAuthentication)
                 .BodyData(Doctor)
                 .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", "Updating of the Doctor Info cannot be done!"))
                 .Execute();
            if (response != null)
            {
                MessageBox.ShowMessageBoxInfo("Doctor Update Info", "Doctor Information was updated successfully!");
            }

        }
        public void Register_Patient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientRegisterForm = new PatientRegister(User);
            patientRegisterForm.ShowDialog();

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
            Application.Current.Shutdown();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int currentIndex = int.Parse(((Button)e.Source).Uid);

            if (currentIndex == 0)
            {
                GridCursor.Margin = new Thickness(25 + (150 * currentIndex), 0, 0, 0);
            }
            else
            {
                GridCursor.Margin = new Thickness(40 + (150 * currentIndex), 0, 0, 0);
            }

            displayCurrentTab(currentIndex);

        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var isPatientVisitationsVisible = PatientVisitation.Visibility == Visibility.Visible;

            var index = isPatientVisitationsVisible ? PatientVisitation.SelectedIndex : Reservations.SelectedIndex;
            var cell = isPatientVisitationsVisible ? PatientVisitation.CurrentCell.Column.DisplayIndex : Reservations.CurrentCell.Column.DisplayIndex;
            InfoForm infoForm = null;
            EditForm editForm = null;

            if (cell == 0)
            {

                if (isPatientVisitationsVisible)
                    editForm = new EditForm(User, (object)VisitList[index]);
                else
                    editForm = new EditForm(User, (object)ReservationList[index]);
            }
            else if (cell == 2)
            {

                if (isPatientVisitationsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Patient);
                else
                    infoForm = new InfoForm((object)ReservationList[index].Patient);
            }
            else if (cell == 3)
            {
                if (isPatientVisitationsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Hospital);
                else
                    infoForm = new InfoForm((object)ReservationList[index].Hospital);
            }

            if (infoForm != null)
                infoForm.ShowDialog();
            if (editForm != null)
            {
                editForm.Closed += EditForm_Closed;
                editForm.ShowDialog();
            }

        }

        private void EditForm_Closed(object sender, EventArgs e)
        {
            this.PatientVisitation.ItemsSource = GETDoctorVisitsRequest(User.AuthenticationCredentials);
            this.Reservations.ItemsSource = GETDoctorReservationsRequest(User.AuthenticationCredentials);
        }

        public void collapsePreviousTab(int index)
        {
            switch (index)
            {
                case 0:
                    PersonalInfo.Visibility = Visibility.Collapsed;
                    SaveBtn.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    VisitBtn.Visibility = Visibility.Collapsed;
                    PatientVisitation.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    ReserveBtn.Visibility = Visibility.Collapsed;
                    Reservations.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public void displayCurrentTab(int index)
        {
            switch (index)
            {
                case 0:
                    collapsePreviousTab(1);
                    collapsePreviousTab(2);
                    Doctor = GETDoctorInfoRequest(User.Guid, User.AuthenticationCredentials);
                    SaveBtn.Visibility = Visibility.Visible;
                    PersonalInfo.Visibility = Visibility.Visible;
                    break;
                case 1:
                    collapsePreviousTab(0);
                    collapsePreviousTab(2);
                    VisitBtn.Visibility = Visibility.Visible;
                    PatientVisitation.Visibility = Visibility.Visible;
                    this.PatientVisitation.ItemsSource = GETDoctorVisitsRequest(User.AuthenticationCredentials);
                    break;
                case 2:
                    collapsePreviousTab(0);
                    collapsePreviousTab(1);
                    this.Reservations.ItemsSource = GETDoctorReservationsRequest(User.AuthenticationCredentials);
                    Reservations.Visibility = Visibility.Visible;
                    ReserveBtn.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ReserveBtn_Click(object sender, RoutedEventArgs e)
        {
            var ReservationForm = new ReservationForm(User, "DoctorReservationForm");
            ReservationForm.Closed += ReservationForm_Closed;
            ReservationForm.ShowDialog();
        }

        private void ReservationForm_Closed(object sender, EventArgs e)
        {
            this.Reservations.ItemsSource = GETDoctorReservationsRequest(User.AuthenticationCredentials);
        }

        private void VisitBtn_Click(object sender, RoutedEventArgs e)
        {
            var VisitationForm = new VisitationRegisterForm(User, "DoctorPSForm");
            VisitationForm.Closed += VisitationForm_Closed;
            VisitationForm.ShowDialog();
        }

        private void VisitationForm_Closed(object sender, EventArgs e)
        {
            this.PatientVisitation.ItemsSource = GETDoctorVisitsRequest(User.AuthenticationCredentials);
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
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name cannot contain digits!");
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

        private bool ValidateDoctorMobilePhone()
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
        private bool ValidateDoctorAddress()
        {
            if (Address.Text.Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Address cannot be empty!");
                return false;
            }

            return true;
        }
        private bool ValidateDoctorSpecialization()
        {
            if (Specialization.Text.Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Specialization cannot be more or less than 10 digits!");
                return false;
            }

            return true;
        }



        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateDoctorFirstName())
                return;
            else if (!ValidateDoctorMiddleName())
                return;
            else if (!ValidateDoctorLastName())
                return;
            else if (!ValidateDoctorEGN())
                return;
            else if (!ValidateDoctorMobilePhone())
                return;
            else if (!ValidateDoctorAddress())
                return;
            else
            {
                PUTDoctorInfoRequest(User.Guid, User.AuthenticationCredentials);
                Doctor = GETDoctorInfoRequest(User.Guid, User.AuthenticationCredentials);
            }

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Name = this.Name.Text;
        }

        private void MiddleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Name = this.MiddleName.Text;
        }

        private void FamilyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Name = this.FamilyName.Text;
        }

        private void Egn_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Egn = this.Egn.Text;
        }

        private void Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Address = this.Address.Text;
        }

        private void MobilePhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.MobilePhone = this.MobilePhone.Text;
        }

        private void Specialization_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doctor.Specialization = this.Specialization.Text;
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorFirstName();
        }

        private void MiddleName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorMiddleName();
        }

        private void FamilyName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorLastName();
        }

        private void Egn_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorEGN();
        }

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorAddress();
        }

        private void MobilePhone_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorMobilePhone();
        }

        private void Specialization_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateDoctorSpecialization();
        }
    }
}
