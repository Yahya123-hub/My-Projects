using System;
using System.Windows.Forms;
using AIMLbot;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using final_gui_Template;


namespace Support
{
    public partial class chat : Form
    {
        public chat()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Bot AI = new Bot();
            AI.loadSettings();
            AI.loadAIMLFromFiles();
            AI.isAcceptingUserInput = false;
            User myuser = new User("Username Here", AI);
            AI.isAcceptingUserInput = true;
            Request r = new Request(txt_input.Text, myuser, AI);
            Result res = AI.Chat(r);
            txt_output.Text = "Output:" + res.Output;
        }

        private void chat_Load(object sender, EventArgs e)
        {

        }
    }
}
