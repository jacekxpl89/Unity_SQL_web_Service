using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{

    public List<Observalbe> observable = new List<Observalbe>();

    public void Start()
    {
        observable = new List<Observalbe>();
    }
    public void remove_observable(Observalbe o)
    {
        observable.Remove(o);  
    }
    public void Add_new_observable(Observalbe o)
    {
        observable.Add(o);
    }
    public void Refresh(object o)
    {
        foreach(var ob in observable)
        {

            ob.Refresh(o);
           
          
        }
    }
}
public  abstract class Observalbe :MonoBehaviour
{
   
    public abstract void Refresh(object o);

}
