using UnityEngine;
using System.Collections;
namespace UnityClass.DJD
{

    public class ChangeSong : MonoBehaviour
    {

        /// <summary>
        /// Este script pede que objeto é o trigger
        /// e altera a reprodução dos audíos 
        /// </summary>

        public GameObject target;

        public void OnTriggerEnter(Collider other)
        {
            Destroy(target);
            FindObjectOfType<AudioManager>().Stop("ThemeGame");
            FindObjectOfType<AudioManager>().Stop("Wind");
            FindObjectOfType<AudioManager>().Play("GlitchTheme");
        }
    }
}
