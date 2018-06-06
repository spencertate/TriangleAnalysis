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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Begin text preparation
            String message = "";

            //Pull data from text boxes
            string aRaw = aSideInput.Text;
            string bRaw = bSideInput.Text;
            string cRaw = cSideInput.Text;

            int aInt = 0, bInt = 0, cInt = 0;

            bool valid = true;
            
            //Side A input validation
            if(aRaw.All(c => char.IsDigit(c)) && aRaw != "")
            {
                aInt = Convert.ToInt32(aRaw);
            }
            else
            {
                message += "\nEnsure Side A is a valid integer.";
                valid = false;
            }

            //Side B input validation
            if (bRaw.All(c => char.IsDigit(c)) && bRaw != "")
            {
                bInt = Convert.ToInt32(bRaw);
            }
            else
            {
                message += "\nEnsure Side B is a valid integer.";
                valid = false;
            }

            //Side C input validation
            if (cRaw.All(c => char.IsDigit(c)) && cRaw != "")
            {
                cInt = Convert.ToInt32(cRaw);
            }
            else
            {
                message += "\nEnsure Side C is a valid integer.";
                valid = false;
            }
            
            //Triangle shape validation
            if(valid && !((aInt + bInt > cInt) && (bInt + cInt > aInt) && (cInt + aInt > bInt)))
            {
                message += "\nGiven sides do not make a triangle." + aInt + " " + bInt + " " + cInt;
                valid = false;
            }

            //If not valid, create message box showing errors
            if(!valid)
            {
                MessageBox.Show("Invalid Triangle: " + message);
                return;
            }

            //Begin valid triangle report
            message = "Inputs make a valid triangle of type:";

            //Test for an equilateral triangle
            if(aInt == bInt && bInt == cInt)
            {
                message += "\nEquilateral Triangle";
            }
            else
            {
                //Test for an isosceles triangle
                if(aInt == bInt || bInt == cInt || cInt == aInt)
                {
                    message += "\nIsosceles Triangle";
                }
                //Test for a right triangle
                if(isRight(aInt, bInt, cInt) || isRight(bInt, cInt, aInt) || isRight(cInt, aInt, bInt))
                {
                    message += "\nRight Triangle";
                }
            }

            //If not any of the three above, type is regular
            if(message == "Inputs make a valid triangle of type:")
            {
                message += "\nRegular Triangle";
            }

            //Show output
            MessageBox.Show(message);
        }

        //Encapsulation of Pythagorean Theorem
        private bool isRight(int a, int b, int c)
        {
            return ((a * a) + (b * b)) == (c * c);
        }
    }
}
