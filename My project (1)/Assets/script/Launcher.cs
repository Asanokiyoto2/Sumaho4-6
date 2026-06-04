using UnityEngine;
public class Launcher : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform spawnPoint;
    public float cooldown = 1f;
    bool canShoot = true;
    Vector2 startPos;
    Vector2 endPos;
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (!canShoot) return;
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            ShootCheck();
        }
#else
       if (!canShoot) return;
       if (Input.touchCount > 0)
       {
           Touch touch = Input.GetTouch(0);
           if (touch.phase == TouchPhase.Began)
           {
               startPos = touch.position;
           }
           if (touch.phase == TouchPhase.Ended)
           {
               endPos = touch.position;
               ShootCheck();
           }
       }
#endif
    }
    void ShootCheck()
    {
        Vector2 dir = endPos - startPos;
        if (dir.magnitude > 50)
        {
            Shoot(dir.normalized);
        }
    }
    void Shoot(Vector2 direction)
    {
        GameObject missile =
            Instantiate(missilePrefab,
            spawnPoint.position,
            Quaternion.identity);
        missile.GetComponent<Missile>()
            .SetDirection(direction);
        canShoot = false;
        Invoke(nameof(ResetCooldown), cooldown);
    }
    void ResetCooldown()
    {
        canShoot = true;
    }
}
