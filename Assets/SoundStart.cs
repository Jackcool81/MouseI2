using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("testFire", gameObject); //must include specfic name of even
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
