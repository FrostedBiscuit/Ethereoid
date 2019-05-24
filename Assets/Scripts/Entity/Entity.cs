using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Field
    [SerializeField]
    protected GameObject model;

    public bool selfDistruct = false;

    public float speed = 2f;
    public float destroyAfter = 5f;
    public float rotationRate = 0.2f;

    // Use this for initialization
    public virtual void Start()
    {
        if(selfDistruct)
            StartCoroutine(Destroy(destroyAfter));

        InvokeRepeating("Rotate", rotationRate, rotationRate);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// Self-Destruct
    /// </summary>
    /// <param name="delay">delay self-destruct by 'delay' seconds</param>
    /// <returns></returns>
    public IEnumerator Destroy(float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        if (Data.Lives > 0)
            Destroy(gameObject);
    }

    public virtual void Rotate()
    {
        float randomX = Random.Range(20f, 60f);
        float randomY = Random.Range(20f, 60f);
        float randomZ = Random.Range(20f, 60f);

        Vector3 rotation = new Vector3(randomX, randomY, randomZ);
        model.transform.Rotate(rotation);
    }
}