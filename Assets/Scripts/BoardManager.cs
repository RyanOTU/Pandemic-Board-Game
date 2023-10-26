using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using UnityEditor.Build.Content;
using Unity.VisualScripting;

public class BoardManager : MonoBehaviour
{
    [SerializeField] Tile[] gameTiles;
    [SerializeField] Player[] players;
    [SerializeField] TMP_InputField locationInputBox;
    [SerializeField] TextMeshProUGUI invalidLocationBox;
    [SerializeField] TextMeshProUGUI tileNameTextBox;
    [SerializeField] TextMeshProUGUI announcerBox;
    [SerializeField] Button addDiseaseButton;
    [SerializeField] Button treatDiseaseButton;
    [SerializeField] MouseCursor mouseCursor;
    [SerializeField] Camera mainCamera;
    [SerializeField] public GameObject diseaseCubePrefab;
    private Tile targetTile;
    private Tile currentTile;
    private Player currentPlayer;
    private int actions = 4;
    private string moveToLocation;
    private Vector3 cursorPos;


    private void Start()
    {
        //GameObject.Find("Miami").GetComponent<Tile>().AddDiseaseCube(2);
        currentPlayer = players[0];
        currentTile = players[0].GetTile();
        invalidLocationBox.text = "";
        tileNameTextBox.text = "";
        announcerBox.text = currentPlayer.GetPlayerNum() +", you have " + actions + " actions left!";
    }
    private void Update()
    {
        cursorPos = mouseCursor.transform.position + new Vector3(0.8f, 0.5f, 0);
        tileNameTextBox.transform.position = cursorPos;

        //I attempted to get this to work but it kept throwing null reference exceptions even though I'm checking for it sooooo I gave up :)
        //if (mouseCursor.GetHoveredTile() != null) tileNameTextBox.text = mouseCursor.GetHoveredTile().locationName;

        moveToLocation = locationInputBox.GetComponent<TMP_InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MoveToTile();
        }
        if (actions == 0 && currentPlayer == players[0])
        {
            currentPlayer = players[1];
        }
        if (actions == 0 && currentPlayer == players[1])
        {
            currentPlayer = players[0];
        }
    }
    public void MoveToTile()
    {
        if (IsValidLocation())
        {
            invalidLocationBox.text = "";
            //Remove player from current tile and add player to target tile
            players[0].SetTile(targetTile);
            currentTile = players[0].GetTile();
            actions--;
            announcerBox.text = currentPlayer.GetPlayerNum() + ", you have " + actions + " actions left!";
        }
        else
        {
            invalidLocationBox.text = "Invalid Location!";
        }
    }
    public bool IsValidLocation()
    {
        //Confused, the currentTile is the target location so I gotta change how that's named/checked so it's not as confusing...
        //FIXXXXXXX
        //ASAPPPPPP
        if (GameObject.Find(moveToLocation) != null) targetTile = GameObject.Find(moveToLocation).GetComponent<Tile>();
        if (targetTile != null && currentPlayer.GetTile() != null)
        {
            for (int i = 0; i < targetTile.GetAdjacentTiles().Length; ++i)
            {
                Debug.Log("Checking tile " + i);
                if (targetTile.GetAdjacentTiles()[i].GetLocationName() == currentPlayer.GetTile().GetLocationName())
                {
                    Debug.Log("Tile " + i + "is adjacent!");
                    return true;
                }
            }
            return false;
        }
        else return false;
    }
    public void AddDisease()
    {
        currentTile.AddDiseaseCube();
    }
    public void TreatDisease()
    {
        currentTile.RemoveDiseaseCube();
    }
    public Tile GetCurrentTile()
    {
        return currentTile;
    }
}
