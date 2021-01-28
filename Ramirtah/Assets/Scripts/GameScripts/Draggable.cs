using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This code allows the player to drag the cards
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public TurnSystem TS;
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    public GameObject EndYourTurnButton;
    GameObject placeholder = null;


    //public GameObject[] BlueS = { GameObject.Find("BlueS1"), GameObject.Find("BlueS2"), GameObject.Find("BlueS3") };

    Vector2 Offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        Offset = transform.position - new Vector3(eventData.position.x, eventData.position.y, 0);

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        //This sets the cards Width and length
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.preferredHeight = 0;

        placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );

        parentToReturnTo = this.transform.parent;
                 
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {


        if (transform.position.y < 400)
        {
            Debug.Log("Player1");
            if (TS.isYourTurn)
            {
                Debug.Log("Player 1 - Yes it is your turn");
                //this.transform.position = eventData.position;
                transform.position = eventData.position + Offset;

                if (placeholder.transform.parent != placeholderParent)
                    placeholder.transform.SetParent(placeholderParent);

                int newSiblingIndex = placeholderParent.childCount;

                for (int i = 0; i < placeholderParent.childCount; i++)
                {
                    if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                    {
                        newSiblingIndex = i;

                        if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break;
                    }
                }

                placeholder.transform.SetSiblingIndex(newSiblingIndex);
            }
            else
            {
                Debug.Log("Player 1 - No it is not your turn");

            }
        }

        else
        {

            Debug.Log("Player2");
            if (!TS.isYourTurn)
            {
                Debug.Log("Player 2 - Yes it is your turn");
                //this.transform.position = eventData.position;
                transform.position = eventData.position + Offset;

                if (placeholder.transform.parent != placeholderParent)
                    placeholder.transform.SetParent(placeholderParent);

                int newSiblingIndex = placeholderParent.childCount;

                for (int i = 0; i < placeholderParent.childCount; i++)
                {
                    if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                    {
                        newSiblingIndex = i;

                        if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                            newSiblingIndex--;

                        break;
                    }
                }

                placeholder.transform.SetSiblingIndex(newSiblingIndex);
            }
            else
            {
                Debug.Log("Player 2 - No it is not your turn");

            }
            
        }



    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log ("OnEndDrag");
        Debug.Log(placeholder.transform.parent.name);
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent <CanvasGroup>().blocksRaycasts = true;

        //This code detects if a card was dropped on a blue spot
        if(placeholder.transform.parent.name == GameObject.Find("BlueS1").name || 
           placeholder.transform.parent.name == GameObject.Find("BlueS2").name ||
           placeholder.transform.parent.name == GameObject.Find("BlueS3").name)
        {
            //This code stops the card from being able to be dragged
            GetComponent<Draggable>().enabled = false;
            //This code enables the HealthTimer script
            GetComponent<HealthTimer>().enabled = true;
            GetComponent<Player1Damage>().enabled = true;
            //This code prevents other cards from being placed on the same spot
            placeholder.transform.parent.GetComponent<DropZone>().enabled = false;
            //This code changes the turn so player 2 can play
            GameObject.Find("TurnSystem").GetComponent<TurnSystem>().isYourTurn = false;
            //This code disables the usage of player 1 draw card button and enables player 2 draw card button
            GameObject.Find("EndYourTurnButton").GetComponent<Button>().interactable = false;
            GameObject.Find("EndYourOpponentTurn").GetComponent<Button>().interactable = true;

            CalcDamagePlayer1();

        }
        //This code detects if a card was dropped on a red spot
        else if (placeholder.transform.parent.name == GameObject.Find("RedS1").name ||
           placeholder.transform.parent.name == GameObject.Find("RedS2").name ||
           placeholder.transform.parent.name == GameObject.Find("RedS3").name)
        {
            //This code stops the card from being able to be dragged
            GetComponent<Draggable>().enabled = false;
            //This code enables the HealthTimer script
            GetComponent<HealthTimer>().enabled = true;
            //This code prevents other cards from being placed on the same spot
            placeholder.transform.parent.GetComponent<DropZone>().enabled = false;
            //This code changes the turn so player 1 can play
            GameObject.Find("TurnSystem").GetComponent<TurnSystem>().isYourTurn = true;
            //This code disables the usage of player 2 draw card button and enables player 1 draw card button
            GameObject.Find("EndYourTurnButton").GetComponent<Button>().interactable = true;
            GameObject.Find("EndYourOpponentTurn").GetComponent<Button>().interactable = false;

            CalcDamagePlayer2();
        }

        this.transform.position = parentToReturnTo.transform.position;
        
        Destroy(placeholder);
        
        
    }

    public void CalcDamagePlayer1()
    {

        int myCardDamage;
        int currentHealth;
        //This code finds the Damage and Player2Health text and converts it into a int
        bool myCardDamageIsNumber = int.TryParse(gameObject.transform.Find("Damage").GetComponent<Text>().text, out myCardDamage);
        bool EnemyHealthIsNumber = int.TryParse(GameObject.Find("Player2Health").GetComponent<Text>().text, out currentHealth);


        if (myCardDamageIsNumber)
        {
            //This code subtracts currentHealth and myCardDamage and uses the anwser to replace the Player2Health
            currentHealth -= myCardDamage;
            GameObject.Find("Player2Health").GetComponent<Text>().text = currentHealth.ToString();

        }
    }
    public void CalcDamagePlayer2()
    {

        int myCardDamage;
        int currentHealth;
        //This code finds the Damage and Player1Health text and converts it into a int
        bool myCardDamageIsNumber = int.TryParse(gameObject.transform.Find("Damage").GetComponent<Text>().text, out myCardDamage);
        bool EnemyHealthIsNumber = int.TryParse(GameObject.Find("Player1Health").GetComponent<Text>().text, out currentHealth);


        if (myCardDamageIsNumber)
        {
            //This code subtracts currentHealth and myCardDamage and uses the anwser to replace the Player1Health
            currentHealth -= myCardDamage;
            GameObject.Find("Player1Health").GetComponent<Text>().text = currentHealth.ToString();

        }

    }
}
 
