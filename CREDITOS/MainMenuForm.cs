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
using System.Windows.Forms.DataVisualization.Charting;

namespace CREDITOS
{
    public partial class MainMenuForm : Form
    {
        private Panel menuPanel;
        private Button resumenButton;
        private Button consultasButton;
        private Button solicitarCreditoButton;
        private Button pagarCreditoButton;
        private Button comprarProductosButton;
        private Button perfilButton;
        private PictureBox resumenIcon;
        private PictureBox consultasIcon;
        private PictureBox solicitarCreditoIcon;
        private PictureBox pagarCreditoIcon;
        private PictureBox comprarProductosIcon;
        private PictureBox perfilIcon;
        private Panel contentPanel;
        private Label welcomeLabel;
        private PictureBox welcomeImage;

        public MainMenuForm()
        {
            InitializeComponent();
            this.Text = "Menú Principal - Aplicación de Crédito Tienda Departamental";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;


            this.Paint += (sender, e) =>
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle,
                    Color.FromArgb(0, 51, 102),
                    Color.FromArgb(102, 178, 255),
                    90F);
                e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
            };


            menuPanel = new Panel
            {
                Size = new Size(250, this.ClientSize.Height),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(150, 0, 51, 102),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10)
            };
            this.Controls.Add(menuPanel);

            int iconSpacing = 70;


            string[] buttonNames = { "Resumen", "Consultas", "Aumentar Crédito", "Pagar Crédito", "Catalogo", "Perfil", "Cerrar Sesión" };
            string[] iconPaths = {
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\asdfgh.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen111.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\aume.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\pagarc.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\carr.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen6.png",
        "C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\Imagen7.png"
    };
            EventHandler[] eventHandlers = {
        ResumenButton_Click,
        ConsultasButton_Click,
        SolicitarCreditoButton_Click,
        PagarCreditoButton_Click,
        ComprarProductosButton_Click,
        PerfilButton_Click,
        LogoutButton_Click
    };

            for (int i = 0; i < buttonNames.Length; i++)
            {

                if (!string.IsNullOrEmpty(iconPaths[i]))
                {
                    PictureBox icon = new PictureBox
                    {
                        Image = Image.FromFile(iconPaths[i]),
                        Size = new Size(40, 40),
                        Location = new Point(15, 30 + i * iconSpacing),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    menuPanel.Controls.Add(icon);
                }

                // Agregar botón
                Button menuButton = new Button
                {
                    Text = buttonNames[i],
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Size = new Size(160, 50),
                    Location = new Point(70, 25 + i * iconSpacing),
                    BackColor = (buttonNames[i] == "Cerrar Sesión") ? Color.FromArgb(211, 47, 47) : Color.FromArgb(0, 102, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 1, BorderColor = Color.White }
                };
                menuButton.Click += eventHandlers[i];
                menuPanel.Controls.Add(menuButton);
            }


            contentPanel = new Panel
            {
                Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height),
                Location = new Point(250, 0),
                BackColor = Color.FromArgb(255, 255, 255),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(contentPanel);

            welcomeLabel = new Label
            {
                Text = "¡Bienvenido a la Aplicación de Crédito!",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 600) / 2, 50),
                Size = new Size(600, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(welcomeLabel);


            welcomeImage = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\cre.png"), // Cambiar por la ruta correcta de la imagen
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(200, 200),
                Location = new Point((contentPanel.Width - 200) / 2, 150)
            };
            contentPanel.Controls.Add(welcomeImage);
        }
        private void ResumenButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título del resumen
            Label resumenTitle = new Label
            {
                Text = "Resumen de Crédito",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 400) / 2, 20),
                Size = new Size(400, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(resumenTitle);

            // Panel del resumen
            Panel resumenPanel = new Panel
            {
                Size = new Size(700, 450),
                Location = new Point((contentPanel.Width - 700) / 2, 100),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20) // Agregar padding para mejorar el espacio interno
            };
            contentPanel.Controls.Add(resumenPanel);

            // Datos del crédito
            Label creditoTotalLabel = new Label
            {
                Text = "Crédito Total: $3000",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), // Azul oscuro para mantener coherencia
                Location = new Point(20, 20),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(creditoTotalLabel);

            Label creditoDisponibleLabel = new Label
            {
                Text = "Crédito Disponible: $1500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                BackColor = Color.FromArgb(220, 235, 255), // Fondo azul claro para destacar disponibilidad
                Location = new Point(20, 70),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(creditoDisponibleLabel);

            Label creditoUtilizadoLabel = new Label
            {
                Text = "Crédito Utilizado: $1500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102), // Azul oscuro para mantener coherencia
                BackColor = Color.FromArgb(230, 240, 255), // Fondo azul más claro para resaltar
                Location = new Point(20, 120),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(creditoUtilizadoLabel);

            Label pagosVencidosLabel = new Label
            {
                Text = "Pagos Vencidos: 0",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                BackColor = Color.FromArgb(230, 240, 255), // Fondo azul claro para diferenciar
                Location = new Point(20, 170),
                Size = new Size(300, 30)
            };
            resumenPanel.Controls.Add(pagosVencidosLabel);

            // Gráfico de crédito disponible y utilizado
            Chart creditoChart = new Chart
            {
                Size = new Size(300, 250),
                Location = new Point(350, 20)
            };
            ChartArea chartArea = new ChartArea
            {
                BackColor = Color.FromArgb(245, 245, 245) // Fondo del área del gráfico para mayor consistencia
            };
            creditoChart.ChartAreas.Add(chartArea);
            Series series = new Series
            {
                Name = "Credito",
                ChartType = SeriesChartType.Pie
            };
            series.Points.Add(new DataPoint(0, 1500) { LegendText = "Disponible", Color = Color.FromArgb(0, 102, 204) }); // Color para disponible
            series.Points.Add(new DataPoint(0, 1500) { LegendText = "Usado", Color = Color.FromArgb(102, 178, 255) }); // Color para usado
            creditoChart.Series.Add(series);
            creditoChart.Legends.Add(new Legend("Legend")
            {
                Docking = Docking.Bottom,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            });
            resumenPanel.Controls.Add(creditoChart);

            // Información adicional
            Label proximoPagoLabel = new Label
            {
                Text = "Próximo Pago: $500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 165, 0), // Naranja para resaltar urgencia
                Location = new Point(20, 230),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(proximoPagoLabel);

            Label fechaCorteLabel = new Label
            {
                Text = "Fecha de Corte: 30/11/2024",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(20, 280),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(fechaCorteLabel);

            Label fechaPagoLabel = new Label
            {
                Text = "Fecha de Pago: 05/12/2024",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(20, 330),
                Size = new Size(400, 30)
            };
            resumenPanel.Controls.Add(fechaPagoLabel);
        }


        private void ConsultasButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título de consultas
            Label consultasTitle = new Label
            {
                Text = "Consultas de Crédito",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 400) / 2, 20),
                Size = new Size(400, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(consultasTitle);

            // Panel principal de consultas
            Panel consultasPanel = new Panel
            {
                Size = new Size(650, 480),
                Location = new Point((contentPanel.Width - 650) / 2, 80),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            contentPanel.Controls.Add(consultasPanel);

            // Gráfico de pagos
            Chart pagosChart = new Chart
            {
                Size = new Size(600, 180),
                Location = new Point(20, 20)
            };
            ChartArea pagosChartArea = new ChartArea
            {
                BackColor = Color.FromArgb(245, 245, 245),
                AxisX =
    {
        LabelStyle = new LabelStyle { Font = new Font("Segoe UI", 10, FontStyle.Bold) }
    },
                AxisY =
    {
        LabelStyle = new LabelStyle { Font = new Font("Segoe UI", 10, FontStyle.Bold) },
        Minimum = 0,
        Maximum = 100
    }
            };
            pagosChart.ChartAreas.Add(pagosChartArea);
            Series pagosSeries = new Series
            {
                Name = "",  // No establecemos un nombre para evitar que aparezca en la leyenda
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true // Mostrar el valor en cada barra para mejorar la visibilidad
            };
            pagosSeries.Points.Add(new DataPoint(0, 60) { AxisLabel = "Pagos Completados", Color = Color.FromArgb(0, 102, 204) });
            pagosSeries.Points.Add(new DataPoint(0, 40) { AxisLabel = "Pagos Pendientes", Color = Color.FromArgb(102, 178, 255) });
            pagosChart.Series.Add(pagosSeries);

            // Eliminar la leyenda que estaba causando el problema
            // pagosChart.Legends.Add(new Legend("PagosLegend")
            // {
            //     Docking = Docking.Top,
            //     Font = new Font("Segoe UI", 10, FontStyle.Regular),
            //     BackColor = Color.Transparent,
            //     ForeColor = Color.Black
            // });

            consultasPanel.Controls.Add(pagosChart);


            // Panel de historial de compras
            Panel historialComprasPanel = new Panel
            {
                Size = new Size(600, 150),
                Location = new Point(20, 220),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label historialComprasLabel = new Label
            {
                Text = "Historial de Compras",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(250, 30)
            };
            historialComprasPanel.Controls.Add(historialComprasLabel);

            DataGridView historialComprasGrid = new DataGridView
            {
                Size = new Size(580, 80),
                Location = new Point(10, 50),
                ColumnCount = 3,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(0, 102, 204),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                GridColor = Color.FromArgb(220, 220, 220)
            };
            historialComprasGrid.Columns[0].Name = "Producto";
            historialComprasGrid.Columns[1].Name = "Fecha";
            historialComprasGrid.Columns[2].Name = "Monto";

            historialComprasGrid.Rows.Add("Televisor", "10/11/2024", "$2000");
            historialComprasGrid.Rows.Add("Lavadora", "15/11/2024", "$1500");
            historialComprasGrid.Rows.Add("Refrigerador", "20/11/2024", "$2500");

            historialComprasPanel.Controls.Add(historialComprasGrid);
            consultasPanel.Controls.Add(historialComprasPanel);

            // Panel de resumen de créditos pendientes
            Panel resumenCreditosPanel = new Panel
            {
                Size = new Size(600, 90),
                Location = new Point(20, 380),
                BackColor = Color.FromArgb(230, 230, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label resumenCreditosLabel = new Label
            {
                Text = "Créditos Pendientes",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(300, 25)
            };
            resumenCreditosPanel.Controls.Add(resumenCreditosLabel);

            Label creditosPendientesLabel = new Label
            {
                Text = "Monto Total Pendiente: $1000\nPróximo Vencimiento: 05/12/2024",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 40),
                Size = new Size(580, 40)
            };
            resumenCreditosPanel.Controls.Add(creditosPendientesLabel);
            consultasPanel.Controls.Add(resumenCreditosPanel);
        }

        private void SolicitarCreditoButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título de la solicitud
            Label solicitudTitle = new Label
            {
                Text = "Solicitud de Aumento de Crédito",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 600) / 2, 20),
                Size = new Size(600, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(solicitudTitle);

            // Panel principal de la solicitud
            Panel solicitudPanel = new Panel
            {
                Size = new Size(600, 450),
                Location = new Point((contentPanel.Width - 600) / 2, 100),
                BackColor = Color.FromArgb(230, 240, 255), // Cambiado a un color más suave y atractivo
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20),
                
            };
            contentPanel.Controls.Add(solicitudPanel);

            // Etiqueta de monto solicitado
            Label montoLabel = new Label
            {
                Text = "Monto Solicitado:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 20),
                Size = new Size(200, 30)
            };
            solicitudPanel.Controls.Add(montoLabel);

            // Cuadro de texto para monto solicitado
            TextBox montoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(240, 20),
                Size = new Size(320, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            solicitudPanel.Controls.Add(montoTextBox);

            // Etiqueta de motivo
            Label motivoLabel = new Label
            {
                Text = "Motivo:",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 80),
                Size = new Size(200, 30)
            };
            solicitudPanel.Controls.Add(motivoLabel);

            // Cuadro de texto para motivo
            TextBox motivoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(240, 80),
                Size = new Size(320, 120),
                Multiline = true,
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            solicitudPanel.Controls.Add(motivoTextBox);

            // Panel de información adicional
            Panel infoPanel = new Panel
            {
                Size = new Size(540, 60),
                Location = new Point(20, 220),
                BackColor = Color.FromArgb(255, 255, 230),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            Label infoLabel = new Label
            {
                Text = "Por favor, explique claramente el motivo para solicitar un aumento.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(102, 51, 0),
                Location = new Point(10, 10),
                Size = new Size(520, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            infoPanel.Controls.Add(infoLabel);
            solicitudPanel.Controls.Add(infoPanel);

            // Botón de enviar solicitud
            Button enviarButton = new Button
            {
                Text = "Enviar Solicitud",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(220, 50),
                Location = new Point((solicitudPanel.Width - 220) / 2, 300),
                BackColor = Color.FromArgb(0, 153, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
            enviarButton.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(montoTextBox.Text) || string.IsNullOrWhiteSpace(motivoTextBox.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de enviar la solicitud.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Solicitud de aumento de crédito enviada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    montoTextBox.Text = string.Empty;
                    motivoTextBox.Text = string.Empty;
                }
            };
            solicitudPanel.Controls.Add(enviarButton);
        }


        private void PagarCreditoButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título del pago
            Label pagoTitle = new Label
            {
                Text = "Pago de Crédito",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 400) / 2, 20),
                Size = new Size(400, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(pagoTitle);

            // Panel principal de pago
            Panel pagoPanel = new Panel
            {
                Size = new Size(600, 500),
                Location = new Point((contentPanel.Width - 600) / 2, 100),
                BackColor = Color.FromArgb(230, 240, 255), // Color más suave y atractivo
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };
            contentPanel.Controls.Add(pagoPanel);

            // Agrupar campos de tarjeta en un panel de "Detalles de Tarjeta"
            Panel tarjetaPanel = new Panel
            {
                Size = new Size(540, 180),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            pagoPanel.Controls.Add(tarjetaPanel);

            Label tarjetaPanelLabel = new Label
            {
                Text = "Detalles de la Tarjeta",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(250, 30)
            };
            tarjetaPanel.Controls.Add(tarjetaPanelLabel);

            Label tarjetaLabel = new Label
            {
                Text = "Número de Tarjeta:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 50),
                Size = new Size(200, 30)
            };
            tarjetaPanel.Controls.Add(tarjetaLabel);

            TextBox tarjetaTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 50),
                Size = new Size(300, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            tarjetaPanel.Controls.Add(tarjetaTextBox);

            Label expiracionLabel = new Label
            {
                Text = "Fecha de Expiración (MM/AA):",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 100),
                Size = new Size(220, 30)
            };
            tarjetaPanel.Controls.Add(expiracionLabel);

            TextBox expiracionTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(240, 100),
                Size = new Size(100, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            tarjetaPanel.Controls.Add(expiracionTextBox);

            Label cvvLabel = new Label
            {
                Text = "Código CVV:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(360, 100),
                Size = new Size(100, 30)
            };
            tarjetaPanel.Controls.Add(cvvLabel);

            TextBox cvvTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(470, 100),
                Size = new Size(50, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                UseSystemPasswordChar = true,
                BorderStyle = BorderStyle.FixedSingle
            };
            tarjetaPanel.Controls.Add(cvvTextBox);

            // Panel de monto a pagar
            Panel montoPanel = new Panel
            {
                Size = new Size(540, 160),
                Location = new Point(20, 220),
                BackColor = Color.FromArgb(240, 248, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            pagoPanel.Controls.Add(montoPanel);

            Label montoPanelLabel = new Label
            {
                Text = "Detalles del Pago",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(250, 30)
            };
            montoPanel.Controls.Add(montoPanelLabel);

            Label montoMinimoLabel = new Label
            {
                Text = "Monto Mínimo a Pagar: $500",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 50),
                Size = new Size(300, 30)
            };
            montoPanel.Controls.Add(montoMinimoLabel);

            Label montoPagarLabel = new Label
            {
                Text = "Monto a Pagar:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 90),
                Size = new Size(200, 30)
            };
            montoPanel.Controls.Add(montoPagarLabel);

            TextBox montoPagarTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Location = new Point(220, 90),
                Size = new Size(200, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            montoPanel.Controls.Add(montoPagarTextBox);

            CheckBox pagoTotalCheckBox = new CheckBox
            {
                Text = "Pagar Totalidad de la Deuda",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 130),
                Size = new Size(300, 30)
            };
            pagoTotalCheckBox.CheckedChanged += (s, args) =>
            {
                if (pagoTotalCheckBox.Checked)
                {
                    montoPagarTextBox.Text = "6000"; // Valor de ejemplo para la deuda total
                    montoPagarTextBox.Enabled = false;
                }
                else
                {
                    montoPagarTextBox.Text = "";
                    montoPagarTextBox.Enabled = true;
                }
            };
            montoPanel.Controls.Add(pagoTotalCheckBox);

            // Botón de pagar
            Button pagarButton = new Button
            {
                Text = "Pagar",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(200, 50),
                Location = new Point((pagoPanel.Width - 200) / 2, 400),
                BackColor = Color.FromArgb(0, 153, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
            pagarButton.Click += (s, args) =>
            {
                if (string.IsNullOrWhiteSpace(tarjetaTextBox.Text) || string.IsNullOrWhiteSpace(montoPagarTextBox.Text) ||
                    string.IsNullOrWhiteSpace(expiracionTextBox.Text) || string.IsNullOrWhiteSpace(cvvTextBox.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de realizar el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (decimal.TryParse(montoPagarTextBox.Text, out decimal montoPagar) && montoPagar < 500)
                {
                    MessageBox.Show("El monto a pagar debe ser igual o mayor al monto mínimo de $500.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Pago realizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tarjetaTextBox.Text = string.Empty;
                    expiracionTextBox.Text = string.Empty;
                    cvvTextBox.Text = string.Empty;
                    montoPagarTextBox.Text = string.Empty;
                    pagoTotalCheckBox.Checked = false;
                }
            };
            pagoPanel.Controls.Add(pagarButton);
        }




        private void ComprarProductosButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título del catálogo
            Label catalogoTitle = new Label
            {
                Text = "Catálogo de Productos",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 450) / 2, 20),
                Size = new Size(450, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(catalogoTitle);

            // Panel principal del catálogo
            Panel catalogoPanel = new Panel
            {
                Size = new Size(800, 600),
                Location = new Point((contentPanel.Width - 800) / 2, 100),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            contentPanel.Controls.Add(catalogoPanel);

            // Panel de productos con desplazamiento automático
            FlowLayoutPanel productosPanel = new FlowLayoutPanel
            {
                Size = new Size(750, 400),
                Location = new Point(25, 20),
                AutoScroll = true,
                BackColor = Color.White
            };

            // Lista de productos
            List<(string, string, string, string)> productos = new List<(string, string, string, string)>
    {
        ("Televisor", "Smart TV 50'' 4K", "$2000", "C:\\Users\\USER\\Downloads\\LG 55” 4K UHD Smart TV 2160p webOS, 55UQ7070ZUE - Walmart_com.jpeg"),
        ("Lavadora", "Lavadora automática 15kg", "$1500", "C:\\Users\\USER\\Downloads\\Whirlpool FFB7038WPL 859991597030.jpeg"),
        ("Refrigerador", "Refrigerador de doble puerta", "$2500", "C:\\Users\\USER\\Downloads\\descarga (1).jpeg"),
        ("Laptop", "Laptop Gaming 16GB RAM", "$15200", "C:\\Users\\USER\\Pictures\\pc-gamer.jpg"),
        ("Smartphone", "Teléfono Inteligente 128GB", "$800", "C:\\Users\\USER\\Pictures\\smartphone.jpg"),
        ("Cafetera", "Cafetera Automática", "$300", "C:\\Users\\USER\\Pictures\\cafetera.jpg")
    };

            // Crear paneles de productos
            foreach (var producto in productos)
            {
                Panel productoPanel = new Panel
                {
                    Size = new Size(210, 320),
                    Margin = new Padding(15),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };

                PictureBox productoImagen = new PictureBox
                {
                    Image = Image.FromFile(producto.Item4),
                    Size = new Size(180, 120),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };
                productoPanel.Controls.Add(productoImagen);

                Label productoNombre = new Label
                {
                    Text = producto.Item1,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Location = new Point(10, 140),
                    Size = new Size(180, 25),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                productoPanel.Controls.Add(productoNombre);

                Label productoDescripcion = new Label
                {
                    Text = producto.Item2,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.FromArgb(64, 64, 64),
                    Location = new Point(10, 170),
                    Size = new Size(180, 40),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                productoPanel.Controls.Add(productoDescripcion);

                Label productoPrecio = new Label
                {
                    Text = producto.Item3,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    Location = new Point(10, 220),
                    Size = new Size(180, 25),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                productoPanel.Controls.Add(productoPrecio);

                Button agregarCarritoButton = new Button
                {
                    Text = "Agregar al Carrito",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Size = new Size(160, 40),
                    Location = new Point(20, 250),
                    BackColor = Color.FromArgb(0, 153, 51),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Cursor = Cursors.Hand
                };
                agregarCarritoButton.Click += (s, args) =>
                {
                    MessageBox.Show($"{producto.Item1} ha sido añadido al carrito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                productoPanel.Controls.Add(agregarCarritoButton);

                productosPanel.Controls.Add(productoPanel);
            }

            catalogoPanel.Controls.Add(productosPanel);

            // Botón proceder a la compra con animación
            Button procederCompraButton = new Button
            {
                Text = "Proceder a la Compra",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Size = new Size(300, 50),
                Location = new Point((catalogoPanel.Width - 300) / 2, 500),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
            procederCompraButton.MouseEnter += (s, args) =>
            {
                procederCompraButton.BackColor = Color.FromArgb(0, 153, 255);
            };
            procederCompraButton.MouseLeave += (s, args) =>
            {
                procederCompraButton.BackColor = Color.FromArgb(0, 102, 204);
            };
            procederCompraButton.Click += (s, args) =>
            {
                MessageBox.Show("Los productos seleccionados han sido añadidos a su tarjeta de crédito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            catalogoPanel.Controls.Add(procederCompraButton);
        }



        private void PerfilButton_Click(object sender, EventArgs e)
        {
            // Limpiar contenido anterior
            contentPanel.Controls.Clear();

            // Título del perfil
            Label perfilTitle = new Label
            {
                Text = "Perfil de Usuario",
                Font = new Font("Segoe UI", 26, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 51, 153),
                Location = new Point((contentPanel.Width - 450) / 2, 20),
                Size = new Size(450, 60),
                TextAlign = ContentAlignment.MiddleCenter
            };
            contentPanel.Controls.Add(perfilTitle);

            // Panel principal del perfil
            Panel perfilPanel = new Panel
            {
                Size = new Size(750, 650),
                Location = new Point((contentPanel.Width - 750) / 2, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };
            contentPanel.Controls.Add(perfilPanel);

            // Imagen de perfil
            PictureBox perfilImagen = new PictureBox
            {
                Image = Image.FromFile("C:\\Users\\USER\\source\\repos\\CREDITOS\\Resources\\usuario.png"),
                Size = new Size(120, 120),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            perfilPanel.Controls.Add(perfilImagen);

            // Botón para actualizar foto
            Button actualizarFotoButton = new Button
            {
                Text = "Actualizar Foto",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(160, 60),
                BackColor = Color.FromArgb(0, 153, 76),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
            actualizarFotoButton.Click += (s, args) =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Seleccionar imagen de perfil";
                    openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Imagen de perfil actualizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        perfilImagen.Image = Image.FromFile(openFileDialog.FileName);
                    }
                }
            };
            perfilPanel.Controls.Add(actualizarFotoButton);

            // Nombre de usuario
            Label nombreUsuarioLabel = new Label
            {
                Text = "Nombre de Usuario:",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 160),
                Size = new Size(250, 30)
            };
            perfilPanel.Controls.Add(nombreUsuarioLabel);

            TextBox nombreUsuarioTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 16),
                Location = new Point(300, 160),
                Size = new Size(300, 35),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                ReadOnly = true
            };
            perfilPanel.Controls.Add(nombreUsuarioTextBox);

            // Correo electrónico
            Label correoLabel = new Label
            {
                Text = "Correo Electrónico:",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 220),
                Size = new Size(250, 30)
            };
            perfilPanel.Controls.Add(correoLabel);

            TextBox correoTextBox = new TextBox
            {
                Font = new Font("Segoe UI", 16),
                Location = new Point(300, 220),
                Size = new Size(400, 35),
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                ReadOnly = true
            };
            perfilPanel.Controls.Add(correoTextBox);

            // Tarjeta de créditos utilizados
            Panel tarjetaCreditosUtilizados = new Panel
            {
                Size = new Size(320, 100),
                Location = new Point(20, 280),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            Label creditosUtilizadosLabel = new Label
            {
                Text = "Créditos Utilizados\nTotal: $4500",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(300, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            tarjetaCreditosUtilizados.Controls.Add(creditosUtilizadosLabel);
            perfilPanel.Controls.Add(tarjetaCreditosUtilizados);

            // Tarjeta de créditos pendientes
            Panel tarjetaCreditosPendientes = new Panel
            {
                Size = new Size(320, 100),
                Location = new Point(360, 280),
                BackColor = Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            Label creditosPendientesLabel = new Label
            {
                Text = "Créditos Pendientes\nTotal: $2000",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(10, 10),
                Size = new Size(300, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            tarjetaCreditosPendientes.Controls.Add(creditosPendientesLabel);
            perfilPanel.Controls.Add(tarjetaCreditosPendientes);

            // Historial de actividades
            Label historialLabel = new Label
            {
                Text = "Historial de Actividades",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 400),
                Size = new Size(400, 40)
            };
            perfilPanel.Controls.Add(historialLabel);

            DataGridView historialGrid = new DataGridView
            {
                Size = new Size(700, 150),
                Location = new Point(20, 450),
                ColumnCount = 3,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                AllowUserToResizeColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 14, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(0, 102, 204),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                },
                GridColor = Color.FromArgb(220, 220, 220)
            };
            historialGrid.Columns[0].Name = "Fecha";
            historialGrid.Columns[1].Name = "Actividad";
            historialGrid.Columns[2].Name = "Monto";

            historialGrid.Rows.Add("01/12/2024", "Pago Realizado", "$500");
            historialGrid.Rows.Add("20/11/2024", "Compra - Televisor", "$2000");
            historialGrid.Rows.Add("15/11/2024", "Compra - Lavadora", "$1500");

            perfilPanel.Controls.Add(historialGrid);
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Cerrando sesión...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
