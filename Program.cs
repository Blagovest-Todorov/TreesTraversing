using System;
using System.Collections.Generic;

namespace _22.TreeTraversing
{
    public class TreeNode<T> 
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value) 
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert  null value!");
            }
            this.value = value;
            this.children = new List<TreeNode<T>>(); // constructor method called 
        }

        public T Value   // this is the property
        {
            get 
            {
                return this.value;
            }
            set 
            {
                this.value = value;
            }
          
        }
        public int ChildrenCount
        {
            get 
            {
              return this.children.Count; 
            }
            
        }
        public void AddChild(TreeNode<T> child) 
        {
            if (child == null )
            {
                throw new ArgumentNullException(
                    "Cannnot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException(
                    "the node alredy has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }
        public TreeNode<T> GetChild(int index) 
        {
            return this.children[index];
        }
      
    }
    public class Tree<T> 
    {
        private TreeNode<T> root;
        public Tree(T value) 
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannnot insert null  value!");

            }
            this.root = new TreeNode<T>(value);
        }
        public Tree(T value, params Tree<T>[] children) : this(value) 
        {
            foreach (Tree<T> child  in children)
            {
                this.root.AddChild(child.root);
            }
        }
        // summary
        // the root node or null if teh tree is empty
        // summary

        public TreeNode<T> Root 
        {
            get 
            {
                return this.root;
            }
            
        }
        private void TraverseDFS(TreeNode<T> root, string spaces) 
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);
            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                TraverseDFS(child, spaces + " ");
            }

        }

        public void TraverseDFS() 
        {
            this.TraverseDFS(this.root, string.Empty);
        }

        public void TraverseBFS()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.root);
            while (queue.Count > 0) 
            {
                TreeNode<T> currentNode = queue.Dequeue();
                Console.WriteLine("{0}", currentNode.Value);
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);

                }
            }
        }
        public void TraverseDFSwithStack() 
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.root);
            while (stack.Count> 0) 
            {
                TreeNode<T> currentNode = stack.Pop();
                Console.WriteLine("{0}", currentNode.Value);
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);

                }
            }
          
        }

    }
    public static class TreeExample 
    {
        static void Main() 
        {
            Tree<int> tree =    // We construct here a tree with its children 
                  new Tree<int>(7,
                               new Tree<int>(19,
  
                                            new Tree<int>(1), 
                                            new Tree<int>(12), 
                                            new Tree<int>(31),
                               new Tree<int>(21), 
                               new Tree<int>(14, 
                                            new Tree<int>(23), 
                                            new Tree<int>(6))));
            Console.WriteLine("Depth-firstSearch (DFS) traversal (resursive):");
            tree.TraverseDFS();
            Console.WriteLine();
            // BFS -> uses Queue ! //Breath First Search --searches by neighbours, searches horisaontally iterate
            // DFS - > uses  Stack !,DFS with a Stack is better than DFS with Recursion ! Recursion could fill the Program Stack up!, and crash program
               // Depth -first-Search --searches in vertically in Depth
            Console.WriteLine("Breath-first Search(BFS) traversasl with (with  Queue):");
            tree.TraverseBFS();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Depth-first Search (DFS) traversal (with stack):" );
            tree.TraverseDFSwithStack();
            Console.WriteLine();

        }

    }
}

