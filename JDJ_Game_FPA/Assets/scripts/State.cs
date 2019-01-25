using System;
using UnityEngine;

namespace UnityClass.DJD
{
    /// <summary>
    /// classe que define um objeto do tipo sound, 
    /// utilizado para adicionar sons ao jogo.
    /// </summary>
    [Serializable]
    public class State
    {
        public string name;
        public bool firstState;
        public bool needRequirement;
        public bool givePlayerItem;  
        public int stateNumber;
        public int JumpToState;
        public Sprite npcTalk;
        public bool enablesObject = false;

        /// <summary>
        /// objectos necessários para o próximo estado.
        /// </summary>
        [Tooltip("Inventory requirements")]
        public Interactible invReq;
        public GameObject enable;

    

    }
}