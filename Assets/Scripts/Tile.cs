using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Animations;

public class Tile : MonoBehaviour
{
    [SerializeField] List<GameObject> diseaseCubes;
    [SerializeField] GameObject[] researchCenters;
    [SerializeField] Material tileColor;
    [SerializeField] Tile[] adjacentTiles;
    [SerializeField] Player player;
    [SerializeField] public string locationName;
    [SerializeField] string mouseHover;
    private BoardManager boardManager;
    private Vector3 diseaseCubesPos;
    private bool isFull;

    private void Awake()
    {
        diseaseCubesPos = this.transform.position;
        diseaseCubesPos.x += this.transform.localScale.x;
        boardManager = GameObject.FindWithTag("BoardManager").GetComponent<BoardManager>();
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
    public void AddDiseaseCube()
    {
        if (diseaseCubes.Count < 3)
        {
            diseaseCubes.Add(Instantiate(boardManager.diseaseCubePrefab, diseaseCubesPos, Quaternion.identity));
            diseaseCubesPos.x += this.transform.localScale.x;
        }
        else if (diseaseCubes.Count == 3)
        {
            isFull = true;
        }
        if (isFull)
        {
            for (int i = 0; i < adjacentTiles.Length; i++)
            {
                if (!adjacentTiles[i].isFull) adjacentTiles[i].AddDiseaseCube();
            }
        }
    }
    public void AddDiseaseCube(int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            if (diseaseCubes.Count < 3)
            {
                diseaseCubes.Add(Instantiate(boardManager.diseaseCubePrefab, diseaseCubesPos, Quaternion.identity));
                diseaseCubesPos.x += this.transform.localScale.x;
            }
        }
    }
    public bool CanAddDiseaseCube()
    {
        if (diseaseCubes.Count < 3) return true;
        else return false;
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
