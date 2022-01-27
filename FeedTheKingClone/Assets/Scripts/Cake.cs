using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public static Cake CurrentCake { get; private set; }
    // Start is called before the first frame update
    void OnEnable()
    {
        CurrentCake = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
