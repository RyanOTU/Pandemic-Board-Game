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
    [SerializeField] int actions = 4;
    [SerializeField] public GameObject diseaseCubeDefault;
    private int currentActions;
    private Tile targetTile;
    private Tile currentTile;
    public Player currentPlayer;
    private string moveToLocation;
    private Vector3 cursorPos;


    private void Start()
    {
        GameObject.Find("Miami").GetComponent<Tile>().AddDiseaseCube(2);
        currentActions = actions;
        currentPlayer = players[0];
        currentTile = players[0].GetTile();
        invalidLocationBox.text = "";
        tileNameTextBox.text = "";
        announcerBox.text = currentPlayer.GetPlayerNum() +", you have " + currentActions + " actions left!";
    }
    private void Update()
    {
        cursorPos = mouseCursor.transform.position + new Vector3(0, -0.5f, 0);
        tileNameTextBox.transform.position = cursorPos;

        //I attempted to get this to work but it kept throwing null reference exceptions even though I'm checking for it sooooo I gave up :)
        if (mouseCursor.hoveredTile != null) tileNameTextBox.text = mouseCursor.hoveredTile.GetComponent<Tile>().locationName;
        else tileNameTextBox.text = "";

        moveToLocation = locationInputBox.GetComponent<TMP_InputField>().text;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MoveToTile();
        }
        if (Input.GetMouseButtonDown(0) && mouseCursor.hoveredTile != null)
        {
            MoveToTile(mouseCursor.hoveredTile);
        }

        if (currentActions == 0 && currentPlayer == players[0])
        {
            currentActions = actions;
            currentPlayer = players[1];
            currentTile = currentPlayer.currentTile;
            currentTile.SetPlayer(currentPlayer);
            AddDisease();
            announcerBox.text = currentPlayer.GetPlayerNum() + ", you have " + currentActions + " actions left!";
        }
        if (currentActions == 0 && currentPlayer == players[1])
        {
            currentActions = actions;
            currentPlayer = players[0];
            currentTile = currentPlayer.currentTile;
            currentTile.SetPlayer(currentPlayer);
            AddDisease();
            announcerBox.text = currentPlayer.GetPlayerNum() + ", you have " + currentActions + " actions left!";
        }
    }
    public void MoveToTile()
    {
        if (IsValidLocation())
        {
            invalidLocationBox.text = "";
            currentPlayer.SetTile(targetTile);
            currentTile = currentPlayer.GetTile();
            DecrementActions();
        }
        else
        {
            invalidLocationBox.text = "Invalid Location!";
        }
    }
    public void MoveToTile(GameObject tile)
    {
        if (IsValidLocation(tile))
        {
            invalidLocationBox.text = "";
            currentPlayer.SetTile(targetTile);
            currentTile = currentPlayer.GetTile();
            DecrementActions();
        }
        else
        {
            invalidLocationBox.text = "Invalid Location!";
        }
    }
    public bool IsValidLocation()
    {
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
    public bool IsValidLocation(GameObject tile)
    {
        if (tile != null) targetTile = tile.GetComponent<Tile>();
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
        if (currentPlayer.role == Player.Roles.QuarrantineExpert)
        {
            //Uncomment to swap between modes (VS / Standard)
            //currentTile.AddDiseaseCube(currentPlayer, diseaseCubeDefault);
            gameTiles[Random.Range(0, gameTiles.Length)].AddDiseaseCube(currentPlayer, diseaseCubeDefault);
            DecrementActions();
        }
        else
        {
            //currentTile.AddDiseaseCube(diseaseCubeDefault);
            gameTiles[Random.Range(0, gameTiles.Length)].AddDiseaseCube(diseaseCubeDefault);
            DecrementActions();
        }
    }
    public void TreatDisease()
    {
        currentTile.RemoveDiseaseCube();
        DecrementActions();
    }
    public void DecrementActions()
    {
        currentActions--;
        announcerBox.text = currentPlayer.GetPlayerNum() + ", you have " + currentActions + " actions left!";
    }
    public Tile GetCurrentTile()
    {
        return currentTile;
    }
}
