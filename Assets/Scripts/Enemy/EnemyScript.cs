using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health = 100;

    public void TakeDamage(float Damage)
    {
        Health -= Health - Damage;
    }
}
