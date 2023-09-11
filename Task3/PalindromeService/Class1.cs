namespace Palindrome.Services;

public class PalindromeServices
{
    public bool IsPalindrome(string s){
        int l=0;
        int r=s.Length-1;
        while (l<=r) {
            
            while (l<=r && !char.IsLetterOrDigit(s[l])){
                l+=1;
            }
            while (r>=l && !char.IsLetterOrDigit(s[r])){
                r-=1;
            }
            if (char.ToLower(s[l])!=char.ToLower(s[r])){
                return false;
            }
            l+=1;
            r-=1;
        }
        return true;

    }

}
