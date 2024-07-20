public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value != Data) {
            if (value < Data) {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        if (value == Data) {
            return true; // base case
        }
        else {
            if (value < Data) { // keep iterating into the left node
                if (Left != null) {
                    return Left.Contains(value); // keep calling the function with the left node
                }
            }
            else { // keep iterating into the right node
                if (Right != null) {
                    return Right.Contains(value); // keep calling the function with the right node
                }
            }
        }
        return false; // after the whole tree is iterated
    }

    public int GetHeight() {
        // TODO Start Problem 4
        // recursively call GetHeight() until reaches a leaf node
        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        // check if current node is not null
        // if not null, call GetHeight() for the left child
        // if left child is null, leftHeight = 0
        int rightHeight = (Right != null) ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, rightHeight); // Replace this line with the correct return statement(s)
        // + 1 is for counting the current node
    }
}