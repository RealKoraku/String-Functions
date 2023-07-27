namespace stringfuncts {
    internal class Program {
        static void Main(string[] args) {

            bool contains = StringContains("Fire", 'f'); //check if char is contained in a string
            Console.WriteLine($"StringContains: {contains}");

            bool contains2 = StringContains("Fire", "fir"); //check if string contains string
            Console.WriteLine($"StringContains(2): {contains2}");

            string padleft = PadLeft("apple", 'c', 3); //select char and amount to insert at beginning of string
            Console.WriteLine($"PadLeft: {padleft}");

            string padright = PadRight("apple", 'c', 3); //select char and amount to insert at end of string
            Console.WriteLine($"PadRight: {padright}");

            string padmid = PadMiddle("apple", 'c', 3); //sselect char and amount to insert at end of string
            Console.WriteLine($"PadMiddle: {padmid}");

            string remove = StringRemove("apple", 'p'); //remove a char from a string
            Console.WriteLine($"StringRemove: {remove}");

            string intersect = StringIntersection("growler", "glow"); //create a string based on only the chars that are the same character and the same position
            Console.WriteLine($"StringIntersection: {intersect}");

            string union = StringUnion("jazz", "pizazz"); //create a string of unique characters from each string
            Console.WriteLine($"StringUnion: {union}");

            string replace = StringReplace("apple", 'p', 'd'); //replace the specified character with the new character
            Console.WriteLine($"StringReplace: {replace}");

            bool numeric = StringIsNumeric("321.86");  //check if a string resembles a number or decimal
            Console.WriteLine($"StringIsNumeric: {numeric}");

            string[] splits = StringSplit("imississippi", 'i'); //split a string into an array on specified character
            Console.WriteLine("StringSplit: ");
            for (int i = 0; i < splits.Length; i++) {
                Console.Write($"{splits[i]}" + " ");
            }
            Console.WriteLine();

            string sentCase = SentenceCase("apples and... oranges and? bananas!"); //provide proper capitalization sentences
            Console.WriteLine($"SentenceCase: {sentCase}");

            string reverse = StringReverse("snapple"); //print the string in reverse
            Console.WriteLine($"StringReverse: {reverse}");

            string tolower = ToLowercase("ApPlEZ"); //make a string entirely lowercase
            Console.WriteLine($"ToLowercase: {tolower}");

            string toupper = ToUppercase("aPPlEz"); //make a string entirely uppercase
            Console.WriteLine($"ToUppercase: {toupper}");

        }//end main

        #region functions
        static string PadLeft(string str, char pad, int length) {

            char[] padStr = new char[length]; //create pad string (ccc)

            for (int i = 0; i < length; i++) {
                padStr[i] = pad;
            }
            string padding = new string(padStr);

            return padding + str;
        }

        static string PadRight(string str, char pad, int length) {

            char[] padStr = new char[length];

            for (int i = 0; i < length; i++) {
                padStr[i] = pad;
            }
            string padding = new string(padStr);

            return str + padding;
        }

        static string PadMiddle(string str, char pad, int length) {
            string str1;
            string str2;
            char[] chrArray = str.ToCharArray();
            char[] chrArray2 = new char[chrArray.Length / 2 + chrArray.Length % 2];
            char[] chrArray3 = new char[chrArray.Length / 2];
            char[] padArray = new char[length];

            for (int i = 0; i < chrArray.Length; i++) {

                if (i < chrArray2.Length) {
                    chrArray2[i] += str[i];
                }

                if (i >= chrArray2.Length) {
                    for (int j = 0; j < chrArray3.Length; j++) {
                        chrArray3[j] += str[i];
                        i++;
                    }
                }
            }

            for (int i = 0; i < length; i++) { //create pad 
                padArray[i] = pad;
            }


            str1 = new string(chrArray2);
            str2 = new string(chrArray3);
            string padding = new string(padArray);
            return str1 + padding + str2;
        }

        static string SentenceCase(string str) {

            char[] chrArray = str.ToCharArray();
            bool firstLetter = true;

            for (int i = 0; i < str.Length; i++) {

                if (str[i] == '.' || str[i] == '!' || str[i] == '?') {
                    firstLetter = true;
                }

                if ((chrArray[i] >= (char)97 && chrArray[i] <= (char)122) && firstLetter) {
                    chrArray[i] = (char)((int)chrArray[i] - 32);
                    firstLetter = false;
                }
            }
            str = new string(chrArray);
            return str;
        }

        static bool StringContains(string str, char chr) {
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == chr) {
                    return true;
                }
            }
            return false;
        }

        static bool StringContains(string str, string str2) {

            for (int i = 0; i < str2.Length; i++) {
                if ((str2[i] != str[i]) & (str2[i] + (char)32 != str[i]) && (str2[i] - (char)32 != str[i])) {
                    return false;
                }
            }
            return true;
        }

        static string StringIntersection(string str1, string str2) {
            char[] str1Array = str1.ToCharArray();
            char[] str2Array = str2.ToCharArray();
            string newString = "";

            if (str1.Length > str2.Length) {

                for (int i = 0; i < str2.Length; i++) {
                    if (char.ToLower(str2[i]) == char.ToLower(str1[i])) {
                        newString += str2[i];
                    }
                }
            } else {

                for (int i = 0; i < str1.Length; i++) {
                    if (char.ToLower(str1[i]) == char.ToLower(str2[i])) {
                        newString += str1[i];
                    }
                }
            }
            return newString;
        }

        static bool StringIsNumeric(string str) {
            int deci = 0;

            for (int i = 0; i < str.Length; i++) {
                if ((str[i] < (char)48) || (str[i] > (char)57)) {
                    if (str[i] != (char)46) {
                        return false;
                    }
                }
                if (str[i] == (char)46) {
                    deci = deci + 1;
                }
                if (deci > 1) {
                    return false;
                }
            }
            return true;
        }

        static string StringRemove(string str, char chr) {
            char[] strArray;
            strArray = str.ToCharArray();

            for (int i = 0; i < strArray.Length; i++) {
                if (strArray[i] == chr) {
                    strArray[i] = '\0';
                }
            }
            string newStr = new string(strArray);
            return newStr;
        }

        static string StringReplace(string str, char origin, char replace) {
            char[] strArray = str.ToCharArray();
            for (int i = 0; i < strArray.Length; i++) {
                if (strArray[i] == origin) {
                    strArray[i] = replace;
                }
            }
            str = new string(strArray);
            return str;
        }

        static string StringReverse(string str) {

            int j = str.Length - 1;
            char[] charArray1 = str.ToCharArray();
            char[] charArray2 = new char[str.Length];

            for (int i = 0; i < charArray1.Length; i++) {
                charArray2[j] = charArray1[i];
                if (j > 0) {
                    j--;
                }
            }
            string str2 = new string(charArray2);
            return str2;

        }

        static string[] StringSplit(string str, char split) {
            int j = 0;
            int splitNum = 0;
            char[] chrArray = str.ToCharArray();


            for (int k = 0; k < str.Length; k++) {
                if (chrArray[k] == split) {
                    splitNum++;
                }
            }
            string[] strArray = new string[splitNum + 1];

            for (int i = 0; i < str.Length; i++) {

                if (chrArray[i] != split) {
                    strArray[j] += chrArray[i];
                } else {
                    j++;
                }
            }
            return strArray;
        }

        static string StringUnion(string str1, string str2) {
            bool contains;
            string unique = "";

            for (int i = 0; i < str1.Length; i++) {
                if (StringContains(unique, str1[i]) == false) {
                    unique += str1[i];
                }
            }
            for (int i = 0; i < str2.Length; i++) {
                if (StringContains(unique, str2[i]) == false) {
                    unique += str2[i];
                }
            }
            return unique;
        }
    

        static string ToLowercase(string str) {
            int i = 0;

            char[] chrArray = str.ToCharArray();
            while (i < chrArray.Length) {
                if (chrArray[i] >= (char)65 && chrArray[i] <= (char)90) {
                    chrArray[i] = (char)((int)chrArray[i] + 32);
                    i++;
                } else i++;
            }
            str = new string(chrArray);
            return str;
        }

        static string ToUppercase(string str) {
            int i = 0;

            char[] chrArray = str.ToCharArray();
            while (i < chrArray.Length) {
                if (chrArray[i] >= (char)97 && chrArray[i] <= (char)122) {
                    chrArray[i] = (char)((int)chrArray[i] - 32);
                    i++;
                } else i++;
            }
            str = new string(chrArray);
            return str;
        }

        static void ForLoopFun () {
            long result;
            for (long i = 2; i < 9223372036854775806; i+=0) {
                Console.WriteLine($"{i}");
                i = i * i;
                if (i == 0) { 
                    break;
                };
            }
        }
#endregion
    }
}