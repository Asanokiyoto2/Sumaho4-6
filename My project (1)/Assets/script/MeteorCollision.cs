using UnityEngine;
public class MeteorCollision : MonoBehaviour
{
    public int scoreValue = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Missile"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
