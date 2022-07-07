using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //will likely contain instructions to update a UI element on CurrentHealth of object
        if(CurrentHealth==0)
        {
            ObjectDestroyed();
        }
    }

    public void isAttacked(int dmg)
    {
        CurrentHealth-= dmg;
        
        //Debugging purposes
        print("current health = " + CurrentHealth);
    }

    public void ObjectDestroyed()
    {
        print("this object has been destroyed!");
    }
}
