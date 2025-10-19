using System.Collections;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Test1
{

    [UnityTest]
    public IEnumerator TestLoginPresenter()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        Assert.IsNotNull(GameObject.Find("LoginPresenter"), "LoginPresenter nem jön létre");
    }

    [UnityTest]
    public IEnumerator TestLoginViewWrongCredentials()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        if (File.Exists(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
        {
            File.Delete(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        }

        GameObject.Find("UserNameInput").GetComponent<TMPro.TMP_InputField>().text = "testuser";
        GameObject.Find("PasswordInput").GetComponent<TMPro.TMP_InputField>().text = "password";
        GameObject.Find("LoginButton").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1f);

        FileAssert.Exists(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        Assert.That(File.ReadAllText(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), Does.Contain("Login Attempt failed: Wrong username or password"));
        File.Delete(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

    }

    [UnityTest]
    public IEnumerator TestLoginViewRightCredentials()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;

        if (File.Exists(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
        {
            File.Delete(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        }

        GameObject.Find("UserNameInput").GetComponent<TMPro.TMP_InputField>().text = "Admin";
        GameObject.Find("PasswordInput").GetComponent<TMPro.TMP_InputField>().text = "admin";
        GameObject.Find("LoginButton").GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1f);

        FileAssert.Exists(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        Assert.That(File.ReadAllText(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt"), Does.Contain("Login Attempt failed: Error 500 Internal server error"));
        File.Delete(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
    }

    [Test]
    public void TestLog()
    {
        FileHandlerService fileHandler = new FileHandlerService();
        fileHandler.SaveLog("Test log message");
        string content=File.ReadAllText(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        Assert.That(content, Does.Contain("Test log message"));
        File.Delete(Application.dataPath + "/Logs/log" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
    }

    
}
