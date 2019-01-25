using UnityEngine;

namespace UnityClass.DJD
{

    /// <summary>
    /// classe responsável por ativar objector de recompensa da missão.
    /// </summary>
    public class GivePlayerItem : MonoBehaviour
    {
        
        public Player p;
        public Interactible givePlayer;
        public Interactible npc;

        private Npc_state state;

        /// <summary>
        /// metodo chamado em cada loop do jogo.
        /// </summary>
        void Awake()
        {
            state = npc.GetComponent<Npc_state>();
        }

        /// <summary>
        /// Verifica se o jogador interagiu com o objeto, adicionando o mesmo no inventário 
        /// </summary>
        void Update()
        {
            if (state.states[state.currentState].givePlayerItem )
            {
                givePlayer.GetComponent<MeshRenderer>().enabled = true;
                givePlayer.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
