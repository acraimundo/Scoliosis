using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Scoliosis.DataAccessComponent
{
	/// <summary>
	/// Classe para encriptar e desencriptar strings.
	/// </summary>
    [ComVisible(false)]
	internal class Criptografia
	{
		/// <summary>
		/// Construtor.
		/// </summary>
		public Criptografia()
		{
		}

		/// <summary>
		/// Encripta uma string usando o algoritmo de chave sim�trica de Rijndael
		/// com o algoritmo de hash MD5.
		/// </summary>
		/// <param name="sText">Texto a ser encriptado.</param>
		/// <returns>O texto encriptado.</returns>
		public static string EncriptarMD5(string sText)
		{
			string passPhrase = "Pas5pr@se";
			string saltValue = "s@1tValue";
			string hashAlgorithm = "MD5";
			int passwordIterations = 2;
			string initVector = "@1B2c3D4e5F6g7H8";
			int keySize = 128;

			// converte as strings em um array de bytes (ASCII)
			byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
			byte[] saltValueBytes  = Encoding.ASCII.GetBytes(saltValue);
			byte[] plainTextBytes  = Encoding.ASCII.GetBytes(sText);
        
			// cria��o do password
			PasswordDeriveBytes password = new PasswordDeriveBytes(
				passPhrase, 
				saltValueBytes, 
				hashAlgorithm, 
				passwordIterations);
        
			// usa o password para criar bytes pseudo-rand�micos
			byte[] keyBytes = password.GetBytes(keySize / 8);
        
			// cria o objeto de Rijndael
			RijndaelManaged symmetricKey = new RijndaelManaged();
        
			// modo Cipher Block Chaining
			symmetricKey.Mode = CipherMode.CBC;
        
			// gera��o do encriptador
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
				keyBytes, 
				initVectorBytes);
        
			// define a stream de mem�ria que armazenar� os dados encriptados
			MemoryStream memoryStream = new MemoryStream();
                
			// define a stream de criptografia (Write para encriptar)
			CryptoStream cryptoStream = new CryptoStream(memoryStream, 
				encryptor,
				CryptoStreamMode.Write);

			// iniciar encriptamento
			cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                
			// finalizar encriptamento
			cryptoStream.FlushFinalBlock();

			// converte na stream de mem�ria
			byte[] cipherTextBytes = memoryStream.ToArray();
                
			// fecha ambas as streams
			memoryStream.Close();
			cryptoStream.Close();
        
			// converte os dados encriptados em uma string base64-encoded
			string cipherText = Convert.ToBase64String(cipherTextBytes);
        
			// retorna a string encriptada
			return cipherText;
		}
    
		// 

		/// <summary>
		/// Desencripta um texto no modo Chipher usando o algoritmo de Rijndael.
		/// </summary>
		/// <param name="sText">Texto a ser desencriptado.</param>
		/// <returns>O texto desencriptado.</returns>
		public static string DesencriptarMD5(string sText)
		{
			string passPhrase = "Pas5pr@se";
			string saltValue = "s@1tValue";
			string hashAlgorithm = "MD5";
			int passwordIterations = 2;
			string initVector = "@1B2c3D4e5F6g7H8";
			int keySize = 128;

			// converte as strings em um array de bytes (ASCII)
			byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
			byte[] saltValueBytes  = Encoding.ASCII.GetBytes(saltValue);
			byte[] cipherTextBytes = Convert.FromBase64String(sText);
        
			// cria��o do password
			PasswordDeriveBytes password = new PasswordDeriveBytes(
				passPhrase, 
				saltValueBytes, 
				hashAlgorithm, 
				passwordIterations);
        
			// usa o password para criar bytes pseudo-rand�micos
			byte[] keyBytes = password.GetBytes(keySize / 8);
        
			// cria o objeto de Rijndael
			RijndaelManaged symmetricKey = new RijndaelManaged();
        
			// modo Cipher Block Chaining
			symmetricKey.Mode = CipherMode.CBC;
        
			// gera��o do desencriptador
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
				keyBytes, 
				initVectorBytes);
        
			// define a stream de mem�ria que armazenar� os dados desencriptados
			MemoryStream  memoryStream = new MemoryStream(cipherTextBytes);
                
			// Define cryptographic stream (always use Read mode for encryption).
			CryptoStream  cryptoStream = new CryptoStream(memoryStream, 
				decryptor,
				CryptoStreamMode.Read);

			byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        
			// inicia desencripta��o
			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 
				0, 
				plainTextBytes.Length);
                
			// fecha ambas as streams
			memoryStream.Close();
			cryptoStream.Close();
        
			// converte os dados desencriptados em uma string
			// Let us assume that the original plaintext string was UTF8-encoded.
			string plainText = Encoding.ASCII.GetString(plainTextBytes, 0, decryptedByteCount);
        
			// retorna a string desencriptada
			return plainText;
		}
	}
}
