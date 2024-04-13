using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class PedestrianBehavior : MonoBehaviour
{
    public NavMeshAgent _agent;
    public TMP_Text showtext;
    public GameObject _targetLocation;
    protected IEnumerator runing;
    // Start is called before the first frame update
    void Start()
    {
        showtext.text = "Pedestrain : Moving";
        runing = playing(_targetLocation);
        StartCoroutine(runing);
    }
    public void Panic()
    {
        showtext.text = "Pedestrain : Panic";
        StopCoroutine(runing);
        runing = panic();
        StartCoroutine(runing);
    }
    protected IEnumerator panic()
    {

        PedestrainWaypoint[] allWayPoint = FindObjectsOfType<PedestrainWaypoint>();
        PedestrainWaypoint largest = allWayPoint[0];
        for (int i = 0; i < allWayPoint.Length; i++)
        {
            if (Vector3.Distance(largest.transform.position, transform.position)> Vector3.Distance(allWayPoint[i].transform.position, transform.position)) 
            {
                largest = allWayPoint[i];
          
            }
        }
    
        _agent.SetDestination(largest.transform.position);
        yield return new WaitForSeconds(3);
        showtext.text = "Pedestrain : Moving";
        _targetLocation = _targetLocation.GetComponent<PedestrainWaypoint>()._nextWaypoint;
        runing = playing(_targetLocation);
        StartCoroutine(runing);
    }
    protected IEnumerator playing(GameObject targetLocation)
    {

     
        _agent.SetDestination(_targetLocation.transform.position);
    
        while (Vector3.Distance(_targetLocation.transform.position,transform.position)>=1f)
        {
          
            yield return new WaitForSeconds(1);
        }

        _targetLocation = targetLocation.GetComponent<PedestrainWaypoint>()._nextWaypoint;

        StartCoroutine(playing(_targetLocation));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
