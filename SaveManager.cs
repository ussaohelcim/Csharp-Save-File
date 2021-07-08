using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
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
        catch (Exception e){ throw e;}
        finally { stream.Close();}
    }
    public Save LoadFile()
    {
        if(File.Exists(output))
        {//check if file exist and load it
            Save file;
            FileStream stream = new FileStream(output, FileMode.Open);

            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                file = (Save)bin.Deserialize(stream);
            }
            catch (Exception e){ throw e;}
            finally{ stream.Close();}

            return file;
        }
        else
        {
            //Here you will create a new file
            Save file = new Save();
            SaveFile(file);
            return file;
        }
    }
}
