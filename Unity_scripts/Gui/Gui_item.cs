using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;

public delegate void Click_Fun();
public class Gui_item : Entity
{
    public int Id;
    public Data_item_stack data_item_stack;
    public Data_item data_item;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI amount;
    public Button Button;
    public Image Img;

    Click_Fun function;


    public async void Start()
    {
        Button = transform.GetChild(0).GetComponent<Button>();
        Img = transform.GetChild(1).GetComponent<Image>();
        Price = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        Name = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        amount = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        Img.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);
        
    }

    public async void Refresh(int itemId) //wczytuje item z podanego id
    {

          data_item = await SQL_Manager.Select<Data_item>("Item", itemId);
         Name.text = data_item.Name;
         Price.text = data_item.Cost.ToString() + "$";
        amount.text = data_item_stack.Amount.ToString();
      
    }

    public override void Load_params()
    {
        throw new System.NotImplementedException();
    }



    public override GameObject Get_new_object(Vector3 poz)
    {
        GameObject new_item = Resources.Load<GameObject>("GUI/Item");
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
        GameObject new_item = Resources.Load<GameObject>("GUI/Item");
        GameObject temp = Instantiate(new_item);
        Gui_item item = temp.GetComponent<Gui_item>();
        Data_item_stack Is = (Data_item_stack)dataA;
        Data_item I = (Data_item)dataB;
        item.data_item_stack = Is;
        item.data_item = I;
        item.Start();
        item.Refresh(Is.Id_item);
        return temp;
    }
}
