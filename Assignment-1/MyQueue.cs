namespace DefaultNamespace;

public class MyQueue
{
    private const int Capasity = 100;
    private string[] _array = new string[Capasity];
    private int _head;
    private int _tail;
    private int _currentCount;

    public void Add(string element)
    {
        if (_currentCount == _array.Length)
        {
            throw new Exception("Queue is full");
        }

        _array[_tail] = element;
        _tail = (_tail + 1) % _array.Length;
        _currentCount++;
    }

    public bool isEmpty()
    {
        return _currentCount == 0;
    }
    
    public string? Remove()
    {
        if (isEmpty())
        {
            return null;
        }

        string element = _array[_head];
        _head = (_head + 1) % _array.Length;
        _currentCount--;
        return element;
    }

    public string? Peek()
    {
        if (isEmpty())
        {
            return null;
        }

        return _array[_head];
    }
}