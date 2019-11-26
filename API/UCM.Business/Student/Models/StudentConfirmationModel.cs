using System;

namespace UCM.Business.Student.Models
{
    public class StudentConfirmationModel
    {
        public Guid Id { get; set; }
        public bool Confirmed { get; set; }
        public Guid StudentsGroupId { get; set; }
    }
}
