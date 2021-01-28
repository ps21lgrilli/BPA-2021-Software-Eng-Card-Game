using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public Text WinnerText;

    // Start is called before the first frame update
    void Update()
    {
        int currentHealth;
        //This code finds the Player2Health text and converts it into a int
        bool EnemyHealthIsNumber = int.TryParse(GameObject.Find("Player2Health").GetComponent<Text>().text, out currentHealth);

        if (EnemyHealthIsNumber) 
        {
            // This detects if Player2Health is 0
            if (currentHealth <= 0)
            {
                //loads the WinnerPlayer1 Scene
                SceneManager.LoadScene(2);
            }
        }
             
    }
}
