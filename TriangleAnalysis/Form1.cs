using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleAnalysis
{
    public partial class Form1 : Form
    {
        private int aInt = -1, bInt = -1, cInt = -1;

        public Form1()
        {
            InitializeComponent();
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            //Set up message output
            string message = "";

            //Check for initialized inputs
            if (aInt == -1 || bInt == -1 || cInt == -1)
            {
                message += "\nInvalid or nonexistant data.";
                txtOutput.Text = message;
                return;
            }
            
            //Triangle shape validation
            if(!((aInt + bInt > cInt) && (bInt + cInt > aInt) && (cInt + aInt > bInt)))
            {
                message += "\nGiven sides do not make a triangle.";
                txtOutput.Text = message;
                return;
            }

            //Begin valid triangle report
            message += "\nInputs make a valid triangle of type:";

            //Test for an equilateral triangle
            if(aInt == bInt && bInt == cInt)
            {
                message += "\n  Equilateral Triangle";
            }
            else
            {
                //Test for an isosceles triangle
                if(aInt == bInt || bInt == cInt || cInt == aInt)
                {
                    message += "\n  Isosceles Triangle";
                }
                //Test for a right triangle
                if(isRight(aInt, bInt, cInt) || isRight(bInt, cInt, aInt) || isRight(cInt, aInt, bInt))
                {
                    message += "\n  Right Triangle";
                }
            }

            //If not any of the three above, type is regular
            if(message == "\nInputs make a valid triangle of type:")
            {
                message += "\n  Regular Triangle";
            }

            //Show output
            txtOutput.Text = message;
        }

        //Encapsulation of Pythagorean Theorem
        private bool isRight(int a, int b, int c)
        {
            return ((a * a) + (b * b)) == (c * c);
        }
        
        //Update the length of side a
        private void aSideInput_TextChanged(object sender, EventArgs e)
        {
            aInt = ValidateInput(aSideInput.Text);
            UpdateOutput();
        }

        //Update the length of side b
        private void bSideInput_TextChanged(object sender, EventArgs e)
        {
            bInt = ValidateInput(bSideInput.Text);
            UpdateOutput();
        }

        //Update the length of side c
        private void cSideInput_TextChanged(object sender, EventArgs e)
        {
            cInt = ValidateInput(cSideInput.Text);
            UpdateOutput();
        }

        //Check if input string is a valid number
        private int ValidateInput(string inp)
        {
            if ((inp.All(c => char.IsDigit(c)) && inp != ""))
            {
               return Convert.ToInt32(inp);
            }
            return -1;     
        }
    }
}
