using UnityEngine;
using UnityEngine.UI;

namespace Assets.FindDifferences.Scripts
{
    [RequireComponent(typeof(Text))]
    public class RemainingChanges : MonoBehaviour
    {
        private Text m_text;

        void Start()
        {
            m_text = GetComponent<Text>();
        }
        void Update()
        {
            m_text.text = string.Format("{0}/{1}", Randomizer.instance.RemainingChanges, Randomizer.instance.TotalChanges);
        }
    }
}