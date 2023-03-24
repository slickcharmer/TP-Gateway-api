﻿using Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        public IEnumerable<Allergy> GetAllergies();
        public Allergy AddAllergy(Allergy allergy);
    }
}
