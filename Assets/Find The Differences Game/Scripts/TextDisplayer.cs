using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FindDifferences.Scripts
{
    /// <summary>
    /// Displays and rotates the "Completed" banner when the level is completed
    /// </summary>
    public class TextDisplayer : MonoBehaviour
    {
        private Transform m_transform;
        private float m_scale;

        void Start()
        {
            m_transform = GetComponent<Transform>();

            m_transform.localEulerAngles = Vector3.zero;
        }
        void Update()
        {
            // As long as we're small enough
            if (transform.localScale.x < 0.75)
            {
                // Rotate the banner
                m_transform.Rotate(0, 0, 360*Time.deltaTime);

                // And increase its size
                m_scale += 0.75f*0.5f*Time.deltaTime;
                m_transform.localScale = new Vector3(m_scale, m_scale, 1f);
            }

            // If we're large enough
            if (m_scale > 0.5f)
            {
                // Navigate to the main menu on mouse click
                if (Input.GetMouseButton(0))
                {
                    //AdDisplayer.Instance.ShowAd();

                    SceneManager.LoadScene("FIndTheDifferencesMainMenu");
                }
            }
        }
    }
}