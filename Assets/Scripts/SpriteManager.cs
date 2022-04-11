using TMPro;
using System.Collections;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] invertables;
    [SerializeField]
    private ParticleSystem[] _playerParticles;
    [SerializeField]
    private Material _defaultParticles;
    [SerializeField]
    private Material _invertedParticles;
    [SerializeField]
    private TextMeshProUGUI _ghostBeatText;
    [SerializeField]
    private TextMeshProUGUI _levelText;

    void Awake()
    {
        invertables = GameObject.FindGameObjectsWithTag("Invertable");
        if (_levelText) _levelText.color = Color.black;
        _ghostBeatText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GhostRunner.Invert += InvertAll;
        GhostRunner.Revert += ResetAll;
    }

    private void OnDisable()
    {
        GhostRunner.Invert -= InvertAll;
        GhostRunner.Revert -= ResetAll;
    }

    private void ResetAll()
    {
        if (invertables.Length <= 0) return;
        for (int i = 0; i < invertables.Length; i++)
        {
            invertables[i].GetComponent<Invertable>().ResetSprite();
        }
        for (int i = 0; i < _playerParticles.Length; i++) // Reset particle systems
        {
            ParticleSystem.MainModule settings = _playerParticles[i].GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.black);
            _playerParticles[i].GetComponent<ParticleSystemRenderer>().material = _defaultParticles;
        }
        _levelText.color = Color.black;
    }

    private void InvertAll()
    {
        if (invertables.Length <= 0) return;
        for (int i = 0; i < invertables.Length; i++)
        {
            invertables[i].GetComponent<Invertable>().InvertSprite();
        }
        for (int i = 0; i < _playerParticles.Length; i++) // Reset particle systems
        {
            ParticleSystem.MainModule settings = _playerParticles[i].GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(Color.white);
            _playerParticles[i].GetComponent<ParticleSystemRenderer>().material = _invertedParticles;
        }
        _levelText.color = Color.white;
    }

    public IEnumerator DisplayLostLevelText()
    {
        _ghostBeatText.gameObject.SetActive(!_ghostBeatText.gameObject.activeSelf);
        yield return new WaitForSeconds(3f);
        _ghostBeatText.gameObject.SetActive(!_ghostBeatText.gameObject.activeSelf);
    }

}
