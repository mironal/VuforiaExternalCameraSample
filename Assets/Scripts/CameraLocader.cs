using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Runtime.InteropServices;
using System;

struct FileDriverUserData
{
    public string sequenceDirectoryAbsolutePath;
}

public class CameraLocader : MonoBehaviour {

    #if UNITY_WSA && !UNITY_EDITOR
    private static FileDriverUserData userData;
    private static IntPtr userDataPrt = IntPtr.Zero;
#endif

    void Awake()
    {
#if UNITY_WSA && !UNITY_EDITOR
        string filePath = Application.streamingAssetsPath.Replace("/", "\\");

        userData = new FileDriverUserData()
        {
            sequenceDirectoryAbsolutePath = filePath
        };

        userDataPrt = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(FileDriverUserData)));
        Marshal.StructureToPtr(userData, userDataPrt, false);


        VuforiaUnity.SetDriverLibrary("FileDriver.dll", userDataPrt);
#endif
        VuforiaRuntime.Instance.InitVuforia();
    }
}
