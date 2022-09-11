﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgrammingLanguage: Entity
    {
        public string Name { get; set; }

        public ProgrammingLanguage() { }

            public ProgrammingLanguage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
