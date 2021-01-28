using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathVariable : MonoBehaviour
{
    //This code creates the cardHealth and cardDamage variable
    public int[] cardHealth = new int[4];
    public int[] cardDamage = new int[4];

    public void Start()
    {
        cardHealth[0] = 99;
        cardDamage[0] = 99;
    }

}
