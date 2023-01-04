using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    
   //cette classe représente le calcul fait à chaque étape sur un noeud du graphe selon Dijkstra
   
    class Etape
    {
        NoeudGraphe precedent;
        int km;
        NoeudGraphe arrive;

        public Etape(int km, NoeudGraphe precedent, NoeudGraphe arrive)
        {
            this.km = km;
            this.precedent = precedent;
            this.arrive = arrive;
        }
        public NoeudGraphe Precedent
        {
            get { return precedent; }
            set { this.precedent = value; }
        }

        public NoeudGraphe Arrive
        {
            get { return arrive; }
            set { this.arrive = value; }
        }

        public int Km
        {
            get { return km; }
            set { this.km = value; }
        }

        public override string ToString()
        {
            return "précédent " + this.precedent.Ville + " KM=" + this.km + " Arrive " + this.Arrive.Ville;
        }
    }
}
