using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private bool _countDown = true;
    private bool _stopped = false;
    
    [SerializeField]
    private float _timeDuration = 60f;
    private float _initialTime;

    private float _timer;
    private float _flashTimer;
    private float _flashDuration = 1f;
    private float _finishTime;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI seperator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    public static event Action TimerFinished;

    void Awake()
    {
        ResetTimer();
        _initialTime = _timeDuration;
    }

    void Update()
    {
        if (_stopped) return;
        if (_countDown && _timer > 0 && !_stopped)
        {
            _timer -= Time.deltaTime;
            UpdateTimerDisplay(_timer);
        }
        else if (!_countDown && _timer < _timeDuration && !_stopped)
        {
            _timer += Time.deltaTime;
            UpdateTimerDisplay(_timer);
        }
        else if (_stopped && _timer > 0)
        {
            Flash();
        }
        else
        {
            _stopped = true;
            TimerFinished?.Invoke();
            Flash();
        }
    }

    public void StopTimer()
    {
        _stopped = true;
        _finishTime = _timer;
    }

    public string GetFinishTime()
    {
        float minutes = Mathf.FloorToInt(_finishTime / 60);
        float seconds = Mathf.FloorToInt(_finishTime % 60);

        string finishTimeString = string.Format("{00:00}{1:00}", minutes, seconds);
        return finishTimeString;
    }

    public void ResetTimer()
    {
        //if (_countDown) _timer = _initialTime;
        //else _timer = 0;
        _timer = _initialTime;
        ResetTimerColors();
        _stopped = false;
        _countDown = true;
        SetTextDisplay(true);
    }   

    public void SetTimer(float duration)
    {
        if (_countDown) _timer = duration;
        else _timer = 0;
        SetTextDisplay(true);
    }

    private void ResetTimerColors()
    {
        firstMinute.color = Color.black;
        secondMinute.color = Color.black;
        seperator.color = Color.black;
        firstSecond.color = Color.black;
        secondSecond.color = Color.black;
    }

    public void InvertTimerColors()
    {
        firstMinute.color = Color.white;
        secondMinute.color = Color.white;
        seperator.color = Color.white;
        firstSecond.color = Color.white;
        secondSecond.color = Color.white;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        // Ex currentTime = 1412
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if (_countDown && _timer != 0)
        {
            _timer = 0;
            UpdateTimerDisplay(_timer);
        }

        if (!_countDown && _timer != _timeDuration)
        {
            _timer = _timeDuration;
            UpdateTimerDisplay(_timer);
        }

        if (_flashTimer <= 0)
        {
            _flashTimer = _flashDuration;
        } 
        else if (_flashTimer >= _flashDuration / 2)
        {
            _flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
        else
        {
            _flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        seperator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }

}
