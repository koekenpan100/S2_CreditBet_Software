using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataModels
{
    public class ItemDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
