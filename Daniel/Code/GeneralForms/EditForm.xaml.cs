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

namespace PS_Hospital_System_Project_2019
{

    public partial class EditForm : Window
    {
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Hospital> Hospitals { get; set; }
        public Patient AdminPatientProfile { get; set; }
        public Doctor AdminDoctorProfile { get; set; }
        public Hospital AdminHospitalProfile { get; set; }
        public Visit DoctorPatientProfile { get; set; }
        public Reservation DoctorReservationProfile { get; set; }
        public Visit HospitalPatientProfile { get; set; }
        public Doctor HospitalDoctorProfile { get; set; }
        public Reservation HospitalReservationProfile { get; set; }
        public Reservation PatientReservationProfile { get; set; }
        public User User { get; set; }
        public Object EditedRecord { set; get; }
        public EditForm()
        {
            InitializeComponent();
            this.DataContext = this;

        }
        public EditForm(User User, object EditedObject)
        {
            InitializeComponent();
            this.User = User;
            EditedRecord = EditedObject;
            ShowForm(EditedObject);

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
        private void ShowForm(object EditRecord)
        {
            this.DataContext = this;
            if (EditRecord is Visit && User.UserRole.Equals("Doctor"))
            {
                this.DoctorPatientProfile = (Visit)EditRecord;
                this.DoctorVisitTime.SelectedTime = new DateTime() + DoctorPatientProfile.VisitTime.TimeOfDay;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                DoctorPatientVisitForm.Visibility = Visibility.Visible;
                return;
            }
            else if (EditRecord is Reservation && User.UserRole.Equals("Doctor"))
            {
                this.DoctorReservationProfile = (Reservation)EditRecord;
                this.DoctorReservationTime.SelectedTime = new DateTime() + DoctorReservationProfile.ReservationTime.TimeOfDay; 
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                DoctorReservationsForm.Visibility = Visibility.Visible;
                return;
            }
            else if (EditRecord is Patient && User.UserRole.Equals("Admin"))
            {

                this.AdminPatientProfile = (Patient)EditRecord;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                this.AdminRegPatientForm.Visibility = Visibility.Visible;

                return;
            }
            else if (EditRecord is Doctor && User.UserRole.Equals("Admin"))
            {
                this.AdminDoctorProfile = (Doctor)EditRecord;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                this.AdminRegDoctorForm.Visibility = Visibility.Visible;
                return;
            }
            else if (EditRecord is Hospital && User.UserRole.Equals("Admin"))
            {
                this.AdminHospitalProfile = (Hospital)EditRecord;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                this.AdminRegHospitalForm.Visibility = Visibility.Visible;
                return;
            }
            else if (EditRecord is Visit && User.UserRole.Equals("Hospital"))
            {
                this.HospitalPatientProfile = (Visit)EditRecord;
                this.HospitalPatientTime.SelectedTime = new DateTime() + HospitalPatientProfile.VisitTime.TimeOfDay;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                this.HospitalPatientForm.Visibility = Visibility.Visible;
                return;
            }
            else if (EditRecord is Reservation && User.UserRole.Equals("Hospital"))
            {
                this.HospitalReservationProfile = (Reservation)EditRecord;
                this.HospitalReservationTime.SelectedTime = new DateTime() + HospitalReservationProfile.ReservationTime.TimeOfDay;
                this.saveBtn.Visibility = Visibility.Visible;
                this.deleteBtn.Visibility = Visibility.Visible;
                this.HospitalReservationForm.Visibility = Visibility.Visible;
                return;
            }
        }
        private bool ValidateEGN()
        {
            if ((AdminRegPatientForm.IsVisible && AdminPatientEgn.Text.ToString().Length != 10) || (AdminRegDoctorForm.IsVisible && AdminDoctorEgn.Text.ToString().Length != 10))
            {
                MessageForm MessageForm = new MessageForm("Wrong Data Input", "The Doctor's EGN should be excatly 10 digits!");
                MessageForm.ShowDialog();
                return false;
            }

            else if ((AdminRegPatientForm.IsVisible && !AdminPatientEgn.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible && !AdminDoctorEgn.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Doctor's EGN should contains only digts!");
                return false;
            }
            return true;
        }
        private bool ValidateAge()
        {
            if ((AdminRegPatientForm.IsVisible && (AdminPatientAge.Text.Length > 3 || AdminPatientAge.Text.Length < 1)) || (AdminRegDoctorForm.IsVisible))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Age cannot be more that 3 or less than 1 digits!");
                return false;
            }
            else if ((AdminRegPatientForm.IsVisible && !AdminPatientAge.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Age can contain only digits!");
                return false;
            }
            return true;
        }
        private bool ValidateFirstName()
        {
            if ((AdminRegPatientForm.IsVisible && AdminPatientName.Text.Length == 0) || (AdminRegDoctorForm.IsVisible && AdminDoctorName.Text.Length == 0) || (AdminRegHospitalForm.IsVisible && AdminHospitalName.Text.Length == 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The First Name is required field and cannot be empty!");
                return false;
            }
            else if ((AdminRegPatientForm.IsVisible && AdminPatientName.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible && AdminDoctorName.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegHospitalForm.IsVisible && AdminHospitalName.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The First Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateMiddleName()
        {
            if ((AdminRegPatientForm.IsVisible && AdminPatientMiddleName.Text.Length == 0) || (AdminRegDoctorForm.IsVisible && AdminDoctorMiddleName.Text.Length == 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name is required field and cannot be empty!");
                return false;
            }
            else if ((AdminRegPatientForm.IsVisible && AdminPatientMiddleName.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible && AdminDoctorMiddleName.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Middle Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateLastName()
        {

            if ((AdminRegPatientForm.IsVisible && AdminPatientFamilyName.Text.Length == 0) || (AdminRegDoctorForm.IsVisible && AdminDoctorFamilyName.Text.Length == 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Last Name is required field and cannot be empty!");
                return false;
            }
            else if ((AdminRegPatientForm.IsVisible && AdminPatientFamilyName.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible && AdminPatientFamilyName.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Last Name cannot contain digits!");
                return false;
            }
            return true;
        }

        private bool ValidateMobilePhone()
        {
            if ((AdminRegPatientForm.IsVisible && AdminPatientMobilePhone.Text.Length != 10) || (AdminRegDoctorForm.IsVisible && AdminDoctorMobilePhone.Text.Length != 10) || (AdminRegHospitalForm.IsVisible && AdminHospitalMobilePhone.Text.Length != 10))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Mobile Phone cannot be more or less than 10 digits!");
                return false;
            }
            else if ((AdminRegPatientForm.IsVisible && !AdminPatientMobilePhone.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegDoctorForm.IsVisible && !AdminDoctorMobilePhone.Text.ToString().All(c => char.IsDigit(c))) || (AdminRegHospitalForm.IsVisible && !AdminHospitalMobilePhone.Text.ToString().All(c => char.IsDigit(c))))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Mobile Phone can contain only digits!");
                return false;
            }
            return true;
        }
        private bool ValidateAddress()
        {
            if ((AdminRegPatientForm.IsVisible && AdminPatientAddress.Text.Length <= 0) || (AdminRegDoctorRecord.IsVisible && AdminDoctorAddress.Text.Length <= 0) || (AdminRegHospitalForm.IsVisible && AdminHospitalAddress.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Address cannot be empty!");
                return false;
            }

            return true;
        }
        private bool ValidateDoctorSpecialization()
        {
            if ((AdminRegDoctorForm.IsVisible && AdminDoctorSpecialization.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Specialization cannot be empty!");
                return false;
            }

            return true;
        }
        private bool ValidateHospitalOwner()
        {
            if ((AdminRegHospitalForm.IsVisible && AdminHospitalOwner.Text.Length <= 0))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Owner cannot be empty!");
                return false;
            }

            return true;
        }
        private bool ValidateDate()
        {
            if ((DoctorPatientVisitForm.IsVisible && DoctorVisitDate.SelectedDate == null) || (DoctorReservationsForm.IsVisible && DoctorReservationDate.SelectedDate == null) || (HospitalPatientForm.IsVisible && HospitalPatientDate.SelectedDate == null)
                || (HospitalReservationForm.IsVisible && HospitalReservationDate.SelectedDate == null) || (PatientReservationsForm.IsVisible && PatientReservationsDate.SelectedDate == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Date cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateTime()
        {
            if ((DoctorPatientVisitForm.IsVisible && DoctorVisitTime.SelectedTime == null) || (DoctorReservationsForm.IsVisible && DoctorReservationTime.SelectedTime == null) || (HospitalPatientForm.IsVisible && HospitalPatientTime.SelectedTime == null)
                || (HospitalReservationForm.IsVisible && HospitalReservationTime.SelectedTime == null) || (PatientReservationsForm.IsVisible && PatientReservationsTime.SelectedTime == null))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Time cannot be empty!");
                return false;
            }
            return true;
        }
        private void PUTVisitsRequest(string BasicAuthentication, string Guid, JObject Visit)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/visits/{Guid}", RequestType.PUT)
                            .BasicAuthentication(BasicAuthentication)
                            .BodyData(Visit)
                            .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                            .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Updating Info Message", "The Visit was successfully updated!");
            }
        }
        private void PUTReservationRequest(string BasicAuthentication, string Guid, JObject Reservation)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/reservations/{Guid}", RequestType.PUT)
                          .BasicAuthentication(BasicAuthentication)
                          .BodyData(Reservation)
                          .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                          .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Updating Info Message", "The Reservation was successfully updated!");
            }
        }
        private void PUTPatientRequest(string BasicAuthentication, string Guid, JObject Patient)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/patients/{Guid}", RequestType.PUT)
                         .BasicAuthentication(BasicAuthentication)
                         .BodyData(Patient)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Updating Info Message", "The Patient was successfully updated!");
            }
        }
        private void PUTDoctorRequest(string BasicAuthentication, string Guid, JObject Doctor)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/doctors/{Guid}", RequestType.PUT)
                         .BasicAuthentication(BasicAuthentication)
                         .BodyData(Doctor)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Updating Info Message", "The Doctor was successfully updated!");
            }
        }
        private void PUTHospitalRequest(string BasicAuthentication, string Guid, JObject Hospital)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/hospitals/{Guid}", RequestType.PUT)
                         .BasicAuthentication(BasicAuthentication)
                         .BodyData(Hospital)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Updating Info Message", "The Hospital was successfully updated!");
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditedRecord is Visit && User.UserRole.Equals("Doctor"))
            {
                PUTVisitsRequest(User.AuthenticationCredentials, ((Visit)EditedRecord).Guid, new JObjectBuilder().With(visit => visit.VisitTime = ((DoctorVisitDate.SelectedDate.Value).Date.Add(DoctorVisitTime.SelectedTime.Value.TimeOfDay))).Build());
                this.Close();
            }
            else if (EditedRecord is Reservation && User.UserRole.Equals("Doctor"))
            {
                PUTReservationRequest(User.AuthenticationCredentials, ((Reservation)EditedRecord).Guid, new JObjectBuilder().With(reservation => reservation.ReservationTime = ((DoctorReservationDate.SelectedDate.Value).Date.Add(DoctorReservationTime.SelectedTime.Value.TimeOfDay))).With(reservation => reservation.Reason = DoctorReservationReason.Text).Build());
                this.Close();
            }
            else if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
            {
                PUTPatientRequest(User.AuthenticationCredentials, ((Patient)EditedRecord).Guid, new JObjectBuilder().With(patient => patient.Name = ((Patient)EditedRecord).Name)
                                                                                                                    .With(patient => patient.MiddleName = ((Patient)EditedRecord).MiddleName)
                                                                                                                    .With(patient => patient.FamilyName = ((Patient)EditedRecord).FamilyName)
                                                                                                                    .With(patient => patient.Egn = ((Patient)EditedRecord).Egn)
                                                                                                                    .With(patient => patient.Age = ((Patient)EditedRecord).Age)
                                                                                                                    .With(patient => patient.MobilePhone = ((Patient)EditedRecord).MobilePhone)
                                                                                                                    .With(patient => patient.Address = ((Patient)EditedRecord).Address).Build());
                this.Close();
            }
            else if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
            {
                PUTDoctorRequest(User.AuthenticationCredentials, ((Doctor)EditedRecord).Guid, new JObjectBuilder().With(doctor => doctor.Name = ((Doctor)EditedRecord).Name)
                                                                                                     .With(doctor => doctor.MiddleName = ((Doctor)EditedRecord).MiddleName)
                                                                                                     .With(doctor => doctor.FamilyName = ((Doctor)EditedRecord).FamilyName)
                                                                                                     .With(doctor => doctor.Egn = ((Doctor)EditedRecord).Egn)
                                                                                                     .With(doctor => doctor.MobilePhone = ((Doctor)EditedRecord).MobilePhone)
                                                                                                     .With(doctor => doctor.Address = ((Doctor)EditedRecord).Address)
                                                                                                     .With(doctor => doctor.Specialization = ((Doctor)EditedRecord).Specialization)
                                                                                                     .Build());
                this.Close();
            }
            else if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
            {
                PUTHospitalRequest(User.AuthenticationCredentials, ((Hospital)EditedRecord).Guid, new JObjectBuilder().With(hospital => hospital.Name = ((Hospital)EditedRecord).Name)
                                                                                      .With(hospital => hospital.Owner = ((Hospital)EditedRecord).Owner)
                                                                                      .With(hospital => hospital.MobilePhone = ((Hospital)EditedRecord).MobilePhone)
                                                                                      .With(hospital => hospital.Address = ((Hospital)EditedRecord).Address).Build());
                this.Close();
            }
            else if (EditedRecord is Visit && User.UserRole.Equals("Hospital"))
            {
                PUTVisitsRequest(User.AuthenticationCredentials, ((Visit)EditedRecord).Guid, new JObjectBuilder().With(visit => visit.VisitTime = ((HospitalPatientDate.SelectedDate.Value).Date.Add(HospitalPatientTime.SelectedTime.Value.TimeOfDay))).Build());
                this.Close();
            }

            else if (EditedRecord is Reservation && User.UserRole.Equals("Hospital"))
            {
                PUTReservationRequest(User.AuthenticationCredentials, ((Reservation)EditedRecord).Guid, new JObjectBuilder().With(reservation => reservation.ReservationTime = ((HospitalReservationDate.SelectedDate.Value).Date.Add(HospitalReservationTime.SelectedTime.Value.TimeOfDay))).Build());
                this.Close();
            }
        }
        private void DELETEVisitRequest(string BasicAuthentication, string Guid)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/visits/{Guid}", RequestType.DELETE)
                         .BasicAuthentication(BasicAuthentication)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Deleting Info Message", "The Visit was successfully deleted!");
            }
        }
        private void DELETEReservationRequest(string BasicAuthentication, string Guid)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/reservations/{Guid}", RequestType.DELETE)
                         .BasicAuthentication(BasicAuthentication)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Deleting Info Message", "The Reservation was successfully deleted!");
            }
        }
        private void DELETEPatientRequest(string BasicAuthentication, string Guid)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/patients/{Guid}", RequestType.DELETE)
                         .BasicAuthentication(BasicAuthentication)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Deleting Info Message", "The Patient was successfully deleted!");
            }
        }
        private void DELETEDoctorRequest(string BasicAuthentication, string Guid)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/doctors/{Guid}", RequestType.DELETE)
                         .BasicAuthentication(BasicAuthentication)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Deleting Info Message", "The Doctor was successfully deleted!");
            }
        }
        private void DELETEHospitalRequest(string BasicAuthentication, string Guid)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/hospitals/{Guid}", RequestType.DELETE)
                         .BasicAuthentication(BasicAuthentication)
                         .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                         .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Deleting Info Message", "The Hospital was successfully deleted!");
            }
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditedRecord is Visit && User.UserRole.Equals("Doctor"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEVisitRequest(User.AuthenticationCredentials, ((Visit)EditedRecord).Guid);
                    this.Close();
                });
                ;
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Reservation && User.UserRole.Equals("Doctor"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEReservationRequest(User.AuthenticationCredentials, ((Reservation)EditedRecord).Guid);
                    this.Close();
                });
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
            {

                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEPatientRequest(User.AuthenticationCredentials, ((Patient)EditedRecord).Guid);
                    this.Close();
                });
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEDoctorRequest(User.AuthenticationCredentials, ((Doctor)EditedRecord).Guid);
                    this.Close();
                });
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
               {
                   DELETEHospitalRequest(User.AuthenticationCredentials, ((Hospital)EditedRecord).Guid);
                   this.Close();
               });
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Visit && User.UserRole.Equals("Hospital"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEVisitRequest(User.AuthenticationCredentials, ((Visit)EditedRecord).Guid);
                    this.Close();
                });
                MessageForm.ShowDialog();
                return;
            }
            else if (EditedRecord is Reservation && User.UserRole.Equals("Hospital"))
            {
                MessageForm MessageForm = new MessageForm("Confirmation Message", "Do you really want to delete this ?", () =>
                {
                    DELETEReservationRequest(User.AuthenticationCredentials, ((Reservation)EditedRecord).Guid);
                    this.Close();
                });
                MessageForm.ShowDialog();
                return;
            }
        }
        private void AdminPatientName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).Name = AdminPatientName.Text;
        }
        private void AdminPatientMiddleName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).MiddleName = AdminPatientMiddleName.Text;
        }
        private void AdminPatientFamilyName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).FamilyName = AdminPatientFamilyName.Text;
        }
        private void AdminPatientAge_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).Age = Int32.Parse(AdminPatientAge.Text);
        }
        private void AdminPatientEgn_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).Egn = AdminPatientEgn.Text;
        }
        private void AdminPatientAddress_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).Address = AdminPatientAddress.Text;
        }
        private void AdminPatientMobilePhone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Patient && User.UserRole.Equals("Admin"))
                ((Patient)EditedRecord).MobilePhone = AdminPatientMobilePhone.Text;
        }
        private void AdminDoctorName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).Name = AdminDoctorName.Text;
        }
        private void AdminDoctorMiddleName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).MiddleName = AdminDoctorMiddleName.Text;
        }
        private void AdminDoctorFamilyName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).FamilyName = AdminDoctorFamilyName.Text;

        }
        private void AdminDoctorEgn_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).Egn = AdminDoctorEgn.Text;
        }
        private void AdminDoctorAddress_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).Address = AdminDoctorAddress.Text;
        }
        private void AdminDoctorMobilePhone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).MobilePhone = AdminDoctorMobilePhone.Text;
        }
        private void AdminDoctorSpecialization_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Doctor && User.UserRole.Equals("Admin"))
                ((Doctor)EditedRecord).Specialization = AdminDoctorSpecialization.Text;
        }
        private void AdminHospitalName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
                ((Hospital)EditedRecord).Name = AdminHospitalName.Text;
        }
        private void AdminHospitalOwner_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
                ((Hospital)EditedRecord).Owner = AdminHospitalOwner.Text;
        }
        private void AdminHospitalAddress_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
                ((Hospital)EditedRecord).Address = AdminHospitalAddress.Text;
        }
        private void AdminHospitalMobilePhone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (EditedRecord is Hospital && User.UserRole.Equals("Admin"))
                ((Hospital)EditedRecord).MobilePhone = AdminHospitalMobilePhone.Text;
        }
    }
}