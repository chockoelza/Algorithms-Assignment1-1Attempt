namespace DefaultNamespace;

public class RPNConverter
{
    public MyQueue Convert(MyQueue inputTokens)
    {
        MyQueue queueOutput = new MyQueue();
        MyStack stackOperator = new MyStack();

        while (!inputTokens.isEmpty())
        {
            string token = inputTokens.Remove();
            if (isNumber(token))
            {
                queueOutput.Add(token);
            }
            else if (token == "(")
            {
                stackOperator.Push(token);
            }

            else if (token == ")")
            {
                while (!stackOperator.isEmpty() && stackOperator.Peek() != "(")
                {
                    queueOutput.Add(stackOperator.Pull());
                }

                stackOperator.Pull();
            }
            else
            {
                while (!stackOperator.isEmpty() && stackOperator.Peek() != "(" &&
                       GetPriority(stackOperator.Peek()) >= GetPriority(token))
                {
                    queueOutput.Add(stackOperator.Pull());
                }
                stackOperator.Push(token);
            }
        }

        while (!stackOperator.isEmpty())
        {
            queueOutput.Add(stackOperator.Pull());
        }

        return queueOutput;
    }
    
    
    public int GetPriority(string op)
    {
        if (op == "-" || op == "+") return 1;
        else if (op == "*" || op == "/") return 2;
        else if (op == "^") return 3;
        return 0;
    }

    public bool isNumber(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return false;
        if (char.IsDigit(token[0])) return true;
        if (token.Length > 1 && token[0] == '-' && char.IsDigit(token[1])) return true;
        return false;
    }
}