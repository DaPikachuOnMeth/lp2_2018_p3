using UnityEngine;
using UnityEngine.SceneManagement;
namespace UnityClass.DJD
{
	/// <summary>
	///Classe responsável pelo menu principal do jogo
	///</summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Inicia o nível. 
        /// </summary>
        public void StartGame()
        {
            SceneManager.LoadScene("Lore");
        }

		/// <summary> Encerra o jogo </summary>
        public void ExitGame()
        {
            Application.Quit();
        }

        ///<summary> verifica se o rato está encima dos botões
        /// e inicia o som para os botões 
        ///</summary>
        public void MouseOver()
        {
            FindObjectOfType<AudioManager>().Play("MouseOver");
        }
    }
}