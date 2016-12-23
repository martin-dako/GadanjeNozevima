using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	private Camera fpsCamera;
	public int KnifeRdy = 1;
	public float KnifeSpeed = 1f;
	public Vector3 knifeHit;
	public GameObject KnifePrefab;
	private LineRenderer line;
	public Vector3 direction;
    public GameObject Knife;
    private Vector3 heading;
    private Vector3 mouseInput;
    private Transform parentTransform;
    public  Text HitText;
    public  Text MissText;
    private int countHit;
    private int countMiss;
    private Transform tempTransform;
   


	// Use this for initialization
	void Start () 
	{

        parentTransform = GetComponentInParent<Transform>();
        fpsCamera = GetComponent<Camera> ();
		line = GetComponent<LineRenderer> ();
        Knife = Instantiate(KnifePrefab,  new Vector3(0.8f,0.5f,1.2f), Quaternion.Euler(0,0,180));
        Knife.SetActive(true);
        Knife.transform.parent = transform; 
        
    }
	
	// Update is called once per frame
	void Update () 
	{

        //print(fpsCamera.transform.forward);
		if ( Input.GetButtonDown("Fire1") == true && KnifeRdy == 1)
		{
			RaycastHit hit;
			Vector3 rayCastOrigin = fpsCamera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f));

            //line.SetPosition(0, Knife.transform.position);

            if (Physics.Raycast (rayCastOrigin, fpsCamera.transform.forward, out hit, 100f)) 
			{
                
                knifeHit = hit.point;
                heading = knifeHit - Knife.transform.position;
                direction = heading.normalized;
                //line.SetPosition(1, knifeHit);

                //print(direction);

            } else 
			{


                direction = rayCastOrigin + fpsCamera.transform.forward * 20 - Knife.transform.position;
                direction = direction.normalized;
                //line.SetPosition(1, rayCastOrigin + fpsCamera.transform.forward * 20 );
                
                //print(direction);
            }
			
            Knife.transform.parent = null;
            Knife.GetComponent<KnifeScript>().InitMove = true;
            KnifeRdy = 0;



            //KnifeStart.GetComponent < Renderer >().enabled = !KnifeStart.GetComponent<Renderer>().enabled;
            //temp = Instantiate (KnifePrefab, Knife.transform.position,Quaternion.LookRotation(heading)); 
            //temp.transform.Rotate(Vector3.right,90);

        }	

	}

   


}
