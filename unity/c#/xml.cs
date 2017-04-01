using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml.Linq;
using System;
public class xml : MonoBehaviour {

    // Use this for initialization
    void Start () {
      int[] nums = {1,2};
      List<Conversation> conversations = loadDataFromXML(nums);

      for(int i = 0 ; i < conversations.Count; i++){
        Debug.Log(conversations[i].getType());
        Debug.Log(conversations[i].getChoices()[0]);
      }
      
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    // class for conversation object
    public class Conversation{
      char type;
      string[] choice;

      public Conversation(char type, string[] choice){
        this.type = type;
        this.choice = choice;
      }

      // return type
      public char getType(){
        return type;
      }
      // return choice by index
      public string getChoiceByIndex(int index){
        return choice[index];
      }
      // return array of choice
      public string[] getChoices(){
        return choice;
      }
    }


    // check other id with array of id from screen
    private int checkId(int[] ids, int otherId){
      for(int i = 0 ; i < ids.Length ; i++){
        if(ids[i] == otherId){
          Debug.Log("Id : " + otherId);
          return otherId;
        }
      }
      return 0;
    }


    public List<Conversation> loadDataFromXML(int[] ids) {

      List<Conversation> conversations = new List<Conversation>();
      string[] tempTxt = null;
       // load xml file
      XDocument doc = XDocument.Load(Application.dataPath + "/Resources/XMLFile1.xml"); 

      var bok = from temp in doc.Descendants("Data").Descendants("conversation")
                  select new
                  {
                      id = temp.Attribute("id").Value,
                      type = temp.Attribute("type").Value,
                      text = temp.Element("text").Value

                  };

      foreach (var item in bok) {

        int index = checkId(ids, Int32.Parse(item.id));

        //  if equl 0 not add conversation 
        if(index != 0  ){
          tempTxt = item.text.Split('|');
          Conversation conversation = new Conversation(item.type[0], tempTxt);
          //Debug.Log(conversation.getType());
          //Debug.Log(conversation.getChoices());
          conversations.Add(conversation);
        }
        
      }
      
      return conversations;
        
    }
    /*
    public void please_save(int id)
    {
        
        XElement save_player = XElement.Load("..\\..\\save.xml");
        save_player.ReplaceAll(new XElement("player", new XAttribute("n", 1),
                            new XElement("level", player.Mp),
                            new XElement("hp", player.Hp)
                        ));
        save_player.Save("..\\..\\save.xml");
        

        XElement save_player = XElement.Load(Application.dataPath + "/Resources/XMLFile1.xml");
        save_player.Add(new XElement("player", new XAttribute("n", id)//,
                            //new XElement("mp", player.Mp),
                           // new XElement("hp", player.Hp)
                        ));
        save_player.Save(Application.dataPath + "/Resources/XMLFile1.xml");
    }
    */
}
