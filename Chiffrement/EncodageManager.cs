using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiffrement
{
    class EncodageManager
    {
        public void Start()
        {
            Console.WriteLine("Voulez vous encoder ou décoder ?");
            string choix = Console.ReadLine();
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
                
            }
            else
            {
                Console.WriteLine("Désolé vous n'avez pas saisie le bon numéro. Veuillez recommencer");
            }


        }
    }
}
