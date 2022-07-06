using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JigsawPuzzlesCollection.Scripts
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class LevelScript : MonoBehaviour
    {
        public Level m_level;



        public void SetDetails(Level level)
        {
            m_level = level;

          
                LevelSelectorScript.Instance.SelectedLevel = level;


                SceneManager.LoadScene("GameJigsaw");
   
        }
    }
}