using TarodevGhost;
using System;
using UnityEngine;

public class GhostRunner : MonoBehaviour {
    [SerializeField]
    private Transform _recordTarget;
    [SerializeField]
    private GameObject _ghostPrefab;
    [SerializeField, Range(1, 10)]
    private int _captureEveryNFrames = 2;
    [SerializeField]
    private FinishLine _finishLine;
    [SerializeField]
    private Respawn _respawn;
    [SerializeField]
    private Timer _timer;

    private ReplaySystem _system;

    private void Awake() => _system = new ReplaySystem(this);

    public static event Action Invert; // change sprites to inverted 
    public static event Action Revert; // change sprites back to default 

    private void OnEnable()
    {
        FinishLine.Crossed += OnFinish;
        ReplaySystem.FinishedPlayingReplay += OnReplayEnd;
    }
    private void OnDisable()
    {
        FinishLine.Crossed -= OnFinish;
        ReplaySystem.FinishedPlayingReplay -= OnReplayEnd;
    }

    private void OnFinish()
    {
        if (_finishLine.OnFinalRun() && !_system.playingReplay)
        {
            _system.FinishRun();
            print("Playing back recording...");
            //_timer.SetTimer(_system.currentReplayDuration);
            //_system.PlayRecording(RecordingType.Best, Instantiate(_ghostPrefab));
            _system.PlayRecording(RecordingType.Last, Instantiate(_ghostPrefab));
            _timer.InvertTimerColors();
            Invert?.Invoke();
        }
        else if (_finishLine.OnFinalRun() && _system.playingReplay) // player beat ghost
        {
            print("LEVEL COMPLETE! BEAT THE GHOST! :}");
            _system.StopReplay();
            _finishLine.FinishLevel();
            _timer.StopTimer();
            // Send Action to Level Manager to Load Next Level
        }
    }

    private void OnReplayEnd()
    {
        StartCoroutine(_respawn.RespawnPlayer());
        print("Replay finished playing");
    }

    public void StartRunAtSpawn()
    {
        if (_system.playingReplay)
        {
            _system.StopReplay();
        }
        _system.StartRun(_recordTarget, _captureEveryNFrames);
        _finishLine.ResetValues();
        _timer.ResetTimer();
        Revert?.Invoke();
        print("Starting run...");
    }
}

