using System;

class UnitNode
{
    public string UnitName;
    public bool IsAvailable;
    public UnitNode Next;

    public UnitNode(string name, bool available)
    {
        UnitName = name;
        IsAvailable = available;
        Next = null;
    }
}

class CircularHospitalRoute
{
    private UnitNode head;
    private UnitNode tail;
    private UnitNode current; // ambulance pointer

    // Add hospital unit
    public void AddUnit(string name, bool available)
    {
        UnitNode newNode = new UnitNode(name, available);

        if (head == null)
        {
            head = tail = newNode;
            tail.Next = head;   // circular link
            current = head;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head;
        }
    }

    // Display circular route
    public void DisplayRoute()
    {
        if (head == null)
        {
            Console.WriteLine("Route is empty.");
            return;
        }

        UnitNode temp = head;
        Console.Write("Hospital Route: ");

        do
        {
            string status = temp.IsAvailable ? "Available" : "Busy";
            Console.Write(temp.UnitName + "(" + status + ") -> ");
            temp = temp.Next;
        }
        while (temp != head);

        Console.WriteLine("Back to Emergency");
    }

    // Remove unit under maintenance
    public void RemoveUnit(string unitName)
    {
        if (head == null)
        {
            Console.WriteLine("No units present.");
            return;
        }

        UnitNode prev = tail;
        UnitNode temp = head;

        do
        {
            if (temp.UnitName.Equals(unitName, StringComparison.OrdinalIgnoreCase))
            {
                // Only one unit
                if (head == tail)
                {
                    head = tail = current = null;
                    Console.WriteLine("Unit " + unitName + " removed. Route empty.");
                    return;
                }

                if (temp == head)
                {
                    head = head.Next;
                    tail.Next = head;
                }

                if (temp == tail)
                {
                    tail = prev;
                    tail.Next = head;
                }

                prev.Next = temp.Next;

                if (current == temp)
                    current = temp.Next;

                Console.WriteLine("Unit " + unitName + " removed for maintenance.");
                return;
            }

            prev = temp;
            temp = temp.Next;
        }
        while (temp != head);

        Console.WriteLine("Unit " + unitName + " not found.");
    }

    // Ambulance rotates until available unit found
    public void RedirectPatient(string patientName)
    {
        if (head == null)
        {
            Console.WriteLine("No hospital units available.");
            return;
        }

        Console.WriteLine("\nAmbulance arriving with " + patientName);
        Console.WriteLine("Starting at: " + current.UnitName);

        UnitNode start = current;

        do
        {
            Console.WriteLine("Checking " + current.UnitName +
                              " (Status: " + (current.IsAvailable ? "Available" : "Busy") + ")");

            if (current.IsAvailable)
            {
                Console.WriteLine("Patient " + patientName +
                                  " redirected to " + current.UnitName);
                current.IsAvailable = false;
                current = current.Next;
                return;
            }

            current = current.Next;
        }
        while (current != start);

        Console.WriteLine("No unit available for patient " + patientName);
    }

    // Mark unit available again
    public void SetAvailable(string unitName)
    {
        if (head == null) return;

        UnitNode temp = head;
        do
        {
            if (temp.UnitName.Equals(unitName, StringComparison.OrdinalIgnoreCase))
            {
                temp.IsAvailable = true;
                Console.WriteLine("Unit " + unitName + " is now AVAILABLE.");
                return;
            }
            temp = temp.Next;
        }
        while (temp != head);
    }
}

class  EmergencyPatientNavigation
{
    static void Main()
    {
        CircularHospitalRoute route = new CircularHospitalRoute();

        // Emergency → Radiology → Surgery → ICU → Emergency
        route.AddUnit("Emergency", false);
        route.AddUnit("Radiology", false);
        route.AddUnit("Surgery", true);
        route.AddUnit("ICU", false);

        route.DisplayRoute();

        route.RedirectPatient("Patient-A");
        route.DisplayRoute();

        route.RedirectPatient("Patient-B");
        route.DisplayRoute();

        route.SetAvailable("ICU");
        route.RedirectPatient("Patient-C");
        route.DisplayRoute();

        route.RemoveUnit("Radiology");
        route.DisplayRoute();

        route.RedirectPatient("Patient-D");
        route.DisplayRoute();
    }
}
