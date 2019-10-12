using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{


    GameObject selector;
    Transform solider;
    float height;
    float max_hp;
    public void Show(bool t)
    {
        if(t)
        {
            selector.SetActive(true);
            return;
        }
        selector.SetActive(false);
    }

    public void Set_Selector(GameObject unit)
    {
        selector = GameObject.CreatePrimitive(PrimitiveType.Cube);
        selector.transform.parent = unit.transform.parent.transform;
        height = unit.transform.position.y + unit.GetComponent<BoxCollider>().bounds.size.y;
        selector.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        selector.GetComponent<Renderer>().material.color = Color.green;
        max_hp = unit.transform.parent.GetComponent<Unit>().E_maxhp;
     
        solider = unit.transform;
        Show(false);
    }
    public void Update()
    {
       
        selector.transform.position = new Vector3(solider.position.x, height, solider.transform.position.z);
        float hp = solider.parent.GetComponent<Unit>().E_hp;
         
        selector.GetComponent<Renderer>().material.color = new Color(0,hp/max_hp,0);
    }

}
