using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiffrement
{
    class Substitution
    {

        public Substitution()
        {
            this.Start();
        }
        public void Start()
        {
            Console.WriteLine("Veuillez entrer votre chaine a encoder.");
            string chaine = Console.ReadLine();
            chaine = this.Nettoyage(chaine);

            Console.WriteLine("Donner le mot de passe qui permet la substitution");
            String mdp = Console.ReadLine();
            mdp = this.Nettoyage(mdp);

            string res = Codage(chaine, mdp);
            string res1 = Decodage(chaine, mdp);

            Console.WriteLine("Votre chaine encodée est : " + res1);
        }

        public string Codage(string chaine, string mdp)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char Lletter = chaine[-1];
            int coord = Encoding.Default.GetBytes(Lletter)[0] + 1;
            int coord = alphabet.Substring(coord, 1);
            return "";
        }

        public string Decodage(string chaine, string mdp)
        {
            return "";
        }

        /// <summary>
        /// Permet de nettoyer les chaines de caractère. Ex: é è ê deviennent e etc... (on garde la ponctuation)
        /// </summary>
        /// <param name="phrase">Phrase à nettoyer. exemple: Un événement à Paris. </param>
        /// <returns>La phrase nettoyer. exemple: Un evenement à Paris. </returns>
        public string Nettoyage(string phrase)
        {
            var normalizedString = phrase.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
