using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            LinkedList queueList = new LinkedList();
            List<string> strings = new List<string> { "PushBack", "PushFront", "Remove", "PopBack", "PopFront", "Size", "Print" };
            string line = "";
            string caseSwitch = "";
            while (!line.Equals("end"))
            {
                
                line = Console.ReadLine();
                string[] sArray = new string[1];
                sArray = line.Split(' ');
                Console.WriteLine(line);
                for (int i = 0; i <strings.Count; i++)
                {
                    if (sArray[0].Equals(strings[i]))
                    {
                        caseSwitch = strings[i];
                        switch (caseSwitch)
                        {
                            case "PushBack":
                                queueList.PushBack(Convert.ToInt32(sArray[1]));
                                break;
                            case "PushFront":
                                queueList.PushFront(Convert.ToInt32(sArray[1]));
                                break;
                            case "Remove":
                                bool result = queueList.Remove(Convert.ToInt32(sArray[1]));
                                Console.WriteLine(result);
                                break;
                            case "PopBack":
                                int poppedBack = queueList.PopBack();
                                Console.WriteLine(poppedBack);
                                break;
                            case "PopFront":
                                int poppedFront = queueList.PopFront();
                                Console.WriteLine(poppedFront);
                                break;
                            case "Size":
                                int size = queueList.Size();
                                Console.WriteLine(size);
                                break;
                            case "Print":
                                queueList.Print((int x) =>
                                {
                                    Console.Write("{0} ", x);
                                    return 0;
                                });
                                Console.WriteLine();
                                break;
                        }
                        break;
                    }
                    
                }
                
            }

        }
    }
    public struct LinkedList
    {
        private IntNode tail;
        private IntNode head;
        private int size;

        public void PushBack(int data)
        {
            IntNode node = new IntNode(data);
            if (head == null)
            {
                head = node;
                tail = node;
                size++;
            }
            else
            {
                tail.next = node;
                tail = tail.next;
                size++;
            }
        }
        public void PushFront(int data)
        {
            IntNode node = new IntNode(data);
            if (head == null)
            {
                head = node;
                tail = node;
                size++;
            }
            else
            {
                head.prev = node;
                head = node;
                size++;
            }
        }
        public int PopBack()
        {
            if (head == null)
            {
                throw new Exception("empty list");
            }
            else
            {
                int result = tail.data;
                tail = tail.prev;
                if (tail != null)
                {
                    tail.next = null;
                }
                else
                {
                    head = tail;
                }
                size--;
                return result;
            }
        }
        public int PopFront()
        {
            if (head == null)
            {
                throw new Exception("empty list");
            }
            else
            {
                int result = head.data;
                head = head.next;
                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = head;
                }
                size--;
                return result;
            }
        }

        public bool Remove(int data)
        {
            
            IntNode node = head;
            if (data.Equals(head.data))
            {
                PopFront();
            }
            else if (data.Equals(tail.data))
            {
                PopBack();
            }
            else
            {
                while (node != null)
                {
                    if (node.data.Equals(data))
                    {
                        node.prev.next = node.next;
                        node.next.prev = node.prev;
                        size--;
                        return true;
                    }
                    node = node.next;
                }
            }
            return false;
        }

        public void Print(Func<int, int> callback)
        {
            IntNode node = head;
            while (node != null)
            {
                callback(node.data);
                node = node.next;
            }
        }
        public int Size()
        {
            return size;
        }

    }
    class IntNode
    {
        public IntNode next = null;
        public IntNode prev = null;
        public int data;

        public IntNode (int data_, IntNode next_ =null, IntNode prev_ = null)
        {
            data = data_;
            prev = prev_;
            next = next_;
        }
    }
}
