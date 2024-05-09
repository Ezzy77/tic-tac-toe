using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Requests;

namespace tic_tac_toe.Services;

public class AuthService
{
    private FirebaseAuthClient _firebaseAuthClient;
    private string _apiKey = Secrets.ApiKey;
    // my firebase domain
    private string _authDomain = Secrets.AuthDomain;

    public AuthService()
    {
        var config = new FirebaseAuthConfig()
        {
            ApiKey = _apiKey,
            AuthDomain = _authDomain,
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            },
        };
        _firebaseAuthClient = new FirebaseAuthClient(config);
    }

    // Sign user in
    // Sign user in
    public async Task<bool> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            // Log this event or alert the user that both email and password fields must be non-empty
            Console.WriteLine("Both Email and Password must be provided.");
            return false;
        }

        try
        {
            var user = _firebaseAuthClient != null 
                ? await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password)
                : null;
            return user != null;
        }
        catch(FirebaseAuthException ex)
        {
            // Log the error message to your Logger service
            Console.WriteLine($"There was an error logging in: {ex.Message}");
            return false;
        }
    }

    // Sign user out
    // Sign user out
    public void Logout()
    {
        if (_firebaseAuthClient != null)
        {
            try
            {
                _firebaseAuthClient.SignOut();
            }
            catch (Exception ex)
            {
                // Handle any specific exceptions related to Firebase Auth
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("FirebaseAuthClient is null. Could not sign out.");
        }
    }

    // Register a new user
    // Register a new user
    public async Task<bool> Register(string email, string password)
    {
        var user = _firebaseAuthClient != null
            ? await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password)
            : null;
        return user != null;
    }
    
    // User status
    // User status
    public bool IsAuthenticated()
    {
        var user = _firebaseAuthClient?.User;
        return user != null;
    }


}