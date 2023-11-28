using AutoMapper;
using PROYECTO.DataAccess;
using PROYECTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO.Mapper
{
    public class AutosProfile :Profile
    {
        public AutosProfile()
        {
            CreateMap<AutosEntity, AutoModels>().ReverseMap();
        }

    }
}
