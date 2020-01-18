using Newtonsoft.Json.Linq;
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
    public partial class ReservationForm : Window
    {
        public ObservableCollection<Patient> PatientList { set; get; }
        public ObservableCollection<Doctor> DoctorList { set; get; }
        public ObservableCollection<Hospital> HospitalList { set; get; }
        public User User { set; get; }
        public string ReservationType { get; set; }

        public ReservationForm(User User, string ReservationForm)
        {

            InitializeComponent();
            ReservationType = ReservationForm;
            this.User = User;
            InitializeLists(ReservationForm);
            this.ShowForm(ReservationForm);
        }

        private void InitializeLists(string ReservationForm)
        {
            PatientList = GETAllPatientsRequest(User.AuthenticationCredentials);
            switch (ReservationForm)
            {
                case "DoctorReservationForm":
                    HospitalList = GETAllHospitalsRequest(User.AuthenticationCredentials);
                    break;
                case "HospitalReservationForm":
                    DoctorList = GETAllDoctorsRequest(User.AuthenticationCredentials);
                    break;
            }
        }
        private ObservableCollection<Doctor> GETAllDoctorsRequest(string BasicAuthentication)
        {
            var Doctors = HttpRequest.Of($"https://localhost:44348/api/doctors", RequestType.GET)
               .BasicAuthentication(BasicAuthentication)
               .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
               .Execute()
               .DeserializeBody<List<Doctor>>();
            var doctorsForHospital = GetDoctorsForHospital(User.Guid, BasicAuthentication);
            return new ObservableCollection<Doctor>(Doctors.Where(doctor => doctorsForHospital.Contains(doctor.Guid)).ToList());
        }
        private List<string> GetDoctorsForHospital(string hospitalId, string BasicAuthentication)
        {
            return HttpRequest
                .Of($"https://localhost:44348/api/hospitals/{hospitalId}/doctors", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<List<string>>();
        }

        private ObservableCollection<Patient> GETAllPatientsRequest(string BasicAuthentication)
        {
            return HttpRequest.Of($"https://localhost:44348/api/patients", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Patient>>();
        }
        private ObservableCollection<Hospital> GETAllHospitalsRequest(string BasicAuthentication)
        {
            var hospitals = HttpRequest.Of($"https://localhost:44348/api/hospitals", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<List<Hospital>>()
                .Where(hospital => GetDoctorsForHospital(hospital.Guid, BasicAuthentication).Contains(User.Guid))
                .ToList();
            return new ObservableCollection<Hospital>(hospitals);
        }
        private void POSTReservationRequest(string BasicAuthentication, JObject Reservation)
        {
            var httpResponse = HttpRequest.Of("https://localhost:44348/api/reservations", RequestType.POST)
                                            .BasicAuthentication(BasicAuthentication)
                                            .BodyData(Reservation)
                                            .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                                            .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageForm MessageForm = new MessageForm("Info", "Successfully created");
                MessageForm.ShowDialog();
                this.Close();
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
        private void ShowForm(string ReservationForm)
        {
            this.DataContext = this;
            switch (ReservationForm)
            {
                case "DoctorReservationForm":
                    this.DoctorReservationPatient.ItemsSource = PatientList;
                    this.DoctorReservationPatient.DisplayMemberPath = "FullName";
                    this.DoctorReservationHospital.ItemsSource = HospitalList;
                    this.DoctorReservationHospital.DisplayMemberPath = "Name";
                    this.DoctorReservationForm.Visibility = Visibility.Visible;
                    this.saveBtn.Visibility = Visibility.Visible;
                    return;
                case "HospitalReservationForm":
                    this.HospitalReservationPatient.ItemsSource = PatientList;
                    this.HospitalReservationPatient.DisplayMemberPath = "FullName";
                    this.HospitalReservationDoctor.ItemsSource = DoctorList;
                    this.HospitalReservationDoctor.DisplayMemberPath = "FullName";
                    this.HospitalReservationForm.Visibility = Visibility.Visible;
                    this.saveBtn.Visibility = Visibility.Visible;
                    return;
            }

        }
        private bool ValidateReservationDate()
        {
            if ((DoctorReservationForm.IsVisible && DoctorReservationDate.SelectedDate == null) || (HospitalReservationForm.IsVisible && HospitalReservationDate.SelectedDate == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Date cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateReservationTime()
        {
            if ((DoctorReservationForm.IsVisible && DoctorReservationTime.SelectedTime == null) || (HospitalReservationForm.IsVisible && HospitalReservationTime.SelectedTime == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Time cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateReservationPatient()
        {
            if ((DoctorReservationForm.IsVisible && DoctorReservationPatient.Text.Length <= 0) || (HospitalReservationForm.IsVisible && HospitalReservationPatient.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Patient cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateReservationHospital()
        {
            if (DoctorReservationHospital.Text.Length <= 0 && DoctorReservationForm.IsVisible)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Hospital cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateReservationDoctor()
        {
            if (HospitalReservationDoctor.Text.Length <= 0 && HospitalReservationForm.IsVisible)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Doctor cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateReason()
        {
            if ((DoctorReservationForm.IsVisible && DoctorReason.Text.Length <= 0) || (HospitalReservationForm.IsVisible && HospitalReason.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Reason cannot be empty!");
                return false;
            }
            else if ((DoctorReservationForm.IsVisible && DoctorReason.Text.ToString().All(c => char.IsDigit(c))) || (HospitalReservationForm.IsVisible && HospitalReason.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Reservation Reason cannot contain digts!");
                return false;
            }
            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateReservationDate())
                return;
            else if (!ValidateReservationTime())
                return;
            else if (!ValidateReservationPatient())
                return;
            else if (!ValidateReservationDoctor())
                return;
            else if (!ValidateReservationHospital())
                return;
            else if (!ValidateReason())
                return;
            else
            {
                switch (ReservationType)
                {
                    case "DoctorReservationForm":
                        JObject doctorReservation = new JObjectBuilder().With(reservation => reservation.Patient = new JObjectBuilder().With(patient => patient.Guid = PatientList[DoctorReservationPatient.SelectedIndex].Guid).Build())
                                                          .With(reservation => reservation.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = User.Guid).Build())
                                                          .With(reservation => reservation.Hospital = new JObjectBuilder().With(hospital => hospital.Guid = HospitalList[DoctorReservationHospital.SelectedIndex].Guid).Build())
                                                          .With(reservation => reservation.ReservationTime = (DoctorReservationDate.SelectedDate.Value).Date.Add(DoctorReservationTime.SelectedTime.Value.TimeOfDay))
                                                          .With(reservation => reservation.Reason = DoctorReason.Text)
                                                          .Build();
                        POSTReservationRequest(User.AuthenticationCredentials, doctorReservation);
                        return;
                    case "HospitalReservationForm":
                        JObject hospitalReservation = new JObjectBuilder().With(reservation => reservation.Patient = new JObjectBuilder().With(patient => patient.Guid = PatientList[HospitalReservationPatient.SelectedIndex].Guid).Build())
                                                          .With(reservation => reservation.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = DoctorList[HospitalReservationDoctor.SelectedIndex].Guid).Build())
                                                          .With(reservation => reservation.Hospital = new JObjectBuilder().With(hospital => hospital.Guid = User.Guid).Build())
                                                          .With(reservation => reservation.ReservationTime = (HospitalReservationDate.SelectedDate.Value).Date.Add(HospitalReservationTime.SelectedTime.Value.TimeOfDay))
                                                          .With(reservation => reservation.Reason = HospitalReason.Text)
                                                          .Build();
                        POSTReservationRequest(User.AuthenticationCredentials, hospitalReservation);
                        return;
                }
            }
        }
    }


}
