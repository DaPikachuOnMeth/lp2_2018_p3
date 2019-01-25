using UnityEngine;
using System;


namespace UnityClass.DJD
{
    /// <summary>
    /// Classe que gere os audios do jogo
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        ///<summary> 
        /// Define que o AudioManager é um singletone,
        /// assim só existirá um durante o jogo.
        ///</summary> 
        public static AudioManager singletone;

        /// <summary>
        /// Método para inicializar componentes e variáveis antes do jogo começar
        /// </summary>
        public void Awake()
        {
            //gere o singletone
            if (singletone == null)
            {
                singletone = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            //para cada som em sounds adicionar os valores ao audio source
            foreach (Sound s in sounds)
            {

                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        /// <summary>
        /// Método para inicializar variáveis ou chamar metodos ao iniciar o jogo.
        /// </summary>
        public void Start()
        {
            Play("Theme");
            Play("Wind");
        }

        /// <summary>
        /// método para iniciar um som.
        /// </summary>
        /// <param name="name">nome do som a ser inicializado.</param>
        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            /*
             * caso o som não exista é mostrado um warning e 
             * o programa continua a correr.
             */
            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not found! ");
                return;

            }
            s.source.Play();
        }

        /// <summary>
        /// método para parar o som.
        /// </summary>
        /// <param name="name">nome do som a ser parado.</param>
        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            /*
             * caso o som não exista é mostrado um warning e 
             * o programa continua a correr.
             */
            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not found! ");
                return;

            }
            s.source.Pause();
        }
    }
}