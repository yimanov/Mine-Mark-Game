using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToURL : MonoBehaviour

{


 private Transform thisTransform;
   public string urname = "https://www.minemark.org/";
   public float time;




//The sound of the click and the source of the sound
public AudioClip soundClick;
public Transform soundSource;

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
    yield return new WaitForSeconds(time);


    if (urname != string.Empty)  Application.OpenURL(urname);
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

 
 
