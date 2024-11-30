using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CREDITOS
{
    public partial class Form1 : Form
    {
        private Panel loginPanel;
        private PictureBox userPicture;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button loginButton;
        private LinkLabel registerLink;
        private PictureBox creditImage;
        private Label creditInfoLabel;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Inicio de Sesión - Aplicación de Crédito Tienda Departamental";
            this.Size = new Size(600, 700);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;


            this.Paint += (sender, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(0, 51, 102),
                    Color.FromArgb(102, 178, 255),
                    90F);
                e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
            };


            loginPanel = new Panel
            {
                Size = new Size(400, 500),
                Location = new Point((this.ClientSize.Width - 400) / 2, (this.ClientSize.Height - 500) / 2),
                BackColor = Color.FromArgb(255, 255, 255, 255)
            };
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(loginPanel);


            Label titleLabel = new Label
            {
                Text = "CREDITOS",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(350, 50),
                Location = new Point((loginPanel.Width - 350) / 2, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            loginPanel.Controls.Add(titleLabel);


            creditImage = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\cre.png"), // Cambiar por la ruta correcta de la imagen
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point((loginPanel.Width - 100) / 2, 70)
            };
            loginPanel.Controls.Add(creditImage);


            userPicture = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\usuario.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(30, 30),
                Location = new Point(20, 190)
            };
            loginPanel.Controls.Add(userPicture);


            usernameTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(60, 190),
                Size = new Size(300, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Gray,
                Text = "Ingrese su nombre de usuario"
            };
            usernameTextBox.GotFocus += (sender, e) =>
            {
                if (usernameTextBox.Text == "Ingrese su nombre de usuario")
                {
                    usernameTextBox.Text = "";
                    usernameTextBox.ForeColor = Color.Black;
                }
            };
            usernameTextBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
                {
                    usernameTextBox.Text = "Ingrese su nombre de usuario";
                    usernameTextBox.ForeColor = Color.Gray;
                }
            };
            loginPanel.Controls.Add(usernameTextBox);


            PictureBox passwordIcon = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen4.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(30, 30),
                Location = new Point(20, 250)
            };
            loginPanel.Controls.Add(passwordIcon);


            passwordTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Location = new Point(60, 250),
                Size = new Size(300, 30),
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Gray,
                Text = "Ingrese su contraseña"
            };
            passwordTextBox.GotFocus += (sender, e) =>
            {
                if (passwordTextBox.Text == "Ingrese su contraseña")
                {
                    passwordTextBox.Text = "";
                    passwordTextBox.ForeColor = Color.Black;
                    passwordTextBox.UseSystemPasswordChar = true;
                }
            };
            passwordTextBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                {
                    passwordTextBox.UseSystemPasswordChar = false;
                    passwordTextBox.Text = "Ingrese su contraseña";
                    passwordTextBox.ForeColor = Color.Gray;
                }
            };
            loginPanel.Controls.Add(passwordTextBox);


            loginButton = new Button
            {
                Text = "Iniciar Sesión",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(350, 50),
                Location = new Point(25, 310),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            loginButton.Click += new EventHandler(LoginButton_Click);
            loginButton.MouseEnter += (sender, e) => loginButton.BackColor = Color.FromArgb(0, 153, 255); // Cambiar color al pasar el mouse para proporcionar retroalimentación visual
            loginButton.MouseLeave += (sender, e) => loginButton.BackColor = Color.FromArgb(0, 102, 204);
            loginPanel.Controls.Add(loginButton);

            registerLink = new LinkLabel
            {
                Text = "¿No tienes una cuenta? Regístrate aquí",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Location = new Point(25, 380),
                Size = new Size(350, 30),
                LinkColor = Color.Blue, // Cambiar el color del enlace para que sea más visible
                TextAlign = ContentAlignment.MiddleCenter
            };
            registerLink.Click += new EventHandler(RegisterLink_Click);
            loginPanel.Controls.Add(registerLink);
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {

            string username = "Raquel";
            string password = "123456";

            if (ContainsInappropriateWords(usernameTextBox.Text) || ContainsInappropriateWords(passwordTextBox.Text))
            {
                MessageBox.Show("Se detectaron palabras inapropiadas. Por favor, ingrese credenciales válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) ||
                usernameTextBox.Text == "Ingrese su nombre de usuario" || passwordTextBox.Text == "Ingrese su contraseña")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usernameTextBox.Text == username && passwordTextBox.Text == password)
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Información inválida, por favor inténtalo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void RegisterLink_Click(object sender, EventArgs e)
        {

            Form registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();

        }

        private bool ContainsInappropriateWords(string input)
        {
            string[] inappropriateWords = { "puta", "perra", "pendeja", "idiota", "estupida", "wey" }; // Palabras inapropiadas de ejemplo
            foreach (string word in inappropriateWords)
            {
                if (input.ToLower().Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
