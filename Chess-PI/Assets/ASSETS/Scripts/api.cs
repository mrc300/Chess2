using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;
public class api 
{
   static void Main()
    {
        using (Process process = new Process())
        {
            process.StartInfo.FileName = @"C:\Users\Asus\Desktop\Chess2\Chess-PI\stockfish\stockfish-windows-x86-64-avx2.exe"; // Path to the Stockfish executable
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            // Example: Sending a command to Stockfish and reading the response
            StreamWriter sw = process.StandardInput;
            StreamReader sr = process.StandardOutput;

            // Send UCI commands to initialize Stockfish
            sw.WriteLine("uci");
            sw.WriteLine("isready");

            // Wait for Stockfish to be ready
            while (!sr.ReadLine().Contains("readyok"))
            {
                // Wait for the engine to be ready
            }

            // Set up the initial position
            sw.WriteLine("position startpos");

            // Instruct Stockfish to find the best move
            sw.WriteLine("go depth 10");

            // Read Stockfish output and extract the best move
            string output;
            while (!(output = sr.ReadLine()).StartsWith("bestmove"))
            {
                // Continue reading until the bestmove is received
            }

            // Extract the best move from the output
            string[] parts = output.Split(' ');
            if (parts.Length >= 2)
            {
                string bestMove = parts[1];
                Console.WriteLine($"Best move: {bestMove}");
            }
            else
            {
                Console.WriteLine("Error parsing best move.");
            }

            process.WaitForExit();
        }
    }
    
}
