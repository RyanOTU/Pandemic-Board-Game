using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject[] diseaseCubes;

    public GameObject[] GetDiseaseCubes()
    {
        return diseaseCubes;
    }
    public GameObject GetDiseaseCube(int i)
    {
        return diseaseCubes[i];
    }

    public void SetDiseaseCubes(GameObject[] diseaseCubeList)
    {
        diseaseCubes = diseaseCubeList;
    }

    public void SetDiseaseCube(int i, GameObject diseaseCube)
    {
        diseaseCubes[i] = diseaseCube;
    }
}
