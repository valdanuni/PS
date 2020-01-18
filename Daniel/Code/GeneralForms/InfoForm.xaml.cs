using System;
using System.Collections.Generic;
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
   
    public partial class InfoForm : Window
    {
        public Person Person { get; set; }
        public Hospital Hospital { get; set; }
        public InfoForm()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public InfoForm(object InfoObject)
        {
            InitializeComponent();
            this.DataContext = this;
           
            if (InfoObject != null )
            {
                this.showForm(InfoObject);
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
        private void showForm(object InfoObject)
        {
            if(InfoObject is Patient || InfoObject is Doctor)
            {
                if (InfoObject is Doctor)
                {
                    this.Specialization.Visibility = Visibility.Visible;
                    this.Age.Visibility = Visibility.Collapsed;
                }
                   
                this.showPersonForm(InfoObject);

            } else if(InfoObject is Hospital)
            {
                this.showHospitalForm(InfoObject);
            }
           
        }
      private void showPersonForm(object Person)
        {
            this.DataContext = this;
            var personTitle = (Person is Patient ? "Patient" : (Person is Doctor ? "Doctor" : ""));
            this.PersonInfoTitle.Text = $"{personTitle} Info";
            this.Person = (Person)Person;
            this.InfoGrid.Visibility = Visibility.Visible;
            this.PersonInfo.Visibility = Visibility.Visible;
        }
        private void showHospitalForm(object Hospital)
        {
            this.DataContext = this;
            this.Hospital = (Hospital) Hospital;
            this.InfoGrid.Visibility = Visibility.Visible;
            this.HospitalInfo.Visibility = Visibility.Visible; 
        }
    }

}
