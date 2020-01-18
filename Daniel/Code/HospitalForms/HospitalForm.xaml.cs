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

namespace PS_Hospital_System_Project_2019
{
    public partial class HospitalForm : Window
    {
        public Hospital HospitalObject { get; set; }
        public User User { get; set; }
        public ObservableCollection<Visit> VisitList { get; set; }
        public ObservableCollection<Doctor> DoctorList { get; set; }
        public ObservableCollection<Doctor> FilteredDoctorList { get; set; }
        public ObservableCollection<Reservation> ReservationList { get; set; }

        public HospitalForm(User User)
        {
            InitializeComponent();
            this.User = User;
            this.DataContext = this;
            HospitalObject = GETHospitalInfoRequest(User.Guid, User.AuthenticationCredentials);
        }
        private Hospital GETHospitalInfoRequest(string param, string BasicAuthentication)
        {
            return HttpRequest.Of($"https://localhost:44348/api/hospitals/{param}", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<Hospital>();
        }
        private ObservableCollection<Reservation> GETHospitalReservationsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/reservations", RequestType.GET)
                    .BasicAuthentication(BasicAuthentication)
                    .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                    .Execute()
                    .DeserializeBody<ObservableCollection<Reservation>>();
        }
        private ObservableCollection<Visit> GETHospitalVisitsRequest(string BaseAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/visits", RequestType.GET)
                    .BasicAuthentication(BaseAuthentication)
                    .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                    .Execute()
                    .DeserializeBody<ObservableCollection<Visit>>();
        }
        private ObservableCollection<Doctor> GETAllDoctorsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of("https://localhost:44348/api/doctors", RequestType.GET)
                       .BasicAuthentication(BasicAuthentication)
                       .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                       .Execute()
                       .DeserializeBody<ObservableCollection<Doctor>>();

        }
        private ObservableCollection<Doctor> GETDoctorsForHospital(string BaseAuthentication, string hospitalId)
        {
            List<Doctor> allDoctors = GETAllDoctorsRequest(BaseAuthentication).ToList();
            List<String> doctorIds = GETHospitalDoctorsRequest(BaseAuthentication, hospitalId);
            return new ObservableCollection<Doctor>(allDoctors.Where(doctor => doctorIds.Contains(doctor.Guid)).ToList());
        }
        private List<String> GETHospitalDoctorsRequest(string BasicAuthentication, string hospitalId)
        {
            return HttpRequest.Of($"https://localhost:44348/api/hospitals/{hospitalId}/doctors", RequestType.GET)
                       .BasicAuthentication(BasicAuthentication)
                       .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                       .Execute()
                       .DeserializeBody<List<String>>();
        }
        private void PUTHospitalInfoRequest(string hospitalId, string BasicAuthentication)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/hospitals/{hospitalId}", RequestType.PUT)
                      .BasicAuthentication(BasicAuthentication)
                      .BodyData(HospitalObject)
                      .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", "Updating of the Hospital Info cannot be done!"))
                      .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Hospital Update Info", "Hospital Information was updated successfully!");
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        public void Register_Doctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorRegister doctorRegisterForm = new DoctorRegister(User);
            doctorRegisterForm.ShowDialog();
            DoctorList = GETAllDoctorsRequest(User.AuthenticationCredentials);
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
        private void ReserveBtn_Click(object sender, RoutedEventArgs e)
        {
            var ReservationForm = new ReservationForm(User, "HospitalReservationForm");
            ReservationForm.Closed += ReservationForm_Closed;
            ReservationForm.ShowDialog();

        }
        private void ReservationForm_Closed(object sender, EventArgs e)
        {
            this.Reservations.ItemsSource = GETHospitalReservationsRequest(User.AuthenticationCredentials);
        }
        private void VisitBtn_Click(object sender, RoutedEventArgs e)
        {
            var VisitationForm = new VisitationRegisterForm(User, "HospitalPSForm");
            VisitationForm.Closed += VisitationForm_Closed;
            VisitationForm.ShowDialog();
        }
        private void VisitationForm_Closed(object sender, EventArgs e)
        {
            this.PatientVisitations.ItemsSource = GETHospitalVisitsRequest(User.AuthenticationCredentials);
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
        public void CollapsePreviousTab(int index)
        {
            switch (index)
            {
                case 0:
                    PersonalInfo.Visibility = Visibility.Collapsed;
                    SaveBtn.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    PatientVisitations.Visibility = Visibility.Collapsed;
                    VisitBtn.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Doctors.Visibility = Visibility.Collapsed;
                    AddDoctorBtn.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    ReserveBtn.Visibility = Visibility.Collapsed;
                    Reservations.Visibility = Visibility.Collapsed;
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
                    CollapsePreviousTab(3);
                    HospitalObject = GETHospitalInfoRequest(User.Guid, User.AuthenticationCredentials);
                    SaveBtn.Visibility = Visibility.Visible;
                    PersonalInfo.Visibility = Visibility.Visible;
                    break;
                case 1:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(2);
                    CollapsePreviousTab(3);
                    VisitList = GETHospitalVisitsRequest(User.AuthenticationCredentials);
                    this.PatientVisitations.ItemsSource = VisitList;
                    VisitBtn.Visibility = Visibility.Visible;
                    PatientVisitations.Visibility = Visibility.Visible;
                    break;
                case 2:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(3);
                    DoctorList = GETAllDoctorsRequest(User.AuthenticationCredentials);
                    this.Doctors.ItemsSource = GETDoctorsForHospital(User.AuthenticationCredentials, User.Guid);
                    AddDoctorBtn.Visibility = Visibility.Visible;
                    Doctors.Visibility = Visibility.Visible;
                    break;
                case 3:
                    CollapsePreviousTab(0);
                    CollapsePreviousTab(1);
                    CollapsePreviousTab(2);
                    ReservationList = GETHospitalReservationsRequest(User.AuthenticationCredentials);
                    this.Reservations.ItemsSource = ReservationList;
                    ReserveBtn.Visibility = Visibility.Visible;
                    Reservations.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var isPatientVisitationsVisible = PatientVisitations.Visibility == Visibility.Visible;
            var isReservationsVisible = Reservations.Visibility == Visibility.Visible;
            var index = isReservationsVisible ? Reservations.SelectedIndex : (isPatientVisitationsVisible ? PatientVisitations.SelectedIndex : Doctors.SelectedIndex);
            var cell = isReservationsVisible ? Reservations.CurrentCell.Column.DisplayIndex : (isPatientVisitationsVisible ? PatientVisitations.CurrentCell.Column.DisplayIndex : Doctors.CurrentCell.Column.DisplayIndex);
            InfoForm infoForm = null;
            EditForm editForm = null;
            if (cell == 0)
            {
                if (isReservationsVisible)
                    editForm = new EditForm(User, (object)ReservationList[index]);
                else if (isPatientVisitationsVisible && !isReservationsVisible)
                    editForm = new EditForm(User, (object)VisitList[index]);
            }
            else if (cell == 1)
            {
                if (!isReservationsVisible && !isPatientVisitationsVisible)
                    infoForm = new InfoForm((object)DoctorList[index]);
            }
            else if (cell == 2)
            {
                if (isReservationsVisible)
                    infoForm = new InfoForm((object)ReservationList[index].Patient);
                else if (isPatientVisitationsVisible && !isReservationsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Patient);

            }
            else if (cell == 3)
            {
                if (isPatientVisitationsVisible)
                    infoForm = new InfoForm((object)VisitList[index].Doctor);
                else if (isReservationsVisible)
                    infoForm = new InfoForm((object)ReservationList[index].Doctor);
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
            this.PatientVisitations.ItemsSource = GETHospitalVisitsRequest(User.AuthenticationCredentials);
            this.Reservations.ItemsSource = GETHospitalReservationsRequest(User.AuthenticationCredentials);
        }
        private void AddDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            DoctorsList DoctorsList = new DoctorsList(User, DoctorList);
            DoctorsList.ShowDialog();
            this.Doctors.ItemsSource = GETDoctorsForHospital(User.AuthenticationCredentials, User.Guid);
        }
        private bool ValidateHospitalName()
        {
            if (HospitalName.Text.Length > 255)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Name cannot be more than 255 characters!");
                return false;
            }
            else if (HospitalName.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalOwner()
        {
            if (HospitalOwner.Text.Length > 255)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Owner cannot be more than 255 characters!");
                return false;
            }
            else if (HospitalOwner.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Owner cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalAddress()
        {
            if (Address.Text.Length > 255)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Address cannot be more than 255 characters!");
                return false;
            }
            else if (Address.Text.Length <= 0 || Address.Text.ToString().All(c => char.IsWhiteSpace(c)))
            {
                MessageForm MessageForm = new MessageForm("Wrong Data Input", "The Hospital Address cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalMobilePhone()
        {
            if (MobilePhone.Text.Length != 10)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Mobile Phone cannot be more than 10 digits !");
                return false;
            }
            else if (!MobilePhone.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Mobile Phone can contain only digits!");
                return false;
            }
            return true;
        }
        private void HospitalName_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateHospitalName();
        }

        private void HospitalOwner_LostFocus(object sender, RoutedEventArgs e)
        {
            ValidateHospitalOwner();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateHospitalName())
                return;
            else if (!ValidateHospitalOwner())
                return;
            else if (!ValidateHospitalAddress())
                return;
            else if (!ValidateHospitalMobilePhone())
                return;
            else
            {
                PUTHospitalInfoRequest(User.Guid, User.AuthenticationCredentials);
                HospitalObject = GETHospitalInfoRequest(User.Guid, User.AuthenticationCredentials);
            }
        }
    }
}
