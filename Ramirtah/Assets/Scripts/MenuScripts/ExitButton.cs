using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitButton : MonoBehaviour
{
    public void exit()
    {
        //This code closes the application
        Debug.Log("QUIT");
        Application.Quit();
    }
}