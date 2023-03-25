using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IRepo<T>
    {
        public void Add(T doctorSchedule);

        public void Update(IEnumerable<T> doctorSchedule);

        public IEnumerable<T> Get();
    }
}
