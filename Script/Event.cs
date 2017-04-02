using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class Event : MonoBehaviour {
    public static bool on_event=true;

    

    public int index = 0;
    public int i,
               j;
    public GameObject pic_monster;
    public Sprite[] sprite_monster;
    public Text textBox;
    public Button button1;
    public Button button2;
    public int[] id;
    public GameObject buttonNext_AttributeCH;
    xml docxml = new xml();
    List<xml.Conversation> conversation;

    private bool canselect = false;

	void Start () {
        conversation = new List<xml.Conversation>();
        if (SceneManager.GetActiveScene().name == "Attribute_ch")
        {
            id = new int[] { 7, 13, 20, 21, 22, 37, 38, 43, 52, 60, 70, 75 };
        }
        conversation = docxml.loadDataFromXML(id);
        button1.interactable = false;
        button2.interactable = false;
        i = 0;
        j = 0;
    }
	void Update () {
        Debug.Log("e " + Score.i + "i " + Score.n + "n " + Score.s + "s " +
            Score.t + "t " + Score.f + "f " + Score.p + "p " + Score.j + "j ");
        if (on_event == true) {
            ShowText();
        }
	}
    public void chose_choice1()
    {
        if (canselect == true)
        {
            //button_choice[0].GetComponentInChildren<Text>().text = "";
            nextTxt();
        }
    }
    public void chose_choice2()
    {
        if (canselect == true)
        {
            //button_choice[1].GetComponentInChildren<Text>().text = "";
            nextTxt();
        }
    }
    void showImgMonster()
    {
        if (SceneManager.GetActiveScene().name != "Attribute_ch"&& SceneManager.GetActiveScene().name != "Battle_Scene")
        {
    
                pic_monster.GetComponent<Image>().sprite = sprite_monster[conversation[i].getPicture()];
            
        }
    }
    string temp_txt_delay = "";
    float txttime = 0;
    int change = 1,
        indexOfText = 0;


    //old parameter string intxt,int[] ii
    void ShowText()
    {
        /*
        string newtext = "";
        char[] cutext;
        bool checkdol = false;
        */
        // change $$ to player name
        /*
            if (intxt.Contains("$$"))
            {
                cutext = intxt.ToCharArray();
                for (int j = 0; j < cutext.Length; j++)
                {
                    if (cutext[j] != '$')
                    {
                        newtext += cutext;
                    checkdol = true;
                    }
                }
            }
        

        if (checkdol == false)
        {
            temp_txt = intxt.ToCharArray();
        }
        else
        {
            temp_txt = newtext.ToCharArray();
        }
        */
        // change $$ to player name

        //txt.text referance to text box
            txttime += Time.deltaTime;
            if(!canselect){
                if (txttime > 0.03f) {
                    if (i < conversation.Count) {
                        if (conversation[i].getType() == 'e' || conversation[i].getType() == 's' || conversation[i].getType() == 't' || conversation[i].getType() == 'j'   ) {
                            if (indexOfText < conversation[i].getChoiceByIndex(j).Length) {
                                temp_txt_delay += conversation[i].getChoiceByIndex(j)[indexOfText].ToString();
                                textBox.text =  temp_txt_delay;
                            showImgMonster();
                            indexOfText++;
                            } else {
                        
                                //select
                                canselect = true;
                                
                                button1.GetComponentInChildren<Text>().text = conversation[i].getChoiceByIndex(1);
                                button2.GetComponentInChildren<Text>().text = conversation[i].getChoiceByIndex(2);
                                button1.interactable = true;
                                button2.interactable = true;
                                // button_choice[k].SetActive(true);
                                // button_choice[k].GetComponentInChildren<Text>().text = conversation[0].getChoiceByIndex(k+1);
                            }   
                        }
                    }
                }
            
            }
    }
    //change question
    void nextTxt()
    {
        i++;
        indexOfText = 0;
        if(i <= conversation.Count){
            i++;
            j = 0;
            Debug.Log("i : " + i);
            Debug.Log("count : " + conversation.Count);
            temp_txt_delay = "";
            indexOfText = 0;
            button1.interactable = false;
            button2.interactable = false;
            textBox.text =  "";
            button1.GetComponentInChildren<Text>().text = "";
            button2.GetComponentInChildren<Text>().text = "";
            if(i >= conversation.Count)
            {
                Debug.Log("next setup");
                Destroy(button1);
                Destroy(button2);
                if (SceneManager.GetActiveScene().name == "Attribute_ch")
                {
                    buttonNext_AttributeCH.SetActive(true);
                    Debug.Log("next setup");
                }
                if (SceneManager.GetActiveScene().name == "Battle_Scene")
                {
                    SceneManager.LoadScene("Game_Shcool");
                }
            }
            
            canselect = false;
        }else{
            
            on_event = false;
        }
    }

}