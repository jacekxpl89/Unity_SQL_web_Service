using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_delete :Acction
{


    public A_delete(GameObject obj,object time) : base(obj, time)
    {

        A_obj = obj;
        B_obj = time;
    }
    public override IEnumerator Start_acction()
    {
        Destroy(A_obj, (float)B_obj);
        done = true;
        yield return null;
    }
}

