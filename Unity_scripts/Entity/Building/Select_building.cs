using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_building : MonoBehaviour
{

    public bool Put;
    public int ObjCount;
    public Renderer rend;

    public void Start()
    {
        rend = this.GetComponent<Renderer>();
        ObjCount = 0;
    }
    private void FixedUpdate()
    {
       
        if (ObjCount > 0)
        {
            rend.material.color = Color.red;
            Put = false;

        }
        else
        {
            Put = true;
            rend.material.color = Color.green;
        }

    }
    public void set_color(Color c)
    {
        rend.material.color = c;
    }
    private void OnDestroy()
    {
        set_color(Color.white);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObjCount++;
    }
    private void OnCollisionExit(Collision collision)
    {
        ObjCount--;
    }



}
