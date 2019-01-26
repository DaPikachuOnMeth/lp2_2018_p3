using UnityEngine;
using UnityEngine.SceneManagement;
namespace UnityClass.DJD
{
    /// <summary>
    /// Classe responsável por alterar a cena do jogo para a cena principal.
    /// </summary>
    public class ChangeScene : MonoBehaviour
    {
        /// <summary>
        /// script para alterar para a cena principal do jogo.
        /// </summary>
        /// <param name="other">o collider do Player. </param>
        public void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene("Scene3");
        }
    }
}
