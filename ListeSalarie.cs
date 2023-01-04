using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class ListeSalarie : IVerifiable 
    {
        List<Salarie> listesal;

        #region Constructeurs
        public ListeSalarie()
        {
            listesal = new List<Salarie>();
        }

        public ListeSalarie(List<Salarie> listesal)
        {
            this.listesal = listesal;
        }
        #endregion

        #region Propriété
        public List<Salarie> Listesal
        {
            get { return listesal; }
            set { listesal = value; }
        }
        #endregion

        #region Ajouter un client
        public void AjoutSalarie(Salarie s)
        {
            if (listesal != null)
            {
                listesal.Add(s);
            }
        }
        #endregion

        #region Supprimer un salarie
        public void SupprSalarie(Salarie s)
        {
            if (listesal != null && listesal.Contains(s))
            {
                listesal.Remove(s);
            }
        }
        #endregion

        #region Verifie si salarié est dans la liste
        public bool Verifie(string s)
        {
            bool ver = false;
            foreach (Salarie sal in listesal)
            {
                if (sal.Nom.ToLower() == s.ToLower()) { ver = true; }

            }
            return ver;

        }

        #endregion

        #region Recherche un salarie et le retourne 
        public Salarie RechercheSalarie(string s)
        {
            bool ver = false;
            Salarie salarie=null;
            foreach (Salarie sal in listesal)
            {
                if (sal.Nom.ToLower() == s.ToLower() &&ver==false) 
                { 
                    salarie = sal;
                    ver = true;
                }

            }
            return salarie;
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            foreach (Salarie s in listesal)
            {
                result += s + "\n";
            }
            return result;
        }

       
    }
}
