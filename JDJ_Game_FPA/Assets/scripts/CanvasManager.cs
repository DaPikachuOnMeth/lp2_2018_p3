using UnityEngine;
using UnityEngine.UI;

namespace UnityClass.DJD
{
    /// <summary>
    /// Classe responsável pelo canvas.
    /// </summary>
    public class CanvasManager : MonoBehaviour
    {
        private static CanvasManager _instance; //singleton

        public GameObject interactionPanel;
        public Text interactionText;
        public GameObject inventoryPanel;
        public Image[] inventoryIcons;

        /// <summary>
        /// Lê os valores _instance
        /// </summary>
        public static CanvasManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Limpa as insntancias no _isntance
        /// </summary>
        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (_instance == null)
                _instance = this;
        }

        /// <summary>
        /// Esconde os ícones no arranque.
        /// </summary>
        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            HideInteractionPanel();

            ClearAllInventorySlotIcons();
        }

        /// <summary>
        /// Esconde a possibilidade de interação
        /// </summary>
        public void HideInteractionPanel()
        {
            interactionPanel.SetActive(false);
        }

        /// <summary>
        /// Usado para mostrar interação com os NPCs
        /// </summary>
        public void ShowInteractionPanel(string text)
        {
            interactionText.text = text;
            interactionPanel.SetActive(true);
        }

        /// <summary>
        /// Limpa todos os slots do inventário
        /// </summary>
        private void ClearAllInventorySlotIcons()
        {
            ClearIcons(inventoryIcons);
        }

        /// <summary>
        /// Desativa todos os icones e limpa os slots
        /// </summary>
        public void ClearIcons(Image[] img)
        {
            for (int i = 0; i < img.Length; ++i)
            {
                img[i].enabled = false;
                img[i].sprite = null;
            }
        }

        /// <summary>
        /// Desativa e tira o objeto no inventário
        /// </summary>
        public void ClearIcon(Image[] img, int i)
        {
            img[i].enabled = false;
            img[i].sprite = null;
        }

        /// <summary>
        /// Define os icones e a sua posição no inventário
        /// </summary>
        public void SetSlotIcon(Image[] img, int slotIndex, Sprite icon)
        {
            img[slotIndex].sprite = icon;
            img[slotIndex].enabled = true;
        }

    }
}