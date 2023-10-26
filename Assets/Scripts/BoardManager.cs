using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField] Tile[] gameTiles;
    [SerializeField] Player[] players;
    [SerializeField] TMP_InputField locationInputBox;
    [SerializeField] TextMeshProUGUI invalidLocationBox;
    [SerializeField] TextMeshProUGUI tileNameTextBox;
    [SerializeField] MouseCursor mouseCursor;
    [SerializeField] Camera mainCamera;
    private Tile targetTile;
    private Tile currentTile;
    private Player currentPlayer;
    private string moveToLocation;
    private Vector3 cursorPos;


    private void Start()
    {
        currentPlayer = players[0];
        invalidLocationBox.text = "";
        tileNameTextBox.text = "";
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
    }
    public void MoveToTile()
    {
        if (IsValidLocation())
        {
            invalidLocationBox.text = "";
            //Remove player from current tile and add player to target tile
            players[0].SetTile(targetTile);
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
        if (targetTile != null)
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
    public void TreatDisease()
    {
        currentTile.RemoveDiseaseCube();
    }
}
