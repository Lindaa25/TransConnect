using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_TransConnect
{
    class Graphe
    {
        List<NoeudGraphe> listNoeuds = new List<NoeudGraphe>();
        

        public Graphe(List<NoeudGraphe> listNoeuds)
        {
            this.listNoeuds = listNoeuds;
            
        }

        public void CalculDetails(Etape etape)
        {

            foreach (Lien l in etape.Arrive.getAdjacents())
            {
                l.getNoeud().AjouterArrivant(etape.Km + l.Km, etape.Arrive);
            }
        }

        public Etape ChercherPrecedent(NoeudGraphe noeud, List<Etape> list)
        {
            Etape result = list[0];
            foreach (Etape e in list)
            {
                if (e.Arrive == noeud) result = e;
            }
            return result;
        }

        public int Dijkstra(NoeudGraphe depart,NoeudGraphe destination)
        {
            // liste qui stockera le résultat à chaque étape de calcul sous la forme de (km,NoeudPrécedent) qui est un lien
            List<Etape> etapeCalcul = new List<Etape>();
            // la première étape de calcul noeud vers lui même avec km =0 
            Etape etape = new Etape(0, depart, depart);
            etapeCalcul.Add(etape);
            // On initialise le noeud courant
            NoeudGraphe noeudCourant = depart;
            // La liste etapesPossibles contient le choix d'étapes possibles à chaque étape de calcul 
            List<Etape> cheminsPossibles;
            // lePlusCourtChemin servira à calculer le choix optimal à une étape de calcul
            Lien lePlusCourtChemin;
            // optimum est le choix retenu à une étape de calcul ayant le km minimal
            Etape optimum;
            // tant que nous n'avons pas atteint la destination
            while (noeudCourant != destination)
            {
                //Nous recupérons la choix fait à la dernière étape de calcul
                Etape last = etapeCalcul.Last();
                //nous calculons tout les chemins possibles à partir du noeud courant selon la dernière étape de calcul
                CalculDetails(last);
                cheminsPossibles = new List<Etape>();
                foreach (NoeudGraphe n in listNoeuds)
                {
                    //si le noeud n'a pas été déjà traité
                    if (!n.Traite)
                    {
                        //si le noeud a des valeurs pour des chemin arrivant vers lui
                        if (n.Arrivants.Count > 0)
                        {
                            //je cherche le plus court chemin vers le noeud n
                            lePlusCourtChemin = n.minimumSurArrivant();

                            //j'ajoute le chemin trouvé à la liste des étapes possibles
                            cheminsPossibles.Add(new Etape(lePlusCourtChemin.Km, lePlusCourtChemin.getNoeud(), n));

                        }
                    }

                }
            
                optimum = cheminsPossibles[0];
                
                
                foreach (Etape s in cheminsPossibles)
                {
                    if (s.Km <= optimum.Km)
                        optimum = s;

                }
                etapeCalcul.Add(optimum);
                noeudCourant.Traite = true;
                noeudCourant = optimum.Arrive;
                // Dans la suite, nous supprimons les chemins liés au noeud courant choisi pour ne plus les prendre
                //en compte dans les prochaines étapes de calcul
                List<Etape> nouveauxCheminsPossibles = new List<Etape>();
                foreach (Etape s in cheminsPossibles)
                {
                    if (s.Arrive != noeudCourant)
                        nouveauxCheminsPossibles.Add(s);
                }
                cheminsPossibles = nouveauxCheminsPossibles;

            }
            //fin de la boucle while
            //
            //retrouver le plus court chemin en faisant un retour en arrière à partir du la dernière étape de calcul trouvée
            List<Etape> solution = new List<Etape>();
            Etape final = etapeCalcul.Last();
            solution.Add(final);
            etape = final;
            NoeudGraphe noeud;
            while (etape.Precedent != depart)
            {
                noeud = etape.Precedent;
                etape = ChercherPrecedent(noeud, etapeCalcul);
                solution.Add(etape);
            }
            Console.WriteLine("la longueur du plus court chemin est " + solution[0].Km);
            Console.WriteLine("le plus court chemin est:" + "\n");
            Console.Write(depart.Ville + " ");
            for (int i = solution.Count - 1; i >= 0; i--)
            {
                Console.Write(solution[i].Arrive.Ville + " ");
            }
            Console.Write("\n");

            return solution[0].Km;

        }
        public override string ToString()
        {
            string s = "";
            s += "les noeuds du graphe avec leurs adjacents sont: " + "\n";
            foreach (NoeudGraphe n in listNoeuds)
            {
                s += n + "\n";

            }

            return s;


        }
    }
}
