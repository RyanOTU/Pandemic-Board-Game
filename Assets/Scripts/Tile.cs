using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject[] diseaseCubes = new GameObject[3];
    [SerializeField] GameObject[] researchCenters;
    [SerializeField] Material tileColor;
    [SerializeField] Tile[] adjacentTiles;
    [SerializeField] Player player;
    [SerializeField] string locationName;
    [SerializeField] string mouseHover;
    public GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;

    private void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;

        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;

        locationName = gameObject.name;
    }
    public void RemoveDiseaseCube()
    {
        for (int i = 0; i < diseaseCubes.Length; i++)
        {
            if (diseaseCubes[i].GetComponent<GameObject>() != null)
            {
                GameObject.Destroy(diseaseCubes[i]);
                break;
            }
        }
    }
    public GameObject[] GetDiseaseCubes()
    {
        return diseaseCubes;
    }
}
