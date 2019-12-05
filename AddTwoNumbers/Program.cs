using System;
using System.Collections.Generic;
using System.Text;

namespace AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {

        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order and each of their nodes contain a single digit. 
        /// Add the two numbers and return it as a linked list.
        /// 
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="l1">first list of digits from the first integer</param>
        /// <param name="l2">second list of digits from the second integer</param>
        /// <example>
        /// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        /// Output: 7 -> 0 -> 8
        /// Explanation: 342 + 465 = 807.
        /// 
        /// </example>
        /// <returns>
        /// a linked list of ints representing the digits of the addition problem above
        /// in reverse order.
        /// </returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)

        {
            ListNode resultListNode = null;
            ListNode currentListNode = null;
            int carryDigit = 0;
            while (l1?.val != null || l2?.val != null)
            {
                int currentAddResult = carryDigit;
                carryDigit = 0;

                if (l1?.val != null)
                {
                    currentAddResult += l1.val;
                    l1 = l1.next;
                }

                if (l2?.val != null)
                {
                    currentAddResult += l2.val;
                    l2 = l2.next;
                }

                int pushDigit = currentAddResult % 10;
                if (resultListNode == null)
                {
                    resultListNode = new ListNode(pushDigit);
                    currentListNode = resultListNode;
                }
                else
                {
                    currentListNode.next = new ListNode(pushDigit);
                    currentListNode = currentListNode.next;
                }

                if (currentAddResult > pushDigit)
                {
                    carryDigit = (currentAddResult - pushDigit) / 10;
                }
            }
            if(carryDigit > 0)
            {
                currentListNode.next = new ListNode(carryDigit);
            }
            return resultListNode;
        }
    }
    class Program
    {
        static ListNode ArrayToListNode(int[] intArray)
        {
            if(intArray.Length == 0)
            {
                return null;
            }

            ListNode resultListNode = new ListNode(intArray[0]);
            ListNode currentListNode = resultListNode;

            for(int i = 1; i < intArray.Length; i++)
            {
                currentListNode.next = new ListNode(intArray[i]);
                currentListNode = currentListNode.next;
            }

            return resultListNode;
        }

        static void PrintLinkedList(ListNode listNode)
        {
            ListNode currentListNode = listNode;
            Console.Write(currentListNode.val + " ");
            while (currentListNode.next != null)
            {
                Console.Write(currentListNode.next.val + " ");
                 currentListNode = currentListNode.next;
            }
        }
        static void Main(string[] args)
        {
            int[] listOneArray = new int[] { 2, 4, 3 };
            int[] listTwoArray = new int[] { 5, 6, 4 };
            ListNode l1 = Program.ArrayToListNode(listOneArray);
            ListNode l2 = Program.ArrayToListNode(listTwoArray);

            ListNode result = new Solution().AddTwoNumbers(l1, l2);

            PrintLinkedList(result);
            Console.Read();
        }
    }
}
