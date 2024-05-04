using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Requests;

namespace tic_tac_toe.Services;

public class DemoService
{
    private FirebaseAuthClient _firebaseAuthClient;
    private const string AuthStateKey = "AuthState";
    private string _apiKey = "AIzaSyB0LBbbnBwnBh5B_WUpAuYlu5r9LXN8K5Y";
    // my firebase domain
    private string _authDomain = "tic-tac-toe-f2da6.firebaseapp.com";

    public DemoService()
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
    public async Task<bool> IsAuthenticatedAsync()
    {
        await Task.Delay(4000);
        var authState = Preferences.Default.Get<bool>(AuthStateKey, false);
        return authState;
    }

    // Sign user in
    public async Task<bool> Login(string email, string password)
    {
        var user = await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
        Preferences.Default.Set<bool>(AuthStateKey, true);
        return user != null;
    }

    // Sign user out
    public void Logout()
    {
        // Check if _firebaseAuthClient is null
        if (_firebaseAuthClient == null)
        {
            throw new InvalidOperationException("_firebaseAuthClient has not been initialized.");
        }

        _firebaseAuthClient.SignOut();
        Preferences.Default.Remove(AuthStateKey);
    }

    // Register a new user
    public async Task<bool> Register(string email, string password)
    {
        var user = await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password);
        Preferences.Default.Set<bool>(AuthStateKey, true);
        return user != null;
    }
    
    // User status
    public bool IsAuthenticated()
    {
        var user = _firebaseAuthClient.User;
        return user != null;
    }

    public async Task<bool> DeleteAccount()
    {
        await Task.Delay(2000);
        return true;
    }
}