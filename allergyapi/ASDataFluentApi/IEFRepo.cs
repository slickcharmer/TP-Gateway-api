using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFluentApi.Entities;

namespace DataFluentApi
{
    public interface IEFRepo
    {
        public List<Allergy> GetAllData();
        public Allergy Add(Allergy entity);

    }
}
