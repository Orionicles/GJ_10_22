using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("attack", 5f, timeBetweenAttacks);
    }

    public void attack()
    {
        int currentAttack = Random.Range(0, 4);

        //return will be replaced with calling the 4 different attacks
        if (currentAttack == 0)
            return;
        if (currentAttack == 1)
            return;
        if (currentAttack == 2)
            return;
        if (currentAttack == 3)
            return;
    }
}
