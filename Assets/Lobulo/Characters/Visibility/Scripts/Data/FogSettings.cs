using UnityEngine;

[CreateAssetMenu(menuName = "FogOfWar/Settings")]
public class FogSettings : ScriptableObject
{
    public int textureSize = 1920;
    public Vector2 worldSize = new Vector2(120f, 90f);
    public Vector3 worldCenter = Vector3.zero;
    public float defaultVisionRadius = 5f;
    public Vector3 GroundSize;

    void Start()
    {
        GroundSize = GameManager.Instance.Ground.GetComponent<Renderer>().bounds.size;
    }
}
