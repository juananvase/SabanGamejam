using UnityEngine;

[CreateAssetMenu(menuName = "FogOfWar/Settings")]
public class FogSettings : ScriptableObject
{
    public int textureSize = 1920;
    public Vector2 worldSize = new Vector2(120f, 90f); // X = ancho (horizontal), Y = alto (vertical, Z en mundo)
    public Vector3 worldCenter = Vector3.zero;
    public float defaultVisionRadius = 5f;
}
