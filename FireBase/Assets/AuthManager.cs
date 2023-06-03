using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase.Extensions;
using Unity.VisualScripting;

public class AuthManager : MonoBehaviour
{
    public TMP_Text logText;
    public Button signInButton, singUpButton;
    public TMP_InputField email, password;

    public virtual void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {

            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    public void OnClickSignIn()
    {
        Debug.Log("clicked SignIn");
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Sign In Canceled");
                logText.text = "SignInWithEmailAndPasswordAsync was canceled.";
                return;
            }

            if (task.IsFaulted)
            {
                Debug.Log("Sign In Failed");
                logText.text = task.Exception.ToString();
                return;
            }

            Debug.Log("Sign In Success");
            Firebase.Auth.FirebaseUser user = task.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", user.DisplayName, user.UserId);
        });
    }

    public void OnClickSignup()
    {
        Debug.Log("clicked Signup");
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Signup Canceled");
                logText.text = "SignInWithEmailAndPasswordAsync was canceled.";
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("Signup Failed");
                logText.text = task.Exception.ToString();
                return;
            }

            Debug.Log("Signup Success");
            Firebase.Auth.FirebaseUser newUser = task.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }
}