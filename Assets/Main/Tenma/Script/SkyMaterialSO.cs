using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkyMaterialSO", menuName = "ScriptableObjects/SkyMaterialSO", order = 1)]
public class SkyMaterialSO : ScriptableObject
{
    public Sprite skySprite;
    public List<Material> skyMaterials;
}
