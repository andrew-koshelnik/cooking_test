using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Services
{
	public class AssetBundleService
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private string URL = "https://drive.google.com/uc?id=1Xl8cDYONbyAn6wxy3SOqKw0k89DhPhZY";
#elif UNITY_EDITOR_WIN
        private string URL = "https://drive.google.com/uc?id=1O8gOCKj7Fcbeze6gDyLkZIFmKyOCACaf";
#endif
        public AssetBundle LobbyAssetBundle;
        
        public AssetBundleService()
        {
            
        }
        
        public IEnumerator  GetLobbyAssetBundle() {
            while (!Caching.ready)
                yield return null;

            
            using (var www = WWW.LoadFromCacheOrDownload(URL, 2))
            {
                while (!www.isDone)
                {
                    Debug.Log($"======{www.progress}");
                    yield return null;
                }

                if (!string.IsNullOrEmpty(www.error))
                {
                    Debug.Log(www.error);
                    yield return null;
                }
                
                LobbyAssetBundle = www.assetBundle;
            }
        }
    }
}