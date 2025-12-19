using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISRPO4._5._6._7
{
    public partial class PR4 : Form
    {
        public PR4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполняем комбобокс языками
            cbxLeng.Items.Add("Русский");
            cbxLeng.Items.Add("Английский");
            cbxLeng.SelectedIndex = 0; // Выбираем русский по умолчанию

            // Устанавливаем диапазон для NumericUpDown
            nudSdwig.Minimum = 1;
            nudSdwig.Maximum = 33;
            nudSdwig.Value = 3; // Стандартный сдвиг для Цезаря
        }

        private void btnShifr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите текст для шифрования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string language = cbxLeng.SelectedItem.ToString();
            int shift = (int)nudSdwig.Value;

            txtOutput.Text = CaesarCipher(txtInput.Text, shift, language, true);
        }

        private void btnDeShifr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Введите текст для дешифрования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string language = cbxLeng.SelectedItem.ToString();
            int shift = (int)nudSdwig.Value;

            txtOutput.Text = CaesarCipher(txtInput.Text, shift, language, false);
        }

        private string CaesarCipher(string text, int shift, string language, bool encrypt)
        {
            // Определяем алфавит в зависимости от языка
            string alphabet;
            int alphabetLength;

            if (language == "Русский")
            {
                alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                alphabetLength = 33;
            }
            else // Английский
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabetLength = 26;
            }

            // Создаем алфавит в нижнем регистре
            string lowerAlphabet = alphabet.ToLower();

            StringBuilder result = new StringBuilder();

            foreach (char c in text)
            {
                char processedChar = c;

                // Проверяем, является ли символ буквой выбранного алфавита
                if (alphabet.Contains(char.ToUpper(c)))
                {
                    string currentAlphabet = char.IsUpper(c) ? alphabet : lowerAlphabet;
                    int index = currentAlphabet.IndexOf(c);

                    if (index >= 0)
                    {
                        // Для дешифровки используем обратный сдвиг
                        int actualShift = encrypt ? shift : -shift;

                        // Вычисляем новый индекс с учетом сдвига
                        int newIndex = (index + actualShift) % alphabetLength;
                        if (newIndex < 0) newIndex += alphabetLength;

                        processedChar = currentAlphabet[newIndex];
                    }
                }

                result.Append(processedChar);
            }

            return result.ToString();
        }

        private void Dell_Click(object sender, EventArgs e)
        {
            // Очищаем все поля
            txtInput.Clear();
            txtOutput.Clear();
            nudSdwig.Value = 3;
            cbxLeng.SelectedIndex = 0;

            // Устанавливаем фокус на поле ввода
            txtInput.Focus();
        }

        private void cbxLeng_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Автоматически меняем максимальное значение сдвига в зависимости от языка
            if (cbxLeng.SelectedItem != null)
            {
                string language = cbxLeng.SelectedItem.ToString();

                if (language == "Русский")
                {
                    nudSdwig.Maximum = 33;
                }
                else // Английский
                {
                    nudSdwig.Maximum = 26;
                }

                // Если текущее значение больше нового максимума, уменьшаем его
                if (nudSdwig.Value > nudSdwig.Maximum)
                {
                    nudSdwig.Value = nudSdwig.Maximum;
                }
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            // Можно добавить логику, если нужно
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            // Можно добавить логику, если нужно
        }

        private void nudSdwig_ValueChanged(object sender, EventArgs e)
        {
            // Можно добавить логику, если нужно
        }
    }
}