using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;

class ChatClient
{
    private static TcpClient client;
    private static StreamWriter writer;
    private static StreamReader reader;

    static void Main(string[] args)
    {
        // Connect to the server at localhost on port 8888
        client = new TcpClient("127.0.0.1", 8888);
        Console.WriteLine("Connected to chat server...");

        writer = new StreamWriter(client.GetStream());
        reader = new StreamReader(client.GetStream());

        // Start a new thread to listen for incoming messages from the server
        Thread readThread = new Thread(ReadMessages);
        readThread.Start();

        // Continuously send messages to the server
        string message;
        while ((message = Console.ReadLine()) != null)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
    }

    private static void ReadMessages()
    {
        string message;
        try
        {
            while ((message = reader.ReadLine()) != null)
            {
                Console.WriteLine("Received: " + message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Disconnected from server.");
        }
    }
}
