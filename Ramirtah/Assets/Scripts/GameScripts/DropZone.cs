//This code allows the player to put the cards in a specific area
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TurnSystem TS;


    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent==this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        if (transform.position.y < 400)
        {
            Debug.Log("Player1");
            if (TS.isYourTurn)
            {
                Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

                Debug.Log("Player 1 - Yes it is your turn");               
                Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
                if (d != null)
                {
                    d.parentToReturnTo = this.transform;
                }
                //GameObject.Find("DMBK").GetComponent<Draggable>().enabled = false;
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
                Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
                if (d != null)
                {
                    d.parentToReturnTo = this.transform;
                }
            }
            else
            {
                Debug.Log("Player 2 - No it is not your turn");

            }
        }


    }
}
