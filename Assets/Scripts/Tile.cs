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
    [SerializeField] public string locationName;
    [SerializeField] string mouseHover;

    private void Start()
    {
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
    public Tile[] GetAdjacentTiles()
    {
        return adjacentTiles;
    }
}
