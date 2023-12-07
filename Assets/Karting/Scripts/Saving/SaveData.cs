using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Arch.Data
{
    [Serializable]
    public class SaveData
    {
        public SaveData()
        {
            playerName = defaultPlayerName;
            hashValue = String.Empty;
        }

        public string playerName;
        private readonly string defaultPlayerName = "Player 1";

        

        public string hashValue;

        public int score;
        public float bestTime;
    } 
}
