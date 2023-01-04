using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Vehicules
    {
        List<Voiture> voitures;
        List<Camionnette> camionnettes;
        List<PoidsLourds> poidslourds;
        List<Citerne> citernes;
        List<Benne> bennes;
        List<Frigorifique> frigorifiques;


        public Vehicules()
        {
            this.voitures = new List<Voiture>();
            this.camionnettes = new List<Camionnette>();
            this.citernes = new List<Citerne>();
            this.bennes = new List<Benne>();
            this.frigorifiques = new List<Frigorifique>();
        }
        public Vehicules(List<Voiture> voitures, List<Camionnette> camionnettes,List<PoidsLourds> poids, List<Citerne> citernes, List<Benne> bennes, List<Frigorifique> frigorifiques)
        {
            this.voitures = voitures;
            this.camionnettes = camionnettes;
            this.poidslourds = poids;
            this.citernes = citernes;
            this.bennes = bennes;
            this.frigorifiques = frigorifiques;
        }


        public List<Voiture> Voitures
        {
            get { return voitures; }
            set { voitures = value; }
        }

        public List<Camionnette> Camionnettes
        {
            get { return camionnettes; }
            set { camionnettes = value; }
        }

        public List<PoidsLourds> Poidslourds
        {
            get { return poidslourds; }
            set { poidslourds = value; }
        }

        public List<Citerne> Citernes
        {
            get { return citernes; }
            set { citernes = value; }
        }

        public List<Benne> Bennes
        {
            get { return bennes; }
            set { bennes = value; }
        }

        public List<Frigorifique> Frigorifiques
        {
            get { return frigorifiques; }
            set { frigorifiques = value; }
        }
    }
}
