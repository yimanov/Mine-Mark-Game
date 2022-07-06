using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FindDifferences.Scripts
{
    [Serializable]
    public class PhotoInfo
    {
        public string Name;
        public GameObject Photo;
        public HaloScript Halo;
        public int NumChanges = -1;

        public List<string> Unlocks;
    }
}