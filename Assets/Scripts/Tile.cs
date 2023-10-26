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
    private GameObject diseaseCubePrefab;
    private bool isFull;

    private void Awake()
    {
        diseaseCubesPos = this.transform.position;
        diseaseCubesPos.x += this.transform.localScale.x;
        boardManager = GameObject.FindWithTag("BoardManager").GetComponent<BoardManager>();
        locationName = gameObject.name;
        this.diseaseCubePrefab = boardManager.diseaseCubeDefault;
    }
    public void RemoveDiseaseCube()
    {
        for (int i = 0; i < diseaseCubes.Count; i++)
        {
            GameObject.Destroy(diseaseCubes[diseaseCubes.Count-1]);
            diseaseCubes.Remove(diseaseCubes[diseaseCubes.Count-1]);
            diseaseCubesPos.x -= this.transform.localScale.x;
        }
        isFull = false;
    }
    public List<GameObject> GetDiseaseCubes()
    {
        return diseaseCubes;
    }
    public void AddDiseaseCube()
    {
        if (diseaseCubes.Count < 3)
        {
            diseaseCubes.Add(Instantiate(this.diseaseCubePrefab, diseaseCubesPos, Quaternion.identity));
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
                diseaseCubes.Add(Instantiate(this.diseaseCubePrefab, diseaseCubesPos, Quaternion.identity));
                diseaseCubesPos.x += this.transform.localScale.x;
            }
        }
    }
    public void AddDiseaseCube(GameObject prefab)
    {
        this.diseaseCubePrefab = prefab;
        if (diseaseCubes.Count < 3)
        {
            diseaseCubes.Add(Instantiate(this.diseaseCubePrefab, diseaseCubesPos, Quaternion.identity));
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
                if (!adjacentTiles[i].isFull) adjacentTiles[i].AddDiseaseCube(this.diseaseCubePrefab);
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
    public void SetPlayer(Player player)
    {
        this.diseaseCubePrefab = player.diseaseCubePrefab;
    }
}
