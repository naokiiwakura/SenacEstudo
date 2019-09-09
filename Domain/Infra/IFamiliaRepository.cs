using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infra
{
    public interface IFamiliaRepository
    {
        List<Familia> Query();
    }
}
