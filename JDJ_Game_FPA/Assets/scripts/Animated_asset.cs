using UnityEngine;

namespace UnityClass.DJD
{
    public class Animated_asset : MonoBehaviour
    {
        public Sprite[] sprites;

        private Sprite defTexture;

        public float framesPsecond = 30;

        private SpriteRenderer spriteRend;

        private Sprite defSprite;

        bool animate = true;
        bool animateBuffer = true;

        /// <summary>
        /// Aplica os sprites por animar
        /// </summary>
        void Start()
        {
            spriteRend = GetComponent<Renderer>() as SpriteRenderer;
            defSprite = spriteRend.sprite;
        }

        /// <summary>
        /// Inicia a função Anim() constantemente
        /// </summary>
        void Update()
        {
            if (animateBuffer)
            {
                Anim();
            }
        }

        /// <summary>
        /// Executa a animação dos sprites considerando o frame rate
        /// </summary>
        void Anim()
        {
            int _index = (int)(Time.timeSinceLevelLoad * framesPsecond);
            _index = _index % sprites.Length;
            spriteRend.sprite = sprites[_index];
            if (!animate)
            {
                animateBuffer = true;
                spriteRend.sprite = defSprite;
            }

        }

        /// <summary>
        /// Para a animação
        /// </summary>
        public void StopAnimation()
        {
            animate = false;
        }

        /// <summary>
        /// Inicia a animação
        /// </summary>
        public void StartAnimation()
        {
            animateBuffer = true;
            animate = true;
        }
    }
}