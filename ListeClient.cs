using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class ListeClient
    {
        List<Client> liste;

        #region Constructeurs
        public ListeClient()
        {
            liste = new List<Client>();
        }

        public ListeClient(List<Client> list)
        {
            this.liste = list;
        }
        #endregion

        #region Propriété
        public List<Client> Liste
        {
            get { return liste; }
            set { liste = value; }
        }
        #endregion

        public void RepertoireClient(string fichier)
        {
            StreamReader lecteur = new StreamReader(fichier);
            string ligne = ""; //ligne vide
            string[] tab;
           
            Client client = null;
        
            while (lecteur.Peek() > 0)  
            {
                ligne = lecteur.ReadLine();

                if (ligne != null && ligne != "")
                {

                    tab = ligne.Split(';'); //String.Split retourne un tab de string contenant les sous chaines de ligne séparées par les élements spécifiés()
                    if ((tab != null) && (tab.Length != 0))
                    {
                        client = new Client(tab[0], tab[1], DateTime.Parse(tab[2]), tab[3], tab[4], tab[5], tab[6]);
                        this.liste.Add(client);
                    }

                }

            }
            lecteur.Close();
        }
        #region Ajouter un client

        //Ajoute le nv client à un fichier annexe pour le sauvegarder dedans
        public void AjoutClient(Client c, string fichier)
        {
           
            //RepertoireClient(fichier);
            
            if (liste != null)
            {
                liste.Add(c);
            }

            StreamWriter fichierOut = new StreamWriter(fichier, false);
            foreach (Client cli in liste)
            {
                fichierOut.WriteLine(cli + "\n");
            }
            fichierOut.Close();
        }
        #endregion

        #region Supprimer un client
        public void SupprClient(Client c,string fichier)
        {
            
            if (liste != null && liste.Contains(c))
            {
                
                liste.Remove(c);
            }

            //écrase le fichier puis réécrit la nv liste
            StreamWriter fichierOut = new StreamWriter(fichier, false);
            foreach(Client cli in liste)
            {
                fichierOut.WriteLine(cli + "\n");
            }

            fichierOut.Close();
   
        }

        #endregion

        public bool Verifie(string s)
        {
            bool ver = false;
            foreach (Client client in liste)
            {
                if (client.Nom.ToLower() == s.ToLower()) { ver = true; }

            }
            return ver;

        }

        public Client RechercheClient(string s)
        {
            bool ver = false;
            Client client = null;
            foreach (Client c in liste)
            {
                if(c.Nom.ToLower() == s.ToLower() && ver == false)
                {
                    client = c;
                    ver = true;
                }

            }
            return client;
        }

        

        #region Affichage
        public override string ToString()
        {
            string result = "";
            foreach (Client c in liste)
            {
                result += c + "\n";
                Console.WriteLine("\n");
            }
            return result;
        }
        #endregion

    }
}
