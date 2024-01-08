using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleLoader
{
    [MenuItem("Build Tool/Create AssetBundles")]
    private static void BuildAllAssetBundles()
    {
        string assetBundleDirPath = Application.streamingAssetsPath;

		try
		{
            BuildPipeline.BuildAssetBundles(assetBundleDirPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
		}
		catch (Exception e)
		{
			Debug.LogWarning(e);
		}
    }

}
