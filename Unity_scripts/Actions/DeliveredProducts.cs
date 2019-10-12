using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveredProducts : Acction
{

    int height = 40;
   public DeliveredProducts(GameObject g1 ,object g2) :base(g1,g2)
    {
        A_obj = g1;
        B_obj = g2;
       
    }
    public override IEnumerator Start_acction()
    {
        done = false;
        Vector3 start_poz = A_obj.transform.position;
        Vector3 end_poz = A_obj.transform.position + new Vector3(0, height, 0);
        GameObject wood_box = Resources.Load<GameObject>("extra/box");
        wood_box.transform.localScale = new Vector3(90, 90, 90);
        for (int i=0;i<(int)B_obj;i++)
        {
            GameObject temp = Instantiate(wood_box);
            temp.transform.position = start_poz;

         
         
            while (temp.transform.position.y <end_poz.y)
            {

                temp.transform.position= Vector3.MoveTowards(temp.transform.position, end_poz, 0.5f);
                yield return new WaitForFixedUpdate();
            }
            Destroy(temp);
        }
        done = true;
    }
}
