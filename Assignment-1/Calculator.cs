namespace DefaultNamespace;

public class Calculator
{
    public double Calculate(MyQueue queueRpn)
    {
        MyDoubleStack stack = new MyDoubleStack();
        while (!queueRpn.isEmpty())
        {
            string token = queueRpn.Remove();
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                double result = 0;
                switch (token)
                {
                    case "+": result = operand1 + operand2; break;
                    case "-": result = operand1 - operand2; break;
                    case "*": result = operand1 * operand2; break;
                    case "/":
                        if (operand2 == 0) throw new Exception("Division by zero!");
                        result = operand1 / operand2; break;
                    case "^":
                        result = Math.Pow(operand1, operand2); break;
                }

                stack.Push(result);

            }
        }

        return stack.Pop();
    }
}