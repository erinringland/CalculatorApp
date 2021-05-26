using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorApp : Form
    {
        string stringNum1;
        char operation;
        public CalculatorApp()
        {
            InitializeComponent(); // Don't ever delete this message!
        }

        private void button2_Click(object sender, EventArgs e) // clearBtn
        {
            calTextBox.Text = "";
            //MessageBox.Show("The text boxes have been cleared", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void additionBtn_Click(object sender, EventArgs e)
        {
            stringNum1 = calTextBox.Text;
            operation = '+';
            calTextBox.Text = "";
        }

        private void subtractBtn_Click(object sender, EventArgs e)
        {
            stringNum1 = calTextBox.Text;
            operation = '-';
            calTextBox.Text = "";
        }

        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            stringNum1 = calTextBox.Text;
            operation = '*';
            calTextBox.Text = "";
        }

        private void divisionBtn_Click(object sender, EventArgs e)
        {
            stringNum1 = calTextBox.Text;
            operation = '/';
            calTextBox.Text = "";
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            double result = 0.0;

            string stringNum2 = calTextBox.Text;

            double n1 = double.Parse(stringNum1);
            double n2 = double.Parse(stringNum2);

            switch (operation)
            {
                case '+':
                    result = n1 + n2;
                    calTextBox.Text = result.ToString();
                    break;
                case '-':
                    result = n1 - n2;
                    calTextBox.Text = result.ToString();
                    break;                
                case '/':
                    result = n1 / n2;
                    calTextBox.Text = result.ToString();
                    break;
            }

            if (operation == '/' && n2 != 0)
                {
                    result = n1 / n2;
                    calTextBox.Text = result.ToString();
                }
            else if (operation == '/' && n2 == 0)
                MessageBox.Show("Cannot divide by Zero!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
        }

        private void decimalBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += ".";
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "1";
        }

        private void twoBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "2";
        }

        private void threeBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "3";
        }

        private void fourBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "4";
        }

        private void fiveBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "5";
        }

        private void sixBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "6";
        }

        private void sevenBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "7";
        }

        private void eightBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "8";
        }

        private void nineBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "9";
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            calTextBox.Text += "0";
        }

        private static void calTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // Decimal
            }
            else
            {
                // Binary
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // add this check value to a list
            }
            else
            {
                // remove this check value from the list
            }
        }
    }
}
