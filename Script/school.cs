using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class school : MonoBehaviour {

	public GameObject button1;
	public GameObject button2;
	public GameObject textBox;
	public GameObject image;
	public int step,
				i,
				j,
				k;
	private xml docxml = new xml();
    private List<xml.Conversation> conversation;

	private bool canselect = false;

	string temp_txt_delay = "";
    float txttime = 0;
    int change = 1,
        indexOfText = 0;
	// Use this for initialization
	void Start () {
		step = 0;
		conversation = new List<xml.Conversation>();
        int[] id = {83};
        conversation = docxml.loadDataFromXML(id);
		i = 0;
		j = 0;
		k = 0;
        //button1.SetActive(false);
        //button2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

		if(step == 0){
			txttime += Time.deltaTime;
			if (txttime > 0.03f) {
						
				if (conversation[i].getType() == 'c' ) {
					if (indexOfText < conversation[i].getChoiceByIndex(j).Length) {
							temp_txt_delay += conversation[i].getChoiceByIndex(j)[indexOfText].ToString();
							textBox.GetComponentInChildren<Text>().text =  temp_txt_delay;
							indexOfText++;
					} else{
						if (Input.GetKey(KeyCode.Space))
                    {
						    
						    textBox.GetComponentInChildren<Text>().text  = "";	
							textBox.SetActive(false);
							image.SetActive(false);
							temp_txt_delay = "";
							indexOfText = 0;
							step = 1;		
							//i = 2;		
							//j = 0;			
							
                    }
					}
				}
					
			}
		}
        if (step == 2){
       
            if (!canselect){
                if (txttime > 0.03f) {
                         Debug.Log(conversation[0].getType());
                    if (i < conversation.Count) {
                        if (conversation[i].getType() == 'e' || conversation[i].getType() == 's' || conversation[i].getType() == 't' || conversation[i].getType() == 'j'
                            ) {
                            Debug.Log("sssssssssss");
                            if (indexOfText < conversation[i].getChoiceByIndex(j).Length) {
                                temp_txt_delay += conversation[i].getChoiceByIndex(j)[indexOfText].ToString();
                                textBox.GetComponentInChildren<Text>().text =  temp_txt_delay;
                                indexOfText++;
                                Debug.Log("sssssssssss");
                            } else {

                                //select
                                Debug.Log ("step2");
                                
                                canselect = true;
                                button1.GetComponentInChildren<Text>().text = conversation[i].getChoiceByIndex(1);
                                button2.GetComponentInChildren<Text>().text = conversation[i].getChoiceByIndex(2);
                                //button1.interactable = true;
                                // button2.interactable = true;
                                button1.SetActive(true);
                                button2.SetActive(true);

                                // button_choice[k].SetActive(true);
                                // button_choice[k].GetComponentInChildren<Text>().text = conversation[0].getChoiceByIndex(k+1);
                            }   
                        }
                    }

                }
            
            }
		}
        if (step == 3)
        {
            SceneManager.LoadScene("Game_Shcool");
        }

	}
    public void chose_choice1()
    {
        if (canselect == true)
        {
            //button_choice[0].GetComponentInChildren<Text>().text = "";
            step = 3;
        }
    }
    public void chose_choice2()
    {
        if (canselect == true)
        {
            //button_choice[1].GetComponentInChildren<Text>().text = "";
            step = 3;
        }
    }
    void showText()
    {

		txttime += Time.deltaTime;
			if (txttime > 0.03f) {
						
				if (conversation[i].getType() == 'c' ) {
					if (indexOfText < conversation[i].getChoiceByIndex(j).Length) {
							temp_txt_delay += conversation[i].getChoiceByIndex(j)[indexOfText].ToString();
							textBox.GetComponentInChildren<Text>().text =  temp_txt_delay;
							indexOfText++;
					} else{
						if (Input.GetKey(KeyCode.Space))
                    {
						    
						    textBox.GetComponentInChildren<Text>().text  = "";	
							temp_txt_delay = "";
							indexOfText = 0;
							step = 1;		
							i = 2;		
							j = 0;			
							
                    }
					}
				}
					
		}
	}

}

