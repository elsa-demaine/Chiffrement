using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiffrement
{
    public class Cesar
    {
        char[] Alpha { get; set; }

        public Cesar()
        {
            Alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        }

        /// <summary>
        /// Permet de choisir s'il on encode ou décode une chaine
        /// </summary>
        public void Start()
        {
            bool exit = false;
            while (!exit) { 
                Console.WriteLine("Que voulez vous faire ?");
                Console.WriteLine("1. Encoder");
                Console.WriteLine("2. Décoder");
                string choix = Console.ReadLine();
                if (choix == "1")
                {
                    StartCodage();
                    exit = true;
                }
                else if (choix == "2")
                {
                    StartDecodage();
                    exit = true;
                }                    
                else
                    exit = false;
            }
        }

        /// <summary>
        /// Permet l'encodage d'une chaine
        /// </summary>
        public void StartCodage()
        {
            Console.WriteLine("Veuilliez entrer votre chaine a encoder.");
            string chaine = Console.ReadLine();
            Console.WriteLine("De combien voulez vous l'encoder ?");
            bool fonctionne = int.TryParse(Console.ReadLine(), out int decalage);
            string res = Codage(chaine, decalage);
            var res2 = Decodage(chaine);
            Console.WriteLine("Votre chaine encodé est : " + res);
        }
        /// <summary>
        /// Permet le décodage d'une chaine
        /// </summary>
        public void StartDecodage()
        {
            Console.WriteLine("Veuilliez entrer votre chaine a décoder.");
            string chaine = Console.ReadLine();
            bool exit = false;
            Console.WriteLine("Avez vous le nombre de décalage ? (o/n)");
            while (!exit)
            {            
                string reponse = Console.ReadLine();
                if (reponse == "o")
                {
                    Console.WriteLine("De combien est le décalage ?");
                    bool fonctionne = int.TryParse(Console.ReadLine(), out int decalage);
                    string res = Decodage(chaine, decalage);
                    Console.WriteLine("Votre chaine décodé est : " + res);
                    exit = true;
                }
                else if (reponse == "n")
                {
                    Console.WriteLine("Voici une liste de solutions : ");
                    List<string> solutions = Decodage(chaine);
                    foreach(string solution in solutions)
                        Console.WriteLine(solution);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Je n'est pas compris. Avez vous le nombre de décalage ? (o/n)");
                    exit = false;
                }
            }
        }

        /// <summary>
        /// Permet d'encoder une chaine
        /// </summary>
        /// <param name="chaine">la chaine à encoder</param>
        /// <param name="decalage">le nombre de décalage pour l'encodement</param>
        /// <returns></returns>
        public string Codage(string chaine, int decalage)
        {
            //La nouvelle chaine
            string newChaine = "";

            //La chaine actuelle découpé en caractères
            char[] caracteres = new char[chaine.Length];
            caracteres = chaine.ToCharArray();

            //Le caractère de la chaine a modifier
            string cara;

            //Parcourir la chaine
            for (int i = 0; i < chaine.Length; i++)
            {
                cara = chaine.Substring(i, 1);

                //Vérification si c'est une lettre minuscule
                if (Alpha.Any(e => e.Equals(caracteres[i])))
                {
                    //Recuperation de l'index de la lettre dans l'alphabet
                    int index = Array.IndexOf(Alpha, caracteres[i]);

                    //Remplace le caractère actuelle avec le caractère décaler
                    try
                    {
                        newChaine += cara.Replace(caracteres[i], Alpha[index + decalage]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        int restart = (index + decalage) - Alpha.Length;
                        newChaine += cara.Replace(caracteres[i], Alpha[restart]);
                    }
                }
                else
                {
                    newChaine += caracteres[i];
                }
            }
            return newChaine;
        }

        /// <summary>
        /// Permet de décoder une chaine
        /// </summary>
        /// <param name="chaine">la chaine a décoder</param>
        /// <param name="decalage">le décalage utilisé pour encoder la chaine</param>
        /// <returns></returns>
        public string Decodage(string chaine, int decalage)
        {
            //La nouvelle chaine
            string newChaine = "";

            //La chaine actuelle découpé en caractères
            char[] caracteres = new char[chaine.Length];
            caracteres = chaine.ToCharArray();

            //Le caractère de la chaine a modifier
            string cara;

            //Parcourir la chaine
            for (int i = 0; i < chaine.Length; i++)
            {
                cara = chaine.Substring(i, 1);

                //Vérification si c'est une lettre minuscule
                if (Alpha.Any(e => e.Equals(caracteres[i])))
                {
                    //Recuperation de l'index de la lettre dans l'alphabet
                    int index = Array.IndexOf(Alpha, caracteres[i]);

                    //Remplace le caractère actuelle avec le caractère décaler
                    try
                    {
                        newChaine += cara.Replace(caracteres[i], Alpha[index - decalage]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        int restart = (index - decalage) + Alpha.Length;
                        newChaine += cara.Replace(caracteres[i], Alpha[restart]);
                    }
                }
                else
                {
                    newChaine += caracteres[i];
                }
            }
            return newChaine;
        }

        /// <summary>
        /// Permet de décoder une chaine sans connaitre le décalage
        /// </summary>
        /// <param name="chaine">la chaine a décoder</param>
        /// <returns>une liste de chaines décoder avec un décalage différent</returns>
        public List<string> Decodage(string chaine)
        {
            List<string> essais = new List<string>();
            for(int i = 0; i < Alpha.Length; i++)
            {
                essais.Add(Decodage(chaine, i));
            }
            return essais;
        }
    }
}
