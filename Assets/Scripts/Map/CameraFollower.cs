using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform player;

    private float leftBound, rightBound, upperBound, lowerBound;

    private void CalculateBounds()
    {
        float verticalExtent = cam.orthographicSize;
        float horizontalExtent = verticalExtent * Screen.width / Screen.height;
        leftBound = horizontalExtent - spriteRenderer.sprite.bounds.size.x / 2.0f;
        rightBound = spriteRenderer.sprite.bounds.size.x / 2.0f - horizontalExtent;
        lowerBound = cam.orthographicSize - spriteRenderer.sprite.bounds.size.y / 2.0f;
        upperBound = spriteRenderer.sprite.bounds.size.y / 2.0f - verticalExtent;
    }

    void Awake()
    {
        cam = GetComponent<Camera>();
        CalculateBounds();
    }

    void Update()
    {
        Vector3 target = new Vector3(
            Mathf.Clamp(player.position.x, leftBound, rightBound),
            Mathf.Clamp(player.position.y, lowerBound, upperBound),
            transform.position.z
        );
        transform.position = target;
    }
}
