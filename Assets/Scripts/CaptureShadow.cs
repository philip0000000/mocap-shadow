using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureShadow : MonoBehaviour
{
    public GameObject Model;
    private SkinnedMeshRenderer ModelSMR;

    private static CaptureShadow instance;

    public Camera CameraToTakeShadow;
    private int takeScreenshotOnNextFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        ModelSMR = Model.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // toggle on/off shadow
        {
            if (ModelSMR.shadowCastingMode == UnityEngine.Rendering.ShadowCastingMode.On)
                ModelSMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            else
                ModelSMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && takeScreenshotOnNextFrame == 0) // save png of shadow only
        {
            TakeScreenshot();
        }
        if (takeScreenshotOnNextFrame > 0)
        {
            if (takeScreenshotOnNextFrame == 2)
                CameraToTakeShadow.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
            --takeScreenshotOnNextFrame;
        }
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame == 1)
        {
            takeScreenshotOnNextFrame = 0;
            RenderTexture renderTexture = CameraToTakeShadow.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width / 2, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(renderTexture.width / 2, 0, renderTexture.width / 2, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            renderResult = rotateTextureClockwise(renderResult);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/SimulatedShadow.png", byteArray);
            #if UNITY_EDITOR
            Debug.Log("Saved SimulatedShadow.png");
            #endif

            RenderTexture.ReleaseTemporary(renderTexture);
            CameraToTakeShadow.targetTexture = null;
            ModelSMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; // add shadow
        }
    }
    private void TakeScreenshot()
    {
        ModelSMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; // remove shadow
        takeScreenshotOnNextFrame = 4;
    }

    Texture2D rotateTextureClockwise(Texture2D originalTexture)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = original.Length - 1 - (j * w + i);
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }
}
