using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Tile currentTile;
    public GameObject diseaseCubePrefab;
    public enum Roles
    {
        Medic,
        QuarrantineExpert
    };
    [SerializeField] public Roles role;
    public enum PlayerNum
    {
        Player1,
        Player2,
        Player3,
        Player4
    };
    [SerializeField] private PlayerNum playerNum;

    public void SetTile(Tile t)
    {
        gameObject.transform.position = t.transform.position + new Vector3(0, t.transform.localScale.y / 2, 0);
        currentTile = t;
    }
    public Tile GetTile()
    {
        return currentTile;
    }
    public PlayerNum GetPlayerNum()
    {
        return playerNum;
    }
    public GameObject GetDiseasePrefab()
    {
        return diseaseCubePrefab;
    }
}
