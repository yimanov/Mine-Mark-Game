using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.FindDifferences.Scripts
{
    /// <summary>
    /// Represents an object that can be changed randomly
    /// </summary>
    public class Changeable : MonoBehaviour
    {
        /// <summary>
        /// The type of changes supportedd by this object
        /// </summary>
        [SerializeField]
        public ChangeTypes supportedChangeTypes;

        /// <summary>
        /// The possible colors this object can change to
        /// </summary>
        public Color[] colorizeOptions;

        /// <summary>
        /// The possible positions this object can move to
        /// </summary>
        public Vector2[] moveOptions;

        /// <summary>
        /// Control if this object can change or not (used to disable changing sub-objects)
        /// </summary>
        public bool canChange;

        /// <summary>
        /// The current changes applied to this object
        /// </summary>
        public ChangeTypes? ChangeType { get; private set; }

        public UnityEngine.Events.UnityEvent OnDiscovered;

        public bool Interactable = true;

        private Transform m_transform;
        private Collider2D m_collider;
        private RawImage m_rawImage;
        private Color m_defaultColor;
        private Vector3 m_defaultRotation;
        private Vector3 m_defaultPosition;

        private Vector2 m_selectedMoveOption;
        private HaloScript m_halo;

        void Awake () {
            // cache instances of components locally
            m_transform = GetComponent<Transform>();
            m_collider = GetComponent<Collider2D>();
            m_rawImage = GetComponent<RawImage>();

            // keep original state of object
            m_defaultColor = m_rawImage.color;
            m_defaultRotation = m_transform.transform.localEulerAngles;
            m_defaultPosition = m_transform.transform.localPosition;

            SearchForHalo();
        }

        public void SearchForHalo()
        {
            m_halo = GetComponentInChildren<HaloScript>(true);
            if (m_halo)
            {
                m_halo.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Reverts the object to its original state
        /// </summary>
        public void ResetTransformation()
        {
            // If halo object is configured, enable it
            if (m_halo)
            {
                m_halo.gameObject.SetActive(true);
            }

            // Enable image if it was disabled
            m_rawImage.enabled = true;

            // Enable images of sub-objects
            var childrenRawImages = GetComponentsInChildren<RawImage>();
            foreach (var childrenRawImage in childrenRawImages)
                childrenRawImage.enabled = true;

            // Reset rotation
            m_transform.Rotate(-m_transform.localEulerAngles.x, -m_transform.localEulerAngles.y, -m_transform.localEulerAngles.z);
            m_transform.Rotate(m_defaultRotation.x, m_defaultRotation.y, m_defaultRotation.z);

            // Reset position
            m_rawImage.transform.Translate(-m_selectedMoveOption);

            // Reset color
            m_rawImage.color = m_defaultColor;

            // Disable collider - object cannot be pressed anymore
            if (m_collider != null)
                m_collider.enabled = false;

            // Reset current change type
            ChangeType = null;

            // If object supports any change types, mark that it can change
            if (supportedChangeTypes != 0)
            {
                canChange = true;
            }
            else
            {
                canChange = false;
            }
        }

        /// <summary>
        /// Applies a certain change type to the object
        /// </summary>
        /// <param name="changeType"></param>
        public void PerformTransformation(ChangeTypes changeType)
        {
            switch (changeType)
            {
                case ChangeTypes.Hide:
                {
                    Debug.Log("Hiding " + gameObject.name);
                    // disable the object's image
                    m_rawImage.enabled = false;
                    
                    // disable the image of all sub-objects
                    var childrenRawImages = GetComponentsInChildren<RawImage>();
                    foreach (var childrenRawImage in childrenRawImages)
                        childrenRawImage.enabled = false;
                    break;
                }
                case ChangeTypes.FlipHorizontal:
                {
                    Debug.Log("FlipHorizontal " + gameObject.name);

                    // flip object horizontally
                    m_transform.Rotate(180, 0, 0);
                    break;
                }
                case ChangeTypes.FlipVertical:
                {
                    Debug.Log("FlipVertical " + gameObject.name);

                    // flip object vertically
                    m_transform.Rotate(0, 180, 0);
                    break;
                }
                case ChangeTypes.Colorize:
                {
                    Debug.Log("Colorize " + gameObject.name);

                    // Select a random color, and colorize the object's image
                    var color = colorizeOptions[Random.Range(0, colorizeOptions.Length)];
                    m_rawImage.color = color;
                    break;
                }
                case ChangeTypes.Move:
                {
                    Debug.Log("Mve " + gameObject.name);

                    // Select a random location, and move the object's image
                    var index0 = Random.Range(0, moveOptions.Length);
                    m_selectedMoveOption = moveOptions[index0];
                    m_rawImage.transform.Translate(m_selectedMoveOption);
                    break;
                }
            }

            // Enable the collider, so that object can be clicked on
            if (m_collider != null)
                m_collider.enabled = true;

            // Set the applied change type
            ChangeType = changeType;
        }
    }
}