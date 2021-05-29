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
            string locationNumString = "";
            var numToConvert = double.Parse(calTextBox.Text);

            List<int> numList = new List<int>();

            int[] locationNumValsRev = new int[] { 67108864, 33554432, 16777216, 8388608, 4194304, 2097152, 1048576, 262144, 131072, 65536, 32768, 16384, 8192, 4096, 2048, 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };


            foreach (var num in locationNumValsRev)
            {
                if (numToConvert == 1)
                {
                    numList.Add(1);
                    numToConvert -= 1;
                }

                if (numToConvert >= num)
                {
                    numList.Add(num);
                    numToConvert -= num;
                }
            }

            foreach (var item in numList)
            {
                switch (item)
                {
                    case 1:
                        locationNumString += 'a';
                        break;
                    case 2:
                        locationNumString += 'b';
                        break;
                    case 4:
                        locationNumString += 'c';
                        break;
                    case 8:
                        locationNumString += 'd';
                        break;
                    case 16:
                        locationNumString += 'e';
                        break;
                    case 32:
                        locationNumString += 'f';
                        break;
                    case 64:
                        locationNumString += 'g';
                        break;
                    case 128:
                        locationNumString += 'h';
                        break;
                    case 256:
                        locationNumString += 'i';
                        break;
                    case 512:
                        locationNumString += 'j';
                        break;
                    case 1024:
                        locationNumString += 'k';
                        break;
                    case 2048:
                        locationNumString += 'l';
                        break;
                    case 4096:
                        locationNumString += 'm';
                        break;
                    case 8192:
                        locationNumString += 'n';
                        break;
                    case 16384:
                        locationNumString += 'o';
                        break;
                    case 32768:
                        locationNumString += 'p';
                        break;
                    case 65536:
                        locationNumString += 'q';
                        break;
                    case 131072:
                        locationNumString += 'r';
                        break;
                    case 262144:
                        locationNumString += 's';
                        break;
                    case 1048576:
                        locationNumString += 't';
                        break;
                    case 2097152:
                        locationNumString += 'u';
                        break;
                    case 4194304:
                        locationNumString += 'v';
                        break;
                    case 8388608:
                        locationNumString += 'w';
                        break;
                    case 16777216:
                        locationNumString += 'x';
                        break;
                    case 33554432:
                        locationNumString += 'y';
                        break;
                    case 67108864:
                        locationNumString += 'z';
                        break;
                }
            }

            char[] newArr = locationNumString.ToCharArray();
            Array.Reverse(newArr);
            string locationNumStringRev = new string(newArr);

            calTextBox.Text = locationNumStringRev;
        }
    }
}
