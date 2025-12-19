using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Label ticketNumberLabel;
        private Label resultLabel;
        private Button generateButton;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            ticketNumberLabel = new Label
            {
                Text = "000000",
                Location = new Point(80, 50),
                Size = new Size(180, 50),
                Font = new Font("Arial", 24, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White
            };
            this.Controls.Add(ticketNumberLabel);

            resultLabel = new Label
            {
                Text = "",
                Location = new Point(80, 110),
                Size = new Size(180, 30),
                Font = new Font("Arial", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(resultLabel);

            generateButton = new Button
            {
                Text = "Сгенерировать билет",
                Location = new Point(80, 150),
                Size = new Size(180, 40),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            generateButton.Click += GenerateButton_Click;
            this.Controls.Add(generateButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Генератор трамвайных билетов";
            this.Size = new Size(350, 250);
        }

        private bool IsLuckyTicket(string ticket)
        {
            if (ticket.Length != 6) return false;

            int sum1 = (ticket[0] - '0') + (ticket[1] - '0') + (ticket[2] - '0');
            int sum2 = (ticket[3] - '0') + (ticket[4] - '0') + (ticket[5] - '0');

            return sum1 == sum2;
        }

        private string GenerateTicket()
        {
            return random.Next(0, 1000000).ToString("D6");
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string ticket = GenerateTicket();
            ticketNumberLabel.Text = ticket;

            if (IsLuckyTicket(ticket))
            {
                resultLabel.Text = "счастливый билет";
                resultLabel.ForeColor = Color.Green;
                ticketNumberLabel.BackColor = Color.LightGreen;
            }
            else
            {
                resultLabel.Text = "не счастливый билет";
                resultLabel.ForeColor = Color.Red;
                ticketNumberLabel.BackColor = Color.White;
            }
        }

        // Остальные методы оставляем пустыми
        private void label1_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void numbers_Click(object sender, EventArgs e) { }
        private void lukyBilet_Click(object sender, EventArgs e) { }
        private void unlukyBilet_Click(object sender, EventArgs e) { }
    }
}