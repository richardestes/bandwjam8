using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    private Respawn _respawn;

    private void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(_respawn.RespawnPlayer());
    }

}
