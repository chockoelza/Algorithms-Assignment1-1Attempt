namespace DefaultNamespace;

public class Tokenizer
{
    public MyQueue Tokenize(string input)
    {
        MyQueue queueInput = new MyQueue();
        string b = "";
        for (int i = 0; i < input.Length; i++)
        {
            char s = input[i];

            bool isUnaryMinus = false;
            if (s == '-')
            {
                if ((i == 0) || (input[i - 1] == '(' || "+-/*^".Contains(input[i - 1])))
                {
                    isUnaryMinus = true;
                }
            }
            
            if (char.IsDigit(s) || isUnaryMinus)
            {
                b += s;
            }

            else if (char.IsWhiteSpace(s))
            {
                if (b.Length > 0)
                {
                    queueInput.Add(b);
                    b = "";
                }
                
            }

            else if ("+-/*^()".Contains(s))
            {
                if (b.Length > 0)
                {
                    queueInput.Add(b);
                    b = "";
                }
                queueInput.Add(s.ToString());
            }
            else
            {
                throw new Exception(
                    "You need to enter either numbers or operations like (+-/*^), but not something else");
            }
        }

        if (b.Length > 0)
        {
            queueInput.Add(b);
        }

        return queueInput;
    }
}