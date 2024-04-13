using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStaminaBehavior : DogBehavior
{
    float _stamina;

    IEnumerator deductStamina()
    {
        _stamina = 10;
 
        while(_stamina>0)
        {
            _stamina -= Time.deltaTime;
            
            showtext.text = "StaminaDog : Patroling \n Stamina : " + Mathf.Round(_stamina) + "/10";
            yield return 0;
        }
        _stamina = 0;
        StopCoroutine(runing);
        _agent.isStopped = true;
        yield return new WaitForSeconds(3);
        _agent.isStopped = false;
        StartCoroutine(deductStamina());
    }
    // Start is called before the first frame update
    void Start()
    {
        showtext.text = "StaminaDog : Patroling \n Stamina : "+ _stamina+"/10";
        runing = playing(_targetLocation);
        StartCoroutine(runing);
        StartCoroutine(deductStamina());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
