using System;
using System.Collections.Generic;
using System.Text;

namespace UCM.Business.StateDesignPattern
{
    class FullOccupiedMaleSeats : HostelMaleSeatsAvailability
    {
        private void Initialize()
        {
            OccupiedMaleSeats = _hostelStatus.MaleSeats;
            AvailableMaleSeats = 0;
        }
        public FullOccupiedMaleSeats(HostelMaleSeatsAvailability state)
        {
            OccupiedMaleSeats = state.OccupiedMaleSeats;
            _hostelStatus = state._hostelStatus;
            Initialize();
        }
        public override void AddAvailableMaleSeat(int count)
        {
            AvailableMaleSeats += count;
            AvailabilityCheck();
        }

        public override void AddOccupiedMaleSeat(int count)
        {
            OccupiedMaleSeats += count;
            AvailabilityCheck();
        }

        public override void AvailabilityCheck()
        {
            if (AvailableMaleSeats == _hostelStatus.MaleSeats)
            {
                _hostelStatus.state = new FullAvailableMaleSeats(this);
            }
            else
            {
                if (OccupiedMaleSeats != _hostelStatus.MaleSeats)
                {
                    _hostelStatus.state = new AvailableMaleSeats(this);
                }
            }
        }
    }
}
