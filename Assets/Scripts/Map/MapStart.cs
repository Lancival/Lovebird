using UnityEngine;
using UnityEngine.SceneManagement;

public class MapStart : MonoBehaviour
{
    public static string sceneName;

    void Start() => sceneName = SceneManager.GetActiveScene().name;
}
