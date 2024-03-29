﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Molotkoff.AssetManagment.Builders
{
    internal class AssetManagerPostProcessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(System.String[] importedAssets, System.String[] deletedAssets, System.String[] movedAssets, System.String[] movedFromAssetPaths)
        {
            foreach (var importedAsset in importedAssets)
            {
                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(importedAsset);
                
                if (asset != null)
                {
                    var assetType = asset.GetType();
                    if (assetType.IsDefined(typeof(AssetAttribute), false)) //is required-asset
                    {
                        AssetManagementBuilder.BuildRequiredAsset(asset);
                    }
                }
            }
        }
    }
}