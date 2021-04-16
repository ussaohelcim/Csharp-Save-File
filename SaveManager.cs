// Script made by Michel Sousa
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]//this will make the class Save serializable
public class Save
{
    /*
    * Here you put everything that you wanna save, maybe some functions as well to modify your save.
    * This can be everything you want.
    */
}
public class SaveManager
{
    string output = "";//here you put the path and name of the file that you wanna create. ex:"C:\saves\save.dat". The file format doesnt matter, as the file will be a binary. 

    public void SaveFile(Save file)
    {
        FileStream stream = new FileStream(output, FileMode.Create);
        BinaryFormatter binary = new BinaryFormatter();

        try { binary.Serialize(stream, file);}
        catch (SerializationException e){ throw e;}
        finally { stream.Close();}
    }
    public void LoadFile()
    {
        if(File.Exists(output))
        {//check if file exist and load it
            Save file;
            FileStream stream = new FileStream(output, FileMode.Open);

            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                file = (Savegame)bin.Deserialize(stream);
            }
            catch (SerializationException e){ throw e;}
            finally{ stream.Close();}

            return file;
        }
        else
        {
            //Here you will create a new file
            Save file = new Savegame();
            return file;
        }
    }
}