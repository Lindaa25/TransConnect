using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Benne
    {
        bool libre;
        string utilisation;
        string id;

        public Benne(string utilisation, string id, bool libre = true)
        {
            this.utilisation = utilisation;
            this.id = id;
            this.libre = libre;
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

        public string Utilisation
        {
            get { return utilisation; }
            set { utilisation = value; }
        }


    }
}
