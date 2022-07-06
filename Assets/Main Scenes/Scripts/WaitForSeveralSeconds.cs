using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSeveralSeconds : MonoBehaviour
{
    public GameObject objecto;
    public GameObject objecto1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    



    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeItSeen()
    {
        objecto1.SetActive(false);
        objecto.SetActive(true);

    }
}
