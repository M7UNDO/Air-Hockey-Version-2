using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawn : MonoBehaviour
{
    public GameObject puckPrefab;
    public Rigidbody2D puckRb;
    public PuckScript puckScript;

    private void Start()
    {
        puckRb = puckScript.rb;
        SpawnPuck();
    }
    public void SpawnPuck()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        Instantiate(puckPrefab, transform.position, Quaternion.identity, transform);
    }

    public void RespawnPuckAI()
    {
        gameObject.transform.position = new Vector3(0, -3.5f, 0);
        Instantiate(puckPrefab, transform.position, Quaternion.identity, transform);
    }

    public void RespawnPuckPlayer()
    {
        gameObject.transform.position = new Vector3(0, 3.5f, 0);
        Instantiate(puckPrefab, transform.position, Quaternion.identity, transform);
    }

    public IEnumerator ResetPuck(bool didAIScore)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(puckPrefab, transform.position, Quaternion.identity, transform);
    }

}
