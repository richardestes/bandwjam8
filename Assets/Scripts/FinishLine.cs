using System;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer _startSprite;
    [SerializeField] 
    private Vector2 _startPoint;
    private Vector2 _initialPosition;
    private Quaternion _initialRotation;
    private bool _onFinalRun;

    public bool finishedLevel = false; // for testing, not needed once next level loads on finish

    public static event Action Crossed;  // An action is a delegate with a return type of void and no arguments

    private void Awake() {
        _onFinalRun = false;
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_startPoint, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name != "Player") return;
        if (finishedLevel) return;
        if (!_onFinalRun) // initial run
        {
            _onFinalRun = true;
            float newRotation = Quaternion.identity.y;
            newRotation = newRotation * -1;
            transform.SetPositionAndRotation(_startPoint, new Quaternion(0, newRotation, 0, 0));
            print("On final run");
        }
        Crossed?.Invoke();
    }

    public void FinishLevel()
    {
        finishedLevel = true;
    }

    public bool OnFinalRun()
    {
        return _onFinalRun;
    }

    public void ResetValues()
    {
        _onFinalRun = false;
        finishedLevel = false;
        transform.SetPositionAndRotation(_initialPosition, _initialRotation);
    }
}