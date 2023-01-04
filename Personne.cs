using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    abstract class Personne 
    {
        #region Attributs
        protected string numSS;
        protected string nom;
        protected string prenom;
        protected DateTime naissance;
        protected string adresse;
        protected string mail;
        protected string tel;
        #endregion

        #region Constructeurs
        public Personne(string numSS, string nom, string prenom, DateTime naissance, string adresse, string mail, string tel)
        {
            this.numSS = numSS;
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
            this.mail = mail;
            this.tel = tel;
        }

        public Personne(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public Personne(string nom, string prenom, DateTime naissance, string adresse, string mail, string tel)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
            this.mail = mail;
            this.tel = tel;
        }

        public Personne()
        {

        }

        #endregion

        #region Propriétés

        public string NumSS
        {
            get { return numSS; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
        }

        public DateTime Naissance
        {
            get { return naissance; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        #endregion

        public override string ToString()
        {
            return  nom + ";" + prenom + ";" + naissance + ";" + adresse + ";" + mail + ";" + tel+";";

        }
    }
}
