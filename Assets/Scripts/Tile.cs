using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] List<GameObject> diseaseCubes = new List<GameObject>(3);
    [SerializeField] GameObject[] researchCenters;
    [SerializeField] Material tileColor;
    [SerializeField] Tile[] adjacentTiles;
    [SerializeField] Player player;
    [SerializeField] public string locationName;
    [SerializeField] string mouseHover;

    private void Awake()
    {
        locationName = gameObject.name;

    }
    public void RemoveDiseaseCube()
    {
        for (int i = 0; i < diseaseCubes.Count; i++)
        {
            if (diseaseCubes[i].GetComponent<GameObject>() != null)
            {
                GameObject.Destroy(diseaseCubes[i].gameObject);
                break;
            }
        }
    }
    public List<GameObject> GetDiseaseCubes()
    {
        return diseaseCubes;
    }
    public Tile[] GetAdjacentTiles()
    {
        return adjacentTiles;
    }
    public string GetLocationName()
    {
        return locationName;
    }
}
