using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obs : MonoBehaviour
{
    [SerializeField] GameObject[] fruitprefab;
    [SerializeField] float secondspawn = 0.5f;
    [SerializeField] float mintras;
    [SerializeField] float maxtras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fruitspawn());
    }

    IEnumerator fruitspawn()
    {
        while (true)
        {
            var wanted = Random.Range(mintras, maxtras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(fruitprefab[Random.Range(0, fruitprefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondspawn);
            Destroy(gameObject, 5f);


        }
    }
}
