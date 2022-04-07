using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollow _cam;
    private SpriteRenderer _sprite;
    private PlayerController _controller;

    [SerializeField]
    private Respawn _respawn;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _controller = GetComponent<PlayerController>();
        if (!_cam) _cam = Camera.main.GetComponent<CameraFollow>();
        StartCoroutine(_respawn.RespawnPlayer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }
}
