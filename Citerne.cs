using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Citerne
    {
        string cuve;
        bool libre;
        string id;

        public Citerne(string cuve,string id, bool libre=true)
        {
            this.cuve = cuve;
            this.libre = libre;
            this.id = id;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Cuve
        {
            get { return cuve; }
            set { cuve = value; }
        }

        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }

    }
}
