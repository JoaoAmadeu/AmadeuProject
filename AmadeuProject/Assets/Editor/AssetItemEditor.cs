using System.Drawing;
using UnityEditor;
using UnityEditor.Sprites;
using UnityEngine;

/// <summary>
/// Replace the thumbnail of the AssetItem, with its 'icon' member
/// </summary>
[InitializeOnLoad]
public static class AssetItemEditor
{
    static AssetItemEditor()
    {
        EditorApplication.projectWindowItemOnGUI += DrawItem;
    }

    private static void DrawItem(string guid, Rect rect)
    {
        if (Application.isPlaying || Event.current.type != EventType.Repaint || !IsPossibleAsset(rect))
        {
            return;
        }

        // Check if this asset is an ItemAsset and if it has a valid sprite icon
        var assetPath = AssetDatabase.GUIDToAssetPath(guid);
        var asset = AssetDatabase.LoadAssetAtPath<ItemAsset>(assetPath);
        if (asset == null)
        {
            return;
        }

        if (asset.Icon != null)
        {
            rect.height = rect.width;
            var texture = asset.Icon.texture;

            // Draw a texture over the old thumbnail
            GUI.color = UnityEngine.Color.HSVToRGB(0, 0, 0.2f);
            GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture, ScaleMode.ScaleToFit);
            GUI.color = UnityEngine.Color.white;

            // Draw the sprite using UV coordinates
            var spriteRect = asset.Icon.rect;
            var textRect = new Rect (
                spriteRect.x / texture.width,
                spriteRect.y / texture.height,
                spriteRect.width / texture.width,
                spriteRect.height / texture.height);
            GUI.DrawTextureWithTexCoords(rect, texture, textRect);
        }
    }

    private static bool IsPossibleAsset(Rect rect)
    {
        // Draw details if project view shows large preview icons:
        if (rect.height > 20)
        {
            return true;
        }

        // Draw details if this asset is a sub asset:
        if (rect.x > 16)
        {
            return true;
        }

        return false;
    }
}