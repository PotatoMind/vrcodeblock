using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; 
    private Color originalColor = Color.red;
    private bool spawn; 
    private string name; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        name =  GetComponent<Renderer>().name; 
        Debug.Log(name);
        spawn = true; 
    }
 
    void OnMouseUp()
    {
        GetComponent<Renderer>().material.color = originalColor;
        spawn = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(spawn){
            GameObject new_obj = (GameObject) Instantiate(prefab); 
            Debug.Log(new_obj);
            new_obj.transform.position = new Vector3(90,200,60);
        }
    }

   
}
