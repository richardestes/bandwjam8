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
    [SerializeField]
    private Sprite _quarterNoteSprite;
    [SerializeField]
    private Sprite _eighthNoteSprite;
    [SerializeField]
    private Sprite _quarterNoteSpriteInv;
    [SerializeField]
    private Sprite _eighthNoteSpriteInv;


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
            ParticleSystem ps = _playerParticles[i].GetComponent<ParticleSystem>();
            ParticleSystem.MainModule settings = ps.main;
            // Is this really a switch statement in a Unity script for managing sprites...
            switch (_playerParticles[i].name)
            {
                case "Jump Particles":
                    print("In Jump Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    break;
                case "Launch Particles":
                    print("In Launch Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSprite);
                    break;
                case "Move Particles":
                    print("In Move Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    break;
                case "Land Particles":
                    print("In Land Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    break;
                case "Double Jump Particles":
                    print("In Double Jump Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSprite);
                    break;
                case "Dash Particles":
                    print("In Dash Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSprite);
                    break;
                case "Dash Ring Particles":
                    print("In Dash Ring Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSprite);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSprite);
                    break;
                default:
                    break;
             //... fuck yeah it is.
            }
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
        for (int i = 0; i < _playerParticles.Length; i++)
        {
            ParticleSystem ps = _playerParticles[i].GetComponent<ParticleSystem>();
            ParticleSystem.MainModule settings = ps.main;
            switch (_playerParticles[i].name)
            {
                case "Jump Particles":
                    print("In Jump Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    break;
                case "Launch Particles":
                    print("In Launch Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSpriteInv);
                    break;
                case "Move Particles":
                    print("In Move Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    break;
                case "Land Particles":
                    print("In Land Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    break;
                case "Double Jump Particles":
                    print("In Double Jump Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSpriteInv);
                    break;
                case "Dash Particles":
                    print("In Dash Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSpriteInv);
                    break;
                case "Dash Ring Particles":
                    print("In Dash Ring Particles");
                    ps.textureSheetAnimation.RemoveSprite(0);
                    ps.textureSheetAnimation.AddSprite(_quarterNoteSpriteInv);
                    ps.textureSheetAnimation.AddSprite(_eighthNoteSpriteInv);
                    break;
                default:
                    break;
            }
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
