using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
namespace JigsawPuzzlesCollection.Scripts
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]

    public class selectButtons : MonoBehaviour
    {

        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;

        public Image ObjectwithImage;
        public Level m_level;
        public Level m_level1;
        public Level m_level2;
        public Level m_level3;

        

        IEnumerator Start()
        {
            var azerbaijani = LocalizationSettings.AvailableLocales.Locales[0];
            var bosnian = LocalizationSettings.AvailableLocales.Locales[1];
            var english = LocalizationSettings.AvailableLocales.Locales[2];

            var ukrainian = LocalizationSettings.AvailableLocales.Locales[3];
            yield return LocalizationSettings.InitializationOperation;

     
            if ( LocalizationSettings.SelectedLocale== azerbaijani)
          
            {

                ObjectwithImage.sprite = sprite1;


            }


            else if (LocalizationSettings.SelectedLocale == english)
            {

                ObjectwithImage.sprite = sprite2;

            }

            else if (LocalizationSettings.SelectedLocale == ukrainian)
            {

                ObjectwithImage.sprite = sprite3;

            }
            else if (LocalizationSettings.SelectedLocale == bosnian)
            {

                ObjectwithImage.sprite = sprite4;

            }
        }


        public void setTheButtons()
        {
            var azerbaijani = LocalizationSettings.AvailableLocales.Locales[0];
            var bosnian = LocalizationSettings.AvailableLocales.Locales[1];
            var english = LocalizationSettings.AvailableLocales.Locales[2];

            var ukrainian = LocalizationSettings.AvailableLocales.Locales[3];

            if (LocalizationSettings.SelectedLocale == azerbaijani)
            {
                LevelSelectorScript.Instance.SelectedLevel = m_level;


                SceneManager.LoadScene("GameJigsaw");

            }

            else if (LocalizationSettings.SelectedLocale == english)
            {

                LevelSelectorScript.Instance.SelectedLevel = m_level1;


                SceneManager.LoadScene("GameJigsaw");

            }

            else if (LocalizationSettings.SelectedLocale == ukrainian)
            {

                LevelSelectorScript.Instance.SelectedLevel = m_level2;


                SceneManager.LoadScene("GameJigsaw");

            }
            else if (LocalizationSettings.SelectedLocale == bosnian)
            {
                LevelSelectorScript.Instance.SelectedLevel = m_level3;


                SceneManager.LoadScene("GameJigsaw");

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}