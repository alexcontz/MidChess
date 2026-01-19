namespace MidChess.lib
{
    public class LANLib
    {
        private const int DEFAULT_PORT = 3000;
        private const string LOCALHOST = "127.0.0.1";

        #region Validation Methods

        /// <summary>
        /// Validates and returns the IP address. If empty, returns localhost.
        /// </summary>
        public bool ValidateIPAddress(string ipAddress, out string validatedIP, out string errorMessage)
        {
            validatedIP = string.Empty;
            errorMessage = string.Empty;

            string cleanIP = ipAddress?.Trim().Replace(" ", "") ?? string.Empty;

            // Default to localhost if empty
            if (string.IsNullOrEmpty(cleanIP) || cleanIP.Replace(".", "").Length == 0)
            {
                validatedIP = LOCALHOST;
                return true;
            }

            // Validate IP format
            string[] octets = cleanIP.Split('.');
            if (octets.Length != 4)
            {
                errorMessage = "Please enter a valid IP address (format: x.x.x.x) or leave blank for localhost.";
                return false;
            }

            // Validate each octet
            foreach (string octet in octets)
            {
                if (string.IsNullOrEmpty(octet) || octet.Trim().Length == 0)
                {
                    errorMessage = "Please enter a complete IP address (format: x.x.x.x) or leave blank for localhost.";
                    return false;
                }

                if (!int.TryParse(octet, out int value) || value < 0 || value > 255)
                {
                    errorMessage = "Please enter a valid IP address (each number must be 0-255) or leave blank for localhost.";
                    return false;
                }
            }

            validatedIP = cleanIP;
            return true;
        }

        /// <summary>
        /// Validates and returns the port number. If empty, returns default port (3000).
        /// </summary>
        public bool ValidatePort(string portText, out int validatedPort, out string errorMessage)
        {
            validatedPort = DEFAULT_PORT;
            errorMessage = string.Empty;

            string cleanPort = portText?.Trim() ?? string.Empty;

            // Default to 3000 if empty
            if (string.IsNullOrEmpty(cleanPort))
            {
                return true;
            }

            // Validate port range
            if (!int.TryParse(cleanPort, out validatedPort) || validatedPort < 1 || validatedPort > 65535)
            {
                errorMessage = "Please enter a valid port number (1-65535).";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a starting color is selected.
        /// </summary>
        public bool ValidateStartingColor(bool whiteSelected, bool blackSelected, out string selectedColor, out string errorMessage)
        {
            selectedColor = string.Empty;
            errorMessage = string.Empty;

            if (!whiteSelected && !blackSelected)
            {
                errorMessage = "Please select a starting color (White or Black).";
                return false;
            }

            selectedColor = whiteSelected ? "White" : "Black";
            return true;
        }

        #endregion
    }
}