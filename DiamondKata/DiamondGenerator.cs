using System.Text;

namespace DiamondKata
{
    public class DiamondGenerator
    {
        public static readonly char[] Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        readonly char whitespace = ' ';

        public string Generate(char input)
        {
            if (input == 'A')
                return input.ToString();

            var result = new StringBuilder();
            var index = Array.FindIndex(Characters, x => x == char.ToUpper(input));

            for (int i = 0; i <= index; i++)
            {
                result.AppendLine(GetLine(Characters[i], index - i, (i * 2) - 1));
            }

            for (int i = index - 1; i >= 0; i--)
            {
                result.AppendLine(GetLine(Characters[i], index - i, (i * 2) - 1));
            }

            return result.ToString();
        }

        string GetLine(char input, int sidePadding, int middlePadding)
        {
            var result = input.ToString();

            if (middlePadding > 0)
            {
                result = result.PadRight(result.Length + middlePadding, whitespace);
                result += input;
            }

            result = result.PadLeft(result.Length + sidePadding, whitespace);
            result = result.PadRight(result.Length + sidePadding, whitespace);
                
            return result;
        }
    }
}