namespace PS_Hospital_System_Project_2019
{
    using PS_Hospital_System_Project_2019.SystemClases;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Windows;
    using System.Windows.Input;
    using MessageBox = SystemClases.MessageBox;

    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
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

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Length > 0 && Password.Password.Length > 0)
            {
                POSTLoginRequest(Username.Text.ToString(), Password.Password.ToString());
            }
            else
            {
                MessageForm MessageForm = new MessageForm("Warning Data Input", "Username/Password cannot be empty!");
                MessageForm.ShowDialog();
            }

        }
        private void POSTLoginRequest(string Username, string Password)
        {
            User User = null;
            var BasicAuthentication = Base64Encode($"{Username}:{Password}");
            var user = HttpRequest.Of("https://localhost:44348/api/login", RequestType.POST)
                             .BasicAuthentication(BasicAuthentication)
                             .OnError(MessageBox.ShowMessageBoxError("Warning Data Input", ""))
                             .Execute()
                             .DeserializeBody<User>();
            if (user != null)
            {
                User = user;
                User.AuthenticationCredentials = BasicAuthentication;
                // SHOW FORM
                ShowForm(User);
            }
        }

        private void ShowForm(User User)
        {
            switch (User.UserRole)
            {
                case "Patient":
                    PatientForm PatientForm = new PatientForm(User);
                    this.Close();
                    PatientForm.ShowDialog();
                    break;
                case "Doctor":
                    DoctorForm DoctorForm = new DoctorForm(User);
                    this.Close();
                    DoctorForm.ShowDialog();
                    break;
                case "Hospital":
                    HospitalForm HospitalForm = new HospitalForm(User);
                    this.Close();
                    HospitalForm.ShowDialog();
                    break;
                case "Admin":
                    AdminForm AdminForm = new AdminForm(User);
                    this.Close();
                    AdminForm.ShowDialog();
                    break;
            }

        }
        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
