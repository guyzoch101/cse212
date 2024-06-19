/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 1 customer
        // Expected Result: 1 customer added to the queue
        Console.WriteLine("Test 1");
        var test1 = new CustomerService(10);
        test1.AddNewCustomer();
        Console.WriteLine($"Before serving: {test1}");
        test1.ServeCustomer();
        Console.WriteLine($"After serving: {test1}");

        // Defect(s) Found: should save customer in variable before removing from Queue

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 2 customers
        // Expected Result: 2 customers added to the queue
        Console.WriteLine("Test 2");
        var test2 = new CustomerService(10);
        test2.AddNewCustomer();
        test2.AddNewCustomer();
        Console.WriteLine($"Before serving: {test2}");
        test2.ServeCustomer();
        test2.ServeCustomer();
        Console.WriteLine($"After serving: {test2}");

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: no customers
        // Expected Result: "No customers in Queue" displayed
        Console.WriteLine("Test 3");
        var test3 = new CustomerService(10);
        Console.WriteLine($"Before serving: {test3}");
        test3.ServeCustomer();
        Console.WriteLine($"After serving: {test3}");

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 4
        // Scenario: enforced maximum customers
        // Expected Result: Maximum customers = 10 when an invalid number is entered
        Console.WriteLine("Test 4");
        var test4 = new CustomerService(-1);
        Console.WriteLine(test4);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 5
        // Scenario: overflowing number of customers
        // Expected Result: "Maximum customers in Queue" is displayed while exceeding maximum customer
        Console.WriteLine("Test 5");
        var test5 = new CustomerService(3);
        for(int i = 1; i <= (3 + 1); ++i) {
            test5.AddNewCustomer();
            // Console.WriteLine(test5);
        }

        // Defect(s) Found: _queue.Count >(=) _maxSize -> only ">" allows the queue to overflow by 1
        // error message only appears when _queue.Count > _maxSize, which is after the Queue is overflew

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in Queue.");
            return;
        }
        var customer = _queue[0]; // save customer first before removing
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}