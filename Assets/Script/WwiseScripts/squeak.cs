using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squeak : MonoBehaviour
{
    void squeak1()
    {
        AkSoundEngine.PostEvent("squeak1", gameObject); //must include specfic name of event

    }
    void squeak2()
    {
        AkSoundEngine.PostEvent("squeak2", gameObject); //must include specfic name of event

    }
    void squeak3()
    {
        AkSoundEngine.PostEvent("squeak3", gameObject); //must include specfic name of event

    }
}
