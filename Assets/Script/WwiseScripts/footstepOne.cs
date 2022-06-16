using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepOne : MonoBehaviour
{
    public GameObject player;
    void step()
    {
        AkSoundEngine.PostEvent("step1", player); //must include specfic name of even
    }

    void step2()
    {
        AkSoundEngine.PostEvent("step2", player); //must include specfic name of even
    }
}
