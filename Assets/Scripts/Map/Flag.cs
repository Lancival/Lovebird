using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteCrossFade))]

public class Flag : MonoBehaviour
{
    private CircleCollider2D col;
    private SpriteCrossFade fader;

    [Header("Flag Sprites")]
        [SerializeField] private Sprite flagRegular;
        [SerializeField] private Sprite flagGlowing;

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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            fader.sprite = flagRegular;
        }
    }
}
