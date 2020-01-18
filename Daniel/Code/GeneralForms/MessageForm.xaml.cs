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
   
    public partial class MessageForm : Window
    {
        public string MessageTitle { set; get; }
        public string MessageContent { set; get; }
        public Action ActionOnConfirm { get; set; }

        public MessageForm(string MessageTitle, string MessageContent)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MessageTitle = MessageTitle;
            this.MessageContent = MessageContent;
        }
        public MessageForm(string MessageTitle, string MessageContent, Action ActionOnConfirm)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MessageTitle = MessageTitle;
            this.MessageContent = MessageContent;
            this.ActionOnConfirm = ActionOnConfirm;
            ShowConfirmationMessageBox();
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
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            ActionOnConfirm();
            this.Close();
        }
        private void ShowConfirmationMessageBox()
        {
                this.ConfirmBtn.Visibility = Visibility.Visible;
                this.CancelBtn.Visibility = Visibility.Visible;
        }
        
    }
}
