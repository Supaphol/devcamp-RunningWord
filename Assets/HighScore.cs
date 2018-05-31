using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

[DataContract]
public class HighScore : MonoBehaviour {
	[DataMember]
	public int[] scores = new int[10];

	[DataMember]
	public string[] names = new string[]{"FluffyCat","FluffyCat","FluffyCat","FluffyCat","FluffyCat",
	"FluffyCat","FluffyCat","FluffyCat","FluffyCat","FluffyCat"};
	

	public static void SaveHighScore(HighScore data){
		FileStream file = File.Create(Application.persistentDataPath + "/high score.dat");
		DataContractSerializer ds = new DataContractSerializer(Type.GetType("HighScore"));
		MemoryStream streamer = new MemoryStream();

		ds.WriteObject(streamer, data);
		streamer.Seek(0, SeekOrigin.Begin);
		file.Write(streamer.GetBuffer(), 0 , streamer.GetBuffer().Length);
		file.Close();

		string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0","")).ToString();
		Debug.Log(result);
	}


	public static HighScore LoadHighScore(){
		FileStream file;
		file = File.OpenRead(Application.persistentDataPath + "/high score.dat");
		DataContractSerializer ds = new DataContractSerializer(Type.GetType("HighScore"));
		MemoryStream streamer = new MemoryStream();
		byte[] bytes = new byte[file.Length];
		file.Read(bytes,0,(int)file.Length);
		streamer.Write(bytes,0,(int)file.Length);
		streamer.Seek(0, SeekOrigin.Begin);
		HighScore temp = (HighScore)ds.ReadObject(streamer);
		file.Close();
		return temp;
	}


	public void Add(int value ,string name, HighScore other){
		if(value > other.scores[9]){
			other.scores[9] = value;
			other.names[9] = name;
    int length = other.scores.Length;
	

    int temp = other.scores[0];
	string tempName = other.names[0];

    for (int i = 0; i < length; i++)
    {
        for (int j = i+1; j < length; j++)
        {
            if (other.scores[i] < other.scores[j])
            {

                temp = other.scores[i];
				tempName = other.names[i];
                other.scores[i] = other.scores[j];
				other.names[i] = other.names[j];

                other.scores[j] = temp;
				other.names[j] = tempName;
            }
        }
    }
	}
	}
	// Use this for initialization
	void Start () {
		SaveHighScore(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
