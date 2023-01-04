using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    
    class Client : Personne,IComparable
    {
        List<Commande> commande;
        float montant;
        string ville;

        public Client(string numSS, string nom, string prenom, DateTime naissance, string adresse, string mail, string tel) : base(numSS, nom, prenom, naissance, adresse, mail, tel)
        {
            List<Commande> commande = new List<Commande>();
            this.montant = 0;
        }

        public Client(string nom, string prenom, DateTime naissance, string adresse, string mail, string tel,string ville,float montant=0):base(nom, prenom, naissance, adresse, mail, tel)
        {
            List<Commande> commande = new List<Commande>();
            this.ville = ville;

            this.montant = montant;
        }
        public Client(string nom, string prenom, string ville) : base(nom, prenom)
        {
            List<Commande> commande = new List<Commande>();
            this.ville = ville;
            this.montant = 0;
        }


        public List<Commande> Commande
        {
            get { return commande; }
            set { commande = value; }
        }

        public float Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }


        #region Affichage avec ToString

        public override string ToString()
        {
            return base.ToString() + ville+";";
        }

        #endregion

        #region Icomparable 
        public int CompareTo(object obj)
        {
            Client val = (Client)obj;
            
            int n = Nom.CompareTo(val.Nom);
            if (n == 0) { n = Prenom.CompareTo(val.Prenom); } //si le même nom on compare le prénom
            return n;
        }
        #endregion

        public int myCompare(Client a, Client b)
        {
            int i = a.Montant.CompareTo(b.Montant);
            
            return i;
            
            
        }
    }
}
