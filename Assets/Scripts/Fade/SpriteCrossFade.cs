using UnityEngine;

public class SpriteCrossFade : MonoBehaviour
{
    [Header("SpriteRenderer Components")]
        [SerializeField] private FadeSpriteRenderer fader1;
        [SerializeField] private FadeSpriteRenderer fader2;

        private SpriteRenderer renderer1;
        private SpriteRenderer renderer2;

    [Header("Parameters")]
        [SerializeField] private float duration = 1.0f;
        [SerializeField] private Sprite _sprite;
        public Sprite sprite
        {
            get => _sprite;
            set
            {
                _sprite = value;
                if (firstRendererActive)
                {
                    renderer2.gameObject.SetActive(true);
                    renderer2.sprite = _sprite;
                    fader2.FadeIn(duration);
                    fader1.FadeOutInactive(duration);
                    firstRendererActive = false;
                }
                else
                {
                    renderer1.gameObject.SetActive(true);
                    renderer1.sprite = _sprite;
                    fader1.FadeIn(duration);
                    fader2.FadeOutInactive(duration);
                    firstRendererActive = true;
                }
            }
        }
        private bool firstRendererActive = true;

    void Awake()
    {
        if (sprite == null || fader1 == null || fader2 == null)
        {
            Debug.LogError(string.Format("SpriteCrossFade {0} missing member values.", this.name));
            Destroy(this);
        }
        else
        {
            renderer1 = fader1.GetComponent<SpriteRenderer>();
            renderer2 = fader2.GetComponent<SpriteRenderer>();

            renderer1.sprite = _sprite;
            renderer1.gameObject.SetActive(true);
            renderer2.gameObject.SetActive(false);
        }
    }
}