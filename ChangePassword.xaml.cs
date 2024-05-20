namespace SpinningTrainer
{
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btn_changePassword(object sender, EventArgs e)
        {
            string newPassword = newPasswordEntry.Text;
            string confirPassword = confirPasswordEntry.Text;

            string email = emailUsua(contraCodUsua);

            if (newPassword == confirPassword) 
            {
                ChangePassword(newPassword);

                // Inicializar el menú principal de la app
                
            } 
            else { Console.WriteLine("Las contraseñas no coinciden"); }
  
        }
    }
}