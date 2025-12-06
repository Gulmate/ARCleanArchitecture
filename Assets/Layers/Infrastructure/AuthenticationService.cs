using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;

public class AuthenticationService : IAutentication
{
    [Inject]
    private readonly IFileHandlerService _logger;
    public async Task<bool> Login(string email, string password)
    {
        string json = $"{{ \"email\": \"{email}\", \"password\": \"{password}\" }}";

        return await SendJsonPostRequest("https://localhost:19955/api/Auth/login", json);
    }



    private async Task<bool> SendJsonPostRequest(string URL, string json)
    {
        using (UnityWebRequest www = UnityWebRequest.Post( URL, json, "application/json"))
        {
            await www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error While Sending: " + www.responseCode);
                _logger.SaveLog("Login Attempt failed: " + www.error);
                return false;
            }
            else
            {
                _logger.SaveLog("Successful login");
                return true;
            }
        }
    }

    public async Task<bool> Register(string email, string password,string firstName, string lastName, string role)
    {
        string json = $"{{ \"email\": \"{email}\", \"password\": \"{password}\", \"firstName\": \"{firstName}\", \"lastName\": \"{lastName}\", \"firstName\": \"{lastName}\" }}";
        return await SendJsonPostRequest("https://localhost:19955/api/Auth/register", json);
    }

    private bool DummyLoginCheck(string username, string password)
    {
        if (username != "Admin" || password != "admin")
        {
            _logger.SaveLog("Login Attempt failed: Wrong username or password");
            return false;
        }
        else
        {
            _logger.SaveLog("Successful login");
            return true;
        }
    }

    private void DummyRegisterCheck(string username, string password)
    {
        _logger.SaveLog("Register Attempt failed: Error 500 Internal server error");
    }   
}
