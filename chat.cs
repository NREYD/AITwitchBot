using OllamaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace chat
{
    internal class Program
    {
        static string channelName = "#usernamehere"; // <- username of the channel you want the bot to be in

        static async Task TwitchChat()
        {
            string ip = "irc.chat.twitch.tv";
            int port = 6667;
            string password = "oauthhere"; // <- check README.md for how to set this up
            string botUsername = "usernamehere"; // <- should be the username of the twitch account you got the oauth off of

            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(ip, port);

                using (var streamReader = new StreamReader(tcpClient.GetStream()))
                using (var streamWriter = new StreamWriter(tcpClient.GetStream()) { NewLine = "\r\n", AutoFlush = true })
                {
                    await streamWriter.WriteLineAsync($"PASS {password}");
                    await streamWriter.WriteLineAsync($"NICK {botUsername}");
                    await streamWriter.WriteLineAsync($"JOIN {channelName}");

                    while (true)
                    {
                        string chat = await streamReader.ReadLineAsync();
                        Console.WriteLine(chat);

                        if (chat.StartsWith("PING"))
                        {
                            // Respond to PING to keep the connection alive
                            await streamWriter.WriteLineAsync("PONG :tmi.twitch.tv");
                        }
                        else if (chat.Contains("PRIVMSG"))
                        {
                            var messageParts = chat.Split(' ');
                            var username = messageParts[1].Split('!')[0].Substring(1);
                            var message = chat.Substring(chat.IndexOf(":", 1) + 1);

                            if (message.Contains("this is a twitch message")) // change this with what you want the bot to respond to 
                            {
                                Console.WriteLine($"{username} asked VoniBot {message}");
                                await OllamaResponse(streamWriter, username, message);
                            }
                        }
                    }
                }
            }
        }

        static async Task OllamaResponse(StreamWriter streamWriter, string username, string chat)
        {
            var uri = new Uri("http://localhost:11434");
            var ollama = new OllamaApiClient(uri);
            ollama.SelectedModel = "llama3.1";
            var prompt = $"Whatever is said after the semi colon is the chat message, and i need you to only respond to that say nothing else but your response to the message, (insert prompt here) ; {chat}"; //prompt for the bot

            ConversationContext? context = null;
            string responseContent = string.Empty;

            context = await ollama.StreamCompletion(prompt, context, stream =>
            {
                responseContent += stream.Response;
            });

            // Send the response back to the Twitch chat, addressing the user
            await streamWriter.WriteLineAsync($"PRIVMSG {channelName} :@{username} {responseContent}");
        }

        static async Task Main(string[] args)
        {
            await TwitchChat();
        }
    }
}
