public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: create a priority queue with the following persons(priority): Bob(3), Tim(7), Sue(1)
        // Expected Result: Tim
        Console.WriteLine("Test 1");
        var players1 = new PriorityQueue();
        players1.Enqueue("Bob", 3);
        players1.Enqueue("Tim", 7);
        players1.Enqueue("Sue", 1);
        // Console.WriteLine(players);
        Console.WriteLine(players1.Dequeue());
        // Defect(s) Found: none

        Console.WriteLine("---------");

        // Test 2
        // Scenario: create a priority queue with the following persons(priority): Bob(3), Tim(3), Sue(1)
        // Bob and Time have the same priority -> testing if the FIFO strategy is implemented
        // Expected Result: Bob
        Console.WriteLine("Test 2");
        var players2 = new PriorityQueue();
        players2.Enqueue("Bob", 3);
        players2.Enqueue("Tim", 3);
        players2.Enqueue("Sue", 1);
        // Console.WriteLine(players2);
        Console.WriteLine(players2.Dequeue());
        // Defect(s) Found: PriorityQueue Dequeue: line 26 >= -> >
        // only when a greater priority index is encountered, it will update highPriorityIndex
        // highPriorityIndex will remain at the first-in person if encountered same priority index

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
        // Test 3 (complex version of Test 2)
        // Scenario: create a priority queue with the following persons(priority): Bob(10), Tim(6), Sue(11), John(11), Mary(11)
        // Expected Result: Sue
        Console.WriteLine("Test 3");
        var players3 = new PriorityQueue();
        players3.Enqueue("Bob", 10);
        players3.Enqueue("Tim", 6);
        players3.Enqueue("Sue", 11);
        players3.Enqueue("John", 11);
        players3.Enqueue("Mary", 11);
        // Console.WriteLine(players3);
        Console.WriteLine(players3.Dequeue());
        // Defect(s) Found: none

        Console.WriteLine("---------");

        // Test 4
        // Scenario: empty queue
        // Expected Reuslt: "The queue is empty."
        Console.WriteLine("Test 4");
        var players4 = new PriorityQueue();
        // Console.WriteLine(players4);
        Console.WriteLine(players4.Dequeue());
        // Defect(s) Found: none

        Console.WriteLine("---------");
    }
}