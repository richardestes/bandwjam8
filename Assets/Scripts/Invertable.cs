using UnityEngine;

public class Invertable : MonoBehaviour
{
    [SerializeField]
    private Sprite _defaultSprite;
    [SerializeField]
    private Sprite _invertedSprite;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void ResetSprite()
    {
        _sr.sprite = _defaultSprite;
    }

    public void InvertSprite()
    {
        _sr.sprite = _invertedSprite;
    }

}
