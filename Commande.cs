using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Commande
    {
        #region Attributs
        Client client;
        string a;
        string b;
        double prix;
        Chauffeur chauffeur;
        string vehicules;
        DateTime date;
        string vehiculeId;

        #endregion

        #region Constructeurs
        public Commande(Client client, string a, string b,double prix, Chauffeur chauffeur,string ve,string veid,DateTime date)
        {
            this.client = client;
            this.a = a;
            this.b = b;
            this.prix = prix;
            this.chauffeur = chauffeur;
            this.vehicules = ve;
            this.vehiculeId = veid;
            this.date = date;
        }
        #endregion

        public Client Client
        {
            get { return client; }
            set { client = value; }
        }

        public string A
        {
            get { return a; }
            set { a = value; }
        }

        public string B
        {
            get { return b; }
            set { a = value; }
        }

        public string Vehicules
        {
            get { return vehicules; }
            set { vehicules = value; }
        }

        public string VehiculeId
        {
            get { return vehiculeId; }
            set { vehiculeId = value; }

        }

        public Chauffeur Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public override string ToString()
        {
            return Client.Nom + ";" + A + ";" + B + ";" + Prix + ";" + Chauffeur.Id + ";" + Vehicules + ";" + VehiculeId + ";" + date;
        }


    }
}
