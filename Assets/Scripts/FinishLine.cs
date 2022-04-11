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
    private float _flippedRotation;


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
            _flippedRotation = GetNewRotation(gameObject.transform.eulerAngles.y);
            transform.SetPositionAndRotation(_startPoint, new Quaternion(0, _flippedRotation, 0, 0));
            print("On final run");
        }
        Crossed?.Invoke();
    }

    private float GetNewRotation(float oldRotation)
    {
        if (gameObject.transform.eulerAngles.y == 180f) return 0f;
        else return 180f;
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