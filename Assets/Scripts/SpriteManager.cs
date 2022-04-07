using System;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] invertables;

    void Start()
    {
        invertables = GameObject.FindGameObjectsWithTag("Invertable");
        print(invertables.Length);
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
        foreach (GameObject obj in invertables)
        {
            obj.GetComponent<Invertable>().ResetSprite();
        }
    }

    private void InvertAll()
    {
        if (invertables.Length <= 0) return;
        foreach (GameObject obj in invertables)
        {
            obj.GetComponent<Invertable>().InvertSprite();
        }
    }

}
