using System.IO;
using UnityEditor;
using UnityEngine;

namespace Game.Utils
{
#if UNITY_EDITOR
	
	public class AssetBundlesUtil
	{
		[MenuItem("Tools/Bundles_All")]
		public static void BuildBundlesAndroidIOS()
		{
			BuildAndroidBundlesHD();
			BuildWindowsBundlesHD();
		}
		
		public static void BuildAndroidBundlesHD()
		{
			BuildPhaseBundles(BuildTarget.Android, BuildAssetBundleOptions.None);
		}
		
		public static void BuildWindowsBundlesHD()
		{
			BuildPhaseBundles(BuildTarget.StandaloneWindows, BuildAssetBundleOptions.None);
		}
		
		private static void BuildPhaseBundles(BuildTarget target, BuildAssetBundleOptions options)
		{
			AssetDatabase.Refresh();

			var fullPath = $"Builds/AssetBundles/{BuildTargetToRuntimePlatform(target)}/";

			if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
				Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
		
			var buildManifest = BuildPipeline.BuildAssetBundles(fullPath, options, target);

			if (buildManifest == null)
			{
				Debug.Log("Error in build");
				return;
			}
		}
		
		private static RuntimePlatform BuildTargetToRuntimePlatform(BuildTarget target)
		{
			switch (target)
			{
				case BuildTarget.Android:
					return RuntimePlatform.Android;
				case BuildTarget.StandaloneWindows:
					return RuntimePlatform.WindowsEditor;
				default:
					return RuntimePlatform.WindowsEditor;
			}
		}
	}
#endif
}