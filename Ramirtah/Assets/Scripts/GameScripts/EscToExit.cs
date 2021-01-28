using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This code causes the game to close after pressing the ESC Key
public class EscToExit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
