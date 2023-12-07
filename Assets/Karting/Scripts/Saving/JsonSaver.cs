using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

namespace Arch.Data
{
    public class JsonSaver
    {
        private static readonly string _filename = "saveData1.sav";

        public static string GetSaveFilename()
        {
            return Application.persistentDataPath + "/" + _filename;
        }

        public void save(SaveData data)
        {
            data.hashValue = String.Empty;

            string json = JsonUtility.ToJson(data);

            data.hashValue = GetSHA256(json);

            json = JsonUtility.ToJson(data);
            

            string saveFilename = GetSaveFilename();

            FileStream fileStream = new FileStream(saveFilename, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public bool Load(SaveData data)
        {
            string loadFilename = GetSaveFilename();
            if (File.Exists(loadFilename))
            {
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    string json = reader.ReadToEnd();

                    //to check if data has been manipulated
                    if (CheckData(json))
                    {
                        Debug.Log("Saved data still safe");
                    }
                    else
                    {
                        Debug.LogError("Saved data has been manipulated");
                        return false;
                    }

                    JsonUtility.FromJsonOverwrite(json, data);
                }

                return true;
            }

            return false;
        }

        private bool CheckData(string json)
        {
            //create new SaveData instance
            SaveData tempSaveData = new SaveData();
            //override this new instance with already saved data
            JsonUtility.FromJsonOverwrite(json, tempSaveData);
            
            //save the hash string to compare latter
            string oldHash = tempSaveData.hashValue;
            //clean it
            tempSaveData.hashValue = String.Empty;

            //save a new Json string
            string tempJson = JsonUtility.ToJson(tempSaveData);
            //get the new hash string
            string newHash = GetSHA256(tempJson);

            return (newHash == oldHash);


        }

        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }


        public string GetHexTringFromHash(byte[] hash)
        {
            string hexString = string.Empty;

            foreach (byte b in hash)
            {
                hexString += b.ToString("x2");
            }
            return hexString;
        }
        private string GetSHA256(string text)
        {
            byte[] textToByte = Encoding.UTF8.GetBytes(text);
            SHA256Managed mySHA256 = new SHA256Managed();

            byte[] hashValue = mySHA256.ComputeHash(textToByte);

            return GetHexTringFromHash(hashValue);
        }
    } 
}
