using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    int ID = 1;

    public void ChangeID(int option)
    {
        this.ID = option+1;
    }

    public void PlayGame()
    {
        if(ID!=0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + ID);
    }

    public void QuitGame()
    {
        Debug.Log("Gra wylaczona");
        Application.Quit();
    }

}
