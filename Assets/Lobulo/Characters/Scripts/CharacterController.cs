using UnityEngine;

public abstract class CharacterController : MonoBehaviour, Istunnable
{
    public virtual void OnStunned() { }
}
