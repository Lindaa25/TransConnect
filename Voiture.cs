using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Voiture
    {
        int nbPassagers;
        bool libre;
        string id;


        public Voiture(string id,int nb,bool libre = true)
        {
            this.id = id;
            this.nbPassagers = nb;
            this.libre = libre;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
            
        public int NbPassagers
        {
            get { return nbPassagers; }
            set { nbPassagers = value; }
        }

        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }


    }
}
