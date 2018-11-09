using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Tools:MonoBehaviour
{
    [UnityEditor.MenuItem("Tools/AssetBundle")]
    public static void BuildTools()
    {
        UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.AppendHashToAssetBundleName|BuildAssetBundleOptions.ForceRebuildAssetBundle,EditorUserBuildSettings.activeBuildTarget);
    }
}
