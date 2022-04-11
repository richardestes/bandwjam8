using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _mainSong, _inverseSong;

    // Start is called before the first frame update
    void Start()
    {
        if (_source) _source.clip = _mainSong;
        _source.Play();
    }

    public void SwitchSong()
    {
        _source.Stop();
        if (_source.clip == _mainSong)
        {
            _source.clip = _inverseSong;
        }
        else
        {
            _source.clip = _mainSong;
        }
        _source.Play();
    }

    public void ResetSong()
    {
        _source.Stop();
        _source.clip = _mainSong;
        _source.Play();
    }
}
