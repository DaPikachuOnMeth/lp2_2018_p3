using UnityEngine;

namespace UnityClass.DJD
{

    /// <summary>
    /// classe responsável por rotacionar o npc.
    /// </summary>
    public class Npc_rotate : MonoBehaviour
    {

        public float maxDistance = 5;

        [Tooltip("select between texture and sprite")]
        private bool type;

        
        [Tooltip("Speed that which the npc look's away. Higher = faster.")]
        public float lookAway = 1.5f;
        
        [Tooltip("Speed that which the npc look's at the player. Higher = faster.")]
        public float lookAt = 4.0f;
        
        private GameObject target;
        private Quaternion idle;
        private Animated_asset spriteAnimator;
        private TextureAnimator textureAnimator;

        /// <summary>
        /// método chamado ao iniciar o jogo
        /// </summary>
        void Start()
        {
            CheckType();
            idle = transform.localRotation;
            target = GameObject.FindGameObjectWithTag("Player");
        }

        /// <summary>
        /// método chamado em cada loop do jogo.
        /// </summary>
        void Update()
        {
            //caso a distância entre o player e o npc seja menor que maxDistance
            if (Vector3.Distance(transform.position, target.GetComponent<Transform>().position) <= maxDistance)
            {
                //gira o npc para a tal posição
                Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookAt * Time.deltaTime);
                transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));
                if (type == true)
                { spriteAnimator.StartAnimation(); }
                else { textureAnimator.StartAnimation(); }

            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, idle, lookAway);
                transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));
                if (type == true)
                { spriteAnimator.StopAnimation(); }
                else { textureAnimator.StopAnimation(); }
            }
        }

        /// <summary>
        /// verifica se o npc tem sprites ou texturas.
        /// </summary>
        void CheckType()
        {
            spriteAnimator = GetComponentInChildren<Animated_asset>();
            if (spriteAnimator != null)
            {
                type = true;
            }
            else
            {
                textureAnimator = GetComponent<TextureAnimator>();
                type = false;
            }
        }
    }
}