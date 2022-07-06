using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCurrentScene : MonoBehaviour
{

    public string scenno;
    public int time;

    public void Start()
    {



    }
    private IEnumerator Countdown2()
    {


        yield return new WaitForSeconds(time);


        SceneManager.LoadScene(scenno);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void changeGO()
    {
        StartCoroutine(Countdown2());

    }


}
