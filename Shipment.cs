namespace c__oop_ass5;

public abstract partial class Shipment
{

    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;

    public static int TotalShipmentsCreated;

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


    //  Static Constructor -> يتنفّذ تلقائيًا (مرة واحدة) عند تهيئة الكلا ويطبع الرسالة المطلوبة.
    static Shipment()
    {
        TotalShipmentsCreated = 0;
        Console.WriteLine("Shipment System Initialized");
    }

   

    public Shipment(string trackingCode)    // constructor 
    {
        this.trackingCode = trackingCode;
        this.description = "Unknown";
        this.weight = 1;
        this.deliveryFee = 50;
        this.Destination = default;

        TotalShipmentsCreated++;
    }

    public Shipment(string trackingCode, string description, decimal weight,
            decimal deliveryFee, DeliveryAddress destination)
    {
        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;

        TotalShipmentsCreated++;
    }

    // 6  Static Method -> دي بترجع قيمة العداد، ولما نيجي نستخدمها هنناديها باسم الكلاس

    public static int GetTotalShipmentsCreated()
    {
        return TotalShipmentsCreated;
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


    // ---------------------------------- kinds of cpyies ----------------------------------

    

    public Shipment CopyShipment()
    {
        return ShallowCopy();
    }

    // Shallow Copy

    public Shipment ShallowCopy()
    {
        TotalShipmentsCreated++; // بتعمل شحنة جديدة، لكن مش بتشغّل الـكونستركتور MemberwiseClone

        return (Shipment)MemberwiseClone();
    }

    // Deep Copy

    public Shipment DeepCopy()
    {
        Shipment copy = (Shipment)MemberwiseClone();

        copy.Destination = new DeliveryAddress
        (
            this.Destination.City,
            this.Destination.Street,
            this.Destination.BuildingNumber
        );
        TotalShipmentsCreated++;   // بتعمل شحنة جديدة، لكن مش بتشغّل الـكونستركتور MemberwiseClone

        return copy;
    }


    // Implementation of ( OnTrackingStatusChanged )
    partial void OnTrackingStatusChanged(string newStatus)
    {
        Console.WriteLine($"Tracking status changed to: {newStatus}");
    }



}
