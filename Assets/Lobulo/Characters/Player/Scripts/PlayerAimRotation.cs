using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAimRotation : MonoBehaviour
    {
        
         [SerializeField] private PlayerDataSO playerDataData;
        [SerializeField] private Camera _mainCamera;

        private void Update()
        {
            Aim();
        }

        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                var direction = position - transform.position;
                direction.y = 0;
                
                transform.forward = direction;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, playerDataData.GroundMask))
            {
                return (success: true, position: hitInfo.point);
            }
            else
            {
                return (success: false, position: Vector3.zero);
            }
        }
    }
