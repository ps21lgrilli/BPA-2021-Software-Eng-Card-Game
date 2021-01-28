using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunnyText : MonoBehaviour
{
    //Variables for this script
    public Text funText;
    public Text responseText;
    public static string menuStringText;

    private void Start()
    {
        RetrieveDatabase();
    }

    private void RetrieveDatabase()
        //Code to retrieve from database
    {
        int key = Random.Range(1, 10);
        //Requsting where to get the data
        RestClient.Get("https://ramitah-d1f8a-default-rtdb.firebaseio.com/Data/" + key.ToString()  + ".json").Then(response =>
        {
            Data texas = new Data();
            texas = JsonUtility.FromJson<Data>(response.Text);
            Debug.Log(texas.stringFunText);
            //Where to put the data
            funText.text = texas.stringFunText.ToString();

        }).Catch(err => Debug.Log(err.Message));
    }
}


