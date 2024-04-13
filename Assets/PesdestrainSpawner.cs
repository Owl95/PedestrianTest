using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesdestrainSpawner : MonoBehaviour
{
    public GameObject _pedestrain;
    public GameObject firstWayPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject a = Instantiate(_pedestrain);
            a.GetComponent<PedestrianBehavior>()._targetLocation = firstWayPoint;
            a.transform.position = transform.position;
        }
    }
}
