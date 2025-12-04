using UnityEngine;
using System.Collections;

public class BossEffe : MonoBehaviour
{
    Camera camera;

    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    IEnumerator BossEffect()
    {
        Time.timeScale = 0;
        camera.

        yield return null;
    }
}
