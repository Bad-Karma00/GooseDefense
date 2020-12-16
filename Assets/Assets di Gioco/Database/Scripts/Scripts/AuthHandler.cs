using System.Collections.Generic;
using UnityEngine;
using FullSerializer;
using Proyecto26;
using TMPro;
using UnityEngine.SceneManagement;


public class AuthHandler : MonoBehaviour
{
    private const string apiKey = "AIzaSyBjJ5mu6w_7z-2tx_lQD-XJLkknNBPwcQg"; // You can find this in your Firebase project settings

    private static fsSerializer serializer = new fsSerializer();

    public delegate void EmailVerificationSuccess();
    public delegate void EmailVerificationFail();

    public static string idToken; // Key that proves the request is authenticated and the identity of the user
    public static string userId;
    public static string identificativo;
    public static string token;
    public static User utente = new User("null", 0);
   

    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;

    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_Text warningRegisterText;

    [Header("Reset")]
    public TMP_InputField passresetField;
    public TMP_Text warningResetText;

   
    public void Register()
    {
        SignUp(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text);
        
    }
    public void Login()
    {
        SignIn(emailLoginField.text, passwordLoginField.text);
    }

    public void Reset() {
        ResetPass.Resetta(passresetField.text);
    }

    /// <summary>
    /// Sings up user with Firebase Auth using Email and Password method
    /// Uploads the user object to Firebase Database
    /// Sends verification email
    /// </summary>
    /// <param name="email"> User's email </param>
    /// <param name="password"> User's password </param>
    /// <param name="user"> User object, which gets uploaded to Firebase Database </param>
    public static void SignUp(string email, string password, string username)
    {
        User user = new User(username, 1);
        var payLoad = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/signupNewUser?key={apiKey}",
            payLoad).Then(
            response =>
            {
            Debug.Log("Created User");
               
                var responseJson = response.Text;

                // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
                // to serialize more complex types (a Dictionary, in this case)
                var data = fsJsonParser.Parse(responseJson);
                object deserialized = null;
                serializer.TryDeserialize(data, typeof(Dictionary<string, string>), ref deserialized);

                var authResponse = deserialized as Dictionary<string, string>;
                
                DatabaseHandler.PostUser(user, authResponse["localId"], () => { }, authResponse["idToken"]);
                SendEmailVerification(authResponse["idToken"]);
            });

    }

    /// <summary>
    /// Sends verification email
    /// </summary>
    /// <param name="newIdToken"> User's token, retrieved from SignUp </param>
    private static void SendEmailVerification(string newIdToken)
    {
        var payLoad = $"{{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"{newIdToken}\"}}";
        RestClient.Post(
            $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/getOobConfirmationCode?key={apiKey}", payLoad);
    }

    /// <summary>
    /// Signs in the user with Firebase Auth using Email and Password method
    /// Checks if user accepted verification email
    /// If that's the case, logs the user's object (name, surname, age)  
    /// </summary>
    /// <param name="email"> User's email </param>
    /// <param name="password"> User's password </param>
    public static void SignIn(string email, string password)
    {
        var payLoad = $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"returnSecureToken\":true}}";
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key={apiKey}",
            payLoad).Then(
            response =>
            {
                var responseJson = response.Text;

                var data = fsJsonParser.Parse(responseJson);
                object deserialized = null;
                serializer.TryDeserialize(data, typeof(Dictionary<string, string>), ref deserialized);

                var authResponse = deserialized as Dictionary<string, string>;
                CheckEmailVerification(authResponse["idToken"], () =>
                {
                    DatabaseHandler.GetUser(userId, user => { identificativo = userId; token = idToken; utente.level = user.level; utente.name = user.name; Debug.Log($"{user.name}, {user.level}"); }, idToken);
                    SceneManager.LoadScene("VeroMenu");
                }, () => { Debug.Log("Email not verified"); });
            });
    }



    /// <summary>
    /// Checks if user accepted verification email
    /// </summary>
    /// <param name="newIdToken"> User's token, retrieved from SignIn </param>
    /// <param name="callback"> What to do after acknowledging the user has verified the email </param>
    /// <param name="fallback"> What to do after acknowledging the user hasn't verified the email </param>
    private static void CheckEmailVerification(string newIdToken, EmailVerificationSuccess callback,
            EmailVerificationFail fallback)
    {
        var payLoad = $"{{\"idToken\":\"{newIdToken}\"}}";
        RestClient.Post($"https://www.googleapis.com/identitytoolkit/v3/relyingparty/getAccountInfo?key={apiKey}",
            payLoad).Then(
            response =>
            {
                var responseJson = response.Text;

                // Using the FullSerializer library: https://github.com/jacobdufault/fullserializer
                // to serialize more complex types (UserData, in this case)
                var data = fsJsonParser.Parse(responseJson);
                object deserialized = null;
                serializer.TryDeserialize(data, typeof(UserData), ref deserialized);

                var authResponse = deserialized as UserData;

                if (authResponse.users[0].emailVerified)
                {
                    userId = authResponse.users[0].localId;
                    idToken = newIdToken;

                    callback();
                }
                else
                {
                    fallback();
                }
            });
    }
}


