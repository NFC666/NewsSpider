using Newtonsoft.Json.Linq;

namespace Spider.Common.Helpers;

public class JsonConverterHelper
{
    public static List<T> FromJsonListToList<T>(string json,string jsonPath)
    {
        JObject jObject;
        try
        {
            jObject = JObject.Parse(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"json格式错误，或连接失败：{json}");
        }

        var jArray = jObject.SelectToken(jsonPath);
        
        if(!(jArray is JArray))
            throw new Exception("无法转化为list");

        var list = jArray.ToObject<List<T>>();
        if(list == null)
            throw new Exception("list为空！");
        return list;
    }
}