using UnityEngine;

namespace UnityClass.DJD
{
    /// <summary>
    /// Classe responsável por ativar a porta como interactible.
    /// </summary>
    public class Vanish_wall : MonoBehaviour
    {
        [Tooltip("set the platforms who need to be activated here")]
        public GameObject[] platforms;

        /// <summary>
        /// conjunto de enables necessários para ativar a porta.
        /// </summary>
        private bool[] enables = new bool[4];

        /// <summary>
        /// método chamado em cada loop do jogo.
        /// </summary>
        void Update()
        {
            int i = 0;
            foreach (GameObject g in platforms)
            {
                enables[i] = g.GetComponent<BoxCollider>().enabled;
                i++;
            }

            if (AllOn(enables))
            {
                GetComponent<Interactible>().isActive = true;
            }
            else
                GetComponent<Interactible>().isActive = false;
        }

        /// <summary>
        /// metodo que confirma se os enables esão ativos.
        /// </summary>
        /// <param name="e">enables que necessitam estar ativos (true).</param>
        /// <returns>true se todos estiverem ativo e false se algum estiver inativo.</returns>
        private bool AllOn(bool[] e)
        {
            foreach (bool c in e)
            {
                if (c == false)
                { return false; }
            }
            return true;
        }
    }
}
