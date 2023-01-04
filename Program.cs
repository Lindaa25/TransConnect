using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet_TransConnect
{
    class Program
    {

        #region client
        public static void AjoutClient(ListeClient listeclient)
        {
            listeclient.RepertoireClient("ListeClient.txt");
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous ajouter un client ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            while (rep == "oui")
            {
                Console.Write("\nEntrez nom : ");
                string nom = Console.ReadLine();
                Console.Write("\nEntrez prénom : ");
                string prenom = Console.ReadLine();
                Console.Write("\nEntrez date de naissance (JJ/MM/AAAA): ");
                DateTime naissance = DateTime.Parse(Console.ReadLine());
                Console.Write("\nEntrez adresse : ");
                string adresse = Console.ReadLine();
                Console.Write("\nEntrez ville : ");
                string ville = Console.ReadLine();
                Console.Write("\nEntrez mail : ");
                string mail = Console.ReadLine();
                Console.Write("\nEntrez tel: ");
                string tel = Console.ReadLine();

                Client c = new Client(nom, prenom, naissance, adresse, mail, tel,ville);
                
                listeclient.AjoutClient(c, "ListeClient.txt");
                Console.WriteLine(listeclient);

                do
                {
                    Console.WriteLine("Voulez-vous ajouter un client ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");

            }
        }

        public static void SupprClient(ListeClient listeclient)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous supprimer un client ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            while (rep == "oui")
            {
                Console.WriteLine("Quel client voulez-vous supprimer ? donnez son nom");
                string nom = Console.ReadLine();
                Client s = null;
                if(listeclient == null)
                {
                    listeclient.RepertoireClient("ListeClient.txt");
                }
                
                if (listeclient.Verifie(nom))
                {
                    
                    s = listeclient.RechercheClient(nom);
                    listeclient.SupprClient(s, "ListeClient.txt");
                    
                }
                Console.WriteLine("liste des salariés :\n" + listeclient);
                Console.WriteLine("\n");
                do
                {
                    Console.WriteLine("Voulez-vous supprimer un client ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");

               
            }
        }

        public static void OrdreAlphabetique(ListeClient liste)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous afficher les clients dans l'ordre alphabétique ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");
            while (rep == "oui")
            {
                liste.Liste.Sort();
                liste.Liste.ForEach(x => Console.WriteLine(x + "\n"));
                Console.WriteLine("\n");

                do
                {
                    Console.WriteLine("Voulez-vous afficher les clients dans l'ordre alphabétique ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");
            }
        }

        public static void TriParVille(ListeClient liste)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous afficher les clients par ville ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");
            while (rep == "oui")
            {
                List<Client> listeC = liste.Liste.OrderBy(x => x.Ville).ToList();
                listeC.ForEach(x => Console.WriteLine(x.Nom +" "+x.Prenom +" - "+x.Ville+"\n"));

                Console.WriteLine("\n");

                do
                {
                    Console.WriteLine("Voulez-vous afficher les clients par ville ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");
            }
        }

        public static void TriParAchatCumule(ListeClient liste)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous afficher les clients par montant des achats cumulés ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");
            while (rep == "oui")
            {
                liste.Liste.ForEach(delegate (Client j) { Console.Write(j.Prenom + " " + j.Nom + " "+j.Montant+"\n"); });
     
                Console.WriteLine("\n");

                do
                {
                    Console.WriteLine("Voulez-vous afficher les clients par montant des achats cumulés ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");
            }
        }

        public static void ModifierMontantachat(ListeClient liste)
        {
            Console.WriteLine("Modifier Montant achat des clients ? oui/non" );
            string rep = Console.ReadLine();

            if (rep == "oui")
            {
                foreach (Client c in liste.Liste)
                {
                    Console.WriteLine("Ecrivez un Montant : ");
                    float montant = float.Parse(Console.ReadLine());
                    c.Montant = montant;
                }
            }
        }
        #endregion

        #region Salariés

        public static void NoeudSalarie()
        {
            Salarie dupond = new Salarie("Dupond", "Pierre", "Directeur général", 200000);
            Noeud racine = new Noeud(dupond);
            Arbre organigramme = new Arbre(racine);


            ListeSalarie listeSal2 = new ListeSalarie();
            Salarie s = new Salarie("Stark", "Tony", "Chef d'Equipe", 15000);
            Salarie s1 = new Salarie("Rogers", "Steve", "Directeur des opérations", 15000);
            Salarie s2 = new Salarie("Banner", "Bruce", "Commercial", 15000);
            Salarie s3 = new Salarie("Romanoff", "Natasha", "Directrice commerciale", 15000);

            listeSal2.AjoutSalarie(s1);
            listeSal2.AjoutSalarie(s);
            listeSal2.AjoutSalarie(s3);
            listeSal2.AjoutSalarie(s2);

            organigramme.CreationArbre(s1);
            organigramme.CreationArbre(s);
            organigramme.CreationArbre(s3);
            organigramme.CreationArbre(s2);

            organigramme.AffichageArborescence(racine);
            Console.WriteLine("\n");
            LicencierSalarie(listeSal2, organigramme);

        }

        //demande à l'utilisateur s'il veut voir l'organigramme et l'afficher si oui
        public static void AfficherOrganigramme(Arbre organigramme,Noeud racine)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous afficher l'organigramme ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            if(rep == "oui")
            {
                //méthode dans la classe Arbre
                organigramme.AffichageArborescence(racine);
                Console.WriteLine("\n");
            }
            
        }
   
        public static void AjoutSalarie(ListeSalarie liste,Arbre arbre)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous ajouter un salarié ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            while(rep == "oui")
            {
                /*
                Console.Write("Entrez n°SS : ");
                string ss = Console.ReadLine();
                Console.Write("\nEntrez nom : ");
                string nom = Console.ReadLine();
                Console.Write("\nEntrez prénom : ");
                string prenom = Console.ReadLine();
                Console.Write("\nEntrez date de naissance (JJ/MM/AAAA): ");
                DateTime naissance = DateTime.Parse(Console.ReadLine());
                Console.Write("\nEntrez adresse : ");
                string adresse = Console.ReadLine();
                Console.Write("\nEntrez mail : ");
                string mail = Console.ReadLine();
                Console.Write("\nEntrez tel: ");
                string tel = Console.ReadLine();
                Console.Write("\nEntrez date entrée dans l'entreprise: ");
                DateTime entree = DateTime.Parse(Console.ReadLine());
                */
                Console.Write("\nEntrez nom : ");
                string nom = Console.ReadLine();
                Console.Write("\nEntrez prénom : ");
                string prenom = Console.ReadLine();
                Console.Write("\nEntrez poste : ");
                string poste = Console.ReadLine();
                Console.Write("\nEntrez salaire : ");
                float salaire = float.Parse(Console.ReadLine());

                Salarie s = new Salarie(nom, prenom, poste, salaire);
                //Salarie s = new Salarie(ss, nom, prenom, naissance, adresse, mail, tel, entree, poste, salaire);

                liste.AjoutSalarie(s);  //ajout du salarie dans la liste de salarié
                arbre.CreationArbre(s);

                Console.WriteLine("Liste des salariés : \n"+liste);
                arbre.AffichageArborescence(arbre.Noeud);
                Console.WriteLine("\n");
                do
                {
                    Console.WriteLine("Voulez-vous ajouter un salarié ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");

            }
            
        }

        public static void LicencierSalarie(ListeSalarie liste,Arbre arbre)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous licencier un salarié ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non"); //reponse attendue oui ou non

            while(rep == "oui")
            {
                Console.WriteLine("Quel salarié voulez-vous licencier ? donnez son nom");
                string nom = Console.ReadLine();
                Salarie s = null;
                if (liste.Verifie(nom)) 
                {
                    s = liste.RechercheSalarie(nom);
                    liste.SupprSalarie(s);
                    arbre.SupprimerNoeud(s, arbre.Noeud);
                }
                Console.WriteLine("liste des salariés :\n"+liste);
                
                arbre.AffichageArborescence(arbre.Noeud);
                Console.WriteLine("\n");

                do
                {
                    Console.WriteLine("Voulez-vous licencier un salarié ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");
            }

        }

        #endregion

        #region Commandes
        public static void CreerCommande(ListeClient liste,List<Chauffeur> listeChauffeur,Vehicules vehicules,List<Commande> listeCommande)
        {
            string rep;
            do
            {
                Console.WriteLine("Voulez-vous ajouter une commande ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            while (rep == "oui")
            {
                Console.WriteLine("Nom du client qui a passé la commande: ");
                string nom = Console.ReadLine();
                Client s = null; //notre client pour attribut Commande
                liste.RepertoireClient("ListeClient.txt"); //récupère la liste de client dans le fichier ListeClient.txt
                if (!liste.Verifie(nom)) { AjoutClient(liste); }
                s = liste.RechercheClient(nom);

                Console.WriteLine("Entrer la date de la commande (JJ/MM/AAAA): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Entrer le point de départ (ville): ");
                string pointA = Console.ReadLine();
                Console.WriteLine("Entrer le point d'arrivée (ville): ");
                string pointB = Console.ReadLine();

                #region Chauffeur
                Chauffeur c = new Chauffeur();
                bool trouve=false;
                for(int i = 0; i <= listeChauffeur.Count && trouve==false; i++)
                {
                    if(listeChauffeur[i].Libre == true && listeChauffeur[i].Nblivraison<1) //si le chauffeur est libre et n'a pas fait de livraison aujourd'hui
                    {
                        c = listeChauffeur[i];
                        listeChauffeur[i].Nblivraison++; //on lui ajoute livraison aujourd'hui
                        listeChauffeur[i].Libre = true;
                        c.NblivraisonT++; //on ajoute au chauffeur une livraison à son nb total de livraison

                        trouve = true;
                    }
                }
                #endregion
                Console.WriteLine("Entrer le véhicule (Voiture,Camionnette,PoidsLourds,Citerne,Benne,Frigorifique): ");

                string vehicule = Console.ReadLine();

                string vehiculeId="";

                if (vehicule == "Voiture")
                {
                    Console.WriteLine("Combien de passagers ? ");
                    int nbPassagers = int.Parse(Console.ReadLine());
                    bool trouve1 = false;
                    for (int i = 0; i < vehicules.Voitures.Count && trouve1 == false; i++)
                    {
                        if (vehicules.Voitures[i].Libre == true && vehicules.Voitures[i].NbPassagers==nbPassagers) //si la voiture est libre et a le nb de place qu'il faut
                        {
                            vehiculeId = vehicules.Voitures[i].Id;
                            vehicules.Voitures[i].Libre=true;
                            trouve = true;
                        }
                    }
                }
                else if(vehicule == "Camionenette")
                {
                    Console.WriteLine("Pour quel usage ? ");
                    string usage = Console.ReadLine();
                    trouve = false;
                    for (int i = 0; i <= vehicules.Camionnettes.Count && trouve == false; i++)
                    {
                        if (vehicules.Camionnettes[i].Libre == true && vehicules.Camionnettes[i].Usage == usage) //si la camionette est libre et est fait pr le mm usage
                        {
                            vehiculeId = vehicules.Camionnettes[i].Id;
                            vehicules.Voitures[i].Libre = true;
                            trouve = true;
                        }
                    }

                }
                else if(vehicule == "PoidsLourds")
                {
                    trouve = false;
                    for (int i = 0; i <= vehicules.Poidslourds.Count && trouve == false; i++)
                    {
                        if (vehicules.Poidslourds[i].Libre== true) //si la camionette est libre et est fait pr le mm usage
                        {
                            vehiculeId = vehicules.Poidslourds[i].Id;
                            vehicules.Poidslourds[i].Libre = true;
                            trouve = true;
                        }
                    }

                }
                else if(vehicule == "Citerne")
                {
                    trouve = false;
                    for (int i = 0; i <= vehicules.Citernes.Count && trouve == false; i++)
                    {
                        if (vehicules.Citernes[i].Libre == true) //si la citerne est libre
                        {
                            vehiculeId = vehicules.Citernes[i].Id;
                            vehicules.Citernes[i].Libre = true;
                            trouve = true;
                        }
                    }
                }
                else if(vehicule == "Benne")
                {
                    trouve = false;
                    for (int i = 0; i <= vehicules.Bennes.Count && trouve == false; i++)
                    {
                        if (vehicules.Bennes[i].Libre == true) //si la benne est libre 
                        {
                            vehiculeId = vehicules.Bennes[i].Id;
                            vehicules.Bennes[i].Libre = true;
                            trouve = true;
                        }
                    }

                }
                else if(vehicule == "Frigorifique")
                {
                    trouve = false;
                    for (int i = 0; i <= vehicules.Frigorifiques.Count && trouve == false; i++)
                    {
                        if (vehicules.Frigorifiques[i].Libre == true) //si frigorifique est libre 
                        {
                            vehiculeId = vehicules.Frigorifiques[i].Id;
                            vehicules.Frigorifiques[i].Libre = true;
                            trouve = true;
                        }
                    }
                }
                #region Trouver le plus court chemin --> Dijkstra
                int km = LePlusCourtChemin(pointA, pointB);
    
                #endregion

                double prix = km * c.PrixKm; //nb de Km * prix km du chauffeur

                Commande commande = new Commande(s, pointA, pointB, prix, c, vehicule, vehiculeId, date);
                Console.WriteLine(commande);

                if (listeCommande != null)
                {
                    listeCommande.Add(commande);
                }

                StreamWriter fichierOut = new StreamWriter("ListeCommande.txt", true);
                
                fichierOut.WriteLine(commande + "\n");
                
                fichierOut.Close();


                do
                {
                    Console.WriteLine("Voulez-vous ajouter une autre commande ?  oui/non");
                    rep = Console.ReadLine();

                } while (rep != "oui" && rep != "non");

            }

        }

        public static int LePlusCourtChemin(string pointA, string pointB)
        {
            StreamReader lecteur = new StreamReader("Distance.txt");
            string ligne = ""; //ligne vide
            string[] tab;
            bool trouve = false;

            NoeudGraphe noeud1 = null;
            NoeudGraphe noeud2 = null;
            List<NoeudGraphe> listeNoeud = new List<NoeudGraphe>();
            bool dedans = false;
            bool dedans2 = false;
            while (lecteur.Peek() > 0)
            {
                dedans = false;
                dedans2 = false;
                ligne = lecteur.ReadLine();

                if (ligne != null && ligne != "")
                {

                    tab = ligne.Split(';'); //String.Split retourne un tab de string contenant les sous chaines de ligne séparées par les élements spécifiés()
                    if ((tab != null) && (tab.Length != 0))
                    {
                        noeud1 = new NoeudGraphe(tab[0]);
                        noeud2 = new NoeudGraphe(tab[1]);

                        for (int i = 0; i < listeNoeud.Count && dedans == false; i++)
                        { //si le noeud1 est déjà dans la liste 
                            if (tab[0] == listeNoeud[i].Ville)
                            {
                                noeud1 = listeNoeud[i]; //on le remplace par le noeud déjà existant
                                dedans = true;
                            }
                        }
                        for (int i = 0; i < listeNoeud.Count && dedans == false; i++) //si le noeud2 est déjà dans la liste
                        {
                            if (tab[1] == listeNoeud[i].Ville)
                            {
                                noeud2 = listeNoeud[i];
                                dedans2 = true;
                            }
                        }
                        if (!dedans)
                        {
                            listeNoeud.Add(noeud1);

                        }
                        if (!dedans2) { listeNoeud.Add(noeud2); }

                        noeud1.AjouterLien(int.Parse(tab[2]), noeud2);
                    }
                }

            }
            NoeudGraphe n1 = null;
            NoeudGraphe n2 = null;
            lecteur.Close();
            Graphe g1 = new Graphe(listeNoeud);
            trouve = false;
            for (int i = 0; i < listeNoeud.Count && trouve == false; i++)
            {
                if (pointA == listeNoeud[i].Ville)
                {
                    n1 = listeNoeud[i];
                    trouve = true;
                }
            }
            trouve = false;
            for (int i = 0; i < listeNoeud.Count && trouve == false; i++)
            {
                if (pointB == listeNoeud[i].Ville)
                {
                    n2 = listeNoeud[i];
                    trouve = true;
                }
            }
            Console.WriteLine(g1);
            return g1.Dijkstra(n1, n2); //affiche le plus court chemin selon notre graphe
        }

        public static void NvListeCommande(List<Commande> ListeCommande, ListeClient listeClient,List<Chauffeur> listeChauffeur)
        {
            StreamReader lecteur = new StreamReader("ListeCommande.txt");
            string ligne = ""; //ligne vide
            string[] tab;

            Commande commande = null;

            while (lecteur.Peek() > 0)
            {
                ligne = lecteur.ReadLine();

                if (ligne != null && ligne != "")
                {

                    tab = ligne.Split(';'); //String.Split retourne un tab de string contenant les sous chaines de ligne séparées par les élements spécifiés()
                    if ((tab != null) && (tab.Length != 0))
                    {
                        Client c = listeClient.RechercheClient(tab[0]);
                        Chauffeur chauffeur = new Chauffeur();
                        for(int i = 0; i < listeChauffeur.Count; i++)
                        {
                            if (listeChauffeur[i].Id == tab[5])
                            {
                                chauffeur = listeChauffeur[i];
                            }
                        }

                        commande = new Commande(c, tab[1], tab[2], double.Parse(tab[3]), chauffeur, tab[5],tab[6],DateTime.Parse(tab[7]));
                        ListeCommande.Add(commande);
                    }

                }

            }
            lecteur.Close();
        }

        public static void AfficherCommande(List<Commande> listeCommande)
        {

        }
        #endregion

        #region Statistiques

        public static void NbLivraison(List<Chauffeur> listeChauffeur)
        {
            string rep = "";
            do
            {
                Console.WriteLine("Afficher par chauffeur nb de livraison ?  oui/non");
                rep = Console.ReadLine();

            } while (rep != "oui" && rep != "non");

            if (rep == "oui")
            {
                for (int i = 0; i < listeChauffeur.Count; i++)
                {
                    Console.WriteLine(listeChauffeur[i].Id + " : " + listeChauffeur[i].NblivraisonT + " livraisons");
                }
            }
            
        }
        public static double MoyennePrix(List<Commande> listeCommande)
        {
            double moyenne = 0;
            int nb = 0;
            foreach (Commande c in listeCommande)
            {
                moyenne += c.Prix;
                nb++;
            }


            return moyenne / nb;
        }



        #endregion


        static void Main(string[] args)
        {
 
            #region Clients
            ListeClient listeClient = new ListeClient();

            

            #endregion


            #region Salarié
            Salarie dupond = new Salarie("Dupond", "Pierre", "Directeur général", 200000); //sommet de l'arbre dupond directeur
            Salarie parker = new Salarie("Parker", "Peter", "Directeur des opérations", 2000);
            Salarie s1 = new Salarie("Joyeuse", "jojo", "Directrice des RH", 2000);
            Salarie s2 = new Salarie("Couleur", "coco", "Formation", 2000);
            
            Noeud racine = new Noeud(dupond);
            Noeud n1 = new Noeud(parker);
            Noeud n2 = new Noeud(s1);
            Noeud n3 = new Noeud(s2);
            
            racine.Fils = n1;
            n1.Frere = n2;
            n2.Fils = n3;
            
            Arbre organigramme = new Arbre(racine);
            ListeSalarie listeSal = new ListeSalarie();
            //AjoutSalarie(listeSal, organigramme);
            #endregion

            #region Commandes
            Chauffeur c1 = new Chauffeur(new DateTime(12/03/2018),"01",5);
            Chauffeur c2 = new Chauffeur(new DateTime(10/01/2019),"02",10);
            Chauffeur c3 = new Chauffeur(new DateTime(10/10/2021),"03");

            List < Chauffeur > listeChauffeur = new List<Chauffeur>();
            listeChauffeur.Add(c1);
            listeChauffeur.Add(c2);
            listeChauffeur.Add(c3);

            Voiture v1 = new Voiture("V1",2);
            Voiture v2 = new Voiture("V2",4);
            Voiture v3 = new Voiture("V3",5);

            Camionnette cam1 = new Camionnette("vitrerie", "Cam1");
            Camionnette cam2 = new Camionnette("vitrerie", "Cam2");
            Camionnette cam3 = new Camionnette("vitrerie", "Cam3");

            PoidsLourds p1 = new PoidsLourds(122, "sable", "P1");
            PoidsLourds p2 = new PoidsLourds(122, "sable", "P2");
            PoidsLourds p3 = new PoidsLourds(122, "sable", "P3");

            Citerne ci1 = new Citerne("cuve", "CI1");
            Citerne ci2 = new Citerne("cuve", "CI2");

            Benne b1 = new Benne("utilisation", "B1");

            Frigorifique f1 = new Frigorifique("F1");

            Vehicules vehicules = new Vehicules();
            vehicules.Voitures.Add(v1);
            vehicules.Voitures.Add(v2);
            vehicules.Voitures.Add(v3);
            vehicules.Camionnettes.Add(cam1);
            vehicules.Camionnettes.Add(cam2);
            vehicules.Camionnettes.Add(cam3);
            vehicules.Bennes.Add(b1);
            vehicules.Frigorifiques.Add(f1);

            List<Commande> listeCommande = new List<Commande>();


            #endregion

            int choix;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "1 : Gestion Clients\n"
                                 + "2 : Gestion Salariés\n"
                                 + "3 : Gestion Commandes\n"
                                 +"4 : Stats\n"

                                 + "Quel est votre choix ?");
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    #region    Menu            

                    case 1:
                        AjoutClient(listeClient);
                        SupprClient(listeClient);
                        OrdreAlphabetique(listeClient);
                        TriParVille(listeClient);
                        ModifierMontantachat(listeClient); //pour tester la méthode TriParAchatCumule
                        TriParAchatCumule(listeClient);
                        
 
                        break;
                    case 2:

                        
                        AfficherOrganigramme(organigramme, racine);
                        AjoutSalarie(listeSal,organigramme);
                        LicencierSalarie(listeSal,organigramme);


                        break;
                    case 3:

                        //listeClient.RepertoireClient("ListeClient.txt");
                        //NvListeCommande(listeCommande, listeClient, listeChauffeur);
                        
                        CreerCommande(listeClient, listeChauffeur, vehicules,listeCommande);
                        
                        
                        break;
                    case 4:
                        NbLivraison(listeChauffeur);

                        listeClient.RepertoireClient("ListeClient.txt");
                        NvListeCommande(listeCommande, listeClient, listeChauffeur);
                        
                        Console.WriteLine(MoyennePrix(listeCommande));

                        break;
                

                    default:

                        break;
                }
                #endregion

                Console.WriteLine("Tapez Escape pour sortir ou un numero d exo");
                Console.ReadKey();
            } while (choix != 9);
            
       
            Console.ReadKey();
        }
    }
}
