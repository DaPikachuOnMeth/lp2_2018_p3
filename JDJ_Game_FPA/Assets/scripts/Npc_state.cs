using UnityEngine;
namespace UnityClass.DJD
{
    /// <summary>
    /// Classe responsável pela máquina de estados básica do npc.
    /// </summary>
    public class Npc_state : MonoBehaviour
    {
        public State[] states = new State[1];
        /// <summary>
        /// estado atual da maquina de estados.
        /// </summary>
        public int currentState = 0;

        /// <summary>
        /// referência ao Player.
        /// </summary>
        [HideInInspector]
        internal Player p;
        /// <summary>
        /// referencia ao children no qual guarda a sprite do npc.
        /// </summary>
        [Tooltip("Game Objct com os balões")]
        public GameObject children;
        [HideInInspector]
        public SpriteRenderer text;

        /// <summary>
        /// Metodo para inicializar componentes e variáveis antes do jogo começar.
        /// </summary>
        void Awake()
        {
            p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            text = gameObject.transform.Find("Npc_Talk").GetComponent<SpriteRenderer>();
            text.sprite = states[currentState].npcTalk;

        }


        /// <summary>
        /// método para selecionar o estado do npc neste determinado momento.
        /// </summary>
        public bool CallState()
        {
            if (!states[currentState].firstState)
            {
                if (states[currentState].needRequirement)
                {
                    if (p.HasInInventory(states[currentState].invReq))
                    {
                        p.RemoveFromInventory(states[currentState].invReq);
                        currentState = states[currentState].JumpToState;
                        text.sprite = states[currentState].npcTalk;
                        if (states[currentState].enablesObject)
                        { states[currentState].enable.SetActive(true); };


                        return true;
                    }
                    else
                    {
                        text.sprite = states[currentState].npcTalk;
                        if (states[currentState].enablesObject)
                        { states[currentState].enable.SetActive(true); };
                        return false;
                    }

                }
                else
                {
                    currentState = states[currentState].JumpToState;
                    text.sprite = states[currentState].npcTalk;
                    if (states[currentState].enablesObject)
                    { states[currentState].enable.SetActive(true); };

                    return false;
                }
                
            }
            else
            {
                text.sprite = states[currentState].npcTalk;
                currentState = states[currentState].JumpToState;
                
                if (states[currentState].enablesObject)
                { states[currentState].enable.SetActive(true); };

                return true;
            }
        }
    }
}