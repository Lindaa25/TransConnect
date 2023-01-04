using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Arbre
    {
        Noeud noeud;

        public Arbre(Noeud n = null)
        {
            this.noeud = n;
        }


        public Noeud Noeud
        {
            get { return noeud; }
            set { noeud = value; }
        }
        #region AFfichage arbre
        public void AffichageArborescence(Noeud n, int offset = 0)
        {
            if (n != null)
            {
                //Etape 1 - Afficher la valeur
                Console.Write("\n");
                AfficheOffset(offset);

                if (offset != 0) // tous les éléments sauf la racine
                {
                    Console.Write("||");
                }
                Console.Write(n.Salarie);

                //Etape 2 - Appel récursif fils en bas à droite

                if (n.Fils != null)
                {
                    AffichageArborescence(n.Fils, offset + 2);

                }

                // Etape 2 - appel récursif frères en colonne

                if (n.Frere != null)
                {

                    AffichageArborescence(n.Frere, offset);
                }

            }

        }

        public void AfficheOffset(int offset)
        {
            for (int i = 0; i < offset; i++)
            {
                Console.Write("   "); // 3 espaces
            }
        }
        #endregion

        #region créér arbre pour nv salarié en fct de son poste
        public void CreationArbre(Salarie salarie)
        {


            if (salarie.Poste.ToLower().Contains("Directeur".ToLower()) || salarie.Poste.ToLower().Contains("Directrice".ToLower()))
            {
                // on créé noeud salarie
                Noeud directeur = new Noeud(salarie);
                //si racine a déja un fils le noeud devient frère du fils, sinon c'est le fils de la racine
                if (noeud.Fils == null) { noeud.AjoutFils(directeur); }
                else { noeud.Fils.AjoutFrere(directeur); }

            }
            if (salarie.Poste.ToLower() == "Commercial".ToLower())
            {
                Noeud commercial = new Noeud(salarie);
                commercial.AjoutCommercial(noeud, commercial);
            }
            if (salarie.Poste.ToLower().Contains("Equipe".ToLower()))
            {

                Noeud equipe = new Noeud(salarie);
                equipe.AjoutChefEquipe(noeud, equipe);
            }
            if (salarie.Poste.ToLower() == "Chauffeur".ToLower())
            {
                Noeud chauffeur = new Noeud(salarie);
                chauffeur.AjoutChauffeur(noeud, chauffeur);
            }

        }
        #endregion

        #region Supprimer salarié existant

        public void SupprimerNoeud(Salarie salarie,Noeud n)
        {
            
            if (salarie!=null && n != null)
            {
                if (salarie.Nom.ToLower() == n.Salarie.Nom.ToLower())
                {
                    n.Salarie.Nom="LICENCIé";
                    n = null; //prblm avec le fait que ce soit null
                    
                    //if (n.Fils == null&&n.Frere==null) { n = null; }
                    //else { n.Salarie.Nom = "VIDE"; }


                }
                else
                {
                    SupprimerNoeud(salarie, n.Frere);
                    SupprimerNoeud(salarie, n.Fils);
                }
        
            }
        }
        #endregion
    }
}
