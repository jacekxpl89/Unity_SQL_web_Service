using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_load_bar : Acction
{
    public Animator animator;

    public A_load_bar(GameObject go, object time) : base(go, time)
    {
        A_obj = go;
        B_obj = time;
      

    }
    public override IEnumerator Start_acction()
    {
        done = false;
        
        if (B_obj == null || A_obj == null)
        {
           
            yield break;
        }
     
        Gui_bar gui = Instantiate(Resources.Load<GameObject>("Gui/Gui_bar").GetComponent<Gui_bar>(), A_obj.transform.GetChild(0).transform);

        float time = 0;
        float timeend = (float)B_obj;
        while (time < timeend)
        {
            time += 0.01f;
            gui.Refresh(time / timeend);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gui.gameObject);
        yield return new WaitForSeconds(0.5f);
     
        done = true;
    }

}
