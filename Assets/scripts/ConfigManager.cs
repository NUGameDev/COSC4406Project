using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
public class ConfigManager : MonoBehaviour {
	public string configdata;
	public string line;
	public string Load(string tag)//function used pull values from the config file
	{
		string filename = Application.dataPath +"/config.ini"; //The path of the config file
		StreamReader theReader = new StreamReader(filename, Encoding.Default);//Reader used to read in lines
		using (theReader)
		{
			do//loops until end of file
			{
				do //loops until tag is found
				{
					line = theReader.ReadLine();//reads in a line
					if (line == tag)//finds tag of variable
					{
						line = theReader.ReadLine();//loads next value after tag
						break;//breaks the loop
					}
				}
				while(1==1);
				if (line != null)//makes sure the line isn't null
				{
					configdata = line;
					theReader.Close();//closes the reader
					return configdata;//returns the requested value from the config file
				}
			}
			while (line != null);    
			theReader.Close();
			return "";
		}
	}
}
