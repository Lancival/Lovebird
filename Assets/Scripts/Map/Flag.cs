using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteCrossFade))]

public class Flag : MonoBehaviour
{
    private CircleCollider2D col;
    private SpriteCrossFade fader;
    private string sceneName;
    private bool inRange;

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
        sceneName = this.name.Substring(0, this.name.Length - 5);
    }

    void Start() => fader.sprite = flagRegular;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            fader.sprite = flagGlowing;
            banner.FadeIn(bannerSprite);
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            fader.sprite = flagRegular;
            banner.FadeOut();
            inRange = false;
        }
    }

    public void LoadIsland(InputAction.CallbackContext context)
    {
        if (inRange)
        {
            SceneLoader.instance?.LoadScene(sceneName);
            inRange = false;
        }
    }
}
