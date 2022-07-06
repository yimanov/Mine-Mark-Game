namespace Assets.FindDifferences.Scripts.Popup
{
    public class NativeMessage
    {
        #region PUBLIC_FUNCTIONS

        public NativeMessage(string title, string message)
        {
            init(title, message, "Ok");
        }

        public NativeMessage(string title, string message, string ok)
        {
            init(title, message, ok);
        }

        private void init(string title, string message, string ok)
        {
#if UNITY_ANDROID
            AndroidMessage.Create(title, message, ok);
#endif
        }

        #endregion
    }
}