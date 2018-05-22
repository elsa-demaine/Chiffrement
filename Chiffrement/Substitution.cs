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
            string newAlpha = newAlphabet(mdp);
            string sentenceCrypted = Chiffrer(chaine, newAlpha);

            Console.WriteLine(sentenceCrypted);
        }
        /// <summary>
        /// Create new alphabet with password
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns></returns>
        public string newAlphabet(string chaine)
        {
            string alphabet = "abcdefghikjlmnopqrstuvwxyz";
            string phraseEnCours = chaine + alphabet;
            string phraseCrypte = "";

            foreach (char letter in phraseEnCours)
            {
                if (phraseCrypte.IndexOf(letter) == -1)
                {
                    phraseCrypte += letter;
                }
                else
                {
                    phraseCrypte += "";
                }
            }
            return phraseCrypte;
        }

        public string Chiffrer(string phrase, string alphabet)
        {
            string response = "";
            char[] alphabetLetter = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            foreach(char letter in phrase)
            {
                if(alphabetLetter.Contains(letter))
                {
                    int coord = Array.IndexOf(alphabetLetter, letter);
                    response += alphabet[coord];
                }
                else if (Char.IsWhiteSpace(letter))
                {
                    response += " ";
                }
                else if (Char.IsPunctuation(letter))
                {
                    response += letter;
                }
                else
                {
                    response += "";
                }
            }
            return response;
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
