using System;
using System.Collections.Generic;
using System.Linq;
using cooking.Enum;
using Models.Layers;
using strange.extensions.mediation.api;
using UnityEngine;
using Views.SoftCurrencyPanel;
using Object = UnityEngine.Object;

namespace Game.Services
{
	public class AssetService
	{
		[Inject] public LayerModel LayerModel { get; set; }
		
		private readonly Dictionary<string, GameObject> _linksMap = new Dictionary<string, GameObject>();
		private readonly Dictionary<string, Object> _cache;
		
		private AssetPaths _assetPaths;
		
		public AssetService()
		{
			_cache = new Dictionary<string, Object>();
			_assetPaths = new AssetPaths();
		}
		
		public T Get<T>(string assetName, bool sync = false) where T:Object
		{
			Object asset;
			_cache.TryGetValue(assetName, out asset);

			var lowerName = assetName.ToLower();

			if (_assetPaths.Keys.Contains(lowerName))
			{
				if (asset == null)
				{
					asset = Resources.Load<T>(_assetPaths[lowerName]);
					_cache.Add(assetName, asset);
				}

				return (T)asset;
			}
			else
			{
				throw new Exception($"Missing asset {lowerName} path at assetPaths, try to regenerate asset paths class");
			}
		}

		public GameObject Spawn(string assetName, Layers layerType)
		{
			var asset = Get<GameObject>(assetName);

			var layer = LayerModel.Layers.FirstOrDefault(l => l.Type == layerType);
			
			if (layer != null && asset != null)
			{
				return layer.Spawn(asset);
			}

			return null;
		}

		public GameObject SpawnAt(string assetName, Transform holder, Vector3 position)
		{
			var asset = Get<GameObject>(assetName);
			
			if (holder != null && asset != null)
			{
				var instance = GameObject.Instantiate(asset, holder, false);
				instance.transform.localPosition = position;
				
				return instance;
			}

			return null;
		}

		public GameObject SpawnAt(GameObject prefab, Transform holder)
		{
			if (holder != null && prefab != null)
			{
				var instance = GameObject.Instantiate(prefab, holder, false);
				
				return instance;
			}

			return null;
		}
		
		public GameObject SpawnAt(GameObject prefab, Layers layerType)
		{
			var layer = LayerModel.Layers.FirstOrDefault(l => l.Type == layerType);
			
			if (layer != null && prefab != null)
			{
				var instance = GameObject.Instantiate(prefab, layer.transform, false);
				return instance;
			}

			return null;
		}

		public GameObject SpawnAt(GameObject prefab, Transform holder, Vector3 position)
		{
			if (holder != null && prefab != null)
			{
				var instance = GameObject.Instantiate(prefab, holder, false);
				instance.transform.localPosition = position;
				
				return instance;
			}

			return null;
		}

		public void Link(string key, GameObject instance)
		{
			if (_linksMap.ContainsKey(key))
			{
				_linksMap.Remove(key);
			}
			_linksMap.Add(key, instance);
		}
		
		public GameObject GetLinkedObject(string key)
		{
			return (_linksMap.ContainsKey(key)) ? _linksMap[key] : null;
		}
	}
}