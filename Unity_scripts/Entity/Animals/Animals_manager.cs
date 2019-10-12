using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals_manager : MonoBehaviour
{
    public List<Animals> Animals = new List<Animals>();
    public List<Animals> game_Animals = new List<Animals>();

    public Animals_manager()
    {
        Load();
    }
    public void Load()
    {
        Animals.Add(new Bird());
    }

}
