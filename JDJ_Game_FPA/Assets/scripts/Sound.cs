using UnityEngine;
using System;


namespace UnityClass.DJD
{
    /// <summary>
    /// classe que define um objeto do tipo sound, 
    /// utilizado para adicionar sons ao jogo.
    /// </summary>
    [Serializable]
    public class Sound
    {

        public string name;
        public AudioClip clip;
        
        [Range(0f, 1f)]
        public float volume=0.5f;
        
        [Range(0.1f, 3f)]
        public float pitch=1;
        
        public bool loop;
        
        [HideInInspector]
        public AudioSource source;


    }
}