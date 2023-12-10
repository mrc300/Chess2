using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class StockFish
{
    Process stockfishProcess;
    private static int lineCount = 0;
    private static StringBuilder output = new StringBuilder();
    public StockFish(){
        //string stockfishPath = Application.dataPath + @"/ASSETS/Scripts/stockfish/stockfish-windows-x86-64-modern.exe";
        string stockfishPath = Application.dataPath + @"/stockfish/stockfish-windows-x86-64-modern.exe";
        stockfishProcess = new Process();
        stockfishProcess.StartInfo.FileName = stockfishPath;
        stockfishProcess.StartInfo.UseShellExecute = false;
        stockfishProcess.StartInfo.RedirectStandardInput = true;
        stockfishProcess.StartInfo.RedirectStandardOutput = true;
        stockfishProcess.StartInfo.CreateNoWindow = true;
        stockfishProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                lineCount++;
                output.Append("\n[" + lineCount + "]: " + e.Data);
            }
        });
        stockfishProcess.Start();
    }

    public string getBestMove(string position) {
        stockfishProcess.Refresh();
        SendCommand("position fen " + position);
        SendCommand("go depth 10");
        SendCommand("");
        return GetResponse();
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
