using TMPro;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] invertables;

    [SerializeField]
    private TextMeshProUGUI levelText;

    void Awake()
    {
        print("Finding invertables"); // DEBUG
        invertables = GameObject.FindGameObjectsWithTag("Invertable");
        if (levelText) levelText.color = Color.black;
        //print(invertables.Length); // DEBUG
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
        print("Resetting all sprites"); // DEBUG
        if (invertables.Length <= 0) return;
        for (int i = 0; i < invertables.Length; i++)
        {
            invertables[i].GetComponent<Invertable>().ResetSprite();
        }
        //foreach (GameObject obj in invertables)
        //{
        //    if (!obj) return; // Put in a null check to prevent NullReferenceException errors on each spawn
        //    obj.GetComponent<Invertable>().ResetSprite();
        //}
        levelText.color = Color.black;
    }

    private void InvertAll()
    {
        if (invertables.Length <= 0) return;
        for (int i = 0; i < invertables.Length; i++)
        {
            invertables[i].GetComponent<Invertable>().InvertSprite();
        }
        //foreach (GameObject obj in invertables)
        //{
        //    //if (!obj) return; // Put in a null check to prevent NullReferenceException errors on each spawn
        //    obj.GetComponent<Invertable>().InvertSprite();
        //}
        levelText.color = Color.white;
    }

}
