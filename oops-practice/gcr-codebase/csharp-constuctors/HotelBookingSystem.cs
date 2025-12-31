using System;
public class HotelBooking
{
    public string GuestName;
    public string RoomType;
    public int Nights;

    public HotelBooking()
    {
        GuestName = "Devansh Singh";
        RoomType = "2 Person Room";
        Nights = 3;
    }

    public HotelBooking(string guestName,string roomType,int nights)
    {
        GuestName = guestName;
        RoomType = roomType;
        Nights = nights;
    }

    public HotelBooking(HotelBooking Previous)
    {
        GuestName = Previous.GuestName;
        RoomType = Previous.RoomType;
        Nights = Previous.Nights;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Guest Name:"+GuestName);
        Console.WriteLine("Room Type:"+RoomType);
        Console.WriteLine("Nights:"+Nights);
    }
}
public class HotelBookingSystem
{
    static void Main(string[] args)
    {
        HotelBooking hb = new HotelBooking();
        hb.DisplayDetails();

        HotelBooking hb2 = new HotelBooking("Dev","Deluxe",2);
        hb2.DisplayDetails();

        HotelBooking hb3 = new HotelBooking(hb2);
        hb3.DisplayDetails();
    }
}