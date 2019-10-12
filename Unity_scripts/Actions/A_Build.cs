using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Build : Acction
{
    public Animator animator;

    public A_Build(GameObject go, object time) : base(go, time)
    {
        A_obj = go;
        B_obj = time;
       
    }
    public override IEnumerator Start_acction()
    {
        done = false;
        if (B_obj == null || A_obj==null)
        {
            yield break;
        }
       
         GameObject bar_gui = Resources.Load<GameObject>("Gui/Gui_bar");
         GameObject temp= Instantiate(bar_gui, A_obj.transform);
         Gui_bar gui = temp.GetComponent<Gui_bar>();
         
        float time = 0;
        float timeend = (float)B_obj;
        while (time < timeend)
        {
            time += 0.01f;
            gui.Refresh(time / timeend);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(temp);
        done = true;
    }

}
