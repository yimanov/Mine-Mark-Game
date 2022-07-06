using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownExample : MonoBehaviour
{

    List<string> names = new List<string>() { "Azərbaycanca", "English", "український", "bosanski" };

    public Dropdown dropdown;
    public Text selectedName;
   

    private void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }



}