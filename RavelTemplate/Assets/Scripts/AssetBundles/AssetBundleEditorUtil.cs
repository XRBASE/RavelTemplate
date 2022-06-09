using TMPro;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
    public static class AssetBundleEditorUtil
    {
        
        /// <summary>
        /// Loop through all gameobjects with shaders to replace them
        /// </summary>
        public static void FixShadersForEditor(GameObject prefab)
        {
            var renderers = prefab.GetComponentsInChildren<Renderer>(true);
            foreach (var renderer in renderers)
            {
                ReplaceShaderForEditor(renderer.sharedMaterials);
            }

            var tmps = prefab.GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var tmp in tmps)
            {
                ReplaceShaderForEditor(tmp.material);
                ReplaceShaderForEditor(tmp.materialForRendering);
            }

            var spritesRenderers = prefab.GetComponentsInChildren<SpriteRenderer>(true);
            foreach (var spriteRenderer in spritesRenderers)
            {
                ReplaceShaderForEditor(spriteRenderer.sharedMaterials);
            }

            var images = prefab.GetComponentsInChildren<Image>(true);
            foreach (var image in images)
            {
                ReplaceShaderForEditor(image.material);
            }

            var particleSystemRenderers = prefab.GetComponentsInChildren<ParticleSystemRenderer>(true);
            foreach (var particleSystemRenderer in particleSystemRenderers)
            {
                ReplaceShaderForEditor(particleSystemRenderer.sharedMaterials);
            }

            var particles = prefab.GetComponentsInChildren<ParticleSystem>(true);
            foreach (var particle in particles)
            {
                var renderer = particle.GetComponent<Renderer>();
                if (renderer != null) ReplaceShaderForEditor(renderer.sharedMaterials);
            }
        }
        
        /// <summary>
        /// replace the shader of the skybox
        /// </summary>
        public static void FixSkyboxMaterial()
        {
            ReplaceShaderForEditor(RenderSettings.skybox);
        }

        public static void ReplaceShaderForEditor(Material[] materials)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                ReplaceShaderForEditor(materials[i]);
            }
        }
        
        /// <summary>
        /// Replace the shader of a material to the shader with that name in the registry
        /// </summary>
        public static void ReplaceShaderForEditor(Material material)
        {
            if (material == null) return;

            var shaderName = material.shader.name;
            var shader = Shader.Find(shaderName);

            if (shader != null) material.shader = shader;
        }
    }
#endif