//collatz conjecture
int n = 1;
while (true)
{
    int conj = n;
    int iter = 0;
    while (conj > 1)
    {
        if (conj % 2 == 0)
        {
            conj /= 2;
        }
        else
        {
            conj = conj * 3 + 1;
        }
        iter++;
    }

    if(iter > 500)
    {
        Console.WriteLine($"{n}- number took {iter} iterations.");
    }
    n++;
}
 