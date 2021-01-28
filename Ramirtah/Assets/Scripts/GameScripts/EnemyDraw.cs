using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyDraw : MonoBehaviour
{
    public TurnSystem TS;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    //public GameObject Card5;
    //public GameObject Card6;
    //public GameObject Card7;
    //public GameObject Card8;
    //public GameObject Card9;
    //public GameObject Card10;
    //public GameObject Card11;
    //public GameObject Card12;
    //public GameObject Card13;
    //public GameObject Card14;
    //public GameObject Card15;
    //public GameObject Card16;
    //public GameObject Card17;
    //public GameObject Card18;
    //public GameObject Card19;
    //public GameObject Card20;
    //public GameObject PlayerHand;
    public GameObject EnemyHand;

    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);
        cards.Add(Card3);
        cards.Add(Card4);
    }

    public void OnClick()
    {
        for (var i = 0; i < 1; i++)
        {
            //GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            //playerCard.transform.SetParent(PlayerHand.transform, false);

            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyHand.transform, false);
            enemyCard.GetComponent<Draggable>().TS = TS;
            TS.playerCard.Add(enemyCard);

        }
    }
}