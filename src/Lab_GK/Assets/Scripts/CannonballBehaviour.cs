using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehaviour : MonoBehaviour
{

    public GameObject ExplosionEffectPrefab;

    private UIController UIController;
    private bool hitSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        UIController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -50f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag.Equals("Wall") || target.gameObject.tag.Equals("Ground"))
        {
            GameObject newExplosionPoint = 
                Instantiate(ExplosionEffectPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z)  , Quaternion.identity);
            Destroy(gameObject);
        }

        if (target.gameObject.tag.StartsWith("Target"))
        {
            if (!hitSomething)
            {
                hitSomething = true;
                Debug.Log("Hit something: " + target.gameObject.tag);
                Instantiate(ExplosionEffectPrefab, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
                if (target.gameObject.tag.Equals("TargetInside"))
                    UIController.setScore(UIController.getScore() + 500);
                else
                    UIController.setScore(UIController.getScore() + 100);
                Destroy(gameObject);
                Destroy(target.gameObject.transform.parent.gameObject);
            }
        }
    }
}
