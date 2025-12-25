using System.Text;

public static class KhmerNumerals
{
    private static readonly char[] KhmerDigits =
    {
        '០', '១', '២', '៣', '៤', '៥', '៦', '៧', '៨', '៩'
    };

    public static string ToKhmerNumerals(int value) => ToKhmerNumerals(value.ToString());

    public static string ToKhmerNumerals(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var sb = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (c >= '0' && c <= '9')
                sb.Append(KhmerDigits[c - '0']);
            else
                sb.Append(c);
        }

        return sb.ToString();
    }
}

