using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Acction
{


    public Animator animator;
    public string a_name;
    public float a_speed;
    public Vector3 a_goal;
 
    public Walk(GameObject go, object o,Vector3 aim) : base(go, o)
    {
        A_obj = go;
        B_obj = o;
        a_goal = aim;
    }

    public override IEnumerator Start_acction()
    {
        done = false;
        Vector3 poz = a_goal;
        if(B_obj !=null)
          {
            A_obj.transform.position = (Vector3)B_obj;
        }
      
        A_obj.transform.LookAt(poz);
        A_obj.transform.localEulerAngles += new Vector3(0, 180, 0);
        a_speed = 50;
       
      
        while(!done)
        {
            Vector3 walk_poz = Vector3.MoveTowards(A_obj.transform.position, poz, 0.01f * a_speed);

            A_obj.transform.position = new Vector3(walk_poz.x, 0, walk_poz.z);
            done = A_obj.transform.position.Equals(new Vector3(poz.x, 0, poz.z));

            yield return new WaitForFixedUpdate();
           
        }
      

    }
}