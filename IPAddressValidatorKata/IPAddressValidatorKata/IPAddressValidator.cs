namespace IPAddressValidatorKata
{
    public class IPAddressValidator
    {
        public bool ValidateIpv4Address(string ipAddress)
        {
            if (IpAddressIsEmpty(ipAddress))
            {
                return false;
            }
            var splitedIpAddress = GetSplitedIpAddress(ipAddress);
            var ipAddressLength = GetIpAddressLength(splitedIpAddress);
            if (IpAddressNotGroupedInto4OneByteBlocks(ipAddressLength))
            {
                return false;
            }

            if (IpAddressEndsWith255OrZero(splitedIpAddress))
            {
                return false;
            }
            return true;
        }

        private static bool IpAddressEndsWith255OrZero(string[] splitedIpAddress)
        {
            return splitedIpAddress[3] == "255" || splitedIpAddress[3] == "0";
        }

        private static bool IpAddressNotGroupedInto4OneByteBlocks(int ipAddressLength)
        {
            return ipAddressLength != 4;
        }

        private static int GetIpAddressLength(string[] splitedIpAddress)
        {
            return splitedIpAddress.Length;
        }

        private static string[] GetSplitedIpAddress(string ipAddress)
        {
            return ipAddress.Split('.');
        }

        private static bool IpAddressIsEmpty(string ipAddress)
        {
            return string.IsNullOrWhiteSpace(ipAddress);
        }
    }
}
