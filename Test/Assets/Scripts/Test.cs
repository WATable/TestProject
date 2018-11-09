using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{

    // Use this for initialization
    public Text text;

    private void Awake()
    {
        StartCoroutine(StartLoad("cfg/skill_1001.txt"));
    }

    IEnumerator StartLoad(string filename)
    {
        CheckUrl(filename);
        WWW www = new WWW(Application.streamingAssetsPath + "/" + filename);
        yield return www;
        Debug.Log("错误号:" + www.error + "\t" + www.url);

        if (!www.isDone)
        {
            Debug.LogError("www 下载错误");
        }
        else
        {
            WritePer(Application.persistentDataPath + "/" + filename, www.bytes);
            yield return new WaitForEndOfFrame();
            string info = PluginCreate.test_read_cfg(Application.persistentDataPath + "/cfg").ToString();
            Debug.Log(info + "===============>>>>>");
            text.text = "读取文件信息:" + info;
        }
    }
    public void WritePer(string url, byte[] data)
    {
        Debug.Log("路径=======>>>" + url);
        using (FileStream sv = new FileStream(url, FileMode.OpenOrCreate))
        {
            sv.Write(data, 0, data.Length);
            sv.Close();
            sv.Dispose();
        }
    }

    public void CheckUrl(string url)
    {

        Debug.Log("检测目录====>>>" + url);
        int index = url.IndexOf("/");

        if (index == -1)
        {
            return;
        }

        if (index == 0)
        {
            CheckUrl(url.Substring(1));
            return;
        }
        else
        {
            Debug.Log(Application.persistentDataPath + "/" + url.Substring(0, index));
            if (!Directory.Exists(Application.persistentDataPath + "/" + url.Substring(0, index)))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + url.Substring(0, index));
            }
            CheckUrl(url.Substring(index + 1));
        }



    }
    //1,1,2,3,5,8,13

    public void GetLamba(int length)
    {
        int index = 1;
        while (index != length)
        {

        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
    }
}
