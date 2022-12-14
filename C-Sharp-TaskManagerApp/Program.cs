
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {
       public static void ShowAllProcesses()
        {
            int processCount = 0;
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
             Console.WriteLine("Process: {0} | ID: {1} | Status {2} | Memory {3}mb", process.ProcessName, process.Id, process.Responding, process.PrivateMemorySize64/1024/1024);
             processCount += 1;
            }
            Console.WriteLine("Number of Total Processes: {0} ", processCount);
        }
        static void Main(string[] args)
        {

            string input;
            begin:
             Console.WriteLine(
            "\n\n\t...................Task Manager...................\n\n" +
            "\t\t\tWHAT WOULD YOU LIKE TO DO?\n\n" +
            "\t\t 1. Start Process\n"+
            "\t\t 2. View Process\n"+
            "\t\t 3. Create Process\n"+
            "\t\t 4. Terminate Process\n" +
            "\t\t 5. Check if Thread IsAlive or IsBackground\n" + 
            "\t\t 6. Press 6 to Exit \n"  
             );
            Console.Write("Pick One Option:");
            input = Console.ReadLine();
            if (input == "1") goto Start;
            if (input == "2") goto View;
            if (input == "3") goto Create;
            if (input == "4") goto Terminate;
            if (input == "5") goto ThreadStatus;
            if (input == "6") System.Environment.Exit(1);
            Console.WriteLine("Invalid option!");
            goto begin;
            Start:
            {
                string processPath;
                while(true)
                {
                Console.Write("\n\n Enter full path of an executable file ");
                processPath = Console.ReadLine();
                if(File.Exists(processPath))
                {
                Process.Start(processPath);
                Console.WriteLine($"{ processPath} is started. ");
                Console.Write("\n\n\n");
                break;
                }
                else{
                Console.WriteLine($" {processPath} does not exist,enter correct path");
                }
                }
                goto begin;
            }
            View:
            { 
               ShowAllProcesses();
                    goto begin;
            }
            Create:
            { 
                 string  newPath;
                 string  arg ="";
                while(true)
                {
                Console.WriteLine("Create a custom process");
                newPath = Console.ReadLine();
                if(File.Exists(newPath))
                {
                   
                Console.WriteLine("Enter argument");
                arg = Console.ReadLine();
                Process.Start(newPath,arg);
                break;
                }else{
                 Console.WriteLine($"{newPath}, {arg} does not exist");
                }
                 
                }
                    goto begin;
            }
    
            Terminate:
            {
              int processID = 0;
                Console.Write("\n\nEnter input Process ID:");
                while(!int.TryParse(Console.ReadLine(), out processID))
                {
                Console.WriteLine("invalid input,please try again");
                }
                Process.GetProcessById(processID).Kill();
                Console.WriteLine("Process '{0}' died.", processID);
                Console.Write("\n\n\n");
                goto begin;
            }
            
               
            ThreadStatus:
            Console.WriteLine(
            "\n\n\t...................Pick one Thread Option...................\n\n" +
            "\t\tType A to Check if thred IsAlive.\n"+ 
            "\t\tType B to Check if thread IsBackground.\n" 
             );
             input ="";
            
            while(input !="A" && input !="B")
            {
            Console.WriteLine("\nPlease select A or B");
            input = Console.ReadLine();
            input = input.ToUpper();
            }
                if (input == "A") goto A;
                if (input == "B") goto B;
                A:
                {
                Thread thread = Thread.CurrentThread;
                thread.Name ="My Current Thread";
                Console.WriteLine("Checks if the thread isAlive , status is = {0}", thread.IsAlive);
                goto begin;
                }
                 B:
                {
                  
                Thread thread = Thread.CurrentThread;
                thread.Name ="My Current Thread";
                Console.WriteLine("Checks if the thread isBakground , status is = {0}", thread.IsBackground);
                goto begin;
                }
               
        }
    }
}
