using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintScreenShot : MonoBehaviour
{
    const string FilePath = @"C:\Users\UserName\Desktop\ScreenShots";

    public void CaptureScreenShot()
    {
        ScreenCapture.CaptureScreenshot(FilePath);
    }

    void printIt()
    {
       
            CaptureScreenShot();
    }
}
