using System;
using UCM.Business.Person.Models;

namespace UCM.Business.Admin.Models
{
    public class AdminDetailsModel : PersonDetailsModel
    {
        public Guid Id { get; set; }
    }
}
