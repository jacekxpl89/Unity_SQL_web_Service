using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CursorState
{
    Build, Rotate
}
public class Mouse_Manager : MonoBehaviour
{
    public Transform Obj_to_move;
    Vector3 mouse_poz;
    Vector3 click_poz;
    public LayerMask mask;
    int LastPozX, LastPozY, LastPozZ;
   

    CursorState state;
  
   
    private void Start()
    {
     
        Obj_to_move = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        Obj_to_move.gameObject.layer = 9;
        Destroy(Obj_to_move.GetComponent<BoxCollider>());
     
    }

    private void FixedUpdate()
{
        mouse_poz = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouse_poz);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            int PozX = (int)Mathf.Round(hit.point.x);
            int PozZ = (int)Mathf.Round(hit.point.z);

            if (PozX != LastPozX || PozZ != LastPozZ)
            {
                LastPozZ = PozZ;
                LastPozX = PozX;
               
                    Obj_to_move.position = new Vector3(PozX, .5f, PozZ);
            }
            
        }

     
      

    }


  

}
