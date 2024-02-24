using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser {
    public class ExParser {
        public static double Evaluate(string expression) {
            // Replacing ',' with '.' for culture-independent parsing
            expression = expression.Replace(',', '.');
            expression = expression.Replace(" ", "");

            // Special case for square root (√)
            while (expression.Contains("√")) {
                int sqrtIndex = expression.IndexOf("√");
                int endIndex = sqrtIndex + 1;
                while (endIndex < expression.Length && (char.IsDigit(expression[endIndex]) || expression[endIndex] == '.')) {
                    endIndex++;
                }
                double number = double.Parse(expression.Substring(sqrtIndex + 1, endIndex - sqrtIndex - 1), CultureInfo.InvariantCulture);
                double sqrtResult = Math.Sqrt(number);
                expression = expression.Replace("√" + number, sqrtResult.ToString(CultureInfo.InvariantCulture));

                if (sqrtIndex != 0 && char.IsDigit(expression[sqrtIndex - 1])) throw new Exception("NaN");
            }

            // Split the expression into numbers and operators
            List<double> numbers = new List<double>();
            List<char> operators = new List<char>();

            int index = 0;
            while (index < expression.Length) {
                // Find the end of the number
                int endIndex = index + 1;
                while (endIndex < expression.Length && (char.IsDigit(expression[endIndex]) || expression[endIndex] == '.')) {
                    endIndex++;
                }

                // Extract the number
                string numberStr = expression.Substring(index, endIndex - index);
                double number = double.Parse(numberStr, CultureInfo.InvariantCulture);
                numbers.Add(number);

                index = endIndex;

                // Find the next operator (if any)
                if (index < expression.Length) {
                    operators.Add(expression[index]);
                    index++;
                }
            }

            // Evaluate exponentiation (^)
            for (int i = 0; i < operators.Count; i++) {
                if (operators[i] == '^') {
                    numbers[i] = Math.Pow(numbers[i], numbers[i + 1]);
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            // Evaluate multiplication (*) and division (/)
            for (int i = 0; i < operators.Count; i++) {
                if (operators[i] == '/') {
                    numbers[i] /= numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                } else if (operators[i] == '*') {
                    numbers[i] *= numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            // Evaluate addition (+) and subtraction (-)
            double result = numbers[0];
            for (int i = 0; i < operators.Count; i++) {
                if (operators[i] == '+') {
                    result += numbers[i + 1];
                } else if (operators[i] == '-') {
                    result -= numbers[i + 1];
                }
            }

            return result;
        }
    }
}
