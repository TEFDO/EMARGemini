using System.Collections.Generic;
using System.Text.Json;
using EMAR.Models;

namespace EMAR.Helpers
{
    public static class StandartlarSerializer
    {
        public static string Serialize(List<StandartItem> list)
        {
            return JsonSerializer.Serialize(list);
        }

        public static List<StandartItem> Deserialize(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return new();
            return JsonSerializer.Deserialize<List<StandartItem>>(json) ?? new();
        }
    }
}