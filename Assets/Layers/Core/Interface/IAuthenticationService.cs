using UnityEngine;

public interface IAutentication
{
    public bool Login(string username, string password);
    public void Register(string username, string password);
}
