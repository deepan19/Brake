using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brake.Controllers.Resources;
using Brake.Models;

namespace Brake.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelResources>();
        }
    }
}
