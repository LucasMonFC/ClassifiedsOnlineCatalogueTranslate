using MSCLoader;
using UnityEngine;

using static I386PC.I386API;

namespace I386PC;

public class Del {

    public void load() {
        Texture2D t = new Texture2D(2048, 2048);
        t.LoadImage(_386PC.Properties.Resources.FLOPPY_DEL);

        I386Command c = new I386Command(enter, null);
        i386.AddCommand("del", c);

        I386Diskette d = i386.CreateDiskette(new Vector3(-9.848896f, 0.2180641f, 13.98685f), new Vector3(270f, 271f, 0f));
        d.LoadExe("del", 320);
        d.SetTexture(t);
    }

    private bool enter() {
        bool invalid = true;

        if (i386.argv.Length > 1) {
            GameObject g = GameObject.Find("COMPUTER/Memory");
            PlayMakerArrayListProxy c_drive = g.GetArrayListProxy("C");
            invalid = !c_drive.Remove(i386.argv[1], "", true);
        }
        
        if (invalid) {
            i386.POS_WriteNewLine("Could not find file");
        }
        else {
            i386.POS_WriteNewLine($"Deleted {i386.argv[1]}");
        }

        return true; // exit
    }
}
