using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private GameObject candleAttackObject;
    [SerializeField] private GameObject knifeAttackObject;
    [SerializeField] private GameObject handAttackObject;
    [SerializeField] private GameObject shovelAttackObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("attack", 5f, timeBetweenAttacks);
    }

    public void attack()
    {
        int currentAttack = Random.Range(0, 4);

        //remove return and uncomment attack calls once we have correct references
        if (currentAttack == 0)
            //candleAttackObject.StartCandleAttack();
            return;
        if (currentAttack == 1)
            // knifeAttackObject.StartKnifeAttack();
            return;
        if (currentAttack == 2)
            //handAttackObject.StartHandAttack();
            return;
        if (currentAttack == 3)
            //shovelAttackObject.StartShovelAttack();
            return;
    }
}
