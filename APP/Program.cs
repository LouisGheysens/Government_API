// See https://aka.ms/new-console-template for more information
using MongoDB.Driver;

Console.WriteLine("Hello, World!");


MongoClient client = new MongoClient();
MongoServer server = client.GetServer();
MongoDatabase db = server.GetDatabase("Person");