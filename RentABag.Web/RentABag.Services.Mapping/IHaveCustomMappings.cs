using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Services.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
