using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CREDITOS
{
    public partial class RegisterForm : Form
    {
        private TextBox nameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private PictureBox userPicture;
        private Button uploadINEButton;
        private Button uploadAddressProofButton;
        private Button submitButton;
        private Button backButton;
        private Button exitButton;
        private OpenFileDialog openFileDialog;
        private Label uploadStatusLabel;

        public RegisterForm()
        {
            InitializeComponent();
            this.Text = "Registro de Usuario - Aplicación de Crédito Tienda Departamental";
            this.Size = new Size(600, 900);
            this.StartPosition = FormStartPosition.CenterScreen;


            this.Paint += (sender, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(0, 51, 102),
                    Color.FromArgb(102, 178, 255),
                    90F);
                e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
            };


            Panel registerPanel = new Panel
            {
                Size = new Size(500, 800),
                Location = new Point((this.ClientSize.Width - 500) / 2, (this.ClientSize.Height - 800) / 2),
                BackColor = Color.FromArgb(255, 255, 255)
            };
            registerPanel.Anchor = AnchorStyles.None;
            registerPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(registerPanel);


            userPicture = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen8.png"), // Icono para representar al usuario
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(100, 100),
                Location = new Point((registerPanel.Width - 100) / 2, 20)
            };
            registerPanel.Controls.Add(userPicture);


            Label nameLabel = new Label
            {
                Text = "Nombre:",
                Location = new Point(50, 140),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(nameLabel);

            nameTextBox = new TextBox
            {
                Location = new Point(200, 140),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su nombre" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            nameTextBox.Leave += (sender, e) =>
            {
                nameTextBox.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nameTextBox.Text.ToLower());
            };
            registerPanel.Controls.Add(nameTextBox);


            Label lastNameLabel = new Label
            {
                Text = "Apellido:",
                Location = new Point(50, 190),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(lastNameLabel);

            lastNameTextBox = new TextBox
            {
                Location = new Point(200, 190),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su apellido" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            lastNameTextBox.Leave += (sender, e) =>
            {
                lastNameTextBox.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastNameTextBox.Text.ToLower());
            };
            registerPanel.Controls.Add(lastNameTextBox);


            Label emailLabel = new Label
            {
                Text = "Correo:",
                Location = new Point(50, 240),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(emailLabel);

            emailTextBox = new TextBox
            {
                Location = new Point(200, 240),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su correo electrónico" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            emailTextBox.Leave += EmailTextBox_Leave;
            registerPanel.Controls.Add(emailTextBox);


            Label phoneLabel = new Label
            {
                Text = "Teléfono:",
                Location = new Point(50, 290),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(phoneLabel);

            phoneTextBox = new TextBox
            {
                Location = new Point(200, 290),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su número de teléfono" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            phoneTextBox.KeyPress += PhoneTextBox_KeyPress;
            registerPanel.Controls.Add(phoneTextBox);


            Label usernameLabel = new Label
            {
                Text = "Usuario:",
                Location = new Point(50, 340),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(usernameLabel);

            usernameTextBox = new TextBox
            {
                Location = new Point(200, 340),
                Size = new Size(250, 30),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su nombre de usuario" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            registerPanel.Controls.Add(usernameTextBox);


            Label passwordLabel = new Label
            {
                Text = "Contraseña:",
                Location = new Point(50, 390),
                Size = new Size(150, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black
            };
            registerPanel.Controls.Add(passwordLabel);

            passwordTextBox = new TextBox
            {
                Location = new Point(200, 390),
                Size = new Size(250, 30),
                UseSystemPasswordChar = true,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                // PlaceholderText = "Ingrese su contraseña" (Comentario: PlaceholderText no es compatible en .NET Framework, use la simulación manual de placeholder)
            };
            registerPanel.Controls.Add(passwordTextBox);


            CheckBox showPasswordCheckBox = new CheckBox
            {
                Text = "Mostrar contraseña",
                Location = new Point(200, 420),
                Size = new Size(150, 20),
                ForeColor = Color.Black
            };
            showPasswordCheckBox.CheckedChanged += (sender, e) =>
            {
                passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            };
            registerPanel.Controls.Add(showPasswordCheckBox);


            uploadINEButton = new Button
            {
                Text = "Subir Foto INE",
                Location = new Point(50, 460),
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            uploadINEButton.Click += UploadINEButton_Click;
            registerPanel.Controls.Add(uploadINEButton);


            uploadAddressProofButton = new Button
            {
                Text = "Subir Comprobante de Domicilio (PDF)",
                Location = new Point(50, 510),
                Size = new Size(300, 30),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            uploadAddressProofButton.Click += UploadAddressProofButton_Click;
            registerPanel.Controls.Add(uploadAddressProofButton);

            uploadStatusLabel = new Label
            {
                Location = new Point(50, 540),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Gray,
                Text = "Ningún archivo seleccionado"
            };
            registerPanel.Controls.Add(uploadStatusLabel);

            // Botón de enviar
            submitButton = new Button
            {
                Text = "Registrar",
                Location = new Point(200, 580),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            submitButton.Click += SubmitButton_Click;
            submitButton.MouseEnter += (sender, e) => submitButton.BackColor = Color.FromArgb(0, 153, 255);
            submitButton.MouseLeave += (sender, e) => submitButton.BackColor = Color.FromArgb(0, 102, 204);
            registerPanel.Controls.Add(submitButton);


            backButton = new Button
            {
                Text = "Regresar",
                Location = new Point(100, 640),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            backButton.Click += BackButton_Click;
            backButton.MouseEnter += (sender, e) => backButton.BackColor = Color.FromArgb(150, 200, 255);
            backButton.MouseLeave += (sender, e) => backButton.BackColor = Color.FromArgb(100, 149, 237);
            registerPanel.Controls.Add(backButton);


            exitButton = new Button
            {
                Text = "Salir",
                Location = new Point(300, 640),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(211, 47, 47),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            exitButton.Click += ExitButton_Click;
            exitButton.MouseEnter += (sender, e) => exitButton.BackColor = Color.FromArgb(255, 69, 69);
            exitButton.MouseLeave += (sender, e) => exitButton.BackColor = Color.FromArgb(211, 47, 47);
            registerPanel.Controls.Add(exitButton);
        }
        private void UploadINEButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "Imagenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Seleccione una imagen del INE"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Imagen del INE cargada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uploadStatusLabel.Text = "Imagen del INE: " + openFileDialog.FileName;
                uploadStatusLabel.ForeColor = Color.Green;
            }
        }

        private void UploadAddressProofButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "Documentos PDF (*.pdf)|*.pdf",
                Title = "Seleccione el comprobante de domicilio"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Comprobante de domicilio cargado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                uploadStatusLabel.Text = "Comprobante de domicilio: " + openFileDialog.FileName;
                uploadStatusLabel.ForeColor = Color.Green;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                 string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(phoneTextBox.Text) ||
                 string.IsNullOrWhiteSpace(usernameTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ContainsInappropriateWords(nameTextBox.Text) || ContainsInappropriateWords(lastNameTextBox.Text) ||
                ContainsInappropriateWords(usernameTextBox.Text) || ContainsInappropriateWords(passwordTextBox.Text))
            {
                MessageBox.Show("Se detectaron palabras inapropiadas. Por favor, ingrese datos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Registro completado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Close();

        }

        private void BackButton_Click(object sender, EventArgs e)
        {

            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private bool ContainsInappropriateWords(string input)
        {
            string[] inappropriateWords = { "puta", "perra", "pendeja", "idiota", "estupida", "wey", "zorra", "pendejo", "estupido" };
            foreach (string word in inappropriateWords)
            {
                if (input.ToLower().Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(emailTextBox.Text, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTextBox.Focus();
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
