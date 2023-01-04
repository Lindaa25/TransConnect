using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class PoidsLourds
    {
        float volume;
        string matiere;
        bool libre;
        string id;

        public PoidsLourds(float vol,string matiere,string id,bool libre = true)
        {
            this.id = id;
            this.volume = vol;
            this.matiere = matiere;
            this.libre = libre;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public string Matiere
        {
            get { return matiere; }
            set { matiere = value; }
        }

        public bool Libre
        {
            get { return libre; }
            set { libre = value; }
        }

    }

}
