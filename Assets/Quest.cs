using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string QuestTitle;
    public string QuestDescription;
    public bool QuestCompletion;
    //maybe reward the player when done?
    public void Complete()
    {
        isActive = false;
    }
}
