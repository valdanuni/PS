using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Hospital_System_Project_2019.SystemClases
{
    public static class MessageBox
    {
        public static Action<string> ShowMessageBoxError(string MessageTitle, string MessageBody)
        {
            return error =>
            {
                MessageForm MessageForm = new MessageForm(MessageTitle, error ?? MessageBody);
                MessageForm.ShowDialog();
            };
        }
        public static void ShowMessageBoxInfo(string MessageTitle, string MessageBody)
        {
            MessageForm MessageForm = new MessageForm(MessageTitle, MessageBody);
            MessageForm.ShowDialog();
        }
    }
}
