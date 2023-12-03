using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEngine;
using System.Text;



public class StockFish
{


    private static StringBuilder output = new StringBuilder();
     Process stockfishProcess;
    public StockFish(){
        string stockfishPath = Application.dataPath + @"/ASSETS/Scripts/StockFish/stockfish-windows-x86-64-avx2.exe";
        stockfishProcess = new Process();
        stockfishProcess.StartInfo.FileName = stockfishPath;
        stockfishProcess.StartInfo.UseShellExecute = false;
        stockfishProcess.StartInfo.RedirectStandardInput = true;
        stockfishProcess.StartInfo.RedirectStandardOutput = true;
        stockfishProcess.StartInfo.CreateNoWindow = true;
        stockfishProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                output.Append("\n " + e.Data);
            }
        });
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
        stockfishProcess.BeginOutputReadLine();
        while(!output.ToString().Contains("bestmove"))Thread.Sleep(10);
        stockfishProcess.CancelOutputRead();
        string res =output.ToString();
        output.Clear();
        return res;
    }
}
