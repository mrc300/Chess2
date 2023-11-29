using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class StockFish
{
    Process stockfishProcess;
    public StockFish(){
        string stockfishPath = @"C:\Users\leosr\OneDrive\Ambiente de Trabalho\stockfish\stockfish-windows-x86-64-modern.exe";
        stockfishProcess = new Process();
        stockfishProcess.StartInfo.FileName = stockfishPath;
        stockfishProcess.StartInfo.UseShellExecute = false;
        stockfishProcess.StartInfo.RedirectStandardInput = true;
        stockfishProcess.StartInfo.RedirectStandardOutput = true;
        stockfishProcess.StartInfo.CreateNoWindow = true;
        stockfishProcess.Start();
    }

    public void SendCommand(Process process, string command)
    {
        StreamWriter streamWriter = process.StandardInput;
        streamWriter.WriteLine(command);
        streamWriter.Flush();
    }

    public string GetResponse(Process process)
    {
        StreamReader streamReader = process.StandardOutput;
        return streamReader.ReadLine();
    }
}
