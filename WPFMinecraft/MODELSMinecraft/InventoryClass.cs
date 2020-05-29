using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELSMinecraft
{
    public class InventoryClass : Basisklasse
    {
        public int ItemsAantal { get; set; }

        public InventoryClass(int hoeveelheid)
        {
            this.ItemsAantal = hoeveelheid;
        }

        public override string Valideer(string property)
        {
            if (property == "count" && ItemsAantal < 1)
            {
                return "Number of items must be greater than 0";
            }
            if (property == "count" && ItemsAantal > 64)
            {
                return "number of items cannot exceed 64";
            }
            if (property == "count" && ItemsAantal > 0 && ItemsAantal < 65)
            {
                return "Ok";
            }

            return "error";
        }
    }
}
