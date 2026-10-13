namespace c__oop_ass5;

public class DeliveryCenter
{
    private Shipment[] shipments;  // array to store shipments 

    public string CenterName { get; set; } = "";

    public DeliveryCenter()  // constructor
    {
        shipments = new Shipment[20];  // store 20 shipment
    }

    // Integer Indexer
    public Shipment this[int index]  // ....هات الشحنه اللي الايندكس بتاعها 
    {
        get
        {
            if (index >= 0 && index < shipments.Length)
            {
                return shipments[index];
            }

            return default;
        }

        set
        {
            if (index >= 0 && index < shipments.Length)
            {
                shipments[index] = value;
            }
        }
    }

    // String Indexer
    public Shipment this[string trackingCode]  // ....دور على الشحنه اللي الكود بتاعها
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++) // يعدي على كود كود يقارنه باللي انت باعته
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    return shipments[i];
                }
            }

            return default;
        }
    }

    // AddShipment
    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)  // لو لاقيت مكان فاضي ضيف فيه 
            {
                shipments[i] = shipment;
                return true;
            }
        }

        return false;
    }

    // RemoveShipment
    public bool RemoveShipment(string trackingCode)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
            {
                shipments[i] = null;
                return true;
            }
        }

        return false;
    }

    // PrintAllShipments
    public void PrintAllShipments()
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null)
            {
                Console.WriteLine("----------------------------");
                shipments[i].PrintShipment();
                Console.WriteLine();
            }
        }
    }



    /*
      Reference type → Shipment
      poosible Actual object  → StandardShipment
     
      GetTrackingStatus() -> not in (shipment) but in Interface:(ITrackable) 
      therefore we do casting -> shipment apply ITrackable , deal with it as a ITrackable

     */
    public void PrintTrackingStatuses()
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null)
            {

                // deal with shipment as a ITrackable 
                // then store it in var : (trackable) 
                ITrackable trackable = (ITrackable)shipments[i];
                
                Console.WriteLine(trackable.GetTrackingStatus());
            }
        }
    }




}
