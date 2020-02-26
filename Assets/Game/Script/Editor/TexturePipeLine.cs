using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorTutorial
{
    public class TexturePipeLine : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            TextureImporter importer = assetImporter as TextureImporter;
            if( importer.filterMode == FilterMode.Point ) return;
            
            importer.spriteImportMode = SpriteImportMode.Single;
		
            importer.spritePixelsPerUnit = 16;
            importer.filterMode = FilterMode.Point;
            importer.maxTextureSize = 2048;
            importer.textureCompression = TextureImporterCompression.Uncompressed;

            TextureImporterSettings settings = new TextureImporterSettings();
            importer.ReadTextureSettings( settings );
            settings.ApplyTextureType( TextureImporterType.Sprite );
            importer.SetTextureSettings( settings ) ;
        }
    }
    
}
