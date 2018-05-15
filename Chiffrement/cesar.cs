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

        public void Start()
        {
            Console.WriteLine("Veuilliez entrer votre chaine a encoder.");
            string chaine = Console.ReadLine();
            Console.WriteLine("De combien voulez vous l'encoder ?");
            bool fonctionne = int.TryParse(Console.ReadLine(), out int decalage);
            string res = Codage(chaine, decalage);
            string res1 = Decodage(chaine, decalage);
            Console.WriteLine("Votre chaine encodé est : " + res1);
        }

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
