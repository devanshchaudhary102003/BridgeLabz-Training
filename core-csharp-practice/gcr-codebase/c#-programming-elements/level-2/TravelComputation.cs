using System;

class TravelComputation {
   static void Main(string[] args) {

 
      string name = Console.ReadLine();
      
      string fromCity = Console.ReadLine(); 
	  String viaCity = Console.ReadLine();  
	  String toCity = Console.ReadLine(); 

      double distanceFromToVia = Convert.ToDouble(Console.ReadLine());
      int timeFromToVia = Convert.ToInt32(Console.ReadLine());
      double distanceViaToFinalCity = Convert.ToDouble(Console.ReadLine());
      int timeViaToFinalCity = Convert.ToInt32(Console.ReadLine());

      double totalDistance = distanceFromToVia + distanceViaToFinalCity;
      int totalTime = timeFromToVia + timeViaToFinalCity;

      Console.WriteLine("The Total Distance travelled by "+name+" from "+fromCity+" to "+toCity+" via "+viaCity+" is "+totalDistance+" km and the Total Time taken is "+totalTime+" minutes");
   }
}
