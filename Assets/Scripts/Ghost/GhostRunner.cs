using TarodevGhost;
using Tarodev;
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
    private MusicManager _musicManager;
    [SerializeField]
    private LevelManager _levelManager;
    [SerializeField]
    private SpriteManager _spriteManager;
    [SerializeField]
    private PatrolPlatform _patrolPlatform;

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
            _system.PlayRecording(RecordingType.Last, Instantiate(_ghostPrefab));
            Invert?.Invoke();
            _musicManager.SwitchSong();
        }
        else if (_finishLine.OnFinalRun() && _system.playingReplay) // player beat ghost
        {
            print("LEVEL COMPLETE! BEAT THE GHOST! :}");
            _system.StopReplay();
            _finishLine.FinishLevel();
            _levelManager.LoadNextLevel();
        }
    }

    private void OnReplayEnd() // Ghost beat you
    {
        Revert?.Invoke();
        _finishLine.ResetValues();
        _musicManager.SwitchSong();
        StartCoroutine(_spriteManager.DisplayLostLevelText());
        StartCoroutine(_respawn.RespawnPlayer());
        print("Replay finished playing");
    }

    public void StartRunAtSpawn()
    {
        if (_system.playingReplay)
        {
            _system.StopReplay();
            _musicManager.SwitchSong();
        }
        Revert?.Invoke();
        _system.StartRun(_recordTarget, _captureEveryNFrames);
        _finishLine.ResetValues();
        if (_patrolPlatform) _patrolPlatform.ResetPosition();
        print("Starting run...");
    }
}

