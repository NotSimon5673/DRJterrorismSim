using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shoot : MonoBehaviour
{
    public float scaleLimit = 2.0f;    
    public float z = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 shootPos = Vector3.forward  * 2;
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
         RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetButtonDown("Fire1"))
        {


            for(int i = 0; i < 20; i++){
                ShootRay();
            }
             
        }
    }
    void ShootRay() {
         //  Try this one first, before using the second one
         //  The Ray-hits will form a ring          
         //  The Ray-hits will be in a circular area
         float randomRadius = Random.Range( 0, scaleLimit );        
         
         float randomAngle = Random.Range ( 0, 2 * Mathf.PI );
         
         //Calculating the raycast direction
         Vector3 direction = new Vector3(
             randomRadius * Mathf.Cos( randomAngle ),
             randomRadius * Mathf.Sin( randomAngle ),
             z
         );
         
         //Make the direction match the transform
         //It is like converting the Vector3.forward to transform.forward
         direction = transform.TransformDirection( direction.normalized * -1 );
         
         //Raycast and debug
         Ray r = new Ray( transform.position, direction );
         RaycastHit hit;        
         if( Physics.Raycast( r, out hit ) ) {
             Debug.DrawLine( transform.position, hit.point, Color.red, 52, false );    
             Debug.Log("hit");
         }    
     }
}
