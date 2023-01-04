using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Lien
    {
        NoeudGraphe noeud;
        int km;

        public Lien(int km, NoeudGraphe noeud)
        {
            this.noeud = noeud;
            this.km = km;
        }

        public int Km
        {
            get { return km; }
            set { this.km = value; }
        }

        public NoeudGraphe getNoeud()
        {
            return this.noeud;
        }
        public override string ToString()
        {
            return "Km: " + km + ", Noeud:" + noeud.Ville;
        }

    }
}
