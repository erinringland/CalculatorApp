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
            if (!calTextBox.Text.Contains('.')) 
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

        private void calTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true; 

            if (calTextBox.Text.Contains('.') && (e.KeyChar == '.'))
                e.Handled = true;
        }

        private void convertToBinary_Click(object sender, EventArgs e)
        {
            decimal numConvert = decimal.Parse(calTextBox.Text);
            decimal Quotient = numConvert / 2;

            if(numConvert <= 0 )
                MessageBox.Show("Cannot convert a negative number!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Stack<decimal> binCount = new Stack<decimal>();

            binCount.Push(numConvert % 2);

            while (Quotient > 1)
            {
                decimal Remainder = Math.Floor(Quotient % 2);
                binCount.Push(Remainder);
                Quotient /= 2;
            }

            calTextBox.Text = "";

            foreach (var item in binCount)
                calTextBox.Text += item;
        }

        private void convertToDec_Click(object sender, EventArgs e)
        {
            string binString = calTextBox.Text;

            foreach (var num in binString)
                if (num != '0' && num != '1')
                {
                    MessageBox.Show("The number entered is not a binary number!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            var binArr = binString.Select(ch => ch - '0').ToArray();
            var multiplerNum = binArr.Length - 1;
            double finalNum = 0;

            calTextBox.Text = "";

            foreach (var item in binArr)
            {
                finalNum += item * Math.Pow(2, multiplerNum);
                multiplerNum--;
            }

            calTextBox.Text = finalNum.ToString();

        }

        private void convertToLocationNum_Click(object sender, EventArgs e)
        {

        }
    }
}
