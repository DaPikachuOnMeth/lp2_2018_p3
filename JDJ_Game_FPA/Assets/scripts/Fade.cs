using UnityEngine;
using UnityEngine.UI;

namespace UnityClass.DJD
{

    /// <summary>
    /// classe responsável pelo Fade da sprite do Jump Pad.
    /// </summary>
    public class Fade : MonoBehaviour
    {

        //Attach an Image you want to fade in the GameObject's Inspector
        public Image m_Image;

        [Tooltip("Amount of time it takes to fade in the image. (float)")]
        public float m_FadeInTimer = 0.15f;

        [Tooltip("Amount of time it takes to fade out the image. (float)")]
        public float m_FadeOutTimer = 0.15f;
        //Use this to tell if the toggle returns true or false
        bool m_Fading;

        /// <summary>
        /// Metodo para inicializar as coisas antes do jogo começar.
        /// </summary>
        private void Awake()
        {
            //Used to enable the component so it doesn't apear in the game tab
            //before start of the game.
            m_Image.enabled = true;
            m_Image.CrossFadeAlpha(0, 0f, false);
        }

        /// <summary>
        /// verifica e aplica o efeito fade quando m_Fadin = true 
        /// </summary>
        void Update()
        {
            //If toggle method returns true, fade in the Image
            if (m_Fading == true)
            {
                //Fully fade in Image (1) with the duration of 2
                m_Image.CrossFadeAlpha(1, m_FadeInTimer, false);
            }
            //If the toggle is false, fade out to nothing (0) the Image with a duration of 2
            if (m_Fading == false)
            {
                m_Image.CrossFadeAlpha(0, m_FadeOutTimer, false);
            }
        }
        /// <summary>
        /// método para ativar o fade.
        /// </summary>
        public void ToggleTrue()
        {
            m_Fading = true;
        }

        /// <summary>
        /// método para desativar o fade.
        /// </summary>
        public void ToggleFalse()
        {
            m_Fading = false;
        }
    }
}