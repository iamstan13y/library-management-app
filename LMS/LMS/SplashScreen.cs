namespace LMS
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        int progress = 0;
        private void TmrLoad_Tick(object sender, EventArgs e)
        {
            string initialText = "Loading, Please wait";
            progress++;
            if (progress <= 20)
            {
                lblLoading.Text += ".";
                if (progress % 4 == 0) lblLoading.Text = initialText;
            }
            else
            {
                LoginForm loginForm = new();
                loginForm.Show();
                tmrLoad.Stop();
                Close();
            }
        }
    }
}