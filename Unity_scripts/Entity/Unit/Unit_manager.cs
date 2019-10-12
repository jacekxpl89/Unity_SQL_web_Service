using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_manager : MonoBehaviour
{
    public List<Unit> units = new List<Unit>();
  
   public Unit_manager()
    {
       Load();
    }
    public void Load()
    {
        units.Add(new Solider());
       
    }
}
