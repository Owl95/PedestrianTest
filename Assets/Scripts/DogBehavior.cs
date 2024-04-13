using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : PedestrianBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        showtext.text = "Dog : Patroling";
        runing = playing(_targetLocation);
        StartCoroutine(runing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
