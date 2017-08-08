using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CryptoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Encrypt(string text)
        {
            string cipherText = "";
            //Password for encryption
            string password = @"DSODKey!";
            //Initial vector
            string iv = @"DSODiv!!";
            UnicodeEncoding UE = new UnicodeEncoding();
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            //Create a memory stream object
            MemoryStream memoryStream = new MemoryStream();
            //put the password and init vector into RijndaelManaged object
            rijndaelCipher.Key = UE.GetBytes(password);
            rijndaelCipher.IV = UE.GetBytes(password);
            //Create an encryptor
            ICryptoTransform rijndaelEncryptor = rijndaelCipher.CreateEncryptor();
            //Initialise a cryptoStream object
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelEncryptor, CryptoStreamMode.Write);


            try
            {

                byte[] plainBytes = Encoding.ASCII.GetBytes(text);
                //Encrypt the plaintext
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] cipherBytes = memoryStream.ToArray();
                //Convert the stream into String
                cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
            }
            catch
            {
                return "error while encrypting";
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }

            //Return the ciphertext
            return cipherText;
        }

        public string Decrypt(string cipher)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            //Password for encryption
            string password = @"DSODKey!";
            //Initial vector
            string iv = @"DSODiv!!";
            UnicodeEncoding UE = new UnicodeEncoding();
            //put the password and init vector into RijndaelManaged object
            rijndaelCipher.Key = UE.GetBytes(password);
            rijndaelCipher.IV = UE.GetBytes(password);

            //Create a memory stream object
            MemoryStream memoryStream = new MemoryStream();
            //Create an encryptor
            ICryptoTransform rijndaelDecryptor = rijndaelCipher.CreateDecryptor();
            //Initialise a cryptoStream object
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);
            string text = "";

            try
            {
                //Convert String to bytes
                byte[] cipherBytes = Convert.FromBase64String(cipher);
                //Decrypt the ciphertext
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] plainBytes = memoryStream.ToArray();
                //Convert bytes to String
                text = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
            }
            catch
            {
                return "Error while decrypting";
            }
            return text;
        }
    }
}
