using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField][Range(1f,10f)]
    private float _waitTime;
    [SerializeField]
    private GameObject _platform;

    private IEnumerator Start()
    {
        while (true)
        {
            // Randomize the wait time because
            // in-sync disappearing platforms can
            // be frustrating
            _waitTime += Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(_waitTime);
            _platform.SetActive(!_platform.activeSelf);
        }
    }

}
