using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

class ChatServer
{
    private static TcpListener listener;
    private static List<TcpClient> clients = new List<TcpClient>();

    static void Main(string[] args)
    {
        // Start the server on port 8888
        listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();
        Console.WriteLine("Chat Server started...");

        while (true)
        {
            // Accept new client
            TcpClient client = listener.AcceptTcpClient();
            clients.Add(client);
            Console.WriteLine("New client connected...");

            // Start a new thread to handle the client
            Thread clientThread = new Thread(HandleClient);
            clientThread.Start(client);
        }
    }

    private static void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        StreamReader reader = new StreamReader(client.GetStream());
        string message;

        try
        {
            // Continuously listen for messages from the client
            while ((message = reader.ReadLine()) != null)
            {
                Console.WriteLine("Received: " + message);
                BroadcastMessage(message, client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Client disconnected.");
        }
        finally
        {
            clients.Remove(client);
            client.Close();
        }
    }

    private static void BroadcastMessage(string message, TcpClient senderClient)
    {
        // Send the received message to all other connected clients
        foreach (var client in clients)
        {
            if (client != senderClient)
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}
