using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using UnityEngine;

public class PluginCreate {

#if UNITY_ANDROID && !UNITY_EDITOR  
    [DllImport("test")]
    public static extern int test_read_cfg(string path);
#else 

    [DllImport("Dll1")]
    public static extern int test_read_cfg(string path);
#endif
}
