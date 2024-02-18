using System.Text.RegularExpressions;

namespace ObsidianUI.Utils;

// All the code in this file is included in all platforms.
public static class ExtensionMethod
{
    public static short ToInt16(this object obj) => Convert.ToInt16(obj);

    public static int ToInt32(this object obj) => Convert.ToInt32(obj);

    public static long ToInt64(this object obj) => Convert.ToInt64(obj);

    public static decimal ToDecimal(this object obj) => Convert.ToDecimal(obj);
    public static double ToDouble(this object obj) => Convert.ToDouble(obj);
    public static float ToFloat(this object obj) => Convert.ToSingle(obj);

    public static bool ToBoolean(this object obj) => Convert.ToBoolean(obj);

    public static byte ToByte(this object obj) => Convert.ToByte(obj);

    public static char ToChar(this object obj) => Convert.ToChar(obj);
    public static DateTime ToDateTime(this object obj) => Convert.ToDateTime(obj);
    public static bool NotAny<TSource>(this IEnumerable<TSource> source) => !source.Any();

    public static bool NotAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> func) => !source.Any(func);

    public static bool IsOnlyNumbers(this string value)
    {
        var regex = new Regex("^[0-9]*$");
        var match = regex.Match(value);
        return match.Success;
    }
    /// <summary>
    /// <para>PER SOSTITUIRE [key] che torna NULL se il Dictionary non la contiene </para>
    /// <para> Verifica che il Dictionary contenga la chiave, se non la contiene se non la contiene torna una lista vuota </para>
    /// </summary>
    /// <typeparam name="K"> Tipo della chiave </typeparam>
    /// <typeparam name="V"> Tipo del valore </typeparam>
    /// <param name="dic"> Dictionary da scorrere </param>
    /// <param name="key"> Chiave da selezionare </param>
    /// <returns> Il valure della chiave passata </returns>
    public static V GetValue<K, V>(this Dictionary<K, V> dic, K key) where V : new() => dic.ContainsKey(key) ? dic[key] : new V();
    /// <summary>
    /// <para>PER SOSTITUIRE [key] che torna NULL se il Dictionary non la contiene </para>
    /// <para> Verifica che il Dictionary contenga la chiave, se non la contiene se non la contiene torna una lista vuota </para>
    /// </summary>
    /// <typeparam name="K"> Tipo della chiave </typeparam>
    /// <typeparam name="V"> Tipo del valore </typeparam>
    /// <param name="dic"> Dictionary da scorrere </param>
    /// <param name="key"> Chiave da selezionare </param>
    /// <returns> Il valure della chiave passata </returns>
    public static List<V> GetValues<K, V>(this Dictionary<K, List<V>> dic, K key) => dic.ContainsKey(key) ? dic[key] : new List<V>();

    /// <summary>
    /// Checks if the date is between the two provided dates
    /// </summary>
    /// <param name="date"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="compareTime"></param>
    /// <returns></returns>
    public static bool IsDateBetween(this DateTime date, DateTime startDate, DateTime endDate, bool compareTime = false) => compareTime ? date >= startDate && date <= endDate : date.Date >= startDate.Date && date.Date <= endDate.Date;
}