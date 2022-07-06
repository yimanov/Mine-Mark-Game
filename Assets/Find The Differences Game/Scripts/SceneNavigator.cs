using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FindDifferences.Scripts
{
    public class SceneNavigator : MonoBehaviour
    {
        public string sceneName;

        public void Navigate()
        {
            if (string.IsNullOrEmpty(sceneName))
                return;

            SceneManager.LoadScene(sceneName);
        }
    }
}