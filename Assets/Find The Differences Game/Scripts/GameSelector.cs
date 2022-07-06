using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
 
using System.Collections.Generic;
 
namespace Assets.FindDifferences.Scripts
{
    /// <summary>
    /// Controls the loading of a scenes in the game
    /// </summary>
    public class GameSelector : MonoBehaviour
    {
        private List<string> languages;
        private Text languageText;
        public static int indexit;
        public AudioClip soundClick;
        public Transform soundSource;
        public float delay = 0.5f;
        private Transform thisTransform;
        public static string FirstLevel = "Bunny";
        /// <summary>
        /// The name of the currently selected scene
        /// </summary>
        public static string selectedScene;

        /// <summary>
        /// Name of scene/level to load
        /// </summary>
        public string levelName;
        public string levelAze;
        /// <summary>
        /// Controls if the scenes is currently available for play
        /// </summary>
        private bool isLocked;

        public GameObject m_lockObject;



        void Start()
        {

            thisTransform = transform;


         /*   isLocked = levelName != FirstLevel && PlayerPrefs.GetInt("Locked:" + levelName, 0) == 0;
            GetComponent<Button>().interactable = !isLocked;
            // If the current scene is not locked
            if (!isLocked)
            {
                // Disable the "coming soon" text
                //m_lockText = gameObject.GetComponentInChildren<Text>();
                m_lockObject.SetActive(false);
            }
            */
        }

        public void OnClick()
        {
            StartCoroutine(OnClickMe());

        }

        IEnumerator OnClickMe()
        {

            
         //   if (soundSource) if (soundSource.GetComponent<AudioSource>()) soundSource.GetComponent<AudioSource>().PlayOneShot(soundClick);

            //Wait a while
            yield return new WaitForSeconds(delay);


          
           

            if (DropDownExample1.value1 == 3)
            {
                // Keep a reference to the selected scene
                selectedScene = levelAze;
                // Load the game scene
                SceneManager.LoadScene("FindTheDifferencesGame");

            }

            else
            {
                // Keep a reference to the selected scene
                selectedScene = levelName;
                // Load the game scene
                SceneManager.LoadScene("FindTheDifferencesGame");


            }


         
 
        }
    }
}