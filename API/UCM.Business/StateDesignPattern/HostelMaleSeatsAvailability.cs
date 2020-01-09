using UCM.Business.HostelStatus.Models;

namespace UCM.Business.StateDesignPattern
{
    public abstract class HostelMaleSeatsAvailability
    {
        public HostelStatusDetailsModel _hostelStatus { get; set; }
        public int AvailableMaleSeats { get; set; }
        public int OccupiedMaleSeats { get; set; }
        public abstract void AddOccupiedMaleSeat(int count);
        public abstract void AddAvailableMaleSeat(int count);
        public abstract void AvailabilityCheck();
    }
}
