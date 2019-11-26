using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UCM.Business.Generics;
using UCM.Business.Person.Models;

namespace UCM.Business.Person
{
    public class PersonService : DetailsService<Domain.Entities.Person, PersonDetailsModel>, IPersonService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public PersonService(IGenericRepository genericRepository, IMapper mapper)
            : base(genericRepository, mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Person> FindPersonByEmailAsync(string email)
        {
            var persons = await _genericRepository.FindAsync<Domain.Entities.Person>(x => x.Email == email,
                "PersonRoles.Role");

            return persons.FirstOrDefault();
        }
    }
}
