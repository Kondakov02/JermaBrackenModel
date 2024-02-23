using System.Collections.Generic;
using UnityEngine;

namespace JermaBrackenModel.Core
{
    internal static class Assets
    {
        public static AssetBundle AssetBundle { get; private set; }

        private static Dictionary<string, Object> AssetList { get; set; }

        public static void LoadBundle(string assetBundlePath)
        {
            // Load the bundle
            AssetBundle = AssetBundle.LoadFromFile(assetBundlePath);

            // Check if the bundle loaded
            if ((Object)(object)AssetBundle == (Object)null)
            {
                Logger.LogError("Asset bundle " + assetBundlePath + " failed to load!");
            }

            // Create dictionary "asset name" - "asset"
            AssetList = new Dictionary<string, Object>();

            // Load all assets into an array
            Object[] allAssets = AssetBundle.LoadAllAssets();

            // Fill the dictionary
            foreach (Object asset in allAssets)
            {
                AssetList.Add(asset.name, asset);
            }
        }

        public static T GetAsset<T>(string name) where T : Object
        {
            // An attempt to get asset from the dictionary
            if (!AssetList.TryGetValue(name, out var asset))
            {
                Logger.LogError("Attempted to load asset of name " + name + " but no asset of that name exists!");
                // Returns uninitialized instance of type T.
                // This is done to return anything perhaps?
                return default(T);
            }

            // Weird check to see if the asset is of correct type T
            T loadedAsset = (T)(object)((asset is T) ? asset : null);
            if ((Object)(object)loadedAsset == (Object)null)
            {
                Logger.LogError("Attempted to load an asset of type " + typeof(T).Name + " but asset of name " + name + " does not match this type!");
                return default(T);
            }

            return loadedAsset;
        }
    }
}
