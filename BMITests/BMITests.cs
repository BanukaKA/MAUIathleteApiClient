using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMIClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BMIClassLibrary.Tests
{
    //Name : Banuka Kumara Ambegoda
    //Test 3 - PROG1442

    [TestClass()]
    public class BMITests
    {
        #region Part A Value Testing
        [TestMethod()]
        public void BMITestA1()
        {
            //Arraange
            double height = 1.68;
            double weight = 71;            
            double expected = 25.2;
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BMITestA2()
        {
            //Arraange
            double height = 1.78;
            double weight = 72;
            double expected = 22.7;
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BMITestA3()
        {
            //Arraange
            double height = 1.78;
            double weight = 54;
            double expected = 17.0;
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BMITestA4()
        {
            //Arraange
            double height = 1.73;
            double weight = 102;
            double expected = 34.1;
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BMITestA5()
        {
            //Arraange
            double height = 1.90;
            double weight = 101;
            double expected = 28.0;
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Part B Boundary Testing For Exceptions


        //Height below 0
        //Delta = -0.01
        [TestMethod()]
        public void BMITestB3()
        {
            //Arrange
            double height = -0.01;
            double weight = 100;
            string catagory;
            string reply = "";


            //Act
            try
            {
                double bmi = BMI.bmiValue(height, weight, out catagory);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Assert
                if (e.Message.Contains("Height"))
                {
                    StringAssert.Contains(e.Message, BMI.HeightBelowZeroMessage);
                    reply = "height";
                }
                if (e.Message.Contains("Weight"))
                {
                    StringAssert.Contains(e.Message, BMI.WeightBelowZeroMessage);
                    reply = "weight";
                }
                return;
            }
            Assert.Fail($"Failed to get the expected {reply} value");
        }

        //Weight below 0
        //Delta = -0.01
        [TestMethod()]
        public void BMITestB4()
        {
            //Arrange
            double height = 2;
            double weight = -0.01;
            string catagory;
            string reply = "";


            //Act
            try
            {
                double bmi = BMI.bmiValue(height, weight, out catagory);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Assert
                if (e.Message.Contains("Height"))
                {
                    StringAssert.Contains(e.Message, BMI.HeightBelowZeroMessage);
                    reply = "height";
                }
                if (e.Message.Contains("Weight"))
                {
                    StringAssert.Contains(e.Message, BMI.WeightBelowZeroMessage);
                    reply = "weight";
                }
                return;
            }
            Assert.Fail($"Failed to get the expected {reply} value");
        }

        //Both below 0
        //Delta = -0.01
        [TestMethod()]
        public void BMITestB5()
        {
            //Arrange
            double height = -0.01;
            double weight = -0.01;
            string catagory;
            string reply = "height and weight";


            //Act
            try
            {
                double bmi = BMI.bmiValue(height, weight, out catagory);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Assert
                if (e.Message.Contains("Height"))
                {
                    StringAssert.Contains(e.Message, BMI.HeightBelowZeroMessage);
                    reply = "height";
                }
                if (e.Message.Contains("Weight"))
                {
                    StringAssert.Contains(e.Message, BMI.WeightBelowZeroMessage);
                    reply = "weight";
                }
                return;
            }
            Assert.Fail($"Failed to get the expected {reply} value");
        }

        #endregion

        #region Part C Boundary Testing for BMI status

        //Delta = -0.01
        [TestMethod()]
        public void BMITestC1()
        {
            //Arraange
            double height = 1.735;
            double weight = 105;
            //BMI = 35.1 if height is rounded properly thus making Obese class I and Not overweight
            string expectedCatagory = "Obese Class I (Moderately obese)";
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expectedCatagory, catagory);

        }

        [TestMethod()]
        public void BMITestC2()
        {
            //Arraange
            double height = 1.784;
            double weight = 59;
            //This must give of a BMI of 18.5 on the boundary thus making the weight Normal

            string expectedCatagory = "Normal";
            string catagory;

            //Act
            double actual = BMI.bmiValue(height, weight, out catagory);

            //Assert
            Assert.AreEqual(expectedCatagory, catagory);

        }

        #endregion
    }
}