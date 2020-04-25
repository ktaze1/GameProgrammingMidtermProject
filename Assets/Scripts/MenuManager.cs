using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load(int index)
    {
        SceneManager.LoadScene(index);   
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
