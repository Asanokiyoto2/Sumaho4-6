using UnityEngine;
public class Missile : MonoBehaviour
{
    public float speed = 10f;
    Vector2 moveDir;
    public void SetDirection(Vector2 dir)
    {
        moveDir = dir;
    }
    void Update()
    {
        transform.Translate(
            moveDir * speed * Time.deltaTime,
            Space.World);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
