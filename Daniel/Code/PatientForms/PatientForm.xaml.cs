namespace PS_Hospital_System_Project_2019
{
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
    using System.Windows.Controls;
    using System.Windows.Input;
    using MessageBox = PS_Hospital_System_Project_2019.SystemClases.MessageBox;
    public partial class PatientForm : Window
    {

        public Patient patient { get; set; }
        public ObservableCollection<Visit> VisitList { get; set; }
        public ObservableCollection<DiagnoseList> DiagnosesList { get; set; }
        public ObservableCollection<Reservation> ReservationLlist { get; set; }
        public ObservableCollection<Doctor> DoctorList { get; set; }
        public User User { get; set; }
        public PatientForm(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            User = user;
            patient = GETPatientInfoRequest(User.Guid, User.AuthenticationCredentials);
            GETPatientReservationsRequest(User.AuthenticationCredentials);

        }
        private Patient GETPatientInfoRequest(string param, string BasicAuthentication)
        {
            return HttpRequest.Of($"https://localhost:44348/api/patients/{param}", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<Patient>();
        }
        private ObservableCollection<Reservation> GETPatientReservationsRequest(string BasicAuthentication)
        {
            ReservationLlist = HttpRequest.Of("https://localhost:44348/api/reservations", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Reservation>>();
            return ReservationLlist;
        }
        private ObservableCollection<Visit> GETPatientVisitsRequest(string BasicAuthentication)
        {
            VisitList = HttpRequest.Of("https://localhost:44348/api/visits", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Visit>>();
            return VisitList;
        }
        private ObservableCollection<Doctor> GETPatientDoctorsRequest(string BasicAuthentication)
        {
            DoctorList = HttpRequest.Of("https://localhost:44348/api/doctors", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Doctor>>();
            return DoctorList;
        }
        private ObservableCollection<DiagnoseList> GETPatientDiagnosesRequest(string BasicAuthentication)
        {
            DiagnosesList = HttpRequest.Of("https://localhost:44348/api/diagnoses", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<DiagnoseList>>();
            return DiagnosesList;
        }
        private void PUTPatientInfoRequest(string param, string BasicAuthentication)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/patients/{param}", RequestType.PUT)
                .BasicAuthentication(BasicAuthentication)
                .BodyData(patient)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", "Updating of the Person Info cannot be done!"))
                .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Patient Update Info", "Patient Information was updated successfully!");
            }
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Minimize(object sender, RoutedEventArgs e)
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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
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

            DisplayCurrentTab(currentIndex);
        }
        private void CollapsePreviousTab(int index)
        {
            switch (index)
            {
                case 0:
                    PersonalInfo.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    Visits.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Diagnoses.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    Reservations.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    Doctors.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void DisplayCurrentTab(int index)
        {
            switch (index)
            {
                case 0:
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(2);
                    CollapsePreviousTab(3);
                    CollapsePreviousTab(4);
                    patient = GETPatientInfoRequest(User.Guid, User.AuthenticationCredentials);
                    PersonalInfo.Visibility = Visibility.Visible;
                    break;
                case 1:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(2);
                    CollapsePreviousTab(3);
                    CollapsePreviousTab(4);
                    this.Visits.ItemsSource = GETPatientVisitsRequest(User.AuthenticationCredentials);
                    Visits.Visibility = Visibility.Visible;
                    break;
                case 2:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(3);
                    CollapsePreviousTab(4);
                    this.Diagnoses.ItemsSource = GETPatientDiagnosesRequest(User.AuthenticationCredentials);
                    Diagnoses.Visibility = Visibility.Visible;
                    break;
                case 3:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(2);
                    CollapsePreviousTab(4);
                    this.Reservations.ItemsSource = GETPatientReservationsRequest(User.AuthenticationCredentials);
                    Reservations.Visibility = Visibility.Visible;
                    break;
                case 4:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(2);
                    CollapsePreviousTab(3);
                    this.Doctors.ItemsSource = GETPatientDoctorsRequest(User.AuthenticationCredentials);
                    Doctors.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var isVisitsVisible = Visits.Visibility == Visibility.Visible;
            var isDiagnosesVisible = Diagnoses.Visibility == Visibility.Visible;
            var isDoctorsVisible = Doctors.Visibility == Visibility.Visible;
            var index = isDiagnosesVisible ? Diagnoses.SelectedIndex : (isDoctorsVisible ? Doctors.SelectedIndex : (isVisitsVisible ? Visits.SelectedIndex : Reservations.SelectedIndex));
            var cell = isDiagnosesVisible ? Diagnoses.CurrentCell.Column.DisplayIndex : (isDoctorsVisible ? Doctors.CurrentCell.Column.DisplayIndex : (isVisitsVisible ? Visits.CurrentCell.Column.DisplayIndex : Reservations.CurrentCell.Column.DisplayIndex));
            InfoForm infoForm = null;

            if (cell == 0)
            {
                if (isDoctorsVisible)
                    infoForm = new InfoForm((object)DoctorList[index]);
            }
            else if (cell == 1)
            {

                if (isDiagnosesVisible)
                    infoForm = new InfoForm((object)DiagnosesList[index].Doctor);
                else if (isVisitsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Doctor);
                else if (!isVisitsVisible && !isDiagnosesVisible && !isDoctorsVisible)
                    infoForm = new InfoForm((object)ReservationLlist[index].Doctor);
            }
            else if (cell == 2)
            {
                if (isVisitsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Hospital);
                else if (!isVisitsVisible && !isDiagnosesVisible && !isDoctorsVisible)
                    infoForm = new InfoForm((object)ReservationLlist[index].Hospital);

            }

            if (infoForm != null)
                infoForm.ShowDialog();
        }
        private bool ValidatePatientEGN()
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
        private bool ValidatePatientAddress()
        {
            if (Address.Text.Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Address cannot be empty!");
                return false;
            }
            return true;
        }
        private void EGN_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientEGN();
        }
        private void FirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidatePatientFirstName();
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
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidatePatientFirstName())
                return;
            else if (!ValidatePatientMiddleName())
                return;
            else if (!ValidatePatientLastName())
                return;
            else if (!ValidatePatientEGN())
                return;
            else if (!ValidatePatientAge())
                return;
            else if (!ValidatePatientMobilePhone())
                return;
            else if (!ValidatePatientAddress())
                return;
            else
            {
                PUTPatientInfoRequest(User.Guid, User.AuthenticationCredentials);
                patient = GETPatientInfoRequest(User.Guid, User.AuthenticationCredentials);
            }

        }
        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.Name = this.Name.Text;
        }
        private void MiddleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.MiddleName = this.MiddleName.Text;
        }
        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.FamilyName = this.FamilyName.Text;
        }
        private void Egn_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.Egn = this.Egn.Text;
        }
        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.Age = Int32.Parse(this.Age.Text);
        }
        private void MobilePhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.MobilePhone = this.MobilePhone.Text;
        }
        private void Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient.Address = this.Address.Text;
        }
    }
}
