using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerNum
    {
        Player1,
        Player2,
        Player3,
        Player4
    };
    [SerializeField] private PlayerNum playerNum;
}
