using UnityEngine;

public class AtlantaCoveManager : MonoBehaviour
{
    [SerializeField] private bool unlocked = false;
    [SerializeField] private Sprite cloudsUncovered;

    [Header("Atlanta Cove GameObjects")]
        [SerializeField] private GameObject flag;
        [SerializeField] private GameObject clouds;

    void Start()
    {
        if (unlocked)
        {
            flag.SetActive(true);
            clouds.GetComponent<SpriteCrossFade>().sprite = cloudsUncovered;
        }
        else
        {
            flag.SetActive(false);
        }
    }
}
