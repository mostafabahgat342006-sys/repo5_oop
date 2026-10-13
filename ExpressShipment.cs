namespace c__oop_ass5;

public class ExpressShipment : Shipment  , ITrackable , IInsurable
{
    private decimal extraFee;  //new property

    public decimal ExtraFee
    {
        get
        {
            return extraFee;
        }

        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
        }
    }

    public override decimal EstimatedCost    // override
    {
        get
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
    }

    public ExpressShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        decimal extraFee  // new 
        ) : base(trackingCode, description, weight, deliveryFee, destination) //  chaining
    {
        ExtraFee = extraFee;

        // عشان  يبدء بحالته الافتراضيه
        UpdateTrackingStatus("Out for Delivery"); 
    }


    public override void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
        Console.WriteLine("Extra Fee: " + ExtraFee);
    }


    /*
     
    // body of method in interface (ITrackable)
    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Out for Delivery.";
    }

    */



    // body of method in interface (IInsurable)
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m;
    }


}
