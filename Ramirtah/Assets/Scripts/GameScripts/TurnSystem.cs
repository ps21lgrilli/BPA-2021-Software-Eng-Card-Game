using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

    public List<GameObject> playerCard = new List<GameObject>();
    public List<GameObject> EnemyCardDeck = new List<GameObject>();
    public bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;

    void Start()
    {
        isYourTurn = true;
        yourTurn = -1;
        yourOpponentTurn = 0;
    }

    void Update()
    {
        //This code checks if it is player 1 turn and changes the text if it is or not
        if (isYourTurn == true)
        {
            turnText.text = "Blue's Turn";
        }
        else turnText.text = "Red's Turn";
    }
    //This code
    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOpponentTurn += 1;
    }

    public void EndOpponenturn()
    {
        isYourTurn = true;
        yourTurn += 1;
    }
}
