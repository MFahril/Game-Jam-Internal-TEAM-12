using System.Collections;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3f;
    private bool isAttacking = false;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance > 0.5f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
        else
        {
            // Jika playerTransform sudah null, hentikan pergerakan musuh
            StopAllCoroutines(); // Hentikan semua coroutine serangan
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        while (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= 0.5f)
        {
            playerTransform.GetComponent<Stats>().TakeDamage(2);
            yield return new WaitForSeconds(0.5f);
        }
        isAttacking = false;
    }
}
