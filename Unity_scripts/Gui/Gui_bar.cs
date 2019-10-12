using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Gui_bar : MonoBehaviour
{

    public Image Progress;
    public TextMeshProUGUI text;
   public void Start()
    {
        Progress = transform.GetChild(1).GetComponent<Image>();
        text = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Set_position();
    }

   public void Set_position() //ustawia pasek na obiektem w grze
    {
        if(transform.parent.GetComponent<BoxCollider>())
        {
            Vector3 parent_poz = transform.parent.transform.position;
            float y = transform.parent.GetComponent<BoxCollider>().bounds.size.y;
            transform.position = parent_poz + new Vector3(0, y * 2, 0);
        }
     
    }
    void Set_Color(Color c)
    {
        Progress.color = c;
    }
   public void Refresh(float i) //obraca pasek by był tak samo ustawiony do kamery
    {
        if(Progress!=null && text != null)
        {
             this.transform.eulerAngles = Camera.main.transform.eulerAngles;
             Progress.fillAmount = i;
             text.text = (Mathf.RoundToInt(i*100)).ToString() + "%";
        }

    }
}
