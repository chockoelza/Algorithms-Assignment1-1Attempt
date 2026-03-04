using DefaultNamespace;

class Program
{
    static void Main(string[] args)
    {
        string input;
        if (args.Length > 0)
        {
            input = string.Join("", args);
        }
        else
        {
            Console.WriteLine("Enter an arithmetic example");
            input = Console.ReadLine();
        }

        Tokenizer tokenizer = new Tokenizer();
        MyQueue queueInput = tokenizer.Tokenize(input);

        RPNConverter converter = new RPNConverter();
        MyQueue queueOutput = converter.Convert(queueInput);

        Calculator calc = new Calculator();
        double result = calc.Calculate(queueOutput);
        
        Console.WriteLine($"Result: {result}");
    }
}

