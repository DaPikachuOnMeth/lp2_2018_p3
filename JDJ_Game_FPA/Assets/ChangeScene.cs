using UnityEngine;
using UnityEngine.SceneManagement;
namespace UnityClass.DJD
{

    public class ChangeScene : MonoBehaviour
    {
        /// <summary>
        /// script usado apra mudar de scene
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene("Scene3");
        }
    }
}
