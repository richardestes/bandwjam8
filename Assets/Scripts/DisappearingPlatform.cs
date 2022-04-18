using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField][Range(1f,10f)]
    private float _waitTime;
    [SerializeField]
    private GameObject _platform;

    public bool randomizeWait;

    private IEnumerator Start()
    {
        while (true)
        {
            if (randomizeWait) _waitTime += Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(_waitTime);
            _platform.SetActive(!_platform.activeSelf);
        }
    }

}
