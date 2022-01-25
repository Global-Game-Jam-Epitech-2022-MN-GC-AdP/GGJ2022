using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPChandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private GameObject prefab;
    private GameObject prefab_cp;
    public string Name;
    public string Dialog;
    public string choice1;
    public string choice2;
    public string endDialog;
    private bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        sp.enabled = false;
        isTalking = false;
    }

    public void showKey(int s)
    {
        if (s == 1) {
            sp.enabled = true;
            sp.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, sp.transform.position.z);
        } else {
            sp.enabled = false;
        }
    }

    public void triggerDialog()
    {
        if (isTalking == false) {
            Debug.Log("Talking...");
            isTalking = true;
            prefab_cp = (GameObject)Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            // Setting text to prefab   
            var script = prefab_cp.GetComponent<dialog>();
            //script.setText(Dialog);
            sp.enabled = false;
        }
    }

    public bool isAvailable()
    {
        return isTalking;
    }

    // Update is called once per frame
    void Update()
    {
        // If player quits the dialog
        if (Input.GetKeyDown(KeyCode.Q) && isTalking) {
            Destroy(prefab_cp, 0f);
            isTalking = false;
        }
    }
}
