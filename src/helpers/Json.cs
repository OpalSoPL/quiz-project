using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Godot;

namespace QuizGame.Helpers;
public static class Json
{

    private static JsonSerializerOptions options = new()
    {
        WriteIndented = true
    };

    public static async Task<T> LoadFromFile <T>(string path)
    {
        path = ProjectSettings.GlobalizePath(path);
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

    public static async Task<bool> SaveToFile <T> (T data, string savePath, bool pretty)
    {

        if (options.WriteIndented != pretty)
        {
            options = new()
            {
                WriteIndented = pretty
            };
        }

        try
        {
            await using FileStream stream = new FileStream(savePath,FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(stream, data, options);
        }
        catch (Exception e) when (
            e is FileNotFoundException
            or UnauthorizedAccessException
            or IOException
            or DirectoryNotFoundException
            or PathTooLongException
        )
        {
            return false;
        }

        return true;
    }
}