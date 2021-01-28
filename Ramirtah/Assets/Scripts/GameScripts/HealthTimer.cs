using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTimer : MonoBehaviour
{
    public MathVariable mv;
    // Start is called before the first frame update
    void Start()
    {

        int myCardHealth;

        //This code converts the Health text into a int then subtracts it by 1
        bool myCardHealthIsNumber = int.TryParse(gameObject.transform.Find("Health").GetComponent<Text>().text, out myCardHealth);
        myCardHealth = myCardHealth - 1;
        //This code gets the number that was recently subtracted and converts it back into a string and replace the Health text
        gameObject.transform.Find("Health").GetComponent<Text>().text = myCardHealth.ToString();

    }
}