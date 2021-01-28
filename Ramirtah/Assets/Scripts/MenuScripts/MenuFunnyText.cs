using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunnyText : MonoBehaviour
{
    public Text funText;
    public Text responseText;
    public static string menuStringText;

    private void Start()
    {
        RetrieveDatabase();
    }

    private void RetrieveDatabase()
    {
        int key = Random.Range(1, 4);

        Debug.Log("before get");
        RestClient.Get("https://ramitah-d1f8a-default-rtdb.firebaseio.com/Data/" + key.ToString()  + ".json").Then(response =>
        {
            Data texas = new Data();
            texas = JsonUtility.FromJson<Data>(response.Text);
            Debug.Log(texas.stringFunText);
            
            funText.text = texas.stringFunText.ToString();

        }).Catch(err => Debug.Log(err.Message));
    }
}


