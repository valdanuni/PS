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

    public partial class DoctorsList : Window
    {
        public ObservableCollection<Doctor> HospitalDoctors { get; set; }
        public User User { get; set; }
        public DoctorsList(User User, ObservableCollection<Doctor> DoctorList)
        {
            InitializeComponent();
            this.User = User;
            HospitalDoctors = DoctorList;
            Doctors.ItemsSource = DoctorList;
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
        private void POSTDoctorInfoRequest(string param, string BasicAuthentication, Doctor Doctor)
        {
            var httpResponse = HttpRequest.Of($"https://localhost:44348/api/hospitals/{param}/doctors", RequestType.POST)
                .BasicAuthentication(BasicAuthentication)
                .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", "Adding of Doctor cannot be done!"))
                .BodyData(Doctor.Guid)
                .Execute();
            if (httpResponse.IsSuccessful())
            {
                MessageBox.ShowMessageBoxInfo("Doctor Creation Info", "The Doctor was added successfully!");
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            POSTDoctorInfoRequest(User.Guid, User.AuthenticationCredentials, HospitalDoctors[Doctors.SelectedIndex]);
            this.Close();
        }
    }
}
