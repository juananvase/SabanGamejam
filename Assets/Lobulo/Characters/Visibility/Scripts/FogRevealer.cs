using UnityEngine;

public class FogRevealer : MonoBehaviour
{
    private int index;

    void Start()
    {
        var radius = FogOfWarManager.Instance.settings.defaultVisionRadius;

        index = FogOfWarManager.Instance.RegisterUnit(new FogOfWarManager.UnitInfo
        {
            position = transform.position,
            radius = radius
        });
    }

    void Update()
    {
        FogOfWarManager.Instance.UpdateUnitPosition(index, transform.position);
    }
}
