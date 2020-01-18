namespace PS_Hospital_System_Project_2019
{
    using PS_Hospital_System_Project_2019.SystemClases;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using MessageBox = SystemClases.MessageBox;

    public partial class AdminForm : Window
    {
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Hospital> Hospitals { get; set; }
        public User User { set; get; }
        public AdminForm(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            User = user;
            Patients = GETAllPatientsRequest(User.AuthenticationCredentials);
            PatientsList.ItemsSource = Patients;
        }
        private ObservableCollection<Doctor> GETAllDoctorsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/doctors", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Doctor>>();
        }
        private ObservableCollection<Patient> GETAllPatientsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/patients", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Patient>>();
        }
        private ObservableCollection<Hospital> GETAllHospitalsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/hospitals", RequestType.GET)
               .BasicAuthentication(BasicAuthentication)
               .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
               .Execute()
               .DeserializeBody<ObservableCollection<Hospital>>();
        }
        public void Register_Patient_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientRegisterForm = new PatientRegister(User);
            patientRegisterForm.Closed += PatientRegisterForm_Closed;
            patientRegisterForm.ShowDialog();
        }
        private void PatientRegisterForm_Closed(object sender, EventArgs e)
        {
            Patients = GETAllPatientsRequest(User.AuthenticationCredentials);
            PatientsList.ItemsSource = Patients;
        }
        public void Register_Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorRegister doctorRegisterForm = new DoctorRegister(User);
            doctorRegisterForm.Closed += DoctorRegisterForm_Closed;
            doctorRegisterForm.ShowDialog();
        }
        private void DoctorRegisterForm_Closed(object sender, EventArgs e)
        {
            Doctors = GETAllDoctorsRequest(User.AuthenticationCredentials);
            DoctorsList.ItemsSource = Doctors;
        }
        public void Register_Hospital_Click(object sender, RoutedEventArgs e)
        {
            HospitalRegister hospitalRegisterForm = new HospitalRegister(User);
            hospitalRegisterForm.Closed += HospitalRegisterForm_Closed;
            hospitalRegisterForm.ShowDialog();
        }
        private void HospitalRegisterForm_Closed(object sender, EventArgs e)
        {
            Hospitals = GETAllHospitalsRequest(User.AuthenticationCredentials);
            HospitalsList.ItemsSource = Hospitals;
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var isDoctorsListVisible = DoctorsList.Visibility == Visibility.Visible;
            var isHospitalsListVisible = HospitalsList.Visibility == Visibility.Visible;
            var index = isHospitalsListVisible ? HospitalsList.SelectedIndex : (isDoctorsListVisible ? DoctorsList.SelectedIndex : PatientsList.SelectedIndex);
            var cell = isHospitalsListVisible ? HospitalsList.CurrentCell.Column.DisplayIndex : (isDoctorsListVisible ? DoctorsList.CurrentCell.Column.DisplayIndex : PatientsList.CurrentCell.Column.DisplayIndex);
            InfoForm infoForm = null;
            EditForm editForm = null;

            if (cell == 0)
            {
                if (isHospitalsListVisible)
                {
                    editForm = new EditForm(User, (object)Hospitals[index]);
                }
                else if (isDoctorsListVisible)
                    editForm = new EditForm(User, (object)Doctors[index]);
                else
                    editForm = new EditForm(User, (object)Patients[index]);
            }
            else if (cell == 2)
            {
                if (isHospitalsListVisible)
                    infoForm = new InfoForm((object)Hospitals[index]);
                else if (isDoctorsListVisible)
                    infoForm = new InfoForm((object)Doctors[index]);
                else
                    infoForm = new InfoForm((object)Patients[index]);
            }
            else if (cell == 5)
            {
                if (isDoctorsListVisible)
                    infoForm = new InfoForm((object)Doctors[index]);

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
            Patients = GETAllPatientsRequest(User.AuthenticationCredentials);
            PatientsList.ItemsSource = Patients;
            Doctors = GETAllDoctorsRequest(User.AuthenticationCredentials);
            DoctorsList.ItemsSource = Doctors;
            Hospitals = GETAllHospitalsRequest(User.AuthenticationCredentials);
            HospitalsList.ItemsSource = Hospitals;
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
                GridCursor.Margin = new Thickness(20 + (145 * currentIndex), 0, 0, 0);
            }
            else
            {
                GridCursor.Margin = new Thickness(25 + (145 * currentIndex), 0, 0, 0);
            }

            DisplayCurrentTab(currentIndex);
        }
        public void CollapsePreviousTab(int index)
        {
            switch (index)
            {
                case 0:
                    PatientsList.Visibility = Visibility.Collapsed;
                    RegisterPatientBtn.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    DoctorsList.Visibility = Visibility.Collapsed;
                    RegisterDoctorBtn.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    HospitalsList.Visibility = Visibility.Collapsed;
                    RegisterHospitalBtn.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        public void DisplayCurrentTab(int index)
        {
            switch (index)
            {
                case 0:
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(2);
                    Patients = GETAllPatientsRequest(User.AuthenticationCredentials);
                    PatientsList.ItemsSource = Patients;
                    PatientsList.Visibility = Visibility.Visible;
                    RegisterPatientBtn.Visibility = Visibility.Visible;
                    break;
                case 1:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(2);
                    Doctors = GETAllDoctorsRequest(User.AuthenticationCredentials);
                    DoctorsList.ItemsSource = Doctors;
                    DoctorsList.Visibility = Visibility.Visible;
                    RegisterDoctorBtn.Visibility = Visibility.Visible;
                    break;
                case 2:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    Hospitals = GETAllHospitalsRequest(User.AuthenticationCredentials);
                    HospitalsList.ItemsSource = Hospitals;
                    HospitalsList.Visibility = Visibility.Visible;
                    RegisterHospitalBtn.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
