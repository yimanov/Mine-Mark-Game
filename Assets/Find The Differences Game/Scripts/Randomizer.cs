using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.FindDifferences.Scripts
{
    public class Randomizer : MonoBehaviour
    {
        public static Randomizer instance;

        /// <summary>
        /// List of levels
        /// </summary>
        public PhotoInfo[] photos;

        /// <summary>
        /// Main container of game objects
        /// </summary>
        public GameObject container;

        private GameObject m_source;
        private GameObject m_target;
        private int m_remainingChanges;
        private int m_totalChanges;
        private PhotoInfo m_photoInfo;

        /// <summary>
        /// Number of remaining changes in the scene
        /// </summary>
        public int RemainingChanges
        {
            get { return m_remainingChanges; }
            set
            {
                m_remainingChanges = value;
                if (m_remainingChanges == 0)
                {
                    GameEvents.instance.GameCompleted();
                }
            }
        }

        public int TotalChanges
        {
            get { return m_totalChanges; }
        }

        public PhotoInfo SelectedPhoto
        {
            get { return m_photoInfo; }
        }


        public void Awake()
        {
            instance = this;

            var selectedScene = GameSelector.selectedScene;

            // Find the selected photo
            if (string.IsNullOrEmpty(selectedScene))
            {
                m_photoInfo = photos.First();
            }
            else
            {
                m_photoInfo = photos.First(p => p.Name == selectedScene);
            }

            // Initialize the "original" photo
            m_source = Instantiate(m_photoInfo.Photo, container.transform);
            m_source.name = "Source" + m_photoInfo.Name;
            m_source.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            m_source.transform.SetSiblingIndex(0);
            foreach (var haloScript in m_source.GetComponentsInChildren<HaloScript>())
            {
                haloScript.gameObject.SetActive(false);
            }
            foreach (var changeable in m_source.GetComponentsInChildren<Changeable>())
            {
                changeable.Interactable = false;
            }

            // Initialize the modified photo
            m_target = Instantiate(m_photoInfo.Photo, container.transform);
            m_target.transform.SetSiblingIndex(1);
            m_target.name = "Target" + m_photoInfo.Name;
            ((RectTransform)m_target.transform).pivot = new Vector2(0.5f, 2);
            m_target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public void Start()
        {
            // Find all changeable objects, and reset them
            var changeables = m_target.GetComponentsInChildren<Changeable>();
            foreach (var changeable in changeables)
            {
                changeable.ResetTransformation();
                changeable.SearchForHalo();
            }

            if (SelectedPhoto.Halo != null)
            {
                foreach (var changeable in changeables)
                {
                    Instantiate(SelectedPhoto.Halo, changeable.gameObject.transform);
                    changeable.SearchForHalo();
                }
            }

            // Decide on the number of changes to implement
            changeables = changeables.Where(c => c.canChange).ToArray();
            var count = changeables.Length;
            m_totalChanges = Random.Range(3, count);
            if (m_photoInfo.NumChanges != -1)
                m_totalChanges = m_photoInfo.NumChanges;

            List<Changeable> changed = new List<Changeable>();
            while (changed.Count < m_totalChanges && changeables.Length > 0)
            {
                // Select a changeable object randomly
                var index = Random.Range(0, changeables.Length);
                var toChange = changeables[index];

                // Select a random change type and implement it on the object
                var changeType = GetRandomChangeType(toChange.supportedChangeTypes);
                toChange.PerformTransformation(changeType.Value);
                toChange.canChange = false;

                // Disable changes in all child objects (except in the case of colorization)
                if (changeType != ChangeTypes.Colorize)
                {
                    var children = toChange.GetComponentsInChildren<Changeable>();
                    foreach (var child in children)
                        child.canChange = false;
                }

                // Update list of available changeables
                changeables = changeables.Where(c => c.canChange).ToArray();

                changed.Add(toChange);
                m_remainingChanges++;
            }
        }

        private ChangeTypes? GetRandomChangeType(ChangeTypes changeTypes)
        {
            if ((changeTypes & ChangeTypes.Move) != 0)
                return ChangeTypes.Move;


            // Collect list of allowed change types
            List<ChangeTypes> allowed = new List<ChangeTypes>();
            

            if ((changeTypes & ChangeTypes.Hide) != 0)
                allowed.Add(ChangeTypes.Hide);
            if ((changeTypes & ChangeTypes.FlipHorizontal) != 0)
                allowed.Add(ChangeTypes.FlipHorizontal);
            if ((changeTypes & ChangeTypes.FlipVertical) != 0)
                allowed.Add(ChangeTypes.FlipVertical);
            if ((changeTypes & ChangeTypes.Colorize) != 0)
                allowed.Add(ChangeTypes.Colorize);
            if ((changeTypes & ChangeTypes.Move) != 0)
                allowed.Add(ChangeTypes.Move);

            if (allowed.Count == 0)
                return null;

            // Select one of the change types randomly
            return allowed[Random.Range(0, allowed.Count)];
        }
    }
}