using UnityEngine;

/// <summary>
/// classe para destruír algum objecto assim que o player ativa o triggerEnter
/// </summary>
public class Trigger_Disabler : MonoBehaviour
{
    public bool reverseOnLeave;
    [Tooltip("Array with gameobjects to toggle its activity.")]
    public GameObject[] toggle;

    private Color defColor;

    /// <summary>
    /// Destrói o objeto após o Player dar trigger
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < toggle.Length; i++)
            {
                if (toggle[i].activeSelf)
                    toggle[i].SetActive(false);
                else
                    toggle[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}