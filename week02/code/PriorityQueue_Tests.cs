using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with distinct, out-of-order priorities (e.g., Value: "Item 1" Prio: 2, Value: "Item 2" Prio: 5, Value: "Item 3" Prio: 1).
    // Expected Result: Dequeue() must return the value "Item 2" because it has the highest priority value (5).
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 5);
        priorityQueue.Enqueue("Item 3", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item 2", result);

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]

    // Scenario: Enqueue multiple items that share the exact same highest priority value (e.g., "First" Prio: 10, then "Second" Prio: 10).
    // Expected Result: Dequeue() must return "First" because it was enqueued first and is closest to the front of the queue (FIFO tie-breaker).
    // Defect(s) Found:
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 3);


        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    
    }

    // Add more test cases as needed below.


    [TestMethod]
    // Scenario: Call Dequeue() immediately on a newly instantiated queue with zero items elements.
    // Expected Result: An InvalidOperationException must be thrown with the exact exception message string "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        
        Assert.AreEqual("The queue is empty.", exception.Message);
    }


    [TestMethod]
    // Scenario: Enqueue a mix of priorities ("Low" Prio: 1, "High-A" Prio: 10, "High-B" Prio: 10), dequeue one element, then add a "Medium" Prio: 5 item, and empty the queue.
    // Expected Result: The first Dequeue() returns "High-A" (FIFO tie-breaker). Consecutive dequeues must return "High-B", then "Medium", and finally "Low".
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High-A", 10);
        priorityQueue.Enqueue("High-B", 10);

        // Dequeue first highest priority
        Assert.AreEqual("High-A", priorityQueue.Dequeue());

        // Add an intermediary priority item
        priorityQueue.Enqueue("Medium", 5);

        // Dequeue remaining items in strict priority order
        Assert.AreEqual("High-B", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}