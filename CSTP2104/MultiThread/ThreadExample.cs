namespace WindowsAppLib.MultiThread;

public class ThreadExample
{
    public void RunAThread()
    {
        Thread t = new Thread(DoCalculation);
        t.Start();

    }

    void DoCalculation()
    {
        for (int i = 1; i < 10; i++)
        {
            int result = i * i;
            Console.WriteLine("result of {1} is {0}", result, i);
        }
    }
}