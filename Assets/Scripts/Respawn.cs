using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour {
    [SerializeField]
    private Transform player;
    [SerializeField] 
    private Vector2 _respawnPoint;
    [SerializeField] 
    private float _penaltyTime = 0.5f;
    [SerializeField]
    private GhostRunner _ghostRunner;
    [SerializeField]
    private MusicManager _musicManager;
    private float _timeStartedPenalty;

    private void OnTriggerEnter2D(Collider2D col) {
        StartCoroutine(RespawnPlayer());
    }

    public IEnumerator RespawnPlayer() {
        _timeStartedPenalty = Time.time;
        _ghostRunner.StartRunAtSpawn();
        do
        {
            player.position = _respawnPoint;
            yield return null;
        } while (_timeStartedPenalty + _penaltyTime > Time.time);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_respawnPoint,0.5f);
    }
    
}
