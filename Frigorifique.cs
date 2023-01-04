using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Frigorifique
    {
        bool libre;
        string id;

        public Frigorifique(string id,bool libre = true)
        {
            this.libre = libre;
            this.id = id;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }

    }
}
