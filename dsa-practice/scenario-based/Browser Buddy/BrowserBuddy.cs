using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Collections.Generic;
class HistoryNode
{
    public string Url;
    public HistoryNode prev;
    public HistoryNode next;

    public HistoryNode(string url)
    {
        Url = url;
    }
}

class Tab
{
    private HistoryNode current;

    public void Add(string url)
    {
        HistoryNode node = new HistoryNode(url);

        if(current != null )
        {
            current.next = null;        // clear forward history

            current.next = node;
            node.prev = current;
        }
        current = node;
        Console.WriteLine("Added : "+url);
    } 

    public void Back()
    {
        if(current != null && current.prev != null)
        {
            current = current.prev;
            Console.WriteLine("Back To: "+current.Url);    
        }
        else
        {
            Console.WriteLine("No Back History");
        }
    }

    public void Forward()
    {
        if(current != null && current.next != null)
        {
            current = current.next;
            Console.WriteLine("Forward To: "+current.Url);
        }
        else
        {
            Console.WriteLine("No Forward History");
        }
    }

    public string CurrentPage()
    {
        return current != null ? current.Url : "Empty Tab";
    }
}

class Browser
{
    private Tab CurrentTab;
    private Stack<Tab> ClosedTab;

    public Browser()
    {
        CurrentTab = new Tab();
        ClosedTab = new Stack<Tab>();

        Console.WriteLine("New Tab Opened");
    }

    public void Add(string url)
    {
        CurrentTab.Add(url);
    }

    public void Back()
    {
        CurrentTab.Back();
    }

    public void Forward()
    {
        CurrentTab.Forward();
    }

    public void ClosedTabs()
    {
        ClosedTab.Push(CurrentTab);
        CurrentTab = new Tab();
        Console.WriteLine("Tab Closed");
    }

    public void RestoreTabs()
    {
        if(ClosedTab.Count > 0)
        {
            CurrentTab = ClosedTab.Pop();
            Console.WriteLine("Tab Restore");
        }
        else
        {
            Console.WriteLine("No Closed Tab To Restore");
        }
    }

    public void ShowCurrentPage()
    {
        Console.WriteLine("Current Page: " + CurrentTab.CurrentPage());
    }
}
class BrowserBuddy
{
    static void Main(string[] args)
    {
        Browser browser = new Browser();
        int choice;

        do
        {
            Console.WriteLine("============ Browser Buddy Menu =================");
            Console.WriteLine("1. Add Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Forward");
            Console.WriteLine("4. Show Current Page");
            Console.WriteLine("5. Close Tabs");
            Console.WriteLine("6. Restore Tabs");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter Choice: ");

            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Url: ");
                    string url = Console.ReadLine();
                    browser.Add(url);
                    break;

                case 2:
                    browser.Back();
                    break;

                case 3:
                    browser.Forward();
                    break;

                case 4:
                    browser.ShowCurrentPage();
                    break;

                case 5:
                    browser.ClosedTabs();
                    break;

                case 6:
                    browser.RestoreTabs();
                    break;

                case 0:
                    Console.WriteLine("Existing Browser Buddy.....");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            
        }while(choice != 0);
    }
}