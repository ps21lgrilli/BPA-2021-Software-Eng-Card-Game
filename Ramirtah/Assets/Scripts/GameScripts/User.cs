using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is code of what to put in the database which is the amount of turns
public class User
{
    public int redTurns;
    public int blueTurns;

    public User()
    {
        redTurns = TurnSystem.numRedDrawCard;
        blueTurns = TurnSystem.numBlueDrawCard;
    }
}
