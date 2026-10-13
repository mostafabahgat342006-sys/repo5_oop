namespace c__oop_ass5;

public abstract class Shipment
{

    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;


    public string TrackingCode
    {
        get
        {
            return trackingCode;
        }

        private set
        {
            if (!string.IsNullOrWhiteSpace(value)) // cannot be null, empty, or whitespace.
            {
                trackingCode = value;
            }
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                description = value;
            }
        }
    }

    public decimal Weight
    {
        get
        {
            return weight;
        }

        set
        {
            if (value > 0)   // validation
            {
                weight = value;
            }
        }
    }

    public decimal DeliveryFee
    {
        get
        {
            return deliveryFee;
        }

        private set
        {
            if (value > 0)
            {
                deliveryFee = value;
            }
        }
    }

    public virtual DeliveryAddress Destination { get; set; }

    public abstract decimal EstimatedCost { get; }  // computed property

    /*
    public virtual decimal EstimatedCost   // computed property
    {
        get
        {
            return DeliveryFee + ((decimal)Weight * 5);
        }
    }
    */


    public Shipment(string trackingCode)    // constructor 
    {
        this.trackingCode = trackingCode;
        this.description = "Unknown";
        this.weight = 1;
        this.deliveryFee = 50;
        this.Destination = default;
    }

    public Shipment(string trackingCode, string description, decimal weight,
            decimal deliveryFee, DeliveryAddress destination)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;
    }

    public void UpdateDeliveryFee(decimal new_Fee)   // to add new fee 
    {
        if (new_Fee > 0)
        {
            DeliveryFee = new_Fee;  // حط الجديد مكان القديم
        }
    }

    // Overloading
    public void UpdateWeight(decimal weight)
    {
        Weight = weight;
    }

    public void UpdateWeight(decimal weight, decimal packingWeight)  
    {
        Weight = weight + packingWeight;
    }



    public abstract void PrintShipment();

    /*
    public virtual void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Delivery Fee: " + DeliveryFee);
        Console.WriteLine("Destination: " + Destination.GetFullAddress());
        Console.WriteLine("Estimated Cost: " + EstimatedCost);
    }
    */


}
