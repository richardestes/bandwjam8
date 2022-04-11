using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollow _cam;

    [SerializeField]
    private Respawn _respawn;

    private void Start()
    {
        if (!_cam) _cam = Camera.main.GetComponent<CameraFollow>();
        StartCoroutine(_respawn.RespawnPlayer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }
}