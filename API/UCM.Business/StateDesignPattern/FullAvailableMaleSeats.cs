﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UCM.Business.StateDesignPattern
{
    class FullAvailableMaleSeats : HostelMaleSeatsAvailability
    {
        private void Initialize()
        {
            AvailableMaleSeats = _hostelStatus.MaleSeats;
            OccupiedMaleSeats = 0;
        }
        public FullAvailableMaleSeats(HostelMaleSeatsAvailability state)
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
            if (OccupiedMaleSeats == _hostelStatus.MaleSeats)
                _hostelStatus.state = new FullOccupiedMaleSeats(this);
            else
                if (AvailableMaleSeats == _hostelStatus.MaleSeats)
                    _hostelStatus.state = new FullAvailableMaleSeats(this);
        }
    }
}