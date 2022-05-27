using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class FishParticle : MonoBehaviour
{
    public IEnumerator FlyToPlayer()
    {
        float startTime = Time.time;
        Vector3 position = GameObject.Find("Player").transform.position;
        position = new Vector3(position.x, position.y + 0.5f, position.z);

        do
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, position, Time.time - startTime);
            transform.localScale = Vector3.one * (1 + startTime - Time.time);
        }
        while (Time.time - startTime < 1.0f);

        Destroy(gameObject);
    }
}
