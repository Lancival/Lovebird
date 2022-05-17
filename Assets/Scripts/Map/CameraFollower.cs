using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;

    private float leftBound;
    private float rightBound;
    private float upperBound;
    private float lowerBound;

    void Awake() => cam = GetComponent<Camera>();

    private void CalculateBounds()
    {
        float verticalExtent = cam.orthographicSize;
        float horizontalExtent = verticalExtent * Screen.width / Screen.height;

        leftBound = horizontalExtent - spriteRenderer.sprite.bounds.size.x / 2.0f;
        rightBound = spriteRenderer.sprite.bounds.size.x / 2.0f - horizontalExtent;
        lowerBound = verticalExtent - spriteRenderer.sprite.bounds.size.y / 2.0f;
        upperBound = spriteRenderer.sprite.bounds.size.y / 2.0f - verticalExtent;
    }

    void Start() => CalculateBounds();

    void Update()
    {
        CalculateBounds();
        Vector3 target = new Vector3(player.position.x, player.position.y,transform.position.z);
        target.x = Mathf.Clamp(target.x, leftBound, rightBound);
        target.y = Mathf.Clamp(target.y, lowerBound, upperBound);
        transform.position = target;
    }
}
