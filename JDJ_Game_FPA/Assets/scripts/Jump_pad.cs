using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityClass.DJD
{
    /// <summary>
    /// Classe que define os objectos Jump Pad.
    /// (Serializable para que seja possível ver no inspector do Unity.)
    /// </summary>
    [Serializable]
    public class Jump_pad : MonoBehaviour
    {
        ///<summary> altura do salto. </summary> 
        [Tooltip("Jump height for this jump pad")]
        public float Jump_Height;

        ///<summary> referência a aura vizualizada quando o jogador está encima do jump pad.</summary> 
        [Tooltip("Game object reference for the aura")]
        public GameObject auraBuff;

        /// <summary>
        /// Metodo para inicializar componentes e variáveis antes do jogo começar
        /// </summary>
        private void Awake()
        {
            auraBuff = GameObject.FindGameObjectWithTag("Aura_Buff");
        }

        /// <summary>
        /// método que define se um outro collider entrou no 
        /// componente collider deste objecto.
        /// </summary>
        /// <param name="obj"> componente Collider do objecto detetado.</param>
        public void OnTriggerEnter(Collider obj)
        {
            //caso o objecto seja o player
            if (obj.gameObject.CompareTag("Player"))
            {
                //altera a altura do salto do player
                obj.gameObject.GetComponent
                    <FirstPersonController>().m_JumpSpeed = Jump_Height;
                //ativa a aura
                auraBuff.GetComponent<Fade>().ToggleTrue();
                //ativa o som do jump pad
                FindObjectOfType<AudioManager>().Play("JumpPadBuff");
            }
        }

        /// <summary>
        /// método que define se um outro collider saiu do 
        /// componente collider deste objecto.
        /// </summary>
        /// <param name="obj"> componente Collider do objecto detetado.</param>
        public void OnTriggerExit(Collider obj)
        {
            //caso o objecto seja do player
            if (obj.gameObject.CompareTag("Player"))
            {
                //retorna o valor do salto do player ao valor normal
                obj.gameObject.GetComponent
                    <FirstPersonController>().m_JumpSpeed = 8f;

                //desativa a aura
                auraBuff.GetComponent<Fade>().ToggleFalse();

                //desativa o som do jump pad
                FindObjectOfType<AudioManager>().Stop("JumpPadBuff");
            }
        }
    }
}