using System;
using System.Windows.Forms;
using System.Drawing;

namespace CalculatorApp
{
    public class Form1 : Form
    {
        double firstNumber = 0;
        double secondNumber = 0;
        double result = 0;
        string operation = "";

        Label lblTitle;
        TextBox txtDisplay;
        Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        Button btnPlus, btnMinus, btnMultiply, btnDivide, btnEquals, btnClear, btnDecimal;

        public Form1()
        {
            this.Text = "Calculator App";
            this.Size = new Size(260, 360);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label() { Name = "lblTitle", Text = "Calculator", Location = new Point(10, 10), AutoSize = true };
            txtDisplay = new TextBox() { Name = "txtDisplay", Text = "0", Location = new Point(10, 35), Width = 220, Font = new Font("Arial", 16), TextAlign = HorizontalAlignment.Right };

            btn7 = BuatTombol("btn7", "7", 10, 80);
            btn8 = BuatTombol("btn8", "8", 65, 80);
            btn9 = BuatTombol("btn9", "9", 120, 80);
            btnDivide = BuatTombol("btnDivide", "÷", 175, 80);

            btn4 = BuatTombol("btn4", "4", 10, 135);
            btn5 = BuatTombol("btn5", "5", 65, 135);
            btn6 = BuatTombol("btn6", "6", 120, 135);
            btnMultiply = BuatTombol("btnMultiply", "x", 175, 135);

            btn1 = BuatTombol("btn1", "1", 10, 190);
            btn2 = BuatTombol("btn2", "2", 65, 190);
            btn3 = BuatTombol("btn3", "3", 120, 190);
            btnMinus = BuatTombol("btnMinus", "-", 175, 190);

            btn0 = BuatTombol("btn0", "0", 10, 245);
            btnDecimal = BuatTombol("btnDecimal", ".", 65, 245);
            btnClear = BuatTombol("btnClear", "C", 120, 245);
            btnPlus = BuatTombol("btnPlus", "+", 175, 245);

            btnEquals = BuatTombol("btnEquals", "=", 10, 300);
            btnEquals.Width = 220;

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtDisplay);
            this.Controls.AddRange(new Control[] { btn7, btn8, btn9, btnDivide, btn4, btn5, btn6, btnMultiply, btn1, btn2, btn3, btnMinus, btn0, btnDecimal, btnClear, btnPlus, btnEquals });

            btn0.Click += NumberButton_Click; btn1.Click += NumberButton_Click;
            btn2.Click += NumberButton_Click; btn3.Click += NumberButton_Click;
            btn4.Click += NumberButton_Click; btn5.Click += NumberButton_Click;
            btn6.Click += NumberButton_Click; btn7.Click += NumberButton_Click;
            btn8.Click += NumberButton_Click; btn9.Click += NumberButton_Click;

            btnPlus.Click += OperatorButton_Click; btnMinus.Click += OperatorButton_Click;
            btnMultiply.Click += OperatorButton_Click; btnDivide.Click += OperatorButton_Click;

            btnEquals.Click += btnEquals_Click;
            btnClear.Click += btnClear_Click;
            btnDecimal.Click += btnDecimal_Click;
        }

        private Button BuatTombol(string name, string text, int x, int y)
        {
            return new Button() { Name = name, Text = text, Location = new Point(x, y), Size = new Size(50, 50), Font = new Font("Arial", 12) };
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (txtDisplay.Text == "0")
                txtDisplay.Text = button.Text;
            else
                txtDisplay.Text += button.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = double.Parse(txtDisplay.Text);
            operation = button.Text;
            txtDisplay.Clear();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                secondNumber = double.Parse(txtDisplay.Text);
                switch (operation)
                {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "x": result = firstNumber * secondNumber; break;
                    case "÷":
                        if (secondNumber == 0)
                            throw new DivideByZeroException();
                        result = firstNumber / secondNumber;
                        break;
                }
                txtDisplay.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = "";
            txtDisplay.Text = "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
                txtDisplay.Text += ".";
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
