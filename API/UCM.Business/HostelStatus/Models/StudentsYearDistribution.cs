namespace UCM.Business.HostelStatus.Models
{
    public class StudentsYearDistribution
    {
        public int YearApplicationsNumber { get; set; }
        public double YearApplicationsPercentage { get; set; }

        public int YearStudentsNumber { get; set; }
        public double YearStudentsPercentage { get; set; }

        public double YearPercentageMean { get; set; }

        public int Year { get; set; }
        public string Gender { get; set; }
    }
}
