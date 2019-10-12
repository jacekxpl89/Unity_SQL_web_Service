using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Unit_type
{
    settler,solider,builder,vechicle
}
public abstract class Unit : Entity
{
    public float U_speed;
    public Transform U_target;
    public Unit_type U_type;
  
   

  
    public override void Give_class_params(object e1, object e2)
    {
        Unit o1 = (Unit)e1;
        Unit o2 = (Unit)e2;

        o2.U_type = o1.U_type;
        o2.U_speed = o1.U_speed;
        o2.U_acctionsqueue = new List<Acction>();
        o2.U_target = null;
    }

    public override void Give_attributes(GameObject temp)
    {

   
       GameObject solider = Instantiate(temp.GetComponent<Unit>().E_gameobject, temp.transform);
       solider.AddComponent<Projector>();

        temp.AddComponent<Selector>();
        temp.GetComponent<Selector>().Set_Selector(solider);
    }


  
    public void Find_target(string type)
    {
        if (!U_target)
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, 10, 1);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == type)
                {
                    U_target = targets[i].transform;
                }
            }
        }
    }

}
