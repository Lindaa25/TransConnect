using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Noeud
    {
        #region Attributs
        Salarie salarie;
        Noeud fils;
        Noeud frere;
        #endregion

        #region Constructeurs
        public Noeud(Salarie sal, Noeud fils=null, Noeud frere=null)
        {
            this.salarie = sal;
            this.fils = fils;
            this.frere = frere;
        }
        

        #endregion

        #region Propriétés
        public Salarie Salarie
        {
            get { return salarie; }
            set { salarie = value; }
        }

        public Noeud Fils
        {
            get { return fils; }
            set { fils = value; }
        }

        public Noeud Frere
        {
            get { return frere; }
            set { frere = value; }
        }

        #endregion

        #region Ajout Frere

        public Noeud DernierFrere()
        {
            Noeud n = this;
            if (n != null)
            {
                while (n.frere != null)
                {
                    n = n.frere;
                }
            }
            return n;
        }

        public void AjoutFrere(Noeud bro)
        {
            Noeud n = this;
            if (n != null && bro != null)
            {
                Noeud dernier = DernierFrere();
                dernier.Frere = bro;
            }

        }
        #endregion

        #region Ajout Fils
        public void AjoutFils(Noeud son)
        {
            if (son != null && this != null)
            {
                this.fils = son;
                //Console.WriteLine("fils ajouté");
            }
            else
            {
                Console.WriteLine("fils n'a pas été ajouté");
            }
        }
        #endregion

        public void AjoutCommercial(Noeud racine, Noeud n)
        {
            if (n != null && racine != null)
            {
                if (racine.Salarie.Poste.ToLower() == "Directrice commerciale".ToLower())
                {
                    if (racine.Fils == null) { racine.Fils = n; }
                    else { racine.Fils.AjoutFrere(n); }
                    //Console.WriteLine("ajouté");
                }
                AjoutCommercial(racine.Frere, n);
                AjoutCommercial(racine.Fils, n);
            }
        }

        public void AjoutChefEquipe(Noeud racine, Noeud n)
        {
            
            if (n != null && racine != null)
            {
                if (racine.Salarie.Poste.ToLower() == "Directeur des opérations".ToLower())
                {
                    if (racine.Fils == null) { racine.Fils = n; }
                    else { racine.Fils.AjoutFrere(n); }
                    //Console.WriteLine("ajouté");
                   
                }
                AjoutChefEquipe(racine.Frere, n);
                AjoutChefEquipe(racine.Fils, n);
            }
        }

        public void AjoutChauffeur(Noeud racine, Noeud n)
        {

            if (n != null && racine != null)
            {
                if (racine.Salarie.Poste.ToLower().Contains("Equipe".ToLower()))
                {
                    if (racine.Fils == null) { racine.Fils = n; }
                    else { racine.Fils.AjoutFrere(n); }
                    //Console.WriteLine("ajouté");

                }
                AjoutChefEquipe(racine.Frere, n);
                AjoutChefEquipe(racine.Fils, n);
            }
        }

    }
}
