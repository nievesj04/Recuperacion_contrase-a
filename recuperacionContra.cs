using System;
using System.Data.SqlClient; 

namespace RecuperarContraseña
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Recuperanco email desde la base de datos
        public string emailUsua(string codUsuaIngresado)
        {
            int codUsua = codUsuaIngresado;
            string serverName = ""; // Nombre del servidor
            string dbName = ""; // Nombre de la Base de Datos
            string userId = ""; // Id del usuario DB
            string passwordConnection = ""; // Contraseña de conexión
            
            using (SqlConnection connection = new SqlConnection($"Data Source={serverName}; Initial Catalog={dbName}; Persist Security Info=True; User ID={userId}; Password={passwordConnection}"))
            {
                string query = $"SELECT Email\n" + 
                                "FROM Usuarios\n"+
                                "WHERE CodUsua = @codUsua\n";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@codUsua", codUsuaIngresado);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (cmd.ExecuteNonQuery() == 1) 
                            {
                                if (reader.Read())
                                {
                                    string emailUsuario = reader["Email"].ToString();
                                    return emailUsuario;
                                }
                                else { return "false"; }
                            }
                            else { return "false"; }
                        }
                    }
                }   
            }
        }

        // Numero Random 
        public int RandomNumber()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(1000000, 10000000));

            var random = new Random(seed);
            var randomNumber = random.Next(10000000, 100000000);

            return randomNumber;
        }

        // Envio y validación del codigo de seguridad
        public void SendRandomCode(string email)
        {
            // Envio del codigo al correo electronico
        }

        public bool CodEmail(int codEmail)
        {
            if (codEmail == RandomNumber()) { return true; }
            else { return false; }
        }

        public void ChangePassword(string newPassword)
        {
            string serverName = ""; // Nombre del servidor
            string dbName = ""; // Nombre de la Base de Datos
            string userId = ""; // Id del usuario DB
            string passwordConnection = ""; // Contraseña de conexión

            // Contraseña para desencriptar la contraseña de la base de datos
            using (SqlConnection connection = new SqlConnection($"Data Source={serverName}; Initial Catalog={dbName}; Persist Security Info=True; User ID={userId}; Password={passwordConnection}"))
            {
                string query = "UPDATE Usuarios SET Contra = ENCRYPBYPASSPHRASE('12345', @newPassword)\n" + 
                                " WHERE CodUsua = @codUsua";
                    
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@codUsua", codUsua);

                    cmd.ExecuteNonQuery();
                }   
            }
        }
    }
}