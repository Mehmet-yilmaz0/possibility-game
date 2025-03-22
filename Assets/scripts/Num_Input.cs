using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num_Input : MonoBehaviour
{
    public Number num100;
    public Number num20;
    public Number num3;

    private int value;
    // Start is called before the first frame update
    void Start()
    {
        value = 100*(num100.WhichAmI())+10*(num20.WhichAmI())+1*(num3.WhichAmI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void build()
    {

    }
    public void add()
    {

    }
}
