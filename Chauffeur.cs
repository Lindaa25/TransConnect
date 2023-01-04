using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Chauffeur : Salarie
    {
        bool libre;
        string id;
        int nblivraison;
        int nblivraisonT;
        double prixKm;

        public Chauffeur(DateTime entree, string id,int nblivraisonT=0,int nblivraison=0,bool libre=true): base(entree)
        {
            this.id = id;
            this.prixKm = 0.4 + (0.01 * (DateTime.Now.Year - entree.Year) );
            this.nblivraison = nblivraison;
            this.libre = libre;
            this.nblivraisonT = nblivraisonT;
        }
        

        public Chauffeur()
        {

        }
        public int NblivraisonT
        {
            get { return nblivraisonT; }
            set { nblivraisonT = value; }
        }
        public double PrixKm
        {
            get { return prixKm; }
            set { prixKm = value; }
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

        public  int Nblivraison
        {
            get { return nblivraison; }
            set { nblivraison = value; }
        }



  
    }
}
