using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFluentApi;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        IEFRepo _repo;

        public Logic(IEFRepo repo) 
        {
            _repo = repo;
        }  
        

        public IEnumerable<Allergy> GetAllergies()
        {
            return Mapper.Map(_repo.GetAllData());
        }

        public Allergy AddAllergy(Allergy allergy)
        {
            return Mapper.Map(_repo.Add(Mapper.Map(allergy)));
        }
    }
}
