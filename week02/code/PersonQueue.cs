/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Insert(0, person);
    }

    public Person Dequeue()
    {
        //  a bit of modification here 
        // var person = _queue[0];
        // _queue.RemoveAt(0);

        // modification done here
        int lastIndex = _queue.Count - 1;
        var person = _queue[lastIndex];
        _queue.RemoveAt(lastIndex); 
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}