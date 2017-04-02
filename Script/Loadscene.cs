using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loadscene : MonoBehaviour {
    
	public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goShcool()
    {
        SceneManager.LoadScene("Game_Shcool");
    }
    public void goRoom()
    {
        SceneManager.LoadScene("Game_room");

    }
    public void goAttribute()
    {
        SceneManager.LoadScene("Attribute_ch");
    }
    public void goResultAndCareerPath()
    {
        SceneManager.LoadScene("ResultAndCareerPath");
    }

}

