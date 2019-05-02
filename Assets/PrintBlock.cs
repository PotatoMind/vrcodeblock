using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintBlock : MonoBehaviour, Block<string>
{
    public string execute()
    {
        return "Hello World";
    }
}
