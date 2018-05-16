using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiffrement
{
    class EncodageManager
    {
        /// <summary>
        /// Permet de gérer le type de chiffrement
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Quelle méthode voulez vous utiliser ?");
            Console.WriteLine("1. Par substituion");
            Console.WriteLine("2. César");
            string option = Console.ReadLine();
            if(option == "1")
            {
                Substitution mainSubstitution = new Substitution();
            }
            else if(option == "2")
            {
                Cesar mainCesar = new Cesar();
            }
            else
            {
                Console.WriteLine("Désolé vous n'avez pas saisie le bon numéro. Veuillez recommencer");
            }
            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter.");
            Console.ReadKey();
        }
    }
}
