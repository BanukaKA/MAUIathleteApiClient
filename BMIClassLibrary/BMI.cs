namespace BMIClassLibrary
{

    //Name : Banuka Kumara Ambegoda
    //Test 3 PROG 1442

    //Comment: Change in the Class done to round the final BMI value to 1 decimal place for the ease of testing

    public static class BMI
    {
        public const string HeightBelowZeroMessage = "Height is less than zero";
        public const string WeightBelowZeroMessage = "Weight is less than zero";

        /// <summary>
        /// Helper to calculate BMI based on height in meters and weight in Kg
        /// Returns the numeric value of the BMI and the output string 
        /// contains the BMI category description.
        /// </summary>
        /// <param name="height">Height in Meters</param>
        /// <param name="weight">Weight  in Kilograms</param>
        /// <param name="category">Output string with the Category Description</param>
        /// <returns>Numeric value of the BMI</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double bmiValue(double height, double weight, out string category)
        {
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException("height", height, HeightBelowZeroMessage);
            }
            else if (weight < 0)
            {
                throw new ArgumentOutOfRangeException("weight", weight, WeightBelowZeroMessage);
            }
            else
            {
                double _bmi = weight / Math.Pow(height, 2);

                //Set the category
                if (_bmi < 15)
                {
                    category = "Very severely underweight";
                }
                else if (_bmi < 16)
                {
                    category = "Severely underweight";
                }
                else if (_bmi < 18.5)
                {
                    category = "Underweight";
                }
                else if (_bmi < 25)
                {
                    category = "Normal";
                }
                else if (_bmi <= 30)
                {
                    category = "Overweight";
                }
                else if (_bmi < 35)
                {
                    category = "Obese Class I (Moderately obese)";
                }
                else if (_bmi < 40)
                {
                    category = "Obese Class II (Severely obese)";
                }
                else
                {
                    category = "Obese Class III (Very Severely obese)";
                }
                return Math.Round(_bmi, 1);
            }
        }
    }
}