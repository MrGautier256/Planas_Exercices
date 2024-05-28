using System;
using System.Security.Cryptography;
using System.Text;
using Onvatry.FormationService; // Utilisez l'espace de noms correct trouvé

namespace Onvatry
{
    class Program
    {
        static void Main(string[] args)
        {
            // Créer une instance du client de service web
            var client = new FormationService(); // Remplacez 'Formation' par le nom correct trouvé

            // Appeler la méthode GetKey pour récupérer la clé RSA
            string rsaKey = client.GetKey();
            Console.WriteLine("RSA Key: " + rsaKey);

            // Appeler la méthode GetInstructionsStep2 pour récupérer le message chiffré
            string encryptedMessageBase64 = client.GetInstructionsStep2();
            Console.WriteLine("Encrypted Message (Base64): " + encryptedMessageBase64);

            // Convertir le message chiffré de Base64 en byte array
            byte[] encryptedMessage = Convert.FromBase64String(encryptedMessageBase64);

            // Déchiffrer le message avec la clé RSA
            string decryptedMessage = DecryptMessage(encryptedMessage, rsaKey);
            Console.WriteLine("Decrypted Message: " + decryptedMessage);
        }

        static string DecryptMessage(byte[] encryptedMessage, string rsaKey)
        {
            // Initialiser l'objet RSA
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Charger la clé RSA
                rsa.FromXmlString(rsaKey);

                // Déchiffrer le message
                byte[] decryptedBytes = rsa.Decrypt(encryptedMessage, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
