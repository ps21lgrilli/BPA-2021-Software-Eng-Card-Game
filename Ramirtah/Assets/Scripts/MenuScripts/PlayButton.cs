using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void LoadScene()
    {
        //Loads the Ramirtah Scene
        SceneManager.LoadScene(1); 
    }
}
