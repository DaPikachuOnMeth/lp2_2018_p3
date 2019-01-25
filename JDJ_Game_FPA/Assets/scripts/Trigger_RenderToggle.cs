
using UnityEngine;
using System.Linq;

/// <summary>
/// Classe que define os triggers para alterar entre visível e invisível objetos no cenário.
/// </summary>
public class Trigger_RenderToggle : MonoBehaviour
{

    [Tooltip("ONLY ONE COLLIDER SHOULD HAVE THIS.")]
    public bool initializer = false;
    [Tooltip("Hide objects with the Tag aswell.")]
    public bool toggleTagOff = true;
    [Tooltip("Hide objects with the Tag aswell.")]
    public bool toggleTagOn = true;
    [Tooltip("Reverses its changes on leave.")]
    public bool reverseOnLeave = false;
    [Tooltip("Destroys itself on leave.")]
    public bool destroyOnLeave = false;
    [Tooltip("Destroys itself on Entry.")]
    public bool destroyOnEnter = false;
    [Tooltip("Toggles fog when triggered.")]
    public bool toggleFog = true;
    [Tooltip("Removes fog when triggered.")]
    public bool removeFog = false;
    [Tooltip("Toggles light intensity from the default to the defined one.")]
    public bool toggleIntensity = true;
    [Tooltip("Sets Light intensity to 1")]
    public bool setIntensity = false;
    [Tooltip("Ammount of light intensity.")]
    public int intensityAmmount = 1;
    [Tooltip("Light source which will be modified.")]
    public Light sun;
    [Tooltip("Color to be set on the Light.")]
    public Color colorSet;
    [Tooltip("Array with gameobjects to toggle its rendering on.")]
    public GameObject[] toggleOn;
    [Tooltip("Array with gameobjects to toggle its rendering off.")]
    public GameObject[] toggleOff;
    

    private Color defColor;

    private void Start()
    {
        sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
        ///Defines original sun color.
        defColor = sun.color;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("ToggleOn");
        if (toggleTagOn)
        {
            if (toggleOn.Length != 0)
            {
                toggleOn = toggleOn.Concat(temp).ToArray();
            }
            else
            { toggleOn = temp; }
        }
        if (toggleTagOff)
        {
            temp = GameObject.FindGameObjectsWithTag("ToggleOff");
            if (toggleOff.Length != 0)
            {
                toggleOff = toggleOff.Concat(temp).ToArray();
            }
            else
            { toggleOff = temp; }
        }
                if (initializer) { Initializer(); }
    }

    /// <summary>
    /// Altera o que tem-se de renderizar quando o Player ativa o triggerEnter.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < toggleOn.Length; i++)
            {
                Renderer temp2 = toggleOn[i].GetComponent<Renderer>();
                if (temp2 != null)
                {
                    temp2.enabled = true;
                }
                else
                {
                    temp2 = toggleOn[i].GetComponent<SpriteRenderer>();
                    temp2.enabled = true;
                }
            }

            for (int i = 0; i < toggleOff.Length; i++)
            {
                Renderer temp2 = toggleOff[i].GetComponent<Renderer>();
                if (temp2 != null)
                {
                    temp2.enabled = false;
                }
                else
                {
                    temp2 = toggleOff[i].GetComponent<SpriteRenderer>();
                    temp2.enabled = false;
                }
            }


            if (removeFog || toggleFog) { RenderSettings.fog = false; }

            if (setIntensity || toggleIntensity)
            {
                sun.color = (colorSet);
                RenderSettings.ambientIntensity = 1;
            }
            if (destroyOnEnter) { Destroy(gameObject); }
        }
    }

    /// <summary>
    /// Altera o que tem-se de renderizar quando o Player ativa triggerExit.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (reverseOnLeave)
            {
                    for (int i = 0; i < toggleOn.Length; i++)
                    {
                        var temp2 = toggleOn[i].GetComponent<Renderer>();
                        if (temp2 != null)
                        {
                            temp2.enabled = false;
                        }
                        else
                        {
                            temp2 = toggleOn[i].GetComponent<SpriteRenderer>();
                            temp2.enabled = false;
                        }
                    }

                    for (int i = 0; i < toggleOff.Length; i++)
                    {
                        var temp2 = toggleOff[i].GetComponent<Renderer>();
                        if (temp2 != null)
                        {
                            temp2.enabled = true;
                        }
                        else
                        {
                            temp2 = toggleOff[i].GetComponent<SpriteRenderer>();
                            temp2.enabled = true;
                        }
                    }
            }
            if (toggleFog)
            {
                RenderSettings.ambientIntensity = 0;
                sun.color = defColor;
                RenderSettings.fog = true;
            }
            if (destroyOnLeave) { Destroy(gameObject); }
        }
    }

    /// <summary>
    /// Inicializa o componente com o renderer ligado ou desligado de 
    /// acordo com o valor de toggleOn e toggle Off
    /// </summary>
    private void Initializer()
    {
        Debug.Log("INITIALIZER IF THERE ARE MORE THAN 1 FIX IT.");
        for (int i = 0; i < toggleOff.Length; i++)
        {
            var temp2 = toggleOff[i].GetComponent<Renderer>();
            if (temp2 != null)
            {
                temp2.enabled = true;
            }
            else
            {
                temp2 = toggleOff[i].GetComponent<SpriteRenderer>();
                temp2.enabled = true;
            }
        }

        for (int i = 0; i < toggleOn.Length; i++)
        {
            var temp2 = toggleOn[i].GetComponent<Renderer>();
            if (temp2 != null)
            {
                temp2.enabled = false;
            }
            else
            {
                temp2 = toggleOn[i].GetComponent<SpriteRenderer>();
                temp2.enabled = false;
            }
        }
        Destroy(gameObject);
    }
}