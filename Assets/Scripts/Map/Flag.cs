using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteCrossFade))]

public class Flag : MonoBehaviour
{
    private CircleCollider2D col;
    private SpriteCrossFade fader;

    [Header("Sprites")]
        [SerializeField] private Sprite flagRegular;
        [SerializeField] private Sprite flagGlowing;

    [Header("Banner")]
        [SerializeField] private Banner banner;
        [SerializeField] private Sprite bannerSprite;

    void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        fader = GetComponent<SpriteCrossFade>();
    }

    void Start() => fader.sprite = flagRegular;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            fader.sprite = flagGlowing;
            banner.FadeIn(bannerSprite);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            fader.sprite = flagRegular;
            banner.FadeOut();
        }
    }
}
