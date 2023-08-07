using System.Text;

namespace Interpreter
{
    public class SimpleTextToNumberInterpreter
    {
        private Dictionary<char, int> Variables;

        public SimpleTextToNumberInterpreter(Dictionary<char, int> variables)
        {
            Variables = variables;
        }

        public int Calculate(string expression)
        {
            int result = 0;
            int current = 0;
            int i = 0;
            char lastOperator = '+';

            while (i < expression.Length)
            {
                int value;
                if (int.TryParse(expression[i].ToString(), out value))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(value);
                    int j = i;
                    while (++j < expression.Length && int.TryParse(expression[j].ToString(), out value))
                    {
                        sb.Append(value);
                    }
                    current = int.Parse(sb.ToString());
                    i = j - 1; // Adjust the index to the last digit
                }
                else if (expression[i] == '+' || expression[i] == '-')
                {
                    if (lastOperator == '+')
                        result += current;
                    else
                        result -= current;

                    lastOperator = expression[i];
                    current = 0;
                }
                else if (char.IsLetter(expression[i]))
                {
                    if (i < expression.Length - 1 && char.IsLetter(expression[i + 1]))
                    {
                        return 0;
                    }
                    else
                    {
                        if (Variables.ContainsKey(expression[i]))
                        {
                            current = Variables[expression[i]];
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }

                i++;
            }

            // Apply the last operation
            if (lastOperator == '+')
                result += current;
            else
                result -= current;

            return result;
        }

    }
}