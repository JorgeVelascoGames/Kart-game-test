using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arch.Data
{
    public class DataManager : MonoBehaviour
    {
        public static Action DataLoaded;
		public static Action NewRecord;

        private static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                return _instance;
            }
        }

        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        public void Awake()
        {
            _instance = this;
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
            Load();

            DontDestroyOnLoad(gameObject);
        }       

        public int score
        {
            get { return _saveData.score; }
            set {_saveData.score = value; }
        }

        public float bestTime
        {
            get { return _saveData.bestTime; }
            //We only override the best time if it's better than the older one
            set { if(_saveData.bestTime < value)
					{
						_saveData.bestTime = value;

						if(NewRecord != null)
							NewRecord();
					};
                }
        }
                        
        public void Save()
        {
            _jsonSaver.save(_saveData);
            Debug.Log("Best time: " + _saveData.bestTime);
        }

        public void Load()
        {
            _jsonSaver.Load(_saveData);

            if (DataLoaded != null)
                DataLoaded();
        }

        public void Delete()
        {
            _jsonSaver.Delete();
            _saveData = new SaveData();
        }        
    }
}