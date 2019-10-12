using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnityType
{
    Building,Unit,Monster,other
}
public abstract class Entity : Observer 
{
    public int E_id;
    public string E_name;
    public float E_hp;
    public float E_maxhp;
    public int E_attack;
    public float E_range;
    public int E_model_Id;
    public string E_folder;
    public EnityType E_type;
    public Sprite E_Sprite;
    public GameObject E_gameobject;
    public List<Acction> U_acctionsqueue = new List<Acction>();
    public bool Is_acction = false;


    public void Add_observable(Observalbe o)
    {
        Add_new_observable(o);
    }
    public void Refresh_observable(object o)
    {
        Refresh(o);
    }
    public void Add_action(Acction acction)
    {
        U_acctionsqueue.Add(acction);
    }
    public void Start_actions()
    {
        if (!Is_acction)
        {
            StartCoroutine(Start_actions(1));
        }
    }
    private IEnumerator Start_actions(int b)
    {
        Is_acction = true;
        List<Acction> acction = new List<Acction>();
        foreach (var a in U_acctionsqueue)
        {
            acction.Add(a);
        }
        U_acctionsqueue.Clear();
        foreach (Acction a in acction)
        {
            StartCoroutine(a.Start_acction());
            while (!a.done)
            {
                yield return new WaitForSeconds(0.01f);
            }
        }
        Is_acction = false;
        if (U_acctionsqueue.Count != 0)
        {
            StartCoroutine(Start_actions(0));
        }
    }
    public void Give_parameter(Entity e1 , Entity e2)
    {
        e2.E_id = e1.E_id;
        e2.E_name = e1.E_name;
        e2.E_hp = e1.E_hp;
        e2.E_maxhp = e1.E_maxhp;
        e2.E_attack = e1.E_attack;
        e2.E_model_Id = e1.E_model_Id;
        e2.E_range = e1.E_range;
        e2.E_type = e1.E_type;
        e2.E_folder = e1.E_folder;
        //e2.E_Sprite = Resources.Load<Sprite>(e2.E_folder + "/img");

        e2.E_gameobject = Resources.Load<GameObject>(e2.E_folder + "/"+e2.E_model_Id);
    }



    public abstract void Give_class_params(object e1, object e2);
    public abstract void Add_class_attributes(GameObject temp);
    public abstract void Load_params();
    public abstract void Give_attributes(GameObject temp);
    protected  GameObject Get_Instance<T>(Vector3 poz) where T : Entity
    {
        GameObject temp = new GameObject(E_name);
        temp.AddComponent<T>();
        Give_parameter(this, temp.GetComponent<T>());
        Give_class_params(this, temp.GetComponent<T>());
        Give_attributes(temp);
        Add_class_attributes(temp);
        temp.transform.position = poz;
        return temp;
    }
    public abstract GameObject Get_new_object(Vector3 poz);
    public abstract GameObject Get_new_objectSQL(object dataA,object dataB);


}
