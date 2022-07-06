using UnityEngine;

public class CameraAspect1 : MonoBehaviour
{
    public GameObject Music;
    

	void Awake ()
    {
        
        Camera.main.aspect = 16 / 10f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (FindObjectOfType<Music>() == null)
        {
            Instantiate(Music, Vector3.zero, Quaternion.identity);
        }
        
    }
 
}
