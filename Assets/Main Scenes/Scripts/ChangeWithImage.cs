#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

using UnityEngine;
using System.Collections;

public class ChangeWithImage : MonoBehaviour
{
    private Transform thisTransform;
    public string sceneName;
    public float time;




    //The sound of the click and the source of the sound
    public AudioClip soundClick;
    public Transform soundSource;

    public GameObject gameobjecto;

    //Should there be a click effect
    public bool clickEffect = true;

    public void Start()
    {
        thisTransform = transform;


    }
    private IEnumerator Countdown2()
    {

        if (clickEffect == true) ClickEffect();

        //Play a sound from the source
        if (soundSource) if (soundSource.GetComponent<AudioSource>()) soundSource.GetComponent<AudioSource>().PlayOneShot(soundClick);

        //Wait a while

        gameobjecto.SetActive(true);
        yield return new WaitForSeconds(time);

     



        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void changeGO()
    {
        StartCoroutine(Countdown2());

    }


    IEnumerator ClickEffect()
    {
        //Register the original size of the object
        var initScale = thisTransform.localScale;

        //Resize it to be larger
        thisTransform.localScale = initScale * 1.1f;

        //Gradually reduce its size back to the original size
        while (thisTransform.localScale.x > initScale.x * 1.01f)
        {
            yield return new WaitForFixedUpdate();

            thisTransform.localScale = new Vector3(thisTransform.localScale.x - 1 * Time.deltaTime, thisTransform.localScale.x - 1 * Time.deltaTime, thisTransform.localScale.z);
        }

        //Reset the size to the original
        thisTransform.localScale = thisTransform.localScale = initScale;
    }



}
