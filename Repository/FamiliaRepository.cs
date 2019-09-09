using Domain.Infra;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        public List<Familia> Query()
        {
            var json = File.ReadAllText(@"../Repository/Mock/familias.json", Encoding.GetEncoding("iso-8859-1"));

            var familias = JsonConvert.DeserializeObject<List<Familia>>(json);

            return familias;
        }
    }
}
