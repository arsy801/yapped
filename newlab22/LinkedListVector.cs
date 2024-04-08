namespace newlab22
{
    public class LinkedListVector
    {
        private class Node
        {
            public int value;
            public Node next;

            public Node(int nodeValue = 0, Node? nextNode = null)
            {
                value = nodeValue;
                next = nextNode;
            }
        }

        private Node head;

        public LinkedListVector(int length)
        {
            head = new Node();
            Node node = head;

            for (int i = 1; i < length; i++)
            {
                node.next = new Node();
                node = node.next;
            }
        }

        public LinkedListVector() : this(5) { }

        public int Length
        {
            get
            {
                int Length = 0;
                Node node = head;
                while (node != null)
                {
                    node = node.next;
                    Length++;
                }
                return Length;
            }
        }

        public int this[int index]
        {
            get
            {
                Node node = GetNodeByIndex(index - 1);
                return node.value;
            }
            set
            {
                Node node = GetNodeByIndex(index - 1);
                node.value = value;
            }
        }

        public double GetNorm()
        {
            int sum = 0;

            Node node = head;

            while (node != null)
            {
                sum += node.value * node.value;
                node = node.next;
            }

            return Math.Sqrt(sum);
        }

        public void InsertStart(int value)
        {
            Node node = new Node(value, head);
            head = node;
        }

        public void DeleteStart()
        {
            if (Length == 0)
            {
                return;
            }
            head = head.next;
        }

        public void InsertEnd(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node node = GetNodeByIndex(Length - 1);
                node.next = new Node(value);
            }
        }

        public void DeleteEnd()
        {

            if (head == null)
            {
                return;
            }
            if (head.next == null)
            {
                head = null;
                return;
            }
            Node node = GetNodeByIndex(Length - 2);
            node.next = null;
        }

        public void InsertByIndex(int index, int value)
        {
            if (index == 1)
            {
                InsertStart(value);
            }
            else
            {
                Node prevCurrNode = GetNodeByIndex(index - 2);
                prevCurrNode.next = new Node(value, prevCurrNode.next);
            }
        }

        public void DeleteByIndex(int index)
        {
            if (index < 1 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == Length)
            {
                DeleteEnd();
            }
            else if (index == 1)
            {
                DeleteStart();
            }
            else
            {
                Node prevCurrNode = GetNodeByIndex(index - 2);
                prevCurrNode.next = prevCurrNode.next.next;
            }
        }

        public override string ToString()
        {
            string res = Length + "";
            for (int i = 0; i < Length; i++)
            {
                res += " " + this[i + 1];
            }
            return res;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            Node node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.next;
            }

            return node;
        }
    }
}