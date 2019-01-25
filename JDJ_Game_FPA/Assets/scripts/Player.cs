using System.Collections.Generic;
using UnityEngine;


namespace UnityClass.DJD
{
    /// <summary>
    /// classe responsável pela interação do player com o jogo.
    /// </summary>
    public class Player : MonoBehaviour
    {

        [Tooltip("Distance btween player and interactible")]
        public float maxInteractionDistance;

        [Tooltip("Player's inventory size ")]
        [Range(0, 6)]
        public int inventorySize;

        internal CanvasManager _canvasManager;
        private Camera _camera;

        private RaycastHit _raycastHit;
        private Interactible _currentInteractible;
        public List<Interactible> _inventory;

        /// <summary>
        /// metodo para inicializar variáris ou chamar metodos ao iniciar o jogo.
        /// </summary>
        private void Start()
        {
            _canvasManager = CanvasManager.Instance; //Canvas

            _camera = GetComponentInChildren<Camera>(); //player camera

            _currentInteractible = null; //selected interactible from inventory

            _inventory = new List<Interactible>(inventorySize); //inventory
        }

        /// <summary>
        /// método chamado em cada loop do jogo.
        /// </summary>
        void Update()
        {
            CheckForInteractible();
            CheckForInteractionClick();
        }

        /// <summary>
        /// método para atualizar o raycast.
        /// </summary>
        private void CheckForInteractible()
        {
            if (Physics.Raycast(_camera.transform.position,
                _camera.transform.forward, out _raycastHit,
                maxInteractionDistance))
            {
                Interactible newInteractible = _raycastHit.collider.GetComponent<Interactible>();

                if (newInteractible != null && newInteractible.isInteractive)
                    SetInteractible(newInteractible);
                else
                    ClearInteractible();
            }
            else
                ClearInteractible();
        }

        /// <summary>
        /// método para verificar se foi solicitada uma interação.
        /// </summary>
        private void CheckForInteractionClick()
        {
            if (Input.GetMouseButtonDown(0) && _currentInteractible != null)
            {
                if (_currentInteractible.GetComponent<Interactible>().isPickable)
                {
                    AddToInventory(_currentInteractible);
                    Interact(_currentInteractible);
                }

                else if (HasRequirements(_currentInteractible))
                {
                    Interact(_currentInteractible);
                }


            }
        }

        /// <summary>
        /// método para interagir com o interactible.
        /// </summary>
        private void SetInteractible(Interactible newInteractible)
        {
            _currentInteractible = newInteractible;

            if (HasRequirements(_currentInteractible))
            {
                _canvasManager.ShowInteractionPanel(_currentInteractible.interactionText);
            }
            else if (!HasRequirements(_currentInteractible) && _currentInteractible.IsNPC)
            {
                _canvasManager.ShowInteractionPanel(_currentInteractible.interactionText);
            }

            else
                _canvasManager.ShowInteractionPanel(_currentInteractible.requirementText);
        }

        /// <summary>
        /// método para limpar a referencia do interactible.
        /// </summary>
        private void ClearInteractible()
        {
            _currentInteractible = null;

            _canvasManager.HideInteractionPanel();
        }

        /// <summary>
        /// método para mostrar a mensagem de requerimentos do interactible.
        /// </summary>
        private bool HasRequirements(Interactible interactible)
        {
            if (interactible)
            {
                for (int i = 0; i < interactible.inventoryRequirements.Length; ++i)
                {
                    if (!HasInInventory(interactible.inventoryRequirements[i]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// método para interagir.
        /// </summary>
        private void Interact(Interactible interactible)
        {
            if (interactible.GetComponent<Interactible>().consumesRequirements)
            {
                for (int i = 0; i < interactible.inventoryRequirements.Length; ++i)
                    RemoveFromInventory(interactible.inventoryRequirements[i]);
            }

            interactible.Interact();
        }

        /// <summary>
        /// método para adicionar i interactible ao inventario do player.
        /// </summary>
        private void AddToInventory(Interactible pickable)
        {
            if (_inventory.Count < inventorySize)
            {
                _inventory.Add(pickable);
                pickable.gameObject.SetActive(false);
                UpdateInventoryIcons();
            }
        }

        /// <summary>
        /// método para averiguar se o jogador contem o interactible.
        /// </summary>
        internal bool HasInInventory(Interactible pickable)
        {
            return _inventory.Contains(pickable);
        }

        /// <summary>
        /// método para remover do inventário.
        /// </summary>
        public void RemoveFromInventory(Interactible pickable)
        {
            _inventory.Remove(pickable);
            UpdateInventoryIcons();
        }

        /// <summary>
        /// método para atualzar os ícones do inventário.
        /// </summary>
        private void UpdateInventoryIcons()
        {
            for (int i = 0; i < inventorySize; ++i)
            {
                if (i < _inventory.Count)
                    _canvasManager.SetSlotIcon(_canvasManager.inventoryIcons, i, _inventory[i].inventoryIcon);
                else
                    _canvasManager.ClearIcon(_canvasManager.inventoryIcons, i);
            }
        }
    }
}

