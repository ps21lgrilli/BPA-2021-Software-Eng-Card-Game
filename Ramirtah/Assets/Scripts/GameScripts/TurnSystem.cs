using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class TurnSystem : MonoBehaviour {

    public List<GameObject> playerCard = new List<GameObject>();
    public List<GameObject> EnemyCardDeck = new List<GameObject>();
    public bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;
    public static int numBlueDrawCard = 0;
    public static int numRedDrawCard = 0;

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
        numBlueDrawCard = numBlueDrawCard + 1;
        PostToDatabase();
        Debug.Log("Blue" + numBlueDrawCard);
        isYourTurn = false;
        yourOpponentTurn += 1;
    }

    public void EndOpponenturn()
    {
        numRedDrawCard = numRedDrawCard + 1;
        PostToDatabase();
        Debug.Log("Red" + numRedDrawCard);
        isYourTurn = true;
        yourTurn += 1;
    }
    //Code to add the amount of turns to the database
    private void PostToDatabase()
    {
        User user = new User();
        //Guiding to the database
        RestClient.Put("https://ramitah-d1f8a-default-rtdb.firebaseio.com/" + "Number of times card was drawn" + ".json", user);
    }
}
