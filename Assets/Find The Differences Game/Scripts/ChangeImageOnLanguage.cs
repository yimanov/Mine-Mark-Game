using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class ChangeImageOnLanguage : MonoBehaviour
{

    private List<string> languages;

    public static int indexit;
    private Text languageText;
    Image m_Image;
    public Sprite m_Sprite;
    // Start is called before the first frame update
    void Start()
    {
       
        if (DropDownExample1.value1==3)
        {
            m_Image = GetComponent<Image>();
            m_Image.sprite = m_Sprite;

        }

        else
        {
            GetComponent<Image>().sprite = GetComponent<Image>().sprite;

        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
