using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnap : MonoBehaviour
{
    public float mult = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, Vector3.left * 100, Color.red);

        //only if we hit something
        if (Physics.Raycast(transform.position, Vector3.left, out hit, mult))
        {
            //if we hit a block from the left 
            if (hit.transform.CompareTag("Block"))
            {
                hit.transform.position = transform.position + Vector3.left * mult;
                
            }
        }
        
        //if we hit a block from the right 
        if (Physics.Raycast(transform.position, Vector3.right, out hit, mult))
        {
            //if we hit a block
            if (hit.transform.CompareTag("Block"))
            {
                hit.transform.position = transform.position + Vector3.right * mult;
                
            }
        }

        //if we hit a block from the top 
        if (Physics.Raycast(transform.position, Vector3.up, out hit, mult))
        {
            //if we hit a block
            if (hit.transform.CompareTag("Block"))
            {
                hit.transform.position = transform.position + Vector3.up * mult;
                
            }
        }

        //if we hit a block from the bottom 
        if (Physics.Raycast(transform.position, Vector3.down, out hit, mult))
        {
            //if we hit a block
            if (hit.transform.CompareTag("Block"))
            {
                hit.transform.position = transform.position + Vector3.down * mult;
                
            }
        }
    }
}
