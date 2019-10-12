using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate IEnumerator E_acctions(GameObject go, object o);
public abstract class Acction : MonoBehaviour
{
    public Animator animator;
    public GameObject A_obj;
    public object B_obj;
    private Acction acction;
    public bool done;

    public Acction(GameObject go, object o)
    {
        A_obj = go;
        B_obj = o;
    }


    public abstract IEnumerator Start_acction();
}
public class Empty_acction : Acction
{


    public Empty_acction(GameObject go, object o) : base(go,o)
    {
        A_obj = go;
        B_obj = o;
    }
    public override IEnumerator Start_acction()
    {
       
        animator = A_obj.GetComponent<Animator>();
        animator.SetTrigger("empty");
        yield return null;
    }

  
}