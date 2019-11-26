namespace UCM.Business.Hostel.Models
{
    public class HostelCreateModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MapLocation { get; set; }
        public int TotalCapacity { get; set; }
        public string HostelAdminFullName { get; set; }
    }
}
