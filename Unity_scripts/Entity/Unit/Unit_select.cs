using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_select : MonoBehaviour
{
    public List<GameObject> U_selected = new List<GameObject>();
    public Vector3 U_poz;
    public Acction U_action;
    public Main main;
    public bool Active;

    private void Start()
    {
        main = this.GetComponent<Main>();
        Active = true;
    }

    bool isSelecting = false;
    Vector3 mousePosition1;

    void Update()
    {
        #region select
        if (Input.GetMouseButtonDown(0) && Active)
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
       
        if (Input.GetMouseButtonUp(0))
        {

            U_selected.Clear();
            foreach (var g in Main.Objects)
            {

                if (IsWithinSelectionBounds(g))
                {
                    U_selected.Add(g);
                    g.GetComponent<Selector>().Show(true);
                }
                else
                {
                    try
                    {
                        g.GetComponent<Selector>().Show(false);
                    }
                    catch { }
                  
                }
            }
            isSelecting = false;
        }
        #endregion
        #region move
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 mouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point);
                U_poz = new Vector3(hit.point.x, 0, hit.point.z);
            }

            foreach(var g in U_selected)
            {
                Unit unit = g.GetComponent<Unit>();
             //   unit.U_action = new Walk(U_poz);
            }


        }
        #endregion


    }
    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!isSelecting)
            return false;
        if (gameObject.GetComponent<Entity>().E_type != EnityType.Unit)
            return false;

        var camera = Camera.main;
        var viewportBounds =
           Select_fun.GetViewportBounds(camera, mousePosition1, Input.mousePosition);

        return viewportBounds.Contains(
            camera.WorldToViewportPoint(gameObject.transform.GetChild(0).transform.position));
    }


    void OnGUI()
    {
        if (isSelecting)
        {
          
            var rect =Select_fun.GetScreenRect(mousePosition1, Input.mousePosition);
            Select_fun.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Select_fun.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }


  

}
