using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollow _cam;
    private SpriteRenderer _sprite;
    private PlayerController _controller;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _controller = GetComponent<PlayerController>();
        if (!_cam) _cam = Camera.main.GetComponent<CameraFollow>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }

    public void HandleDeath()
    {
        _sprite.enabled = false;
        _controller.enabled = false;
        _cam.transform.position = _cam.offset;
        SceneManager.LoadScene(0);
        Destroy(this);
    }
}
