using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using UnityEngine.UI;
 
public class DropDownExample1 : MonoBehaviour
{


    public   Dropdown _dropdown;
    const string PrefName = "optionvalue";
    public static int value1;


    IEnumerator   Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        var options = new List<Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new Dropdown.OptionData(locale.name));
        }
        _dropdown.options = options;

        _dropdown.value = selected;
        value1 = _dropdown.value;
        _dropdown.onValueChanged.AddListener(LocaleSelected);
       
    }


    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
       
    }

 
    }

    
 