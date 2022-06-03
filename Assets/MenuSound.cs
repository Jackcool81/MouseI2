using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    void Start()
    {
        //AkSoundEngine.PostEvent("Menu_Music_Playlist", gameObject); //must include specfic name of even
        //AkSoundEngine.SetState("Menu_Music", "GameStart");
        //AkSoundEngine.PostEvent("Game_Start", gameObject);
        //AkSoundEngine.PostEvent("Music_On", gameObject);
    }
    public void MenuHover()
    {
        AkSoundEngine.PostEvent("menu_hover", gameObject); //must include specfic name of even
    }

    public void MenuSelect()
    {
        AkSoundEngine.PostEvent("menu_select", gameObject); //must include specfic name of even
    }

    public void StartGame()
    {
        AkSoundEngine.SetState("FightMusic", "Fighting_music"); //must include specfic name of even
    }

    public void RestartGame()
    {
        AkSoundEngine.PostEvent("StopRetry", gameObject); //must include specfic name of even
        AkSoundEngine.SetState("Menu_Music", "GameStart"); //must include specfic name of even

    }

}
