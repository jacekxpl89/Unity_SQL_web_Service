using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_place : Acction
{
    public Animator animator;
    public Select_building select;
    public A_place(GameObject go) : base(go,null)
    {
        A_obj = go;
      
    }
    public override IEnumerator Start_acction()
    {
        done = false;
        if (A_obj == null)
        {
            yield break;
        }
        select= A_obj.transform.GetChild(0).gameObject.AddComponent<Select_building>();
        while (!done)
        {
            Move_obj();
            yield return new WaitForFixedUpdate();
        }
      
        done = true;
    }
    int LastPozX, LastPozY, LastPozZ;
    public void Move_obj()
    {
        if(A_obj)
        {
            Vector3 mouse_poz = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse_poz);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,3))
            {
                int PozX = (int)Mathf.Round(hit.point.x);
                int PozZ = (int)Mathf.Round(hit.point.z);

                if (PozX != LastPozX || PozZ != LastPozZ)
                {
                    LastPozZ = PozZ;
                    LastPozX = PozX;
                    A_obj.transform.position = new Vector3(hit.point.x, .5f, hit.point.z);
                }

            }


                if(Input.GetMouseButton(0) && select.Put)
                {
                 Destroy(select);
                 done = true;
                }
                if (Input.GetMouseButtonDown(1))
                {
                Destroy(A_obj.gameObject);
                }
            
        }
     

    }

}