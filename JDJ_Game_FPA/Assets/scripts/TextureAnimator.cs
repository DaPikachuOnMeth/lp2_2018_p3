using UnityEngine;

namespace UnityClass.DJD
{

    /// <summary>
    /// Classe responsável por animar texturas.
    /// </summary>
    public class TextureAnimator : MonoBehaviour
    {

        /// <summary>
        /// array de texturas.
        /// </summary>
        public Texture[] textures;

        /// <summary>
        /// textura default.
        /// </summary>
        private Texture defTexture;


        /// <summary>
        /// frames por segundo.
        /// </summary>
        public float framesPsecond;

        /// <summary>
        /// referencia ao renderer no qual a txtura será animada.
        /// </summary>
        private Renderer textureRenderer;

        /// <summary>
        /// variável que define se é para animar ou não a textura.
        /// </summary>
        bool animate = false;
        bool animateBuffer = true;

        /// <summary>
        /// Define e atribui a textura "_MainText" 
        /// </summary>
        void Awake()
        {
            textureRenderer = GetComponent<Renderer>();
            defTexture = textureRenderer.material.GetTexture("_MainTex");
        }

        /// <summary>
        /// Inicia e repete a função Anim().
        /// </summary>
        void Update()
        {
            if (animateBuffer)
            {
                Anim();
            }
        }

        /// <summary>
        /// Quando a função é chamada, começa a animação.
        /// </summary>
        void Anim()
        {
            int _index = (int)(Time.timeSinceLevelLoad * framesPsecond);
            _index = _index % textures.Length;
            textureRenderer.material.SetTexture("_MainTex", textures[_index]);
            if (!animate)
            {
                animateBuffer = true;
                textureRenderer.material.SetTexture("_MainTex", defTexture);
            }
        }

        /// <summary>
        /// Para a animação.
        /// </summary>
        public void StopAnimation()
        {
            animate = false;
        }

        /// <summary>
        /// Inicia a animação.
        /// </summary>
        public void StartAnimation()
        {
            animateBuffer = true;
            animate = true;
        }
    }
}