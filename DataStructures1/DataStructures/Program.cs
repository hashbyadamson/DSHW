using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Team: 1-14 
//Names: Hannah Adamson, Daniel Keele, Spencer Wood, Connor Olsen
//Description: This program allows you to add, display, delete, search, clear, and add a huge list of items to different data structures. 

namespace DataStructures
{
    class Program
    {
        //This method will make it so we don't have you rewrite the menu each time. 
        public static int mainMenu(string data_type)
        {
            int choice;
            Console.WriteLine("\n1. Add one item to " + data_type + "\n" +
                                        "2. Add Huge List of Items to " + data_type + "\n" +
                                        "3. Display " + data_type + "\n" +
                                        "4. Delete from " + data_type + "\n" +
                                        "5. Clear " + data_type + "\n" +
                                        "6. Search " + data_type + "\n" +
                                        "7. Return to Main Menu\n");

            while ((int.TryParse(Console.ReadLine(), out choice)) == false || choice <= 0 || choice>=8)
            {
                Console.WriteLine("\nPlease enter a number between 1 and 7. Thanks!\n");
            }

            return choice;
        }


  
        static void Main(string[] args)
        {
            int iChoice;
            int iChoice2 = 7;

            //Creating all the data structures
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();

            string sDictStringItem;

            //This while loop will allow you to return to the main menu when you choose option 7.
            while (iChoice2 == 7)
            {
                Console.WriteLine("\nMain Menu:\n1.Stack \n2.Queue \n3.Dictionary \n4.Exit\n");

                //Makes Sure the Userinputs a whole number between 1-4.
                while ((int.TryParse(Console.ReadLine(), out iChoice)) == false || iChoice <= 0 || iChoice >= 5)
                {
                    Console.WriteLine("\nPlease enter a number between 1 and 4. Thanks!\n");
                }

                //Stack Option 
                if (iChoice == 1)
                {

                    iChoice2 = 1;

                    if (iChoice == 1)
                    {
                        while (iChoice2 != 7)
                        {
                            iChoice2 = mainMenu("Stack");
                            string var;

                            //Adding to the stack
                            if (iChoice2 == 1)
                            {
                                Console.WriteLine("\nWhat would you like to add?\n");
                                var = Console.ReadLine();
                                myStack.Push(var);
                                Console.WriteLine("\n" + var + " has been added to the Stack.");
                            }

                            //Add Huge List of Items to the stack
                            else if (iChoice2 == 2)
                            {
                                myStack.Clear();
                                for (int i = 1; i < 2001; i++)
                                {
                                    myStack.Push("New Entry " + i.ToString());
                                }
                                Console.WriteLine("\nAdded 2000 items to the stack.");

                            }

                            //Display the Stack
                            else if (iChoice2 == 3)
                            {
                                foreach (Object obj in myStack)
                                {
                                    Console.Write("    {0}", obj);
                                    Console.WriteLine();
                                }
                                if (myStack.Count == 0)
                                {
                                    Console.WriteLine("\nThere are no items in the stack.");
                                }
                            }

                            //Delete an item from the Stack
                            else if (iChoice2 == 4)
                            {
                                int stacksize;
                                string input = "";
                                bool contains_bool = false;

                                while (!contains_bool)
                                {
                                    Console.WriteLine("\nWhich item would you like to delete? ");
                                    input = Console.ReadLine();
                                    contains_bool = myStack.Contains(input);

                                    if (myStack.Contains(input) == true)
                                    {
                                        stacksize = myStack.Count();
                                        string[] tempArray = new string[stacksize];

                                        for (int i = 0; i < stacksize; i++)
                                        {
                                            string stack_value = myStack.Pop();
                                            if (stack_value != input)
                                            {
                                                tempArray[i] = stack_value;
                                            }
                                        }

                                        myStack.Clear();

                                        int array_length = tempArray.Length;

                                        for (int i = array_length - 1; i >= 0; i--)
                                        {
                                            if (tempArray[i] != null)
                                            {
                                                myStack.Push(tempArray[i]);
                                            }
                                        }

                                        Console.WriteLine("\n" + input + " has been removed from the Stack.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry, that item doesn't exist in the stack.");
                                        contains_bool = true;
                                    }
                                }
                            }

                            //Clear the stack
                            else if (iChoice2 == 5)
                            {
                                myStack.Clear();
                                Console.Write("\nStack cleared.\n");
                            }

                            //Search the Stack
                            else if (iChoice2 == 6)
                            {
                                //Time the search of the stack
                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                                Console.Write("\nWhat would you like to search? \n");
                                string input = Console.ReadLine();

                                sw.Start();

                                if (myStack.Contains(input))
                                {
                                    Console.Write("Found!\n");
                                }
                                else
                                {
                                    Console.Write("Not found.\n");
                                }

                                sw.Stop();

                                TimeSpan ts = sw.Elapsed;
                                Console.Write("Search took: " + ts + "\n");
                            }
                            
                            //Return to the main menu
                            else
                            {
                                iChoice2 = 7;
                            }
                        }


                    }

                }

                //Queue Option
                else if (iChoice == 2)
                {
                    Queue<string> myHoldingQueue = new Queue<string>();
                    string input;
                    iChoice2 = 2;

                    while (iChoice2 != 7)
                    {
                        iChoice2 = mainMenu("Queue");

                        //Add an item to the Queue
                        if (iChoice2 == 1)
                        {
                            Console.WriteLine("\nPlease enter a string.\n");
                            input = Console.ReadLine();
                            myQueue.Enqueue(input);
                            Console.WriteLine("\n" + input + " has been added to the Queue.");
                        }

                        //Add a huge list of items to the queue
                        else if (iChoice2 == 2)
                        {
                            for (int j = 0; j < myQueue.Count; j++)
                            {
                                myQueue.Dequeue();
                            }
                            for (int i = 0; i < 2000; i++)
                            {
                                myQueue.Enqueue("New Entry " + (i + 1));
                            }

                            Console.WriteLine("\nYou have added 2000 items to the Queue.");
                        }

                        //Display the Queue
                        else if (iChoice2 == 3)
                        {
                            Console.Write("\n");
                            int qCount = 0;

                            qCount = myQueue.Count;

                            if (qCount == 0)
                            {
                                Console.WriteLine("There are no items in the Queue.\n");
                            }
                            else
                            {
                                foreach (string item in myQueue)
                                {
                                    Console.WriteLine(item);
                                }
                            }

                        }

                        //Delete an item in the queue
                        else if (iChoice2 == 4)
                        {
                            string input2 = "";
                            string item = "";
                            string switcher = "";
                            int queueCount = 0;
                            int holdingQueueCount = 0;
                            bool wasFound = false;

                            queueCount = myQueue.Count;
                            Console.WriteLine("\nWhat would you like to delete? (Enter a string)\n");
                            input2 = Console.ReadLine();
                            for (int h = 0; h < queueCount; h++)
                            {
                                item = myQueue.Peek();
                                if (input2 == item)
                                {
                                    myQueue.Dequeue();
                                    Console.WriteLine("\n" + item + " has been removed from the Queue.\n");
                                    wasFound = true;
                                }
                                else
                                {
                                    myQueue.Dequeue();
                                    myHoldingQueue.Enqueue(item);
                                }
                            }
                            holdingQueueCount = myHoldingQueue.Count;

                            if (wasFound == true)
                            {

                            }
                            else
                            {
                                Console.WriteLine("\nSorry, that item doesn't exist in the Queue.");
                            }
                            for (int g = 0; g < holdingQueueCount; g++)
                            {
                                switcher = myHoldingQueue.Dequeue();
                                myQueue.Enqueue(switcher);
                            }
                        }

                        //Clear the Queue
                        else if (iChoice2 == 5)
                        {
                            myQueue.Clear();
                            Console.WriteLine("\nThe Queue has been cleared.");
                        }

                        //Search for an item in the queue
                        else if (iChoice2 == 6)
                        {
                            string entry = "";
                            string lookFor = "";
                            string swap = "0;";
                            int queueNum = 0;
                            int holdQ = 0;
                            bool isThere = false;
                            queueNum = myQueue.Count;

                            //time the search in the queue
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                            Console.WriteLine("\nEnter a string that you would like to search for.\n");
                            entry = Console.ReadLine();

                            sw.Start();

                            for (int d = 0; d < queueNum; d++)
                            {
                                lookFor = myQueue.Peek();
                                if (entry == lookFor)
                                {
                                    Console.WriteLine("\n" + entry + " was found in the Queue.");
                                    isThere = true;
                                    sw.Stop();
                                    Console.WriteLine("\nTime elapsed: {0}", sw.Elapsed);
                                    myQueue.Dequeue();
                                    myHoldingQueue.Enqueue(lookFor);
                                }
                                else
                                {
                                    myQueue.Dequeue();
                                    myHoldingQueue.Enqueue(lookFor);
                                }
                            }

                            holdQ = myHoldingQueue.Count;

                            if (isThere == true)
                            {

                            }
                            else
                            {
                                Console.WriteLine("\nSorry, " + entry + " was not found in the Queue.");
                                sw.Stop();
                                Console.WriteLine("\nTime elapsed: {0}", sw.Elapsed);
                            }

                            for (int g = 0; g < holdQ; g++)
                            {
                                swap = myHoldingQueue.Dequeue();
                                myQueue.Enqueue(swap);
                            }
                        }

                        //Return to the main Menu
                        else
                        {
                            iChoice2 = 7;
                        }
                    }


                }

                //Dictionary Option
                else if (iChoice == 3)
                {
                    bool keepGoing=new bool();
                    keepGoing = true;
                    iChoice2 = 3;

                    while (keepGoing)
                            {

                            iChoice2 = mainMenu("Dictionary");
                            
                            //Add an item to the dictionary
                            if (iChoice2 == 1)
                            {
                                Console.WriteLine("\nPlease enter the information you want to input into the dictionary.\n");
                                sDictStringItem = Console.ReadLine();
                                myDictionary.Add((myDictionary.Count+1), sDictStringItem);

                            }

                            //Add a list of items to the dictionary
                            else if (iChoice2 == 2)
                            {
                                myDictionary.Clear();

                                for (int x = new int(); x < 2000; x++)
                                {
                                    myDictionary.Add(x, "New Entry " + (x+1));
                                }

                                Console.WriteLine("\n2000 items have been added to the Dictionary.");

                            }

                            //Display the dictionary
                            else if (iChoice2 == 3)
                            {
                                foreach (KeyValuePair<int, string> entry in myDictionary)
                                {
                                    Console.WriteLine(entry.Value);
                                }

                                if (myDictionary.Count == 0)
                                {
                                    Console.WriteLine("\nThere are no items in the Dictionary.");
                                    
                                }

                            }

                            //Delete an item from the Dictionary
                            else if (iChoice2 == 4)
                            {

                                Console.WriteLine("\nWhat is the value that corresponds with the dictionary entry you would like deleted?\n");
                                string toBeDeleted = Console.ReadLine();

                                if (myDictionary.ContainsValue(toBeDeleted))
                                {
                                    myDictionary.Remove(myDictionary.FirstOrDefault(x => x.Value == toBeDeleted).Key);
                                    Console.WriteLine("\nEntry found and removed.");
                                }
                                else
                                {
                                    Console.WriteLine("\nThat value couldn't be found.");
                                }


                            }

                            //Clear the dictionary
                            else if (iChoice2 == 5)
                            {
                                myDictionary.Clear();
                                Console.WriteLine("\nDictionary cleared successfully.");

                            }

                            //Search the Dictionary
                            else if (iChoice2 == 6)
                            {
                                //Use a stopwatch to time the search
                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                                Console.WriteLine("\nWhat value would you like to search for? \n");

                                string searchQuery=Console.ReadLine();

                                sw.Start();

                                if (myDictionary.ContainsValue(searchQuery))
                                {
                                    Console.WriteLine(searchQuery + " was found with key " +myDictionary.FirstOrDefault(x => x.Value == searchQuery).Key);
                                    sw.Stop();
                                    Console.WriteLine("\nTime elapsed: {0}", sw.Elapsed);
                                }
                                else
                                {
                                    Console.WriteLine("Value not found.");
                                    sw.Stop();
                                    Console.WriteLine("\nTime elapsed: {0}", sw.Elapsed);
                                }

                            }

                            //Return to the main menu
                            else
                            {
                                keepGoing = false;
                            }
                    }



                }

                //Exit the program
                else if (iChoice == 4)
                {

                    Environment.Exit(0);

                }
            
                iChoice2 = 7;
            }
        }
    }
}
