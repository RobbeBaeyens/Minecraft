using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MODELSMinecraft
{
    public abstract class Basisklasse
    {
        public abstract string Valideer(string property);

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Foutmeldingen);
        }

        public string Foutmeldingen
        {
            get
            {
                string foutmeldingen = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead)
                    {
                        string fout = Valideer(item.Name);
                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            foutmeldingen += fout + Environment.NewLine;
                        }
                    }
                }

                return foutmeldingen;
            }
        }
    }
}
