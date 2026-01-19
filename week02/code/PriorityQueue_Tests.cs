using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with varying priorities and make sure they come out in the correct order.
    // Expected Result: The item with the highest priority comes out first, followed by the next highest and so on.
    // Defect(s) Found: Dequeue did not always return the highest priority item first.
    public void TestPriorityQueue_CorrectOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("MediumPriority", 2);
        priorityQueue.Enqueue("HighPriority", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriority", result);
    }

    [TestMethod]
    // Scenario: Add items with the same priority and ensure they are dequeued in the order that they were added.
    // Expected Result: Items with the same priority are dequeued in FIFO order. Based on the priority queue, it should be ItemOne, ItemTwo, ItemFour, and ItemThree.
    // Defect(s) Found: Items with the same priority were not dequeued in FIFO order.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("ItemOne", 3);
        priorityQueue.Enqueue("ItemTwo", 3);
        priorityQueue.Enqueue("ItemThree", 1);
        priorityQueue.Enqueue("ItemFour", 2);

        Assert.AreEqual("ItemOne", priorityQueue.Dequeue());
        Assert.AreEqual("ItemTwo", priorityQueue.Dequeue());
        Assert.AreEqual("ItemFour", priorityQueue.Dequeue());
        Assert.AreEqual("ItemThree", priorityQueue.Dequeue());

    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Add items with the mixed priority and ensure they are dequeued in the order that they were added, with the highest priority FIFO going out in the correct order.
    // Expected Result: Items come out in order of priority, with FIFO order for same priority. Expected order is B3, D3, C2, A1, E1.
    // Defect(s) Found: Items with the same priority were not dequeued in FIFO order.
    public void TestPriorityQueue_PriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A1", 1);
        priorityQueue.Enqueue("B3", 3);
        priorityQueue.Enqueue("C2", 2);
        priorityQueue.Enqueue("D3", 3);
        priorityQueue.Enqueue("E1", 1);

        Assert.AreEqual("B3", priorityQueue.Dequeue());
        Assert.AreEqual("D3", priorityQueue.Dequeue());
        Assert.AreEqual("C2", priorityQueue.Dequeue());
        Assert.AreEqual("A1", priorityQueue.Dequeue());
        Assert.AreEqual("E1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An exception is thrown indicating the queue is empty.
    // Defect(s) Found: InvalidOperationException message was incorrect.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}