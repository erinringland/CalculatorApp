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

            if(stringNum1 == String.Empty)
            {
                MessageBox.Show("Please enter a positive decimal!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if(calTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a positive decimal!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal numConvert = decimal.Parse(calTextBox.Text);
            decimal Quotient = numConvert / 2;

            if(numConvert <= 0 )
                MessageBox.Show("Cannot convert a negative decimal!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (calTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a binary number!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            if (calTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter a positive decimal!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private void defaultRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            var colourBG = SystemColors.ControlLight;
            var colourText = SystemColors.ControlText;

            var inputBG = colourBG;
            var inputTextColour = SystemColors.ControlText;

            var btnTextColour = colourText;
            var btnBorderColour = SystemColors.ControlLight;
            var btnBG = SystemColors.ControlLightLight;
            var btnBGalt1 = SystemColors.Control;

            ActiveForm.BackColor = colourBG;
            ActiveForm.ForeColor = colourText;

            calTextBox.BackColor = inputBG;
            calTextBox.ForeColor = inputTextColour;

            textBox1.BackColor = colourBG;
            textBox1.ForeColor = colourText;

            zeroBtn.BackColor = btnBG;
            zeroBtn.ForeColor = btnTextColour;
            zeroBtn.FlatAppearance.BorderColor = btnBorderColour;

            oneBtn.BackColor = btnBG;
            oneBtn.ForeColor = btnTextColour;
            oneBtn.FlatAppearance.BorderColor = btnBorderColour;

            twoBtn.BackColor = btnBG;
            twoBtn.ForeColor = btnTextColour;
            twoBtn.FlatAppearance.BorderColor = btnBorderColour;

            threeBtn.BackColor = btnBG;
            threeBtn.ForeColor = btnTextColour;
            threeBtn.FlatAppearance.BorderColor = btnBorderColour;

            fourBtn.BackColor = btnBG;
            fourBtn.ForeColor = btnTextColour;
            fourBtn.FlatAppearance.BorderColor = btnBorderColour;

            fiveBtn.BackColor = btnBG;
            fiveBtn.ForeColor = btnTextColour;
            fiveBtn.FlatAppearance.BorderColor = btnBorderColour;

            sixBtn.BackColor = btnBG;
            sixBtn.ForeColor = btnTextColour;
            sixBtn.FlatAppearance.BorderColor = btnBorderColour;

            sevenBtn.BackColor = btnBG;
            sevenBtn.ForeColor = btnTextColour;
            sevenBtn.FlatAppearance.BorderColor = btnBorderColour;

            eightBtn.BackColor = btnBG;
            eightBtn.ForeColor = btnTextColour;
            eightBtn.FlatAppearance.BorderColor = btnBorderColour;

            nineBtn.BackColor = btnBG;
            nineBtn.ForeColor = btnTextColour;
            nineBtn.FlatAppearance.BorderColor = btnBorderColour;

            clearBtn.BackColor = btnBGalt1;
            clearBtn.ForeColor = btnTextColour;
            clearBtn.FlatAppearance.BorderColor = btnBorderColour;

            equalBtn.BackColor = btnBGalt1;
            equalBtn.ForeColor = btnTextColour;
            equalBtn.FlatAppearance.BorderColor = btnBorderColour;

            additionBtn.BackColor = btnBGalt1;
            additionBtn.ForeColor = btnTextColour;
            additionBtn.FlatAppearance.BorderColor = btnBorderColour;

            subtractBtn.BackColor = btnBGalt1;
            subtractBtn.ForeColor = btnTextColour;
            subtractBtn.FlatAppearance.BorderColor = btnBorderColour;

            multiplyBtn.BackColor = btnBGalt1;
            multiplyBtn.ForeColor = btnTextColour;
            multiplyBtn.FlatAppearance.BorderColor = btnBorderColour;

            divisionBtn.BackColor = btnBGalt1;
            divisionBtn.ForeColor = btnTextColour;
            divisionBtn.FlatAppearance.BorderColor = btnBorderColour;

            decimalBtn.BackColor = btnBG;
            decimalBtn.ForeColor = btnTextColour;
            decimalBtn.FlatAppearance.BorderColor = btnBorderColour;

            convertToBinary.BackColor = btnBGalt1;
            convertToBinary.ForeColor = btnTextColour;
            convertToBinary.FlatAppearance.BorderColor = btnBorderColour;

            convertToDec.BackColor = btnBGalt1;
            convertToDec.ForeColor = btnTextColour;
            convertToDec.FlatAppearance.BorderColor = btnBorderColour;

            convertToLocationNum.BackColor = btnBGalt1;
            convertToLocationNum.ForeColor = btnTextColour;
            convertToLocationNum.FlatAppearance.BorderColor = btnBorderColour;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) // Apple Radio Button
        {
            var colourBG = Color.FromArgb(65, 65, 65);
            var colourText = Color.White;

            var inputBG = colourBG;
            var inputTextColour = colourText;

            var btnTextColour = colourBG;
            var btnBorderColour = Color.FromArgb(65, 65, 65);
            var btnBG = Color.FromArgb(222, 222, 222);
            var btnBGalt1 = Color.FromArgb(255, 182, 0);
            var btnBGalt2 = Color.FromArgb(200, 200, 200);

            ActiveForm.BackColor = colourBG;
            ActiveForm.ForeColor = colourText;

            calTextBox.BackColor = inputBG;
            calTextBox.ForeColor = inputTextColour;

            textBox1.BackColor = colourBG;
            textBox1.ForeColor = colourText;

            zeroBtn.BackColor = btnBG;
            zeroBtn.ForeColor = btnTextColour;
            zeroBtn.FlatAppearance.BorderColor = btnBorderColour;

            oneBtn.BackColor = btnBG;
            oneBtn.ForeColor = btnTextColour;
            oneBtn.FlatAppearance.BorderColor = btnBorderColour;

            twoBtn.BackColor = btnBG;
            twoBtn.ForeColor = btnTextColour;
            twoBtn.FlatAppearance.BorderColor = btnBorderColour;

            threeBtn.BackColor = btnBG;
            threeBtn.ForeColor = btnTextColour;
            threeBtn.FlatAppearance.BorderColor = btnBorderColour;

            fourBtn.BackColor = btnBG;
            fourBtn.ForeColor = btnTextColour;
            fourBtn.FlatAppearance.BorderColor = btnBorderColour;

            fiveBtn.BackColor = btnBG;
            fiveBtn.ForeColor = btnTextColour;
            fiveBtn.FlatAppearance.BorderColor = btnBorderColour;

            sixBtn.BackColor = btnBG;
            sixBtn.ForeColor = btnTextColour;
            sixBtn.FlatAppearance.BorderColor = btnBorderColour;

            sevenBtn.BackColor = btnBG;
            sevenBtn.ForeColor = btnTextColour;
            sevenBtn.FlatAppearance.BorderColor = btnBorderColour;

            eightBtn.BackColor = btnBG;
            eightBtn.ForeColor = btnTextColour;
            eightBtn.FlatAppearance.BorderColor = btnBorderColour;

            nineBtn.BackColor = btnBG;
            nineBtn.ForeColor = btnTextColour;
            nineBtn.FlatAppearance.BorderColor = btnBorderColour;

            clearBtn.BackColor = btnBGalt2;
            clearBtn.ForeColor = btnTextColour;
            clearBtn.FlatAppearance.BorderColor = btnBorderColour;

            equalBtn.BackColor = btnBGalt1;
            equalBtn.ForeColor = colourText;
            equalBtn.FlatAppearance.BorderColor = btnBorderColour;

            additionBtn.BackColor = btnBGalt1;
            additionBtn.ForeColor = colourText;
            additionBtn.FlatAppearance.BorderColor = btnBorderColour;

            subtractBtn.BackColor = btnBGalt1;
            subtractBtn.ForeColor = colourText;
            subtractBtn.FlatAppearance.BorderColor = btnBorderColour;

            multiplyBtn.BackColor = btnBGalt1;
            multiplyBtn.ForeColor = colourText;
            multiplyBtn.FlatAppearance.BorderColor = btnBorderColour;

            divisionBtn.BackColor = btnBGalt1;
            divisionBtn.ForeColor = colourText;
            divisionBtn.FlatAppearance.BorderColor = btnBorderColour;

            decimalBtn.BackColor = btnBG;
            decimalBtn.ForeColor = btnTextColour;
            decimalBtn.FlatAppearance.BorderColor = btnBorderColour;

            convertToBinary.BackColor = btnBGalt2;
            convertToBinary.ForeColor = btnTextColour;
            convertToBinary.FlatAppearance.BorderColor = btnBorderColour;

            convertToDec.BackColor = btnBGalt2;
            convertToDec.ForeColor = btnTextColour;
            convertToDec.FlatAppearance.BorderColor = btnBorderColour;

            convertToLocationNum.BackColor = btnBGalt2;
            convertToLocationNum.ForeColor = btnTextColour;
            convertToLocationNum.FlatAppearance.BorderColor = btnBorderColour;
        }

        private void sunsetRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            var colourBG = Color.FromArgb(40, 9, 4);
            var colourText = Color.White;

            var inputBG = colourBG;
            var inputTextColour = colourText;

            var btnTextColour = colourText;
            var btnBorderColour = colourBG;
            var btnBG = Color.FromArgb(104, 14, 52);
            var btnBGalt1 = Color.FromArgb(154, 21, 26);
            var btnBGalt2 = Color.FromArgb(194, 27, 18);
            var btnBGalt3 = Color.FromArgb(252, 75, 42);
            var btnBGalt4 = Color.FromArgb(255, 148, 94);

            ActiveForm.BackColor = colourBG;
            ActiveForm.ForeColor = colourText;

            calTextBox.BackColor = inputBG;
            calTextBox.ForeColor = inputTextColour;

            textBox1.BackColor = colourBG;
            textBox1.ForeColor = colourText;

            zeroBtn.BackColor = btnBGalt4;
            zeroBtn.ForeColor = btnTextColour;
            zeroBtn.FlatAppearance.BorderColor = btnBorderColour;

            oneBtn.BackColor = btnBGalt3;
            oneBtn.ForeColor = btnTextColour;
            oneBtn.FlatAppearance.BorderColor = btnBorderColour;

            twoBtn.BackColor = btnBGalt3;
            twoBtn.ForeColor = btnTextColour;
            twoBtn.FlatAppearance.BorderColor = btnBorderColour;

            threeBtn.BackColor = btnBGalt3;
            threeBtn.ForeColor = btnTextColour;
            threeBtn.FlatAppearance.BorderColor = btnBorderColour;

            fourBtn.BackColor = btnBGalt2;
            fourBtn.ForeColor = btnTextColour;
            fourBtn.FlatAppearance.BorderColor = btnBorderColour;

            fiveBtn.BackColor = btnBGalt2;
            fiveBtn.ForeColor = btnTextColour;
            fiveBtn.FlatAppearance.BorderColor = btnBorderColour;

            sixBtn.BackColor = btnBGalt2;
            sixBtn.ForeColor = btnTextColour;
            sixBtn.FlatAppearance.BorderColor = btnBorderColour;

            sevenBtn.BackColor = btnBGalt1;
            sevenBtn.ForeColor = btnTextColour;
            sevenBtn.FlatAppearance.BorderColor = btnBorderColour;

            eightBtn.BackColor = btnBGalt1;
            eightBtn.ForeColor = btnTextColour;
            eightBtn.FlatAppearance.BorderColor = btnBorderColour;

            nineBtn.BackColor = btnBGalt1;
            nineBtn.ForeColor = btnTextColour;
            nineBtn.FlatAppearance.BorderColor = btnBorderColour;

            clearBtn.BackColor = btnBG;
            clearBtn.ForeColor = btnTextColour;
            clearBtn.FlatAppearance.BorderColor = btnBorderColour;

            equalBtn.BackColor = btnBGalt4;
            equalBtn.ForeColor = colourText;
            equalBtn.FlatAppearance.BorderColor = btnBorderColour;

            additionBtn.BackColor = btnBG;
            additionBtn.ForeColor = colourText;
            additionBtn.FlatAppearance.BorderColor = btnBorderColour;

            subtractBtn.BackColor = btnBGalt1;
            subtractBtn.ForeColor = colourText;
            subtractBtn.FlatAppearance.BorderColor = btnBorderColour;

            multiplyBtn.BackColor = btnBGalt2;
            multiplyBtn.ForeColor = colourText;
            multiplyBtn.FlatAppearance.BorderColor = btnBorderColour;

            divisionBtn.BackColor = btnBGalt3;
            divisionBtn.ForeColor = colourText;
            divisionBtn.FlatAppearance.BorderColor = btnBorderColour;

            decimalBtn.BackColor = btnBGalt4;
            decimalBtn.ForeColor = btnTextColour;
            decimalBtn.FlatAppearance.BorderColor = btnBorderColour;

            convertToBinary.BackColor = btnBGalt2;
            convertToBinary.ForeColor = btnTextColour;
            convertToBinary.FlatAppearance.BorderColor = btnBorderColour;

            convertToDec.BackColor = btnBGalt3;
            convertToDec.ForeColor = btnTextColour;
            convertToDec.FlatAppearance.BorderColor = btnBorderColour;

            convertToLocationNum.BackColor = btnBGalt4;
            convertToLocationNum.ForeColor = btnTextColour;
            convertToLocationNum.FlatAppearance.BorderColor = btnBorderColour;
        }

        private void greekRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            var colourBG = Color.White;
            var colourText = Color.FromArgb(65, 65, 65);

            var inputBG = colourBG;
            var inputTextColour = Color.FromArgb(65, 65, 65);

            var btnTextColour = Color.FromArgb(19, 156, 234);
            var btnBorderColour = Color.FromArgb(19, 156, 234);
            var btnBG = Color.White;
            var btnBGalt1 = Color.FromArgb(227, 245, 254);

            ActiveForm.BackColor = colourBG;
            ActiveForm.ForeColor = colourText;

            calTextBox.BackColor = inputBG;
            calTextBox.ForeColor = inputTextColour;

            textBox1.BackColor = colourBG;
            textBox1.ForeColor = colourText;

            zeroBtn.BackColor = btnBG;
            zeroBtn.ForeColor = btnTextColour;
            zeroBtn.FlatAppearance.BorderColor = btnBorderColour;

            oneBtn.BackColor = btnBG;
            oneBtn.ForeColor = btnTextColour;
            oneBtn.FlatAppearance.BorderColor = btnBorderColour;

            twoBtn.BackColor = btnBG;
            twoBtn.ForeColor = btnTextColour;
            twoBtn.FlatAppearance.BorderColor = btnBorderColour;

            threeBtn.BackColor = btnBG;
            threeBtn.ForeColor = btnTextColour;
            threeBtn.FlatAppearance.BorderColor = btnBorderColour;

            fourBtn.BackColor = btnBG;
            fourBtn.ForeColor = btnTextColour;
            fourBtn.FlatAppearance.BorderColor = btnBorderColour;

            fiveBtn.BackColor = btnBG;
            fiveBtn.ForeColor = btnTextColour;
            fiveBtn.FlatAppearance.BorderColor = btnBorderColour;

            sixBtn.BackColor = btnBG;
            sixBtn.ForeColor = btnTextColour;
            sixBtn.FlatAppearance.BorderColor = btnBorderColour;

            sevenBtn.BackColor = btnBG;
            sevenBtn.ForeColor = btnTextColour;
            sevenBtn.FlatAppearance.BorderColor = btnBorderColour;

            eightBtn.BackColor = btnBG;
            eightBtn.ForeColor = btnTextColour;
            eightBtn.FlatAppearance.BorderColor = btnBorderColour;

            nineBtn.BackColor = btnBG;
            nineBtn.ForeColor = btnTextColour;
            nineBtn.FlatAppearance.BorderColor = btnBorderColour;

            clearBtn.BackColor = btnTextColour;
            clearBtn.ForeColor = colourBG;
            clearBtn.FlatAppearance.BorderColor = btnTextColour;

            equalBtn.BackColor = btnBG;
            equalBtn.ForeColor = btnTextColour;
            equalBtn.FlatAppearance.BorderColor = btnBorderColour;

            additionBtn.BackColor = btnTextColour;
            additionBtn.ForeColor = colourBG;
            additionBtn.FlatAppearance.BorderColor = btnBorderColour;

            subtractBtn.BackColor = btnBG;
            subtractBtn.ForeColor = btnTextColour;
            subtractBtn.FlatAppearance.BorderColor = btnBorderColour;

            multiplyBtn.BackColor = btnBG;
            multiplyBtn.ForeColor = btnTextColour;
            multiplyBtn.FlatAppearance.BorderColor = btnBorderColour;

            divisionBtn.BackColor = btnBG;
            divisionBtn.ForeColor = btnTextColour;
            divisionBtn.FlatAppearance.BorderColor = btnBorderColour;

            decimalBtn.BackColor = btnBG;
            decimalBtn.ForeColor = btnTextColour;
            decimalBtn.FlatAppearance.BorderColor = btnBorderColour;

            convertToBinary.BackColor = btnBGalt1;
            convertToBinary.ForeColor = btnTextColour;
            convertToBinary.FlatAppearance.BorderColor = btnBorderColour;

            convertToDec.BackColor = btnBGalt1;
            convertToDec.ForeColor = btnTextColour;
            convertToDec.FlatAppearance.BorderColor = btnBorderColour;

            convertToLocationNum.BackColor = btnBGalt1;
            convertToLocationNum.ForeColor = btnTextColour;
            convertToLocationNum.FlatAppearance.BorderColor = btnBorderColour;

        }
    }
}
