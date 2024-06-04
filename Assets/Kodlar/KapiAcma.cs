using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KapiAcma : MonoBehaviour
{
    private Animator anim;
    private bool IsAtDoor=false;
    [SerializeField]private TextMeshProUGUI CodeText;
    string CodeTextValue =""; 
    public string safeCode;
    public GameObject CodePanel;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CodeText.text=CodeTextValue;

        if(CodeTextValue==safeCode){
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }
        if(CodeTextValue.Length >= 6)
        {
            CodeTextValue = "";

        }

        if(Input.GetKey(KeyCode.E)&& IsAtDoor == true){
            CodePanel.SetActive(true);

        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            IsAtDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       IsAtDoor =false;
       CodePanel.SetActive(false);
    }

    public void AddDigit(string digit){
        CodeTextValue += digit;
    }




}
