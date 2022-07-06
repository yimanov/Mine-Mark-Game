using System.Linq;
using UnityEngine;
using System.Collections;
namespace Assets.FindDifferences.Scripts
{
    /// <summary>
    /// Handle clicks on changeable objects
    /// </summary>
    public class RayCast : MonoBehaviour
    {

        public AudioClip soundClick;
        public Transform soundSource;

        public float time;

        private IEnumerator Countdown2()
        {

         

            //Play a sound from the source
            if (soundSource) if (soundSource.GetComponent<AudioSource>()) soundSource.GetComponent<AudioSource>().PlayOneShot(soundClick);

            //Wait a while
            yield return new WaitForSeconds(time);





        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 5f;

                Vector2 v = new Vector2(mousePosition.x, mousePosition.y);

                Collider2D[] col = Physics2D.OverlapPointAll(v);

                if (col.Length > 0)
                {
                    // Find the first changeable object
                    StartCoroutine(Countdown2());
                    var changeable = col.First().gameObject.GetComponent<Changeable>();
                    if (changeable.Interactable)
                    {
                        // Reset it

                        changeable.ResetTransformation();
                        // And update the number of remaining changes
                        Randomizer.instance.RemainingChanges--;
                    }
                }
            }
        }
    }
}