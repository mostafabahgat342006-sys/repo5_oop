namespace c__oop_ass5;

public class PriorityInternationalShipment : InternationalShipment
{
    public PriorityInternationalShipment(
       string trackingCode,
       string description,
       decimal weight,
       decimal deliveryFee,
       DeliveryAddress destination,
       string destinationCountry,
       decimal customsFee
   ) : base(
       trackingCode,
       description,
       weight,
       deliveryFee,
       destination,
       destinationCountry,
       customsFee) //  chaining    
    {
    }

    public sealed override void GenerateCustomsReport()  // seald : no another overrride
    {
        Console.WriteLine("Priority Customs Report");
    }

}
