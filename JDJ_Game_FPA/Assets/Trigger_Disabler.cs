using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Disabler : MonoBehaviour
{

    public bool reverseOnLeave;
    [Tooltip("Array with gameobjects to toggle its activity.")]
    public GameObject[] toggle;


    private Color defColor;

    private void Awake()
    {
    }

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