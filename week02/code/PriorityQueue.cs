public class PriorityQueue {
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue irregardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority) {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public String Dequeue() {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            Console.WriteLine("The queue is empty.");
            return null;
        }

        // Find the index of the item with the highest priority to remove
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) { // Bug 3
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority) {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        var highPriorityItem = _queue[highPriorityIndex]; // Bug 2
        _queue.RemoveAt(highPriorityIndex); // removes the highest priority item // Bug 1
        return highPriorityItem.Value;
    }

    public override string ToString() {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem {
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority) {
        Value = value;
        Priority = priority;
    }

    public override string ToString() {
        return $"{Value} (Pri:{Priority})";
    }
}