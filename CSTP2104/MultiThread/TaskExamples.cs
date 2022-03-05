using System.Threading.Channels;

namespace WindowsAppLib.MultiThread;

public class TaskExamples
{
    /*
     * Two main reason for partitioning work among threads
     * a)Data parallelism - partitions the data between threads(ex: RunAsParallel())
     * b)Task parallelism - partitions the tasks - each thread performs a different task
     * 
     */
    public void RunTask()
    {
        Task task = Task.Run(() =>
        {
            Console.WriteLine("my first task");
            for (int i = 0; i < 10; i++)
            {
                int result = i * i;
                Console.WriteLine("result at {0} equal {1}", i, result);
            }
        });
        Console.WriteLine(task.IsCompleted);//false
        task.Wait();//wait block for the task to finish
    }
    
    public void RunTask2()
    {
        Task task = Task.Run(() =>
        {
            Console.WriteLine("my second task");
            for (int i = 0; i < 10; i++)
            {
                int result = i * i;
                Console.WriteLine("result at {0} equal {1}", i, result);
            }
        });
        Console.WriteLine(task.IsCompleted);//false
        task.Wait();//wait block for the task to finish
    }
    
    public void RunTask3()
    {
        Task<int> task = Task.Run(() =>
        {
            Console.WriteLine("This task return an int");
            return 3;
        });
        int result = task.Result;//block if the task is already finished
        Console.WriteLine("Task. result ={0}", result);
    }

    public void RunTask4()
    {
        Task<int> task = Task.Run(() =>
        {
            Console.WriteLine("This task will throw an exception");
            int i = 10;
            int j = 0;
            return i / j;
        } );
        int result = task.Result;
        Console.WriteLine($"task.result={result}");
    }

    public void RunAsParallel()
    {
        var s = "The quick brown fox ran over the hill";
        Console.WriteLine(s);
        var r = s
            .AsParallel().WithDegreeOfParallelism(2)
            .Where(c => !char.IsWhiteSpace(c))//selecting characters base on condition
            .Select(char.ToUpper);//do an operation on each character

        var result = new string(r.ToArray());
        Console.WriteLine($"RunAsParallel result={result}");
    }

    public void RunAsParallel2()
    {
        var s = "abctheQuickfoxranoverthehillxyz";
        s
            .AsParallel()
            .Select(char.ToUpper)
            .ForAll(Console.Write);
    }
}