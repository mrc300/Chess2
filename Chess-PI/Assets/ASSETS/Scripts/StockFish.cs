using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;

public class StockFish
{
    Process stockfishProcess;
    public StockFish(){
        string stockfishPath = Application.dataPath + @"/ASSETS/Scripts/stockfish/stockfish-windows-x86-64-modern.exe";
        stockfishProcess = new Process();
        stockfishProcess.StartInfo.FileName = stockfishPath;
        stockfishProcess.StartInfo.UseShellExecute = false;
        stockfishProcess.StartInfo.RedirectStandardInput = true;
        stockfishProcess.StartInfo.RedirectStandardOutput = true;
        stockfishProcess.StartInfo.CreateNoWindow = true;
        stockfishProcess.Start();
    }

    public string getBestMove(string position) {
        stockfishProcess.Refresh();
        SendCommand("position fen " + position);
        SendCommand("go depth 10");
        string res = GetResponse();
        return res;
    }

    private void SendCommand(string command)
    {
        stockfishProcess.StandardInput.WriteLine(command);
        stockfishProcess.StandardInput.Flush();
    }

    private string GetResponse()
    {

        Thread.Sleep(100);
        string res = "";
        UnityEngine.Debug.Log(stockfishProcess.StandardOutput.Peek());
        while (stockfishProcess.StandardOutput.Peek() > -1)
        {
            res += stockfishProcess.StandardOutput.ReadLine() + "\n";
        }
        stockfishProcess.StandardOutput.DiscardBufferedData();
        return res;
    }
}
