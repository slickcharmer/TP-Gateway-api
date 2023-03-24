using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Mapper
    {
        public static Models.Allergy Map(DataFluentApi.Entities.Allergy details)
        {
            return new Models.Allergy() 
            { 
                AllergyId=details.AllergyId,
                AllergyName = details.AllergyName
            };
        }

        public static DataFluentApi.Entities.Allergy Map(Models.Allergy details)
        {
            return new DataFluentApi.Entities.Allergy()
            {
                AllergyId = details.AllergyId,
                AllergyName = details.AllergyName
            };
        }

        public static IEnumerable<Models.Allergy> Map(IEnumerable<DataFluentApi.Entities.Allergy> details)
        {
            return details.Select(Map);
        }

    }
}
