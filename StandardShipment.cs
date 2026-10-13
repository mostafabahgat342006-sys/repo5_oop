namespace c__oop_ass5;

public class StandardShipment : Shipment , ITrackable , IInsurable
{
    public StandardShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)  //  chaining
    {
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5);
        }
    }
    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }


    /*
     
    // body of method in interface (ITrackable)
    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Ready.";
    }

    */



    // body of method in interface (IInsurable)
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }


}
