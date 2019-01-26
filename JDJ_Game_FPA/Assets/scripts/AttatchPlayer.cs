using System;
using UnityEngine;

namespace UnityClass.DJD
{
    /// <summary>
    /// Faz com que o jogador acompanhe as plataformas quando elas movem-se.
    /// </summary>
    [Serializable]
    public class AttatchPlayer : MonoBehaviour
    {
        public GameObject Player;
        public GameObject emptyObject;

        /// <summary>
        /// Verifica se o jogador está em cima da plataforma
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == Player)
            {

                emptyObject.transform.parent = transform;
                Player.transform.parent = emptyObject.transform;
            }
        }

        /// <summary>
        /// Mantém a escala do jogador ao tornar o mesmo child de um objeto vazio com escala default
        /// </summary>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == Player)
            {
                Player.transform.parent = null;
                Player.gameObject.transform.localScale = new Vector3(1F, 1F, 1F);
            }
        }
    }

}
