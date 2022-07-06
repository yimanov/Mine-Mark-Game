using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public int levelNum;

	void Awake()
	{
      
        Camera.main.aspect = 16/10f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	private float life = 1.5f;

	void Update ()
	{
		life -= Time.deltaTime;

		Color c = GetComponent<Renderer>().material.GetColor("_Color");
		GetComponent<Renderer>().material.SetColor("_Color", new Color(c.r, c.g, c.g, life));

		if (life < 0)
		{
			SceneManager.LoadScene(levelNum);
		}
	}
}
