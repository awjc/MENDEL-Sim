using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Autotile a texture: sets the texture's scale equal to the game object's scale
/// </summary>
[ExecuteInEditMode]
public class AutotileTexture : MonoBehaviour 
{
    private Dictionary<string, string[]> ShaderTextures
    {
        get 
        {
            var _shaderTextures = new Dictionary<string, string[]>();
            _shaderTextures["Diffuse"] = new[] { "_MainTex" };
            _shaderTextures["Parallax Diffuse"] = new[] { "_MainTex", "_BumpMap", "_ParallaxMap" };
			_shaderTextures["Parallax Specular"] = new[] { "_MainTex", "_BumpMap", "_ParallaxMap" };
            _shaderTextures["Bumped Specular"] = new[] { "_MainTex", "_BumpMap" };

            return _shaderTextures;
        }
    }

    /// <summary>
    /// Get the texture names to scale
    /// </summary>
    /// <returns></returns>
    private string[] GetTextures(string shaderName)
    {
        if (ShaderTextures.ContainsKey(shaderName))
        {
            return ShaderTextures[shaderName];
        }

        return new[] { "_MainTex" };
    }

	// Update is called once per frame
	void Update () 
    {
		// Get the renderer for the game object
		var meshRenderer = gameObject.GetComponent<MeshRenderer> ();
		if (meshRenderer != null && meshRenderer.sharedMaterial != null)
		{
            Vector2 scaleVector = new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.z);

			// Set the tiling equal to the object's scale
            foreach (string textureName in GetTextures(meshRenderer.sharedMaterial.shader.name))
            {
                if (meshRenderer.sharedMaterial.HasProperty(textureName))
                {
                    meshRenderer.sharedMaterial.SetTextureScale(textureName, scaleVector);
                    meshRenderer.sharedMaterial.GetTexture(textureName).wrapMode = TextureWrapMode.Repeat;
                }
            }
		}
    }
}
