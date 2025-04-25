using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microondas
{
    public partial class Form1 : Form
    {
        private Label timerLabel;
        private PictureBox pictureBox1;
        private Button[] numberButtons;
        private Button startButton;
        private Button stopButton;

        private System.Windows.Forms.Timer timer;

        private TimeSpan remainingTime;

        public int Interval { get; private set; }

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Simulador de Microondas";
            this.Size = new Size(800, 550);

            // PictureBox
            pictureBox1 = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 10),
                Size = new Size(450, 400),
                BackColor = Color.White
            };
            this.Controls.Add(pictureBox1);

            // Timer Label
            timerLabel = new Label
            {
                Text = "00:00:00",
                Font = new Font("Arial", 24, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(470, 10),
                Size = new Size(300, 60)
            };
            this.Controls.Add(timerLabel);

            // Botones numéricos
            numberButtons = new Button[10];
            int xStart = 470;
            int yStart = 80;
            int buttonWidth = 90;
            int buttonHeight = 50;
            int padding = 10;

            for (int i = 1; i <= 9; i++)
            {
                numberButtons[i] = new Button
                {
                    Text = i.ToString(),
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(xStart + ((i - 1) % 3) * (buttonWidth + padding),
                                         yStart + ((i - 1) / 3) * (buttonHeight + padding))
                };
                numberButtons[i].Click += NumberButton_Click;
                this.Controls.Add(numberButtons[i]);
            }

            // Botón 0
            numberButtons[0] = new Button
            {
                Text = "0",
                Size = new Size(buttonWidth, buttonHeight),
                Location = new Point(xStart + buttonWidth + padding,
                                     yStart + 3 * (buttonHeight + padding))
            };
            numberButtons[0].Click += NumberButton_Click;
            this.Controls.Add(numberButtons[0]);

            // Botón Iniciar
            startButton = new Button
            {
                Text = "Iniciar",
                Size = new Size(150, 50),
                Location = new Point(10, 420)
            };
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton);

            // Botón Detener
            stopButton = new Button
            {
                Text = "Detener",
                Size = new Size(150, 50),
                Location = new Point(170, 420)
            };
            stopButton.Click += StopButton_Click;
            this.Controls.Add(stopButton);

            // Timer
            timer = new System.Windows.Forms.Timer();

            {
                Interval = 1000;
            };
            timer.Tick += Timer_Tick;

            Button resetButton = new Button
            {
                Text = "Reset",
                Size = new Size(150, 50),
                Location = new Point(330, 420)
            };
            resetButton.Click += ResetButton_Click;
            this.Controls.Add(resetButton);
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string currentText = timerLabel.Text.Replace(":", "");
                if (currentText.Length >= 6) currentText = currentText.Substring(1);

                currentText += clickedButton.Text;
                currentText = currentText.PadLeft(6, '0');

                timerLabel.Text = $"{currentText.Substring(0, 2)}:{currentText.Substring(2, 2)}:{currentText.Substring(4, 2)}";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string[] parts = timerLabel.Text.Split(':');
            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            int seconds = int.Parse(parts[2]);
            remainingTime = new TimeSpan(hours, minutes, seconds);

            if (remainingTime.TotalSeconds > 0)
                timer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Detener el temporizador si está corriendo
            remainingTime = TimeSpan.Zero; // Reiniciar tiempo restante
            timerLabel.Text = "00:00:00"; // Mostrar 00:00:00 en el display
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (remainingTime.TotalSeconds > 0)
            {
                remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                timerLabel.Text = $"{remainingTime.Hours:D2}:{remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";
            }
            else
            {
                timer.Stop();
                MessageBox.Show("¡Tiempo terminado!", "Microondas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Aquí podrías poner una animación o imagen
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // De momento nada aquí
        }
    }
}
