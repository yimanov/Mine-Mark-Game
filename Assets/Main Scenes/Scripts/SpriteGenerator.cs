using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGenerator : MonoBehaviour
{


    private int rand;
    float x;
    float y;
    float z;
    Vector3 pos;
    public GameObject object1;

    public Sprite[] Sprite_Pic;

    public Image imageContainer;

    // Start is called before the first frame update
    void Start()
    {



         

        rand = Random.Range(0, Sprite_Pic.Length);
       
      
        imageContainer.sprite = Sprite_Pic[rand];




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
