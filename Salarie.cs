using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Salarie : Personne
    {
        protected DateTime entree;
        protected string poste;
        protected float salaire;

        public Salarie(string numSS,string nom, string prenom, DateTime naissance,string adresse, string mail,string tel,DateTime entree,string poste, float salaire): base(numSS,nom, prenom,naissance , adresse, mail, tel)
        {
            this.entree = entree;
            this.poste = poste;
            this.salaire = salaire;
        }

        public Salarie(string nom, string prenom, string poste, float salaire) : base(nom, prenom)
        {
            this.poste = poste;
            this.salaire = salaire;
        }
        public Salarie(string nom, string prenom, DateTime entree):base(nom,prenom)
        {
            this.entree = entree;
        }
        public Salarie()
        {

        }
        public Salarie(DateTime entree)
        {
            this.entree = entree;
        }

        
        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public float Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public override string ToString()
        {
            return nom + "/" + poste;
        }


    }
}
