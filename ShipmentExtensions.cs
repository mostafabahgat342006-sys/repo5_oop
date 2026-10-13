namespace c__oop_ass5;

public static class ShipmentExtensions
{

    // shipment data summary 
    public static string GetSummary(this Shipment shipment) 
    {
        // Replace : convert Shipment → " " , because want print (Standard) not (StandardShipment) 
        string type = shipment.GetType().Name.Replace("Shipment", "");

        string status = ((ITrackable)shipment).GetTrackingStatus();

        // Replace : convert "Shipment SH001 is Ready" -→ " "
        // , because want print (Ready) not (Shipment SH001 is Ready) 
        status = status.Replace($"Shipment {shipment.TrackingCode} is ", "");
                       

        return $"{shipment.TrackingCode} | {type} | {shipment.Weight} KG | {status}";

    }

    public static bool IsDelivered(this Shipment shipment)
    {
        string status = ((ITrackable)shipment).GetTrackingStatus();

        return status == $"Shipment {shipment.TrackingCode} is Delivered.";
    }






}
