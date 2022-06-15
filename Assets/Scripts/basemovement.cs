using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class basemovement : MonoBehaviour
{

    [SerializeField]
    private GameObject ball;
    public ARSessionOrigin aso;
    public ARRaycastManager _ray;

    public List<ARRaycastHit> rayhits = new List<ARRaycastHit>();

    public GameObject cube;
    private GameObject instantiatedcube;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject _lean;

    public float rotatespeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButton(0))
        {
            bool col = aso.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, rayhits);
            if (col)
            {       
                if (instantiatedcube == null)
                {
                    instantiatedcube = Instantiate(cube);
                    _lean.SetActive(true);
                    foreach (var plane in aso.GetComponent<ARPlaneManager>().trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }
                    aso.GetComponent<ARPlaneManager>().enabled = false;
                }
                instantiatedcube.transform.position = rayhits[0].pose.position;

                if (instantiatedcube != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Sphere")
                        {
                            Instantiate(ball, instantiatedcube.transform.position + new Vector3(0, 0, 1), Quaternion.identity);
                        }   
                    }
                }
            }
            }

        }

      
        
    }

   

