using System;

class UserNode
{
    public int UserId;
    public string Name;
    public int Age;
    public int[] FriendIds;
    public int FriendCount;
    public UserNode Next;

    public UserNode(int userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
        FriendIds = new int[10]; // fixed size for simplicity
        FriendCount = 0;
        Next = null;
    }
}

class SocialMediaList
{
    private UserNode head;

    // Add User
    public void AddUser(int id, string name, int age)
    {
        UserNode newUser = new UserNode(id, name, age);

        if (head == null)
        {
            head = newUser;
        }
        else
        {
            UserNode temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = newUser;
        }
    }

    // Find user by ID
    private UserNode FindUser(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserId == id)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    // Add friend connection
    public void AddFriend(int id1, int id2)
    {
        UserNode user1 = FindUser(id1);
        UserNode user2 = FindUser(id2);

        if (user1 == null || user2 == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        user1.FriendIds[user1.FriendCount++] = id2;
        user2.FriendIds[user2.FriendCount++] = id1;

        Console.WriteLine("Friend connection added");
    }

    // Remove friend connection
    public void RemoveFriend(int id1, int id2)
    {
        UserNode user1 = FindUser(id1);
        UserNode user2 = FindUser(id2);

        if (user1 == null || user2 == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        RemoveFriendId(user1, id2);
        RemoveFriendId(user2, id1);

        Console.WriteLine("Friend connection removed");
    }

    private void RemoveFriendId(UserNode user, int friendId)
    {
        for (int i = 0; i < user.FriendCount; i++)
        {
            if (user.FriendIds[i] == friendId)
            {
                for (int j = i; j < user.FriendCount - 1; j++)
                {
                    user.FriendIds[j] = user.FriendIds[j + 1];
                }
                user.FriendCount--;
                break;
            }
        }
    }

    // Find mutual friends
    public void FindMutualFriends(int id1, int id2)
    {
        UserNode user1 = FindUser(id1);
        UserNode user2 = FindUser(id2);

        Console.WriteLine("Mutual Friends:");
        for (int i = 0; i < user1.FriendCount; i++)
        {
            for (int j = 0; j < user2.FriendCount; j++)
            {
                if (user1.FriendIds[i] == user2.FriendIds[j])
                {
                    Console.WriteLine("User ID: " + user1.FriendIds[i]);
                }
            }
        }
    }

    // Display friends of a user
    public void DisplayFriends(int userId)
    {
        UserNode user = FindUser(userId);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.WriteLine("Friends of " + user.Name + ":");
        for (int i = 0; i < user.FriendCount; i++)
        {
            Console.WriteLine("Friend ID: " + user.FriendIds[i]);
        }
    }

    // Search user
    public void SearchUser(string name)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Found: " + temp.UserId + " " + temp.Name);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("User not found");
    }

    public void SearchUser(int id)
    {
        UserNode user = FindUser(id);
        if (user != null)
            Console.WriteLine("Found: " + user.UserId + " " + user.Name);
        else
            Console.WriteLine("User not found");
    }

    // Count friends for each user
    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.Name + " has " + temp.FriendCount + " friends");
            temp = temp.Next;
        }
    }
    public void DisplayAllUsers()
{
    if (head == null)
    {
        Console.WriteLine("No users available.");
        return;
    }

    UserNode temp = head;
    Console.WriteLine("User List:");

    while (temp != null)
    {
        Console.WriteLine(
            "User ID: " + temp.UserId +
            ", Name: " + temp.Name +
            ", Age: " + temp.Age
        );
        temp = temp.Next;
    }
}
}


class SocialMediaManagement
{
    static void Main(string[] args)
    {
        SocialMediaList list = new SocialMediaList();

        // Add Users
        list.AddUser(1, "Devansh", 21);
        list.AddUser(2, "Rahul", 22);
        list.AddUser(3, "Ankit", 20);
        list.AddUser(4, "Neha", 23);

        // Display All Users
        Console.WriteLine("\nAll Users:");
        list.DisplayAllUsers();

        // Add Friend Connections
        Console.WriteLine("\nAdd Friend Connections:");
        list.AddFriend(1, 2);
        list.AddFriend(1, 3);
        list.AddFriend(2, 3);

        // Display Friends of a User
        Console.WriteLine("\nFriends of User 1:");
        list.DisplayFriends(1);

        // Find Mutual Friends
        Console.WriteLine("\nMutual Friends between User 1 and User 2:");
        list.FindMutualFriends(1, 2);

        // Search User
        Console.WriteLine("\nSearch User by Name:");
        list.SearchUser("Ankit");

        Console.WriteLine("\nSearch User by ID:");
        list.SearchUser(4);

        // Count Friends
        Console.WriteLine("\nFriend Count of Each User:");
        list.CountFriends();

        // Remove Friend Connection
        Console.WriteLine("\nRemove Friend Connection between 1 and 3:");
        list.RemoveFriend(1, 3);

        // Final Friends List
        Console.WriteLine("\nFinal Friends of User 1:");
        list.DisplayFriends(1);
    }
}

