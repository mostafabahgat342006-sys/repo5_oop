namespace c__oop_ass5;

internal class DeliveryReport
{
    // Interface Polymorphism
    public void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }

    public void PrintInsurance(IInsurable shipment)
    {
        Console.WriteLine("Insurance: " + shipment.CalculateInsurance());
    }


}
