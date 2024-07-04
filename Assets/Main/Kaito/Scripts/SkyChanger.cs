using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChanger : MonoBehaviour
{

    public void skychangeTo(string mode)
    {
        string newSkyboxPath = "SkyMaterials/Skybox_" + mode;

        // Load the material from the Resources folder
        Material newSkyboxMaterial = Resources.Load<Material>(newSkyboxPath);
        if (newSkyboxMaterial != null)
        {
            // Set the new skybox material
            RenderSettings.skybox = newSkyboxMaterial;

            // Update the lighting environment to reflect the new skybox
            //DynamicGI.UpdateEnvironment();
            Debug.Log("skychangeTo: " + mode);
        }
        else
        {
            Debug.LogWarning("Skybox material not found: " + newSkyboxPath);
        }
    }
}