using UnityEngine;
using UnityEngine.Advertisements;

namespace JigsawPuzzlesCollection.Scripts.Ads
{
    public class InitializeAdsScript : Singleton<InitializeAdsScript>
    {
        public string appleStoreGameId = "3660644";
        public string googlePlayGameId = "3660645";
        public bool testMode = true;

        public string bannerPlacementId = "MainBanner";
        public string rewardedPlacementId = "rewardedVideo";

        void Start()
        {
            if (!string.IsNullOrEmpty(GameId))
            {
               
            }
        }

        public string GameId
        {
            get
            {
#if UNITY_ANDROID
                return googlePlayGameId;
#elif UNITY_IOS
                return appleStoreGameId;
#else
                return null;
#endif
            }
        }
    }
}