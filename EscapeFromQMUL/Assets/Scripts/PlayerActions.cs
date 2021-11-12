using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject attackUI,closeNPC;
    private bool canAttack=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        attackUI.GetComponent<MeshRenderer>().enabled = false;
        canAttack = false;
        Destroy(closeNPC);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            closeNPC = other.gameObject.transform.parent.gameObject;
           attackUI.GetComponent<MeshRenderer>().enabled = true;
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.CompareTag("NPC"))
        {
            attackUI.GetComponent<MeshRenderer>().enabled = false;
            canAttack = false;
        }
    }

   
}
