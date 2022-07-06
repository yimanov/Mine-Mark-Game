using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FindDifferences.Scripts
{
    public class QuitOnBack : MonoBehaviour
    {
        public string Scene;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (string.IsNullOrEmpty(Scene))
                {
                    Application.Quit();
                }
                else
                {
                    SceneManager.LoadScene(Scene);
                }
            }
        }
    }
}