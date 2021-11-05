using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform[] targets;
    public GameObject vision;
    public float speed = 1;
    public int i=0,j=0;
   public  bool playerNotFound;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in targets)
            i++;
        playerNotFound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNotFound)
        logicNpc();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerNotFound = false;
            Debug.LogWarning(playerNotFound);
            
        }
    }

    void logicNpc()
    {
        float step = speed * Time.deltaTime;
        if(j<i)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[j].position, step);     
        }        

        if (Vector3.Distance(transform.position, targets[j].position) < 2)
        {
            j++;            
        }
        if (j == i)
            j = 0;
        transform.LookAt(targets[j].position);
    }
}
