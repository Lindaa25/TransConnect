using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class NoeudGraphe
    {
        string ville;
        List<Lien> adjacents;
        bool traite = false;
        List<Lien> arrivants = new List<Lien>();

        public NoeudGraphe(string ville)
        {
            this.ville = ville;
            adjacents = new List<Lien>();
        }

        public NoeudGraphe(string symbole, List<Lien> adjacents) : this(symbole)
        {
            this.adjacents = adjacents;
        }

        public string Ville
        {
            get { return this.ville; }
            set { this.ville = value; }
        }
        public List<Lien> Arrivants
        {
            get { return this.arrivants; }
            set { this.arrivants = value; }
        }

        public bool Traite
        {
            get { return traite; }
            set { this.traite = value; }
        }

        public List<Lien> getAdjacents()
        {
            return this.adjacents;
        }
        
        public void AjouterLien(int km, NoeudGraphe n)
        {
            
            Lien lien = new Lien(km, n);
            this.adjacents.Add(lien);
            //Console.WriteLine("lien ajouté");

        }

        public void AjouterArrivant(int km, NoeudGraphe n)
        {
            Lien lien = new Lien(km, n);
            this.arrivants.Add(lien);
        }

        // cette méthode permet de calculer le chemin minimal parmi les chemins arrivant vers ce noeud
        public Lien minimumSurArrivant()
        {

            Lien result = this.arrivants[0];
            foreach (Lien l in this.arrivants)
            {
                if (l.Km < result.Km)
                    result = l;
            }

            return result;
        }
        public override string ToString()
        {

            String s = "Noeud: " + this.ville;
            s += "\nles noeuds adjacents sont:";
            foreach (Lien l in this.adjacents)
            {
                s += l.getNoeud().Ville + ", ";
            }
            s += "\n";


            return s;
        }
    }
}
