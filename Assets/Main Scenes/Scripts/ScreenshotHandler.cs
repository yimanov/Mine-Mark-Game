using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;


public class ScreenShotHandler : MonoBehaviour
	{

    private RenderTexture renderTexture;

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
        ScreenCapture.CaptureScreenshotIntoRenderTexture(renderTexture);
        AsyncGPUReadback.Request(renderTexture, 0, TextureFormat.RGBA32, ReadbackCompleted);
    }

    void ReadbackCompleted(AsyncGPUReadbackRequest request)
    {
        // Render texture no longer needed, it has been read back.
        DestroyImmediate(renderTexture);

        using (var imageBytes = request.GetData<byte>())
        {
            // do something with the pixel data.
        }
    }
}
 