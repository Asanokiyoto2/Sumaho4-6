using UnityEngine;
public class Meteor : MonoBehaviour
{
    public float speed = 2f;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        GameManager.Instance.MeteorMiss();
        Destroy(gameObject);
    }
}
