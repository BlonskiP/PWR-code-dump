using UnityEngine;
public abstract class Interactive : MonoBehaviour
{
    public float InteractionRange = 3f;
    public bool active = true;
    protected abstract void Interaction(PlayerCameraController player);
    public void Interact(PlayerCameraController player)
    {
        if(active)
        {
            Interaction(player);
        }
    }
    public abstract void outOfRange(PlayerCameraController player);
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, InteractionRange);
    }
  
}
