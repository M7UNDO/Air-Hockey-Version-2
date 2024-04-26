using System.Collections;
using UnityEngine;

public class PortalManager : MonoBehaviour

{
    public Transform APos;
    public Transform BPos;

    [SerializeField] GameObject Puck;

    [SerializeField] GameObject PortalA;
    [SerializeField] GameObject PortalB;
    private Vector2 entryVelocity;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Portal A"))
        {

            entryVelocity = Puck.GetComponent<Rigidbody2D>().velocity;


            Puck.SetActive(false);
            transform.position = BPos.position;
            Puck.SetActive(true);


            Rigidbody2D rb = Puck.GetComponent<Rigidbody2D>();
            rb.velocity = CalculateExitVelocity(entryVelocity);

            PortalA.SetActive(false);
            PortalB.SetActive(false);

            StartCoroutine(PortalReset());
        }

        


    }

    private IEnumerator PortalReset()
    {
        yield return new WaitForSecondsRealtime(10);
        PortalA.SetActive(true);
        PortalB.SetActive(true);

       
        Vector3 temp = PortalA.transform.position;
        PortalA.transform.position = PortalB.transform.position;
        PortalB.transform.position = temp;

    }


    private Vector2 CalculateExitVelocity(Vector2 entryVelocity)
    {

        return -entryVelocity;
    }
}





//if(col.CompareTag("Portal A"))
//{


//Puck.SetActive(false);
//transform.position = BPos.transform.position;
//Puck.SetActive(true);

//}

//if (col.CompareTag("Portal A"))
//{
//Puck.SetActive(false);
//transform.position = BPos.transform.position;
//Puck.SetActive(true);
//}


