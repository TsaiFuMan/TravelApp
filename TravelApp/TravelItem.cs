using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp
{
    public class TravelItem
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class TravelData
    {
        public List<TravelItem> Miaoli { get; set; }
        public List<TravelItem> Taichung { get; set; }
        public List<TravelItem> Changhua { get; set; }
        public List<TravelItem> Nantou { get; set; }
        public List<TravelItem> Yunlin { get; set; }
        public List<TravelItem> Attractions { get; set; }
        public List<TravelItem> Diet { get; set; }
        public List<TravelItem> Stay { get; set; }
    }

}
