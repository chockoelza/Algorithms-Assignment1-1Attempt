namespace DefaultNamespace;

public class MyStack
{
    private const int Capasity = 100;
    private string[] _array = new string[Capasity];
    private int _pointer;

    public void Push(string element)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Stack is full");
        }

        _array[_pointer] = element;
        _pointer++;
    }
    
    public bool isEmpty()
    {
        return _pointer == 0;
    }
    
    public string? Pull()
    {
        if (isEmpty())
        {
            return null;
        }

        _pointer--;
        var value = _array[_pointer];
        return value;
    }

    public string? Peek()
    {
        if (isEmpty())
        {
            return null;
        }
        return _array[_pointer - 1];
    }


}