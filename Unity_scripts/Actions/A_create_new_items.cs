using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  A_create_new_item  : Acction
{
    public Animator animator;
    Data_player_building data_building;
    int itemId;

    public A_create_new_item(Data_player_building data_building, int itemId) : base(null,null)
    {
        this.data_building = data_building;
        this.itemId = itemId;
        
    }
    public async void Send_product()
    {
      
        Data_item_stack item_stac = new Data_item_stack() { Amount = 1, Id_item = itemId, Id_list = data_building.Id_list };
        await SQL_Manager.Insert<Data_item_stack>("Item_stack",item_stac);
        done = true;

    }
    public override IEnumerator Start_acction()
    {
        done = false;
        Send_product();
        yield return null;
    }

}
