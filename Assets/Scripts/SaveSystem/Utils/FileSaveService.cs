using System.IO;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using UnityEngine;

namespace SaveSystem.Utils
{
    public class FileSaveService : ISaveService
    {
        private readonly string _savePath = Application.persistentDataPath;
        
        public void Save(string key, string dataJson)
        {
            var encryptedJson = Encryptor.Encrypt(dataJson);
            var path = Path.Combine(_savePath, key);
            
            File.WriteAllText(path, encryptedJson);
        }

        public string Load(string key)
        {
            var path = Path.Combine(_savePath, key);
            var decryptedJson = Encryptor.Decrypt(File.ReadAllText(path));
            
            return decryptedJson;
        }
    }
}