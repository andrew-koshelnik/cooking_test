using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Game.Utils
{
	public class PrefabUtil
	{
		[MenuItem("Tools/Update Paths")]
		public static void UpdatePrefabPath()
		{
			Dictionary<string, string> filesPaths = new Dictionary<string, string>();
            
			var folders = new List<string>();
            
			string[] prefabsPaths = Directory.GetFiles(Path.Combine(Application.dataPath, "Resources"),  "*.*", SearchOption.AllDirectories);
			
			var allowedExtensions = new [] {".png", ".prefab", ".jpg", ".asset"}; 
			var files = Directory
				.GetFiles(Path.Combine(Application.dataPath, "Resources"), "*.*", SearchOption.AllDirectories)
				.Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
				.ToList();
			
			foreach(string prefabPath in files)
			{
				var extension = Path.GetExtension(prefabPath);
				var resourcesPath = prefabPath.Replace('\\', '/').Replace(extension, "");
				resourcesPath = resourcesPath.Replace(Application.dataPath + "/Resources/", "");
				
				filesPaths.Add(Path.GetFileNameWithoutExtension(prefabPath), resourcesPath);
			}
			
			var assetPaths = @"using System.Collections.Generic;
			//CODE GEN FILE, DON'T CHANGE IT MANUALLY
            public class AssetPaths : Dictionary<string, string>
            {
                public AssetPaths() : base({CODE_GEN_LEN})
                {
                    {CODE_GEN}
                }
            }";
			
			var assetConstants = @"using System.Collections.Generic;
			//CODE GEN FILE, DON'T CHANGE IT MANUALLY
            public static class AssetsConstants
            {
                {CODE_GEN}

				public static List<string> DishesConfigs = new List<string>()
                {
	                {CODE_GEN2}
                };

				public static List<string> IngredientsConfigs = new List<string>()
                {
	                {CODE_GEN3}
                };
				
            }";
			
			var assetPathsLines = new StringBuilder();
			var assetConstantsLines = new StringBuilder();
			var dishesConstantsLines = new StringBuilder();
			var ingredientsConstantsLines = new StringBuilder();
			
			foreach (var file in filesPaths)
			{
				assetPathsLines.AppendFormat("                this[\"{0}\"] = \"{1}\";\r\n", file.Key.ToLower(), file.Value);
				
				string constname = file.Key.ToUpper();
				constname = constname.Replace(" ", "");
				constname = constname.Replace("-", "_");
                
				assetConstantsLines.AppendFormat("                public const string {0} = \"{1}\";\r\n", constname, file.Key.ToUpper());
				
				if(file.Value.Contains("SO/Dishes/"))
					dishesConstantsLines.AppendFormat("                {0},\n", constname);
				
				if(file.Value.Contains("SO/Ingredients/"))
					ingredientsConstantsLines.AppendFormat("                {0},\n", constname);
			}
			
			assetPaths = assetPaths.Replace("{CODE_GEN}", assetPathsLines.ToString());
			assetConstants = assetConstants.Replace("{CODE_GEN}", assetConstantsLines.ToString());
			assetConstants = assetConstants.Replace("{CODE_GEN2}", dishesConstantsLines.ToString());
			assetConstants = assetConstants.Replace("{CODE_GEN3}", ingredientsConstantsLines.ToString());
			
			assetPaths = assetPaths.Replace("{CODE_GEN_LEN}", filesPaths.Count.ToString());
			
			var codeGenFolder = "Assets/Scripts/Game/CodeGen";
			var assetPathsFile = "AssetPaths.cs";
			var assetConstantFile = "AssetsConstants.cs";
			
			var assetsPathFile = Path.Combine(codeGenFolder, assetPathsFile);
			var assetsConstantsFile = Path.Combine(codeGenFolder, assetConstantFile);
			
			if (!Directory.Exists(codeGenFolder))
			{
				Directory.CreateDirectory(codeGenFolder);
			}
			if (File.Exists(assetsPathFile))
			{
				File.Delete(assetsPathFile);
			}
			if (File.Exists(assetsConstantsFile))
			{
				File.Delete(assetsConstantsFile);
			}
			
			File.WriteAllText(assetsPathFile, assetPaths);
			File.WriteAllText(assetsConstantsFile, assetConstants);

			AssetDatabase.Refresh();
		}
	}
}