using UnityEngine;

namespace Assets.FindDifferences.Scripts
{
    /// <summary>
    /// Manage high-level events of the game
    /// </summary>
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents instance;

        public GameObject completed;

        void Awake()
        {
            instance = this;
            PlayerPrefs.SetInt("Locked:" + GameSelector.FirstLevel, 1);
        }

        /// <summary>
        /// Mark the game as completed - display "completed" banner
        /// </summary>
        public void GameCompleted()
        {
            var unlocks = Randomizer.instance.SelectedPhoto.Unlocks;
            foreach (var level in unlocks)
            {
                PlayerPrefs.SetInt("Locked:" + level, 1);
            }

            completed.SetActive(true);
        }
    }
}