namespace DefaultNamespace;

public class MyDoubleStack
{
    private const int Capasity = 100;
    private double[] _array = new double[Capasity];
    private int _pointer;

    public void Push(double element)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Stack is full");
        }
        _array[_pointer] = element;
        _pointer++;
    }

    public double Pop()
    {
        _pointer--;
        double element = _array[_pointer];
        return element;
    }
}