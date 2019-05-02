using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
    public void run()
    {
        Debug.Log("Potato");
        string test = "";
        foreach(GameObject printBlock in GameObject.FindGameObjectsWithTag("Block"))
        {
            PrintBlock other = (PrintBlock) printBlock.GetComponent(typeof(PrintBlock));
            test = test + other.execute() + "\r\n";
        }
        Debug.Log(test);

        GameObject.Find("run_text").GetComponent<Text>().text = test;
    }

    void OnMouseDown()
    {
        run();
    }
}