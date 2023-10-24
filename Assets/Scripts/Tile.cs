using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject[] diseaseCubes;
    [SerializeField] GameObject[] researchCenters;
    [SerializeField] Player player;

    public void RemoveDiseaseCube(int i)
    {
        GameObject.Destroy(diseaseCubes[i]);
    }
}
