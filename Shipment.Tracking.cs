namespace c__oop_ass5;

public abstract partial class Shipment : ITrackable
{
    private string trackingStatus = "Ready";

    // Only Declaration
    partial void OnTrackingStatusChanged(string newStatus);


    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is {trackingStatus}.";
    }


    public void UpdateTrackingStatus(string status)
    {
        // الحالة الجديدة مش فاضية ، وكمان مختلفة عن الحالية
        if (!string.IsNullOrWhiteSpace(status) && trackingStatus != status)
        {
            trackingStatus = status;

            OnTrackingStatusChanged(status);
        }
    }



}
