using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Xml.Linq;
using System;
public class xml : MonoBehaviour {

    // Use this for initialization
    void Start () {

      
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    // class for conversation object
    public class Conversation {
        int id;
        char type;
        int picture;
        string[] choice;

        public Conversation(char type, string[] choice, int pic, int ids) {
            this.type = type;
            this.choice = choice;
            this.picture = pic;
        }

        // return type
        public int getID()
        {
            return id;
        }
        public char getType() {
            return type;
        }
        public int getPicture()
        {
            return picture;
        }
        // return choice by index
        public string getChoiceByIndex(int index) {
            return choice[index];
        }
        // return list of choice
        public string[] getChoices() {
            return choice;
        }

        // return size of list of choice
        public int getSizeListChoice() {
            return choice.Length;
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
                      text = temp.Element("text").Value,
                      picture= temp.Element("picture").Value
                  };

      foreach (var item in bok) {

        int index = checkId(ids, Int32.Parse(item.id));

        //  if equl 0 not add conversation 
        if(index != 0  ){
          tempTxt = item.text.Split('|');
          Conversation conversation = new Conversation(item.type[0], tempTxt,Int32.Parse(item.picture),Int32.Parse(item.id));
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
