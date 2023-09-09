namespace Counter.Services;

public class CounterServices
{

    public Dictionary<char,int> Count(string s){
        Dictionary<char, int> counter = new Dictionary<char, int>();
        foreach (char c in s.ToLower())
        {
            if (counter.ContainsKey(c))
            {
                counter[c]+=1;
            }
            else{
                counter[c]=1;
            }
        }
        return counter;
    } 
}
