using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using BoneConnect.DataStructures.List;

public class ArrayListConverter<T> : JsonConverter<ArrayList<T>>
{
    public override void WriteJson(JsonWriter writer, ArrayList<T> value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value.ToArray());
    }

    public override ArrayList<T> ReadJson(JsonReader reader, Type objectType, ArrayList<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var array = serializer.Deserialize<T[]>(reader);
        var list = new ArrayList<T>();
        foreach (var item in array)
        {
            list.Add(item);
        }
        return list;
    }
}