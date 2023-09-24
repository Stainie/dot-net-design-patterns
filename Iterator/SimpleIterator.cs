namespace Iterator
{

    /*
     * We use this pattern to traverse a structure.
     * C# provides IEnumerable<T> and IEnumerator<T> interfaces to implement this pattern with yielding.
     */
    public class BinaryTree<T>
    {
        private Node<T> Root { get; set; }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public IEnumerable<Node<T>> InOrderTraversal
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    if (current.Left != null)
                    {
                        foreach (var left in Traverse(current.Left))
                        {
                            yield return left;
                        }
                    }

                    yield return current;

                    if (current.Right != null)
                    {
                        foreach (var right in Traverse(current.Right))
                        {
                            yield return right;
                        }
                    }
                }

                foreach (var node in Traverse(Root))
                {
                    yield return node;
                }

            }
        }

        public IEnumerable<Node<T>> PreorderTraversal
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    yield return current;

                    if (current.Left != null)
                    {
                        foreach (var left in Traverse(current.Left))
                        {
                            yield return left;
                        }
                    }

                    if (current.Right != null)
                    {
                        foreach (var right in Traverse(current.Right))
                        {
                            yield return right;
                        }
                    }
                }

                foreach (var node in Traverse(Root))
                {
                    yield return node;
                }
            }
        }

        public IEnumerable<Node<T>> PostorderTraversal
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    if (current.Left != null)
                    {
                        foreach (var left in Traverse(current.Left))
                        {
                            yield return left;
                        }
                    }

                    if (current.Right != null)
                    {
                        foreach (var right in Traverse(current.Right))
                        {
                            yield return right;
                        }
                    }

                    yield return current;
                }

                foreach (var node in Traverse(Root))
                {
                    yield return node;
                }
            }
        }
    }

    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
}