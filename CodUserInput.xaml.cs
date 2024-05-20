namespace SpinningTrainer
{
    public partial class CodUserInput : ContentPage
    {
        public CodUserInput()
        {
            InitializeComponent();
        }

        private void btn_sendCodUsua(object sender, EventArgs e)
        {
            string contraCodUsua = contraCodUsuaEntry.Text;

            string email = emailUsua(contraCodUsua);

            if (email != "false") { 

                SendRandomCode(email);
                
                // Inicializar pantalla => VerificationCodeInput.xaml 
            }
            else { Console.WriteLine("Codigo de Usuario no encontrado"); }
  
        }
    }
}