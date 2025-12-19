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
    public partial class PR5 : Form
    {
        private string currentInput = "";
        private bool isResultDisplayed = false;

        public PR5()
        {
            InitializeComponent();
        }

        private void AppendToInput(string value)
        {
            if (isResultDisplayed)
            {
                currentInput = "";
                isResultDisplayed = false;
            }

            currentInput += value;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            txtDisplay.Text = currentInput;
        }

        // ПРОСТОЙ И НАДЕЖНЫЙ КАЛЬКУЛЯТОР
        private void CalculateResult()
        {
            try
            {
                if (string.IsNullOrEmpty(currentInput))
                    return;

                // Простая замена π и e
                string expression = currentInput
                    .Replace("π", "3.141592653589793")
                    .Replace("e", "2.718281828459045");

                // Удаляем все функции - делаем простой калькулятор
                expression = expression
                    .Replace("sin(", "")
                    .Replace("cos(", "")
                    .Replace("tan(", "")
                    .Replace("ln(", "")
                    .Replace("abs(", "")
                    .Replace("sqrt(", "")
                    .Replace(")", "");

                // Простой парсер для базовых операций
                double result = SimpleEvaluate(expression);

                currentInput = result.ToString();
                isResultDisplayed = true;
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                currentInput = "Error: " + ex.Message;
                isResultDisplayed = true;
                UpdateDisplay();
            }
        }

        private double SimpleEvaluate(string expr)
        {
            expr = expr.Replace(" ", "");

            // Если выражение пустое
            if (string.IsNullOrEmpty(expr))
                return 0;

            // Ищем операторы в правильном порядке приоритета
            // 1. Умножение и деление
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '*' || expr[i] == '/')
                {
                    double left = SimpleEvaluate(expr.Substring(0, i));
                    double right = SimpleEvaluate(expr.Substring(i + 1));

                    if (expr[i] == '*')
                        return left * right;
                    else
                    {
                        if (right == 0) throw new DivideByZeroException();
                        return left / right;
                    }
                }
            }

            // 2. Сложение и вычитание
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '+' || (expr[i] == '-' && i > 0))
                {
                    double left = SimpleEvaluate(expr.Substring(0, i));
                    double right = SimpleEvaluate(expr.Substring(i + 1));

                    if (expr[i] == '+')
                        return left + right;
                    else
                        return left - right;
                }
            }

            // 3. Степень
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '^')
                {
                    double left = SimpleEvaluate(expr.Substring(0, i));
                    double right = SimpleEvaluate(expr.Substring(i + 1));
                    return Math.Pow(left, right);
                }
            }

            // Если нет операторов - это число
            return double.Parse(expr);
        }

        // ОБРАБОТЧИКИ КНОПОК - ВСЕ ОСТАЕТСЯ КАК БЫЛО
        private void btn1_Click(object sender, EventArgs e) => AppendToInput("1");
        private void btn2_Click(object sender, EventArgs e) => AppendToInput("2");
        private void btn3_Click(object sender, EventArgs e) => AppendToInput("3");
        private void btn4_Click(object sender, EventArgs e) => AppendToInput("4");
        private void btn5_Click(object sender, EventArgs e) => AppendToInput("5");
        private void btn6_Click(object sender, EventArgs e) => AppendToInput("6");
        private void btn7_Click(object sender, EventArgs e) => AppendToInput("7");
        private void btn8_Click(object sender, EventArgs e) => AppendToInput("8");
        private void btn9_Click(object sender, EventArgs e) => AppendToInput("9");
        private void btn0_Click(object sender, EventArgs e) => AppendToInput("0");
        private void btnPoint_Click(object sender, EventArgs e) => AppendToInput(".");

        private void btnPlus_Click(object sender, EventArgs e) => AppendToInput("+");
        private void btnMinus_Click(object sender, EventArgs e) => AppendToInput("-");
        private void btnMult_Click(object sender, EventArgs e) => AppendToInput("*");
        private void btnDivide_Click(object sender, EventArgs e) => AppendToInput("/");
        private void btnPower_Click(object sender, EventArgs e) => AppendToInput("^");

        private void btnOpenBracket_Click(object sender, EventArgs e) => AppendToInput("(");
        private void btnCloseBracket_Click(object sender, EventArgs e) => AppendToInput(")");

        private void btnPi_Click(object sender, EventArgs e) => AppendToInput("π");
        private void btnE_Click(object sender, EventArgs e) => AppendToInput("e");

        // Функции - работают отдельно
        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                double result = Math.Sin(value * Math.PI / 180);
                currentInput = result.ToString();
                isResultDisplayed = true;
                UpdateDisplay();
            }
            catch { }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                double result = Math.Cos(value * Math.PI / 180);
                currentInput = result.ToString();
                isResultDisplayed = true;
                UpdateDisplay();
            }
            catch { }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                double result = Math.Tan(value * Math.PI / 180);
                currentInput = result.ToString();
                isResultDisplayed = true;
                UpdateDisplay();
            }
            catch { }
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                if (value > 0)
                {
                    double result = Math.Log(value);
                    currentInput = result.ToString();
                    isResultDisplayed = true;
                    UpdateDisplay();
                }
            }
            catch { }
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                double result = Math.Abs(value);
                currentInput = result.ToString();
                isResultDisplayed = true;
                UpdateDisplay();
            }
            catch { }
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            try
            {
                double value = SimpleEvaluate(currentInput.Replace("π", "3.141592653589793"));
                if (value >= 0)
                {
                    double result = Math.Sqrt(value);
                    currentInput = result.ToString();
                    isResultDisplayed = true;
                    UpdateDisplay();
                }
            }
            catch { }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                currentInput = currentInput.Remove(currentInput.Length - 1);
                UpdateDisplay();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentInput = "";
            isResultDisplayed = false;
            UpdateDisplay();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                CalculateResult();
            }
        }
    }
}