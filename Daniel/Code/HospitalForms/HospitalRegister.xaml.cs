namespace PS_Hospital_System_Project_2019
{
    using Newtonsoft.Json.Linq;
    using PS_Hospital_System_Project_2019.SystemClases;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Input;
    using MessageBox = SystemClases.MessageBox;

    public partial class HospitalRegister : Window
    {
        User User { get; set; }
        Hospital NewHospital { get; set; }
        public HospitalRegister(User user)
        {
            InitializeComponent();
            this.DataContext = this;
            User = user;
        }
        private void POSTHospitalRequest(string BasicAuthentication, JObject Hospital)
        {
            var createdUser = HttpRequest.Of("https://localhost:44348/api/hospitals", RequestType.POST)
                              .BasicAuthentication(BasicAuthentication)
                              .BodyData(Hospital)
                              .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                              .Execute()
                              .DeserializeBody<NewCreatedUser>();
            if (createdUser != null)
            {
                MessageBox.ShowMessageBoxInfo("Hospital Registration Info", $"Username:{createdUser.Username}\nPassword:{createdUser.Password}");
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
        private bool ValidateHospitalName()
        {
            if (Name.Text.Length > 255)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Name cannot be more than 255 characters!");
                return false;
            }
            else if (Name.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Name cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalOwner()
        {
            if (Owner.Text.Length > 255)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Owner cannot be more than 255 characters!");
                return false;
            }
            else if (Owner.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Owner cannot contain digits!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalAddress()
        {
            if (Address.Text.ToString().Length <= 0)
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital's Address cannot be empty!");
                return false;
            }
            return true;
        }
        private bool ValidateHospitalMobilePhone()
        {
            if (MobilePhone.Text.ToString().Length <= 0 || MobilePhone.Text.ToString().All(c => char.IsWhiteSpace(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Mobile Phone cannot be empty!");
                return false;
            }
            else if (!MobilePhone.Text.ToString().All(c => char.IsDigit(c)))
            {
                MessageBox.ShowMessageBoxInfo("Wrong Data Input", "The Hospital Mobile phone can contain only digts!");
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateHospitalName())
                return;
            else if (!ValidateHospitalOwner())
                return;
            else if (!ValidateHospitalMobilePhone())
                return;
            else if (!ValidateHospitalAddress())
                return;
            else
            {
                POSTHospitalRequest(User.AuthenticationCredentials, new JObjectBuilder().With(hospital => hospital.Name = this.Name.Text)
                                                                                        .With(hospital => hospital.Owner = this.Owner.Text)
                                                                                        .With(hospital => hospital.MobilePhone = this.MobilePhone.Text)
                                                                                        .With(hospital => hospital.Address = this.Address.Text)
                                                                                        .Build());
                this.Close();
            }
        }
    }
}
