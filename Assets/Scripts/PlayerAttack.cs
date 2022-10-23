using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Vector2 atckDir = Vector2.right;

    [SerializeField]
    private float atckSpeed = 0.5f;
    private float time;

    [SerializeField]
    private GameObject projPrefab;

    private void Update()
    {
        ChangeDir(Input.GetAxis("Vertical"));

        if (time > atckSpeed)
        {
            GameObject proj = Instantiate<GameObject>(projPrefab, transform.position, transform.rotation);
            PlayerProjectile playerProjectile = proj.GetComponent<PlayerProjectile>();

            playerProjectile.Shoot(atckDir);

            time = 0;
        }

        time += Time.deltaTime;
    }

    private void ChangeDir(float yAxis)
    {
        float angle = Mathf.Sin(Mathf.PI / 4);
        float dir = transform.localScale.x;

        if (yAxis > 0)
        {
            atckDir = new Vector2(dir * angle, angle);
        } 
        else if (yAxis < 0)
        {
            atckDir = new Vector2(dir * angle, -angle);
        }
        else
        {
            atckDir = new Vector2(dir, 0);
        }
    }
}
