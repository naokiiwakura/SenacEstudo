using System.Collections.Generic;

namespace Domain.Model
{
    public class Familia
    {
        public string Id { get; set; }
        public IList<Pessoa> Pessoas { get; set; }
        public IList<Renda> Rendas { get; set; }
        public int Status { get; set; }
    }
}
