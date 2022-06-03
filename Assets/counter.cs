using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class counter : MonoBehaviour
{
    public TMP_Text counterText;
    // Update is called once per frame
    void Update()
    {
        counterText.text = DateTime.Now.ToString();
    }
}
