using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControl : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.State myState;

    // Start is called before the first frame update
    void Start()
    {
       myState.SetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
