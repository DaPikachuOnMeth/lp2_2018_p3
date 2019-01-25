using System;
using UnityEngine;

namespace UnityClass.DJD
{

    /// <summary>
    /// classe responsável pelos Teleports do jogo.
    /// </summary>
    [Serializable]
    public class Teleport : MonoBehaviour
    {
        /// <summary>
        /// método chamado em cada loop do jogo.
        /// </summary>
        [Tooltip("set false to a fiz teleport, true for one use only")]
        public bool useOnce;
        [Tooltip("position where the player should appear(need one game object with transform)")]
        public Transform TeleportLocation;

        /// <summary>
        /// Faz o teleport do Player
        /// </summary>
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && useOnce)
            {
                other.GetComponent<Transform>().
                    SetPositionAndRotation(TeleportLocation.position, TeleportLocation.rotation);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else if (other.gameObject.CompareTag("Player") && !useOnce)
            {
                other.GetComponent<Transform>().
                    SetPositionAndRotation(TeleportLocation.position, TeleportLocation.rotation);

            }
        }
    }
}
