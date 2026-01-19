using System.Data.Common;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        //var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario:  Add a customer to the queue and serving the customer
        // Expected Result: Name, number, problem
        Console.WriteLine("Test 1");

        //Customer customer1 = new Customer("name", "1", "Problem 1");
        var cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.ServeCustomer();

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Can I add two customers and then serve the customers in the right order?
        // Expected Result: 
        Console.WriteLine("Test 2");
        var cs1 = new CustomerService(4);
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();

        Console.WriteLine("Now serving customers:");
        cs1.ServeCustomer();
        cs1.ServeCustomer();

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
                // Test 3
        // Scenario: Serve a customer without there being a customer
        // Expected Result: Should error out
        Console.WriteLine("Test 3");
        var cs2 = new CustomerService(4);

        Console.WriteLine("No customers in queue");


        // Defect(s) Found: Will give message

        Console.WriteLine("=================");
                // Test 4
        // Scenario: Does the max number of customers get enforced?
        // Expected Result: last customer should be rejected
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(4);
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();

        Console.WriteLine($"Service Queue: {cs4}");


        // Defect(s) Found: 

        Console.WriteLine("=================");
                // Test 5
        // Scenario: Does the max size default if invalid value is provided
        // Expected Result: 
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {cs5}");


        // Defect(s) Found: 

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
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No Customer in the queue");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}