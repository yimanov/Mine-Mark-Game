﻿
using UnityEngine;

using UnityEngine.UI;

namespace JigsawPuzzlesCollection.Scripts
{
    [RequireComponent(typeof(Button))]
    public class CollectionScript : MonoBehaviour
    {
        private Collection m_collection;


        public void SetDetails(Collection collection)
        {
            m_collection = collection;

            var button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();

            if (!m_collection.Free && // Collection is not free
                !m_collection.IsAvailable 
               ) // And Ads are configured
            {
                
                button.onClick.AddListener(() =>
                {
                    LevelSelectorScript.Instance.SelectedCollection = collection;
                 
                });
            }
            else
            {
                button.onClick.AddListener(() =>
                {
                    LevelSelectorScript.Instance.SelectedCollection = collection;
                    MenuScript.Instance.DisplayCollection(collection);
                });
            }

            var cardContentElement = transform.Find("CardContent");

            var imageElement = cardContentElement.Find("Image");
            imageElement.GetComponent<Image>().sprite = collection.Image;

            var textElement = cardContentElement.Find("Text");
            textElement.GetComponent<Text>().text = collection.name;

            var highlightElement = imageElement.Find("Lock");
            if (collection.Free || collection.IsAvailable)
            {
                highlightElement.gameObject.SetActive(false);
            }
            else
            {
                highlightElement.gameObject.SetActive(true);
            }
        }
    }
}