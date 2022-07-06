﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Dropdown))]
public class DropDownForLanguages : MonoBehaviour
{ 
    
    public static int nubmerL;

    public static int value;
    const string PrefName = "optionvalue";

    public Dropdown _dropdown;


    void Awake()
    {
        _dropdown = GetComponent<Dropdown>();

        _dropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(PrefName );
    }

 
}