using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Godot;

namespace QuizGame.Helpers;
public static class Json
{
    public static async Task<T> LoadToFile <T>(string path, bool isEnginePath = false)
    {
        if (isEnginePath)
        {
            path = ProjectSettings.GlobalizePath(path);
        }
        try
        {
            await using FileStream stream = new FileStream(path,FileMode.Open);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
        catch(Exception e) when (
            e is FileNotFoundException or
            DirectoryNotFoundException or
            UnauthorizedAccessException or
            IOException or
            JsonException
        )
        {
            return default;
        }
    }
}