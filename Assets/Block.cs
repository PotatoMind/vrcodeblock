using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Block<T>
{
    T execute();
}