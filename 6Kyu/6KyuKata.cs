/*1. Convert string to camel case
 * Complete the method/function so that it converts dash/underscore delimited words into camel casing.
 * The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case).
 * Examples"the-stealth-warrior" gets converted to "theStealthWarrior"   "The_Stealth_Warrior" gets converted to "TheStealthWarrior"
 */
static string ToCamelCase(string str)
{
    char[] delimiters = { '_', '-' };
    string[] words = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < words.Length; i++)
    {
        if (i == 0 && words[0][0].ToString() == words[0][0].ToString().ToLower())
        {
            continue;
        }
        else
        {
            words[i] = words[i][0].ToString().ToUpper() + words[i].Substring(1);
        }
    }
    str = "";
    Array.ForEach(words, w => str += w);
    return str;
}

/* 2. Counting Duplicates
 * Count the number of Duplicates
 * Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once
 * in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.
 * Example    "abcde" -> 0 # no characters repeats more than once     "aabbcde" -> 2 # 'a' and 'b'
 * "aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)      "indivisibility" -> 1 # 'i' occurs six times
 * "Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
 * "aA11" -> 2 # 'a' and '1'                                          "ABBA" -> 2 # 'A' and 'B' each occur twice
 */
static int DuplicateCount(string str)
{
    str = str.ToLower();
    int count = 0;
    List<char> copy = str.ToList();
    foreach (char x in copy)
    {
        if ((str.IndexOf(x) != str.LastIndexOf(x)) && str.Contains(x))
        {
            count++;
            str = str.Replace(x, ' ');
        }
    }
    return count;
}

/*3. Playing with digits
 * Some numbers have funny properties. For example: 89-- > 8¹ +9² = 89 * 1   695-- > 6² +9³ +5⁴= 1390 = 695 * 2   46288-- > 4³ +6⁴+2⁵ +8⁶ +8⁷ = 2360688 = 46288 * 51
 * Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p
 * we want to find a positive integer k, if it exists, such that the sum of the digits of n taken to the successive powers of p is equal to k * n.
 * In other words: Is there an integer k such as : (a ^ p + b ^ (p + 1) + c ^ (p + 2) + d ^ (p + 3) + ...) = n * k
 * If it is the case we will return k, if not return -1.  Note: n and p will always be given as strictly positive integers.
 */
static long digPow(int n, int p)
{
    int[] digits = n.ToString().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
    double sum = 0;
    for (int i = 0; i < digits.Length; i++)
    {
        sum += Math.Pow(digits[i], p);
        p++;
    }
    double k = sum / n;
    return k == Math.Floor(k) && k != 0 ? Convert.ToInt64(k) : -1;
}

/*4.  Persistent Bugger.
 * Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, 
 * which is the number of times you must multiply the digits in num until you reach a single digit.
 * For example (Input --> Output): 39 --> 3 (because 3*9 = 27, 2*7 = 14, 1*4 = 4 and 4 has only one digit)
 * 999 --> 4 (because 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, and finally 1*2 = 2)  4 --> 0 (because 4 is already a one-digit number)
 */
static int Persistence(long n)
{
    int count = 0;
    while (n.ToString().Length > 1)
    {
        char[] digits = n.ToString().ToCharArray();
        n = 1;
        for (int i = 0; i < digits.Length; i++)
        {
            n *= int.Parse(digits[i].ToString());
        }
        count++;
        Array.Clear(digits, 0, digits.Length);
    }
    return count;
}

/*5 Is a number prime?
 * Define a function that takes an integer argument and returns a logical value true or false depending on if the integer is a prime.
 * Per Wikipedia, a prime number ( or a prime ) is a natural number greater than 1 that has no positive divisors other than 1 and itself.
 * Requirements       You can assume you will be given an integer input.
 * You can not assume that the integer will be only positive. You may be given negative numbers as well ( or 0 ).
 * NOTE on performance: There are no fancy optimizations required, but still the most trivial solutions might time out. 
 * Numbers go up to 2^31 ( or similar, depending on language ). Looping all the way up to n, or n/2, will be too slow.
 * Example    is_prime(1)   false      is_prime(2)   true      is_prime(-1)  false 
 */
static bool IsPrime(int n)
{
    Console.WriteLine(n);
    bool prime = true;
    if (n < 2)
    {
        prime = false;
    }
    else if (n % 2 == 0 && n != 2)
    {
        prime = false;
    }
    else
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                prime = false;
                break;
            }
        }
    }
    return prime;
}

/*6. Multiples of 3 or 5
 * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
 * Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
 * Additionally, if the number is negative, return 0 (for languages that do have them).
 * Note: If the number is a multiple of both 3 and 5, only count it once.
 */
static int Solution(int value)
{
    List<int> multiples = new List<int>();
    value--;
    while (value > 0)
    {
        if (value % 3 == 0 || value % 5 == 0)
        {
            multiples.Add(value);
        }
        value--;
    }
    return multiples.ToArray().Sum();
}

/*7. Create Phone Number
 * Write a function that accepts an array of 10 integers (between 0 and 9), that returns a string of those numbers in the form of a phone number.
 * Example    Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
 * The returned format must be correct in order to complete this challenge. Don't forget the space after the closing parentheses!
 */
static string CreatePhoneNumber(int[] numbers)
{
    List<string> digits = new();
    Array.ForEach(numbers, n => digits.Add(n.ToString()));
    digits.Insert(0, "(");
    digits.Insert(4, ")");
    digits.Insert(5, " ");
    digits.Insert(9, "-");
    string str = "";
    digits.ForEach(c => str += c);
    return str;
}

/*8. Tortoise racing
 * Two tortoises named A and B must run a race. A starts with an average speed of 720 feet per hour. 
 * Young B knows she runs faster than A, and furthermore has not finished her cabbage.
 * When she starts, at last, she can see that A has a 70 feet lead but B's speed is 850 feet per hour. How long will it take B to catch A?
 * More generally: given two speeds v1 (A's speed, integer > 0) and v2 (B's speed, integer > 0) and a lead g (integer > 0) how long will it take B to catch A?
 * The result will be an array [hour, min, sec] which is the time needed in hours, minutes and seconds (round down to the nearest second) or a string in some languages.
 * If v1 >= v2 then return nil, nothing, null, None or {-1, -1, -1} for C++, C, Go, Nim, Pascal, COBOL, Erlang, [-1, -1, -1] for Perl,[] for Kotlin or "-1 -1 -1".
 * Examples:  (form of the result depends on the language)    race(720, 850, 70) => [0, 32, 18] or "0 32 18"    race(80, 91, 37)   => [3, 21, 49] or "3 21 49"
 * Note:  See other examples in "Your test cases".     In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
 * Hints for people who don't know how to convert to hours, minutes, seconds:  Tortoises don't care about fractions of seconds    Think of calculation by hand using only integers (in your code use or simulate integer division)  or Google: "convert decimal time to hours minutes seconds"
 */
static int[] Race(double v1, double v2, double g)
{
    if (v1 >= v2)
    {
        return null;
    }
    int[] time = new int[3];
    int seconds = (int)((double)g / (v2 - v1) * 3600);
    time[0] = seconds / 3600;
    time[1] = seconds % 3600 / 60;
    time[2] = seconds % 60;
    return time;
}

/*9. Sum of Digits/Digital Root
 * Digital root is the recursive sum of all the digits in a number.
 * Given n, take the sum of the digits of n. If that value has more than one digit, 
 * continue reducing in this way until a single-digit number is produced. The input will be a non-negative integer.
 * Examples     16  -->  1 + 6 = 7     942  -->  9 + 4 + 2 = 15  -->  1 + 5 = 6
 * 132189  -->  1 + 3 + 2 + 1 + 8 + 9 = 24  -->  2 + 4 = 6         493193  -->  4 + 9 + 3 + 1 + 9 + 3 = 29  -->  2 + 9 = 11  -->  1 + 1 = 2
 */
static int DigitalRoot(long n)
{
    long num = n.ToString().Length;
    long sum = 0;
    do
    {
        sum = 0;
        for (int i = 0; i < num; i++)
        {
            sum += (n % 10);
            n /= 10;
        }
        n = sum;
        num = sum.ToString().Length;
    }
    while (num > 1);
    return Convert.ToInt32(sum);
}

/*10. Does my number look big in this?
 * A Narcissistic Number is a positive number which is the sum of its own digits, each raised to the power of the number of digits in a given base.
 * In this Kata, we will restrict ourselves to decimal (base 10). For example, take 153 (3 digits), which is narcisstic:
 * 1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153    and 1652 (4 digits), which isn't:   1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938
 * The Challenge: Your code must return true or false (not 'true' and 'false') depending upon whether the given number is a Narcissistic number in base 10. 
 * This may be True and False in your language, e.g. PHP.
 * Error checking for text strings or other invalid inputs is not required, only valid positive non-zero integers will be passed into the function.
 */
static bool Narcissistic(int value)
{
    int count = value.ToString().Length;
    double sum = 0;
    int num = value;
    for (int i = 0; i < count; i++)
    {
        sum += Math.Pow(num % 10, count);
        num /= 10;
    }
    return (int)((double)sum) == value;
}

/*11. Take a Ten Minutes Walk
 * You live in the city of Cartesia where all roads are laid out in a perfect grid. You arrived ten minutes too early to an appointment,
 * so you decided to take the opportunity to go for a short walk. The city provides its citizens with a Walk Generating App on their phones
 * -- everytime you press the button it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']). 
 * You always walk only a single block for each letter (direction) and you know it takes you one minute to traverse one city block,
 * so create a function that will return true if the walk the app gives you will take you exactly ten minutes (you don't want to be early or late!)
 * and will, of course, return you to your starting point. Return false otherwise.
 * Note: you will always receive a valid array containing a random assortment of direction letters ('n', 's', 'e', or 'w' only).
 * It will never give you an empty array (that's not a walk, that's standing still!)
 */
static bool IsValidWalk(string[] walk)
{
    if (walk.Length != 10)
    {
        return false;
    }
    else
    {
        Dictionary<string, int> directions = new Dictionary<string, int>()
        { {"n", 0}, {"s", 0}, {"e", 0}, {"w", 0},};
        foreach (string s in walk)
        {
            directions[s]++;
        }
        return directions["n"] == directions["s"] && directions["w"] == directions["e"];
    }
}

/*12. The Supermarket Queue
 * There is a queue for the self-checkout tills at the supermarket. Your task is write a function to calculate the total time required for all the customers to check out!
 * input  customers: an array of positive integers representing the queue. Each integer represents a customer,
 * and its value is the amount of time they require to check out.     n: a positive integer, the number of checkout tills.
 * output    The function should return an integer, the total time required.
 * Important    Please look at the examples and clarifications below, to ensure you understand the task correctly :)
 * Examples   queueTime([5,3,4], 1) // should return 12 // because when there is 1 till, the total time is just the sum of the times
 * queueTime([10,2,3,3], 2) // should return 10 // because here n=2 and the 2nd, 3rd, and 4th people in the  // queue finish before the 1st person has finished.
 * queueTime([2,3,10], 2) // should return 12 Clarifications  There is only ONE queue serving many tills, and The order of the queue NEVER changes, and
 * The front person in the queue (i.e. the first element in the array/list) proceeds to a till as soon as it becomes free.
 * N.B. You should assume that all the test input will be valid, as specified above.
 * P.S. The situation in this kata can be likened to the more-computer-science-related idea of a thread pool, with relation to running multiple processes at the same time: https://en.wikipedia.org/wiki/Thread_pool
 */
static long QueueTime(int[] customers, int n)
{
    int[] tills = new int[n];
    foreach (int i in customers)
    {
        tills[Array.IndexOf(tills, tills.Min())] += i;
    }
    return tills.Max();
}

/*13. Find the odd int
 * Given an array of integers, find the one that appears an odd number of times.
 * There will always be only one integer that appears an odd number of times.
 * Examples    [7] should return 7, because it occurs 1 time (which is odd). [0] should return 0, because it occurs 1 time (which is odd).
 * [1,1,2] should return 2, because it occurs 1 time (which is odd). [0,1,0,1,0] should return 0, because it occurs 3 times (which is odd).
 * [1,2,2,3,3,3,4,3,3,3,2,2,1] should return 4, because it appears 1 time (which is odd).
 */
static int find_it(int[] seq)
{
    return Array.Find(seq, x => seq.Count(y => y == x) % 2 != 0);
}

/*14.  Highest Scoring Word
 * Given a string of words, you need to find the highest scoring word.
 * Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
 * You need to return the highest scoring word as a string.
 * If two words score the same, return the word that appears earliest in the original string.
 * All letters will be lowercase and all inputs will be valid.
 */
static string High(string s)
{
    string[] str = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int max = 0;
    foreach (string word in str)
    {
        int score = word.Sum(x => char.ToUpper(x) - 64);
        if (score > max)
        {
            max = score;
            s = word;
        }
    }
    return s;
}

/*15. Find The Parity Outlier
 * You are given an array (which will have a length of at least 3, but could be very large) containing integers.
 * The array is either entirely comprised of odd integers or entirely comprised of even integers except for a single integer N.
 * Write a method that takes the array as an argument and returns this "outlier" N.
 * Examples  [2, 4, 0, 100, 4, 11, 2602, 36] Should return: 11 (the only odd number)
 * [160, 3, 1719, 19, 11, 13, -21] Should return: 160 (the only even number)
 */
static int Find(int[] integers)
{
    int[] nums = new int[integers.Length];
    integers.CopyTo(nums, 0);
    for (int i = 0; i < nums.Length; i++)
    {
        nums[i] %= 2;
    }
    int outlier = 0;
    foreach (int i in nums)
    {
        if (Array.IndexOf(nums, i) == Array.LastIndexOf(nums, i))
        {
            outlier = Array.IndexOf(nums, i);
        }
    }
    return integers[outlier];
}

/*16. Split Strings
 * Complete the solution so that it splits the string into pairs of two characters. 
 * If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').
 * Examples:  * 'abc' =>  ['ab', 'c_']     * 'abcdef' => ['ab', 'cd', 'ef']
 */
static string[] Solution2(string str)
{
    if (str.Length % 2 != 0)
    {
        str += "_";
    }
    string[] pairs = new string[str.Length / 2];
    for (int i = 0; i < str.Length; i += 2)
    {
        pairs[i / 2] = str.Substring(i, 2);
    }
    return pairs;
}

/*17. Duplicate Encoder
 * The goal of this exercise is to convert a string to a new string where each character in the new string
 * is "(" if that character appears only once in the original string, or ")" if that character appears more than once in the original string. 
 * Ignore capitalization when determining if a character is a duplicate.
 * Examples  "din"  =>  "((("     "recede"   =>  "()()()"      "Success"  =>  ")())())"          "(( @"   =>  "))((" 
 */
static string DuplicateEncode(string word)
{
    word = word.ToLower();
    string result = "";
    foreach (char c in word)
    {
        result = word.IndexOf(c) == word.LastIndexOf(c) ? result + "(" : result + ")";
    }
    return result;
}
