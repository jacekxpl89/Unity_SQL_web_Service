using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Deliver : Acction
{
    public Animator animator;

    public A_Deliver(GameObject car,GameObject companya, GameObject companyb, int products) : base(null,null)
    {
       
        Car c = car.GetComponent<Car>();
        GameObject car_model = car.transform.GetChild(0).gameObject;
     
            Vector3 poz1 = new Vector3(companya.transform.position.x, 0, companya.transform.position.z);
            Vector3 poz2 = new Vector3(companyb.transform.position.x, 0, companyb.transform.position.z);
       
            c.Add_action(new Walk(car_model, poz1, poz2));
            c.Add_action(new DeliveredProducts(companyb, products));
            c.Add_action(new Walk(car_model, poz2, poz1));
            c.Start_actions();




     
      
    }
    public override IEnumerator Start_acction()
    {
        done = true;
        yield return null;
    }

}
