using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class step : MonoBehaviour
{
    void step1()
    {
        AkSoundEngine.PostEvent("cat_step", gameObject); //must include specfic name of event

    }
}
