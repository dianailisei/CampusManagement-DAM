using System.Threading.Tasks;
using UCM.Business.Generics;
using UCM.Business.Person.Models;

namespace UCM.Business.Person
{
    public interface IPersonService : IDetailsService<PersonDetailsModel>
    {
        Task<Domain.Entities.Person> FindPersonByEmailAsync(string email);
    }
}
