using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField]
    private Transform[] rows;
    [SerializeField]
    private Transform[] cols;

    [Header("positions")]
    [SerializeField]
    private Vector3 startPos;


    [Header("Candle Attack")]
    [SerializeField]
    private GameObject[] fire;


    private int curAttack;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        int currentAttack = Random.Range(0, 4);
        curAttack = 0;

        if (currentAttack == 0)
            animator.SetBool("Candle", true);

        if (currentAttack == 1)
            animator.SetBool("Knife", true);

        if (currentAttack == 2)
            animator.SetBool("Mash", true);

        if (currentAttack == 3)
            animator.SetBool("Scooper", true);
    }

    public void StartArmAttack()
    {
        StartCoroutine(ArmAttack());
    }

    public void SetScooperFalse()
    {
        animator.SetBool("Scooper", false);
    }

    private IEnumerator ArmAttack()
    {
        if (curAttack != 3)
        {
            int curCol = Random.Range(0, 3);
            Vector3 position = transform.position;
            position.x = cols[curCol].position.x;
            position.y = 19;

            Vector3 initPos = transform.position;

            float timeToLerp = 1, time = 0;
            while(time < timeToLerp)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(initPos, position, time / timeToLerp);
                yield return null;
            }

            animator.SetTrigger("MoveDone");

            curAttack++;
        }
        else
        {
            animator.SetBool("Mash", false);
        }
    }

    public void StartKnifeAttack()
    {
        StartCoroutine(KnifeAttack());
    }
    private IEnumerator KnifeAttack()
    {
        if (curAttack != 3)
        {
            //Move boss to position
            int curRow = Random.Range(0, 3);
            Vector3 position = transform.position;
            position.y = rows[curRow].position.y;

            Vector3 initPos = transform.position;

            float timeToLerp = 1;
            float time = 0;
            while(time < timeToLerp)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(initPos, position, time / timeToLerp);
                yield return null;
            }

            // Triggers that attack animation
            animator.SetTrigger("MoveDone");
            curAttack++;
        } 
        else
        {
            // No more knife moves
            animator.SetBool("Knife", false);
        }
    }

    public void StartResetPosition()
    {
        StartCoroutine(ResetPosition());
    }

    private IEnumerator ResetPosition()
    {
        Vector3 initPos = transform.position;

        // If you want slower movement increase time to lerp;
        float timeToLerp = 1, time = 0;

        while (time < timeToLerp)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(initPos, startPos, time/ timeToLerp);

            yield return null;
        }

        animator.SetTrigger("MoveDone");
    }

    public void ShowFire()
    {
        foreach (GameObject f in fire)
        {
            f.SetActive(true);
        }
    }

    public void EndFire()
    {
        animator.SetBool("Candle", false);
        foreach (GameObject f in fire)
        {
            f.SetActive(false);
        }
    }
}
