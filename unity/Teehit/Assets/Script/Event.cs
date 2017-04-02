﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Event : MonoBehaviour {
    public static bool on_event=true;
    public int index = 0;
    public GameObject[] button_choice;
    public int[] id = {7, 13, 20, 21, 22, 37, 38, 43, 52, 60, 70 ,75};
    public int i,
               j;
    public Text textBox;
    xml docxml=new xml();
    List<xml.Conversation> conversation;

    private bool canselect = false;

	void Start () {
        conversation = new List<xml.Conversation>();
        conversation = docxml.loadDataFromXML(id);
        i = 0;
        j = 0;
    }
	void Update () {
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

            if (txttime > 0.03f)
            {

            if (i < conversation.Count) {

                if (conversation[i].getType() == 'e' || conversation[i].getType() == 's' || conversation[i].getType() == 't' || conversation[i].getType() == 'j'   )
                {
                    if (indexOfText < conversation[i].getChoiceByIndex(j).Length)
                    {
                        temp_txt_delay += conversation[i].getChoiceByIndex(j)[indexOfText].ToString();
                        textBox.text =  temp_txt_delay;
                        indexOfText++;
                    }
                    else {
                        /* 
                        //select
                        canselect = true;
                        for (int k=0; k < button_choice.GetLength(0); k++)
                        {

                            button_choice[k].SetActive(true);
                            button_choice[k].GetComponentInChildren<Text>().text = conversation[0].getChoiceByIndex(k+1);
                        }
                        */
                    }   
                }
                }
            }
            
    }
    //change question
    void nextTxt()
    {
        if(i<id.Length)
        {
            i++;
        }
    }

}