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

    public partial class VisitationRegisterForm : Window
    {

        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Hospital> Hospitals { get; set; }
        public User User { set; get; }
        public string VisitationType { get; set; }

        public VisitationRegisterForm(User User, string VisitationForm)
        {
            InitializeComponent();
            VisitationType = VisitationForm;
            this.User = User;
            InitializeLists(VisitationForm);
            ShowForm(VisitationForm);
        }

        private void InitializeLists(string VisitationForm)
        {
            Patients = GETAllPatientsRequest(User.AuthenticationCredentials);
            switch (VisitationForm)
            {
                case "DoctorPSForm":
                    Hospitals = GETAllHospitalsRequest(User.AuthenticationCredentials);
                    break;
                case "HospitalPSForm":
                    Doctors = GETAllDoctorsRequest(User.AuthenticationCredentials);
                    break;
            }
        }

        private ObservableCollection<Doctor> GETAllDoctorsRequest(string BasicAuthentication)
        {
            var doctors = HttpRequest.Of($"https://localhost:44348/api/doctors", RequestType.GET)
                            .BasicAuthentication(BasicAuthentication)
                            .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                            .Execute()
                            .DeserializeBody<ObservableCollection<Doctor>>();
            var hospitalDoctorsIds = GetDoctorsForHospital(BasicAuthentication, User.Guid);
            return new ObservableCollection<Doctor>(doctors.Where(doctor => hospitalDoctorsIds.Contains(doctor.Guid))
                            .ToList());
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
            return new ObservableCollection<Hospital>(HttpRequest.Of($"https://localhost:44348/api/hospitals", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<ObservableCollection<Hospital>>()
                .Where(hospital => GetDoctorsForHospital(BasicAuthentication, hospital.Guid).Contains(User.Guid))
                .ToList());
        }

        private List<string> GetDoctorsForHospital(string BasicAuthentication, string hospitalId)
        {
            return HttpRequest.Of($"https://localhost:44348/api/hospitals/{hospitalId}/doctors", RequestType.GET)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                .Execute()
                .DeserializeBody<List<string>>();
        }

        private void POSTVisitsRequest(string BasicAuthentication, JObject visit)
        {
            var httpResponse = HttpRequest.Of("https://localhost:44348/api/visits", RequestType.POST)
                  .BasicAuthentication(BasicAuthentication)
                  .BodyData(visit)
                  .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                  .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageForm MessageForm = new MessageForm("Info", "The Visit is successfully created");
                MessageForm.ShowDialog();
                this.Close();
            }
        }
        private void POSTDiagnosisRequest(string BasicAuthentication, JObject diagnosis)
        {
            var httpResponse = HttpRequest.Of("https://localhost:44348/api/diagnoses", RequestType.POST)
                                    .BasicAuthentication(BasicAuthentication)
                                    .BodyData(diagnosis)
                                    .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                                    .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageForm MessageForm = new MessageForm("Info", "The Diagnose is successfully created");
                MessageForm.ShowDialog();
                this.Close();
            }
        }
        private static bool IsSuccessful(HttpWebResponse response)
        {
            return response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.Accepted) || response.StatusCode.Equals(HttpStatusCode.NoContent);
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
        private bool ValidatePSDate()
        {
            if ((DoctorPSForm.IsVisible && DoctorPSDate.SelectedDate == null) || (HospitalPSForm.IsVisible && HospitalPSDate.SelectedDate == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Date cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidatePSTime()
        {
            if ((DoctorPSForm.IsVisible && DoctorPSTime.SelectedTime == null) || (HospitalPSForm.IsVisible && HospitalPSTime.SelectedTime == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Time cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidatePSPatient()
        {
            if ((DoctorPSForm.IsVisible && DoctorPSPatient.Text.Length <= 0) || (HospitalPSForm.IsVisible && HospitalPSPatient.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Patient cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidatePSHospital()
        {
            if (DoctorPSHospital.Text.Length <= 0 && DoctorPSForm.IsVisible)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Hospital cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidatePSDoctor()
        {
            if (HospitalPSDoctor.Text.Length <= 0 && HospitalPSForm.IsVisible)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Doctor cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateDiagnose()
        {
            if ((DoctorPSForm.IsVisible && DoctorPSDiagnose.Text.Length <= 0) || (HospitalPSForm.IsVisible && HospitalPSDiagnose.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Diagnose cannot be empty!");
                return false;
            }
            else if ((DoctorPSForm.IsVisible && DoctorPSDiagnose.Text.ToString().All(c => char.IsDigit(c))) || (HospitalPSForm.IsVisible && HospitalPSDiagnose.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Visitation Diagnose cannot contain digts!");
                return false;
            }
            return true;
        }

        private void ShowForm(string VisitationForm)
        {
            this.DataContext = this;
            switch (VisitationForm)
            {
                case "DoctorPSForm":
                    this.DoctorPSPatient.ItemsSource = Patients;
                    this.DoctorPSPatient.DisplayMemberPath = "FullName";
                    this.DoctorPSHospital.ItemsSource = Hospitals;
                    this.DoctorPSHospital.DisplayMemberPath = "Name";
                    this.DoctorPSForm.Visibility = Visibility.Visible;
                    this.saveBtn.Visibility = Visibility.Visible;
                    break;
                case "HospitalPSForm":
                    this.HospitalPSPatient.ItemsSource = Patients;
                    this.HospitalPSPatient.DisplayMemberPath = "FullName";
                    this.HospitalPSDoctor.ItemsSource = Doctors;
                    this.HospitalPSDoctor.DisplayMemberPath = "FullName";
                    this.HospitalPSForm.Visibility = Visibility.Visible;
                    this.saveBtn.Visibility = Visibility.Visible;
                    break;

            }

        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidatePSDate())
                return;
            else if (!ValidatePSTime())
                return;
            else if (!ValidatePSPatient())
                return;
            else if (!ValidatePSDoctor())
                return;
            else if (!ValidatePSHospital())
                return;
            else if (!ValidateDiagnose())
                return;
            else
            {
                switch (VisitationType)
                {
                    case "DoctorPSForm":
                        JObject doctorVisitation = new JObjectBuilder().With(visit => visit.Patient = new JObjectBuilder().With(patient => patient.Guid = Patients[DoctorPSPatient.SelectedIndex].Guid).Build())
                                                                        .With(visit => visit.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = User.Guid).Build())
                                                                        .With(visit => visit.Hospital = new JObjectBuilder().With(hospital => hospital.Guid = Hospitals[DoctorPSHospital.SelectedIndex].Guid).Build())
                                                                        .With(visit => visit.VisitTime = (DoctorPSDate.SelectedDate.Value).Date.Add(DoctorPSTime.SelectedTime.Value.TimeOfDay))
                                                                        .Build();
                        POSTVisitsRequest(User.AuthenticationCredentials, doctorVisitation);
                        JObject doctorDiagnosis = new JObjectBuilder().With(diagnosis => diagnosis.Patient = new JObjectBuilder().With(patient => patient.Guid = Patients[DoctorPSPatient.SelectedIndex].Guid).Build())
                                                                        .With(diagnosis => diagnosis.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = doctor.Guild = User.Guid).Build())
                                                                        .With(diagnosis => diagnosis.DiagnosisTime = (DoctorPSDate.SelectedDate.Value).Date.Add(DoctorPSTime.SelectedTime.Value.TimeOfDay))
                                                                        .With(diagnosis => diagnosis.DiagnosisDescription = DoctorPSDiagnose.Text).Build();
                        POSTDiagnosisRequest(User.AuthenticationCredentials, doctorDiagnosis);
                        return;
                    case "HospitalPSForm":
                        JObject hospitalVisitation = new JObjectBuilder().With(visit => visit.Patient = new JObjectBuilder().With(patient => patient.Guid = Patients[HospitalPSPatient.SelectedIndex].Guid).Build())
                                                .With(visit => visit.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = Doctors[HospitalPSDoctor.SelectedIndex].Guid).Build())
                                                .With(visit => visit.Hospital = new JObjectBuilder().With(hospital => hospital.Guid = User.Guid).Build())
                                                .With(visit => visit.VisitTime = (HospitalPSDate.SelectedDate.Value).Date.Add(HospitalPSTime.SelectedTime.Value.TimeOfDay))
                                                .Build();
                        POSTVisitsRequest(User.AuthenticationCredentials, hospitalVisitation);
                        JObject hospitalDiagnosis = new JObjectBuilder().With(diagnosis => diagnosis.Patient = new JObjectBuilder().With(patient => patient.Guid = Patients[HospitalPSPatient.SelectedIndex].Guid).Build())
                                                                        .With(diagnosis => diagnosis.Doctor = new JObjectBuilder().With(doctor => doctor.Guid = Doctors[HospitalPSDoctor.SelectedIndex].Guid).Build())
                                                                        .With(diagnosis => diagnosis.DiagnosisDescription = HospitalPSDiagnose.Text)
                                                                        .With(diagnosis => diagnosis.DiagnosisTime = (HospitalPSDate.SelectedDate.Value).Date.Add(HospitalPSTime.SelectedTime.Value.TimeOfDay)).Build();
                        POSTDiagnosisRequest(User.AuthenticationCredentials, hospitalDiagnosis);
                        return;
                }
            }
        }
    }
}
