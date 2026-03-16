using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormQuestions : Form
    {
        private int userId;
        private List<Question> questions;
        private int currentIndex = 0;
        private int[] selectedAnswers;
        private int timeLeft = 1500; // 25 минут

        public FormQuestions(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            LoadQuestions();
            selectedAnswers = new int[questions.Count];
            DisplayQuestion();
            StartTimer();
        }

        private void LoadQuestions()
        {
            questions = DatabaseHelper.GetQuestions();
            if (questions.Count == 0)
            {
                MessageBox.Show("Нет вопросов в базе данных.");
                Close();
            }
        }

        private void DisplayQuestion()
        {
            if (currentIndex < questions.Count)
            {
                var q = questions[currentIndex];
                lblQuestion.Text = $"Вопрос {currentIndex + 1}: {q.Text}";
                rbOption1.Text = q.Options[0];
                rbOption2.Text = q.Options[1];
                rbOption3.Text = q.Options[2];
                rbOption4.Text = q.Options[3];

                int prev = selectedAnswers[currentIndex];
                if (prev != 0)
                {
                    switch (prev)
                    {
                        case 1: rbOption1.Checked = true; break;
                        case 2: rbOption2.Checked = true; break;
                        case 3: rbOption3.Checked = true; break;
                        case 4: rbOption4.Checked = true; break;
                    }
                }
                else
                {
                    rbOption1.Checked = rbOption2.Checked = rbOption3.Checked = rbOption4.Checked = false;
                }

                btnNext.Text = (currentIndex == questions.Count - 1) ? "Завершить" : "Далее";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int selected = 0;
            if (rbOption1.Checked) selected = 1;
            else if (rbOption2.Checked) selected = 2;
            else if (rbOption3.Checked) selected = 3;
            else if (rbOption4.Checked) selected = 4;

            if (selected == 0)
            {
                MessageBox.Show("Выберите вариант ответа.");
                return;
            }

            selectedAnswers[currentIndex] = selected;

            if (currentIndex == questions.Count - 1)
                FinishTest();
            else
            {
                currentIndex++;
                DisplayQuestion();
            }
        }

        private void FinishTest()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                int ans = selectedAnswers[i];
                bool isCorrect = (ans == questions[i].CorrectOption);
                DatabaseHelper.SaveUserAnswer(userId, questions[i].Id, ans, isCorrect);
            }

            timer.Stop();

            FormFinish formFinish = new FormFinish();
            formFinish.Show();
            this.Close();
        }

        private void StartTimer()
        {
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло!");
                FinishTest();
            }
            else
            {
                int minutes = timeLeft / 60;
                int seconds = timeLeft % 60;
                lblTimer.Text = $"{minutes:D2}:{seconds:D2}";
            }
        }

        private void FormQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите прервать тест? Результаты не сохранятся.", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormStart start = Application.OpenForms["FormStart"] as FormStart;
            if (start != null)
                start.Show();
            else
                Application.Exit();
        }
    }
}