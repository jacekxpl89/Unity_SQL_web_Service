using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;


public class Gui_building_icon : Entity
{
    public int Id;
    public Data_building Data;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public Button Button;
    public Image Img;

    Click_Fun function;


    public async void Start()
    {
        Button = transform.GetChild(0).GetComponent<Button>();
        Img = transform.GetChild(1).GetComponent<Image>();
        Price = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Name = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        Img.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);

        Name.text = Data.Name;
        Price.text = Data.Cost.ToString() + " $";

       
         
    }



    public override void Load_params()
    {
        throw new System.NotImplementedException();
    }



    public override GameObject Get_new_object(Vector3 poz)
    {
        GameObject new_item = Resources.Load<GameObject>("GUI/Building_icon");
        GameObject temp = Instantiate(new_item);
        return temp;
    }

    public override void Give_class_params(object e1, object e2)
    {

    }

    public override void Add_class_attributes(GameObject temp)
    {

    }

    public override void Give_attributes(GameObject temp)
    {

    }




    public override GameObject Get_new_objectSQL(object dataA, object dataB)
    {
        GameObject new_item = Resources.Load<GameObject>("GUI/Building_icon");
        GameObject temp = Instantiate(new_item);
        Gui_building_icon item = temp.GetComponent<Gui_building_icon>();
        Data_building data = (Data_building)dataA;
        item.Data = data;
        item.Start();
        return temp;
    }
}
