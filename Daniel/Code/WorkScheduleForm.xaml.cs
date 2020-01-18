using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PS_Hospital_System_Project_2019
{
    
    public partial class WorkScheduleForm : Window
    {
        public ObservableCollection<Hospital> Hospitals { get; set; }
        public WorkScheduleForm()
        {
            InitializeComponent();
           // Hospitals = new ObservableCollection<Hospital>();
          //  Hospitals.Add(new Hospital( "saintSofiaHospital", "St. Sofia", "Daniel Bogoev", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
           // Hospitals.Add(new Hospital( "saintSofiaHospital", "Sofia Med", "Valentin Nikolaev", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
           // Hospitals.Add(new Hospital( "saintSofiaHospital", "Pirogov", "Nedqlko Qnkov", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
        }
        public WorkScheduleForm(string WorkScheduleForm)
        {
            InitializeComponent();
            Hospitals = new ObservableCollection<Hospital>();
            //Hospitals.Add(new Hospital( "saintSofiaHospital", "St. Sofia", "Daniel Bogoev", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
           // Hospitals.Add(new Hospital( "saintSofiaHospital", "Sofia Med", "Valentin Nikolaev", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
           // Hospitals.Add(new Hospital( "saintSofiaHospital", "Pirogov", "Nedqlko Qnkov", "Bul. Bulgaria 79, block 119 - A, Harmanli", "0896490084", "Test dalskjdalkd"));
            ShowForm(WorkScheduleForm);
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
        private void ShowForm(string WorkScheduleForm)
        {
            this.DataContext = this;
            switch (WorkScheduleForm)
            {
                case "DoctorWSForm":
                    this.DoctorWSHospital.ItemsSource = Hospitals;
                    this.DoctorWSHospital.DisplayMemberPath = "HospitalName";
                    this.saveBtn.Visibility = Visibility.Visible;
                    this.DoctorWSForm.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
