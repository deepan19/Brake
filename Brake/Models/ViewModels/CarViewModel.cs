using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brake.Models.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }

        private List<Currency> CList = new List<Currency>();

        private List<Currency> CreateList()
        {
            CList.Add(new Currency("USD", "USD"));
            CList.Add(new Currency("CAD", "CAD"));
            CList.Add(new Currency("BTC", "BTC"));
            return CList;
        }

        public CarViewModel()
        {
            Currencies = CreateList();
        }

    }

    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Currency(string id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
