using UnityEngine;

namespace UnityClass.DJD
{
    /// <summary>
    /// classe para alterar o som de uma musica para outra dentro do jogo.
    /// </summary>
    public class ChangeSong : MonoBehaviour
    {
        
        public GameObject target;

        /// <summary>
        /// Altera a música após o jogador dar trigger ao objeto.
        /// </summary>
        public void OnTriggerEnter(Collider other)
        {
            Destroy(target);
            FindObjectOfType<AudioManager>().Stop("ThemeGame");
            FindObjectOfType<AudioManager>().Stop("Wind");
            FindObjectOfType<AudioManager>().Play("GlitchTheme");
        }
    }
}
