using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Camionnette
    {
        string usage;
        bool libre;
        string id;

        public Camionnette(string usage, string id,bool libre = true)
        {
            this.usage = usage;
            this.libre = libre;
            this.id = id;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }

        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }
    }
}
