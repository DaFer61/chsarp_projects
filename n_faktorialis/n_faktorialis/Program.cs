using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

int n = 1;
string n_str;
int fakt;
int fak_prod = 1;
int sum = 0;
int result = 0;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

int[] arr = new int[10];
arr[0] = 1;
for (int i = 0; i < 9; i++)
{
    fak_prod = 1;
    for (int j = 1; j <= i + 1; j++)
    {
        fak_prod *= j;
    }
    arr[i + 1] = fak_prod;
}
while (n < 2000000)
{
    sum = 0;
    n_str = n.ToString();
    for (int i = 0; i < n_str.Length; i++)
    {
        fakt = Int32.Parse(n_str[i].ToString());   
        sum += arr[fakt];
    }
    if (sum == n)
    {
        result = n;
    }
    n++;
}
Console.WriteLine(result);

stopwatch.Stop();
TimeSpan elapsed = stopwatch.Elapsed;

Console.WriteLine($"Elapsed time: {elapsed.TotalMilliseconds} ms");