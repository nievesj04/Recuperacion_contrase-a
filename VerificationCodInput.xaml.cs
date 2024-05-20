namespace SpinningTrainer
{
    public partial class VerificationCodInput : ContentPage
    {
        public VerificationCodInput()
        {
            InitializeComponent();
        }

        private void btn_verificationCodInput(object sender, EventArgs e)
        {
            int codEmail = codEmail.Text;

            bool verificacion = CodEmail(verificationCodInput);

            if (verificacion == true) { /* Inicializar pantalla de cambio de contraseña */ }
            else { Console.WriteLine("El código no coincide con el codigo enviado al correo, intentelo de nuevo"); }
            
        }
    }
}