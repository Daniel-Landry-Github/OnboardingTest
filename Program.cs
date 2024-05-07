namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            string firstName = RequestInformation.RequestFirstName();
            string lastName = RequestInformation.RequestLastName();
            string username = RequestInformation.GenerateUsername(firstName, lastName);
            string emailAddress = RequestInformation.GenerateEmailAddress(username);
            string phoneNumber = RequestInformation.RequestPhoneNumber();
            string personalEmail = RequestInformation.RequestPersonalEmail();
            string startDate = RequestInformation.RequestStartDate();
            string region = RequestInformation.RequestRegion();
            string practice = RequestInformation.RequestPractice();
            string department = RequestInformation.RequestDepartment();
            string ouPath = RequestInformation.GenerateOUPath(practice, department);
            string manager = RequestInformation.RequestManager();
            string title = RequestInformation.RequestTitle();


            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
            Console.WriteLine(username);
            Console.WriteLine(phoneNumber);
            Console.WriteLine(emailAddress);
            Console.WriteLine(personalEmail);
            Console.WriteLine(startDate);
            Console.WriteLine(region);
            Console.WriteLine(practice);
            Console.WriteLine(department);
            Console.WriteLine(ouPath);
            Console.WriteLine(manager);
            Console.WriteLine(title);
        }

    }


    public class RequestInformation
    {
        // 'RequestFirstName' method.
        public static string RequestFirstName()
        {
            string firstName;
            Console.Write("First Name: ");
            firstName = Console.ReadLine();
            // Verification of ONLY alphabetical characters here
            if (!Verifications.ContainsAlphabet(firstName))
            {
                RequestFirstName();
            }
            Console.WriteLine("VERIFIED");
            return firstName;
        }

        // 'RequestLastName' method.
        public static string RequestLastName()
        {
            string lastName;
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            // Verification of ONLY alphabetical characters here
            if (!Verifications.ContainsAlphabet(lastName))
            {
                RequestLastName();
            }
            Console.WriteLine("VERIFIED");
            return lastName;
        }

        // 'GenerateUsername' method.
        public static string GenerateUsername(string firstname, string lastname)
        {
            string username = $"{firstname}.{lastname}";
            // IF connected to AD, would check if generated username exists. Require resubmission if found. Proceed if not found. 
            Console.WriteLine($"Generating Username...{username}");
            return username;
        }

        // 'GenerateEmailAddress' method.
        public static string GenerateEmailAddress(string username)
        {
            string emailAddress = $"{username}@sparkhound.com";
            Console.WriteLine($"Generating Email...{emailAddress}");
            return emailAddress;
        }

        // 'RequestPhoneNumber' method.
        public static string RequestPhoneNumber()
        {
            string phoneNumber;
            Console.Write("Phone Number ('555-111-2222'): ");
            phoneNumber = Console.ReadLine();
            // Verification of valid mobile format (555-111-2222) here.
            if (!Verifications.MobilePhoneFormatting(phoneNumber))
            {
                RequestPhoneNumber();
            }
            Console.WriteLine("VERIFIED");
            return phoneNumber;
        }

        // 'RequestPersonalEmail' method.
        public static string RequestPersonalEmail()
        {
            string personalEmail;
            Console.Write("Personal Email: ");
            personalEmail = Console.ReadLine();
            // Verification of valid email format (<address>@<domain>.com) here.
            return personalEmail;
        }

        // 'RequestStartDate' method.
        public static string RequestStartDate()
        {
            string startDate;
            Console.Write("Start Date: ");
            startDate = Console.ReadLine();
            // Verification of valid date format (MM/DD/YYYY) here.
            return startDate;
        }

        // 'RequestRegion' method.
        public static string RequestRegion()
        {
            string region;
            Console.Write("Region (Baton Rouge, Houston, Dallas, Birmingham) :");
            region = Console.ReadLine();
            // Verification of valid region submission here.
            return region;
        }

        // 'RequestPractice' method.
        public static string RequestPractice()
        {
            string practice;
            Console.Write("Practice: ");
            practice = Console.ReadLine();
            return practice;
        }

        // 'RequestDepartment' method.
        public static string RequestDepartment()
        {
            string department;
            Console.Write("Department: ");
            department = Console.ReadLine();
            return department;
        }

        // 'GenerateOUPath' method.
        public static string GenerateOUPath(string practice, string department)
        {
            //"OU=$Department,OU=$Practice,OU=Domain Users,DC=sparkhound,DC=com"
            string organizationalUnitPath = $"OU={department},OU={practice},OU=Domain Users,DC=sparkhound,DC=com";
            Console.WriteLine($"Generating full OU path...{organizationalUnitPath}");
            return organizationalUnitPath;
        }

        // 'RequestManager' method.
        public static string RequestManager()
        {
            string manager;
            Console.Write("Manager (Username): ");
            manager = Console.ReadLine();
            // IF connected to AD, would verify if submitted username exists.
            return manager;
        }

        // 'RequestTitle' method.
        public static string RequestTitle()
        {
            string title;
            Console.Write("Title: ");
            title = Console.ReadLine();
            return title;
        }

        // 'RequestEquipmentType' method?
    }

    public class Verifications
    {
        public static bool ContainsAlphabet(string submission)
        {
            // Array of each character of the alphabet.
            // (EXTRA) 'verifyType': String that should contain either 'ALL' or '<insert char here>.
            // 'submission': String to be compared against the array.
            char[] array = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'x' };
            bool verified = false;
            string submissonCaseCorrected = submission.ToLower();
            foreach (char sLetter in submissonCaseCorrected)
            {
                // 'verified' variable will remain 'false' until a match is found during the nested foreach enumeration.
                foreach (char aLetter in array)
                {
                    if (aLetter != sLetter) // IF 'd' != "{d}aniel"
                    {
                        verified = false;
                    }
                    else 
                    {
                        verified = true;
                        break; // Break out once letter is verified to reduce unneeded enumeration.
                    }
                }
                if (!verified)
                {
                    Console.WriteLine($"Invalid submission. Non-alphabetic character detected: '{sLetter}'.");
                    return verified;
                }
            }
            return verified;
        }
        public static bool ContainsNumbers(string submission)
        {
            char[] array = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool verified = false;
            string submissionCaseCorrected = submission.ToLower();
            foreach (char sNum in submissionCaseCorrected)
            {
                foreach (char aNum in array)
                {
                    if (aNum != sNum)
                    {
                        verified = false;
                    }
                    else
                    {
                        verified = true;
                        break;
                    }
                }
                if (!verified)
                {
                    Console.WriteLine($"Invalid submission. Non-numberic character detected: '{sNum}'");
                    return verified;
                }
            }
            return verified;
        }

        public static bool MobilePhoneFormatting(string submission)
        {
            // Required mobile phone formatting: '555-111-2222'
            // Inspect index to confirm string length is ONLY 12 characters in length (10 digits and 2 dashes).
            // Inspect substring to confirm if '-' exists in the 3rd index.
            bool verified = false;
            string[] missedRequirements = new string[3];
            if (submission.Length != 12)
            {
                missedRequirements[0] = $"Invalid formatting. Must be 12 characters long. Current length: {submission.Length}.";
            }
            if (submission.IndexOf('-') != 3)
            {
                missedRequirements[1] = "Invalid formatting. Missing initial '-' dash after the 3rd digit.";
            }
            if (submission.Substring(7).IndexOf('-') != 0)
            {
                missedRequirements[2] = "Invalid formatting. Missing final '-' dash after the 6th digit.";
            }

            int i = 0;
            int i2 = 0;
            foreach (string item in missedRequirements)
            {
                if (missedRequirements[i] != null)
                {
                    Console.WriteLine(missedRequirements[i]);
                    i2++;
                }
                i++;
            }

            if (i2 != 0)
            {
                return verified;
            }
            else
            {
                if (!ContainsNumbers(submission.Substring(0, 3)) || !ContainsNumbers(submission.Substring(4, 3)) || !ContainsNumbers(submission.Substring(8)))
                {
                    return verified;
                }
                else
                {
                    verified = true;
                    return verified;
                }
                
            }
        }
    }
}