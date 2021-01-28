using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadScene()
    {
        //Loads the menu Scene
        SceneManager.LoadScene(0); 
    }
}
