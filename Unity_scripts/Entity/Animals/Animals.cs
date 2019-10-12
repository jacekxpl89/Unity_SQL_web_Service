using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Animal_Wild
{
    normal,wild
}
public abstract class Animals : Entity
{
    public float A_speed;
    public Animal_Wild A_wild;
    public override void Give_attributes(GameObject temp)
    {
      
        GameObject build = Instantiate(temp.GetComponent<Animals>().E_gameobject, temp.transform);
        build.GetComponent<BoxCollider>().isTrigger = true;
        build.transform.position = new Vector3(temp.transform.position.x, 0, temp.transform.position.z);
      
      
    }

    public override void Give_class_params(object e1, object e2)
    {
        Animals o1 = (Animals)e1;
        Animals o2 = (Animals)e2;

        o2.A_speed = o1.A_speed;
        o2.A_wild = o1.A_wild;
    }

   

    
  

}
