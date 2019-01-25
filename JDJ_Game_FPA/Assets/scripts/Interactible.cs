using UnityEngine;

namespace UnityClass.DJD
{

    /// <summary>
    /// Classe responsável pelos objectos interagíveis do jogo.
    /// </summary>
    public class Interactible : MonoBehaviour
    {
        
        [Tooltip("Sprite reference for the inventory icon")]
        public Sprite inventoryIcon;
        
        [Tooltip("sound name")]
        public string soundname;
 
        [Tooltip("turn on to make this interactible one reset button for platforms")]
        public bool IsResetButton;

        [Tooltip("turn on if the npc have multiple states")]
        public bool IsNPC;
 
        [Tooltip("turn on to make this interactible active since the game start")]
        public bool defaultOn;
        
        [Tooltip("turn on to make this interactible interactive")]
        public bool isInteractive;
        
        [Tooltip("turn on to make this interactible play the active animation")]
        public bool isActive;
        
        [Tooltip("turn on to make this interactible pickable")]
        public bool isPickable;
        
        [Tooltip("turn on to make this interactible able to multiple interactions")]
        public bool allowsMultipleInteractions;
        
        [Tooltip("write the requeriment text here")]
        public string requirementText;
        
        [Tooltip("write the interaction text here")]
        public string interactionText;
        
        [Tooltip("turn on to consume the requirements")]
        public bool consumesRequirements;
        
        [Tooltip("array with the requirements")]
        public Interactible[] inventoryRequirements;

        [Tooltip("array with other inceractibles who this interactible actives")]
        public Interactible[] indirectInteractibles;
        
        [Tooltip("array with other inceractibles who this interactible actives the IsActive option")]
        public Interactible[] indirectActivations;

        public Interactible[] resetActivations;

        public AudioSource audioSource;

        /// <summary>
        /// metodo para ativar a animação Activate e por isActive = true.
        /// </summary>
        public void Activate()
        {
            isActive = true;
            PlayAnimation("Activate");
        }

        /// <summary>
        /// metodo para interação.
        /// </summary>
        public void Interact()
        {
            if (isActive)
                InteractActive();
            else
                InteractInactive();
        }

        /// <summary>
        /// interação quando IsActive = true
        /// </summary>
        private void InteractActive()
        {
            FindObjectOfType<AudioManager>().Play(soundname);
            if (IsResetButton)
            {
                ResetPlatforms();

                // Used for one exclusive scenario for a button.

                PlayAnimation("InteractActive");

                ActivatePlatforms();

                InteractIndirects();

                ActivateIndirects();
            }
            else
            {
                if (IsNPC)
                {
                    GetComponent<Npc_state>().CallState();
                    
                }
                PlayAnimation("InteractActive");

                ActivatePlatforms();

                InteractIndirects();

                ActivateIndirects();
            }

            if (!allowsMultipleInteractions)
                isInteractive = false;
        }

        /// <summary>
        /// interação quando IsActive = false
        /// </summary>
        private void InteractInactive()
        {
            PlayAnimation("InteractInactive");
        }

        /// <summary>
        /// metodo para ativar a animação
        /// </summary>
        private void PlayAnimation(string animationName)
        {
            Animator animator = GetComponent<Animator>();

            if (animator != null)
                animator.SetTrigger(animationName);
        }

        /// <summary>
        /// metodo para interagir com os indirects
        /// </summary>
        private void InteractIndirects()
        {
            if (indirectInteractibles != null)
            {
                for (int i = 0; i < indirectInteractibles.Length; ++i)
                    indirectInteractibles[i].Interact();
            }
        }

        /// <summary>
        /// metodo para ativar os indirects
        /// </summary>
        private void ActivateIndirects()
        {
            if (indirectActivations != null)
            {
                for (int i = 0; i < indirectActivations.Length; ++i)
                    indirectActivations[i].Activate();
            }

        }

        /// <summary>
        /// metodo para ativar as plataformas
        /// </summary>
        private void ActivatePlatforms()
        {
            if (indirectInteractibles != null)
            {
                for (int i = 0; i < indirectInteractibles.Length; ++i)
                {
                    if (indirectInteractibles[i].tag == "Platform" && indirectInteractibles[i] != null)
                    {
                        if (indirectInteractibles[i].GetComponent<MeshRenderer>().enabled == false ||
                            indirectInteractibles[i].GetComponent<BoxCollider>().enabled == false)
                        {
                            indirectInteractibles[i].GetComponent<MeshRenderer>().enabled = true;
                            indirectInteractibles[i].GetComponent<BoxCollider>().enabled = true;

                            foreach (Interactible g in indirectInteractibles[i].GetComponentsInChildren<Interactible>())
                            {
                                g.GetComponent<MeshRenderer>().enabled = true;
                                g.GetComponent<BoxCollider>().enabled = true;
                            }
                        }

                        else if (indirectInteractibles[i].GetComponent<MeshRenderer>().enabled == true ||
                            indirectInteractibles[i].GetComponent<BoxCollider>().enabled == true)
                        {
                            indirectInteractibles[i].GetComponent<MeshRenderer>().enabled = false;
                            indirectInteractibles[i].GetComponent<BoxCollider>().enabled = false;

                            foreach (Interactible g in indirectInteractibles[i]
                                .GetComponentsInChildren<Interactible>())
                            {
                                g.GetComponent<MeshRenderer>().enabled = false;
                                g.GetComponent<BoxCollider>().enabled = false;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// metodo para resetar as plataformas.
        /// </summary>
        private void ResetPlatforms()
        {
            if (resetActivations != null && IsResetButton)
            {
                for (int i = 0; i < resetActivations.Length; ++i)
                {
                    if (resetActivations[i].tag == "Platform" && indirectInteractibles[i] != null)
                    {
                        if (resetActivations[i].defaultOn)
                        {
                            resetActivations[i].GetComponent<MeshRenderer>().enabled = true;
                            resetActivations[i].GetComponent<BoxCollider>().enabled = true;
                        }
                        else
                        {
                            resetActivations[i].GetComponent<MeshRenderer>().enabled = false;
                            resetActivations[i].GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                }
            }
        }
    }
}