using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Text WinnerText;

    // Start is called before the first frame update
    void Update()
    {
        int currentHealth;
        //This code finds the Player1Health text and converts it into a int
        bool EnemyHealthIsNumber = int.TryParse(GameObject.Find("Player1Health").GetComponent<Text>().text, out currentHealth);

        if (EnemyHealthIsNumber)
        {
            //This detects if Player1Health is 0
            if (currentHealth <= 0)
            {
                //loads the WinnerPlayer2 Scene
                SceneManager.LoadScene(3);
            }
        }

    }
}
