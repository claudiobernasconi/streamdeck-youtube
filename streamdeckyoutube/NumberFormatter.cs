namespace streamdeckyoutube
{
    public class NumberFormatter
    {
        public string FormatNumber(ulong? number)
        {
            if (number < 1000)
            {
                return number.ToString();
            }
            else if (number == 1000)
            {
                return "1000";
            }
            else if (number < 10_000)
            {
                return number.Value.ToString().Substring(0, 1) + "." + number.Value.ToString().Substring(1, 2) + "K";
            }
            else if (number < 100_000)
            {
                return number.Value.ToString().Substring(0, 2) + "." + number.Value.ToString().Substring(2, 1) + "K";
            }
            else if (number < 1_000_000)
            {
                return number.Value.ToString().Substring(0, 3) + "K";
            }
            else if (number < 10_000_000)
            {
                return number.Value.ToString().Substring(0, 1) + "." + number.Value.ToString().Substring(1, 2) + "M";
            }
            else if (number < 100_000_000)
            {
                return number.Value.ToString().Substring(0, 2) + "." + number.Value.ToString().Substring(2, 1) + "M";
            }
            else if (number < 1_000_000_000)
            {
                return number.Value.ToString().Substring(0, 3) + "M";
            }
            else if (number < 10_000_000_000)
            {
                return number.Value.ToString().Substring(0, 1) + "." + number.Value.ToString().Substring(1, 2) + "B";
            }
            else if (number < 100_000_000_000)
            {
                return number.Value.ToString().Substring(0, 2) + "." + number.Value.ToString().Substring(2, 1) + "B";
            }
            else if (number < 1_000_000_000_000)
            {
                return number.Value.ToString().Substring(0, 3) + "B";
            }
            else
            {
                return ">1T";
            }
        }
    }
}
