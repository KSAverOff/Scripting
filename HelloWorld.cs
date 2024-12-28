using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    int x = 2;
    int y = 2;
    void Update()
    {
        if (x == y)
        {
            print("Успех");
        }
    }
}
