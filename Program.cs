using System.Text;

char tempChar = '\0';
int keyCount = 0;

Dictionary<char, string> keypad = new Dictionary<char, string>
{
    { '1', "" },        // special charaters of keypad phone
    { '2', "ABC" },
    { '3', "DEF" },
    { '4', "GHI" },
    { '5', "JKL" },
    { '6', "MNO" },
    { '7', "PQRS" },
    { '8', "TUV" },
    { '9', "WXYZ" },
    { '0', " " }        // space character
};

void resetKeyAndCounter()
{
    tempChar = '\0';
    keyCount = 0;
}

string OldPhonePad(string input)
{
    StringBuilder keySequence = new StringBuilder();
    foreach (char c in input)
    {
        if (c == '#') break;

        if (c == tempChar) keyCount++;              // if the key is as same as previous, continue counting 
        else                                        // else apppend char to key sequence 
        {
            if (tempChar != '\0')
            {
                keySequence.Append(keypad[tempChar][(keyCount - 1) % keypad[tempChar].Length]);
            }
            tempChar = c;
            keyCount = 1;
        }

        if (c == ' ')                               // if the key is white space, reset the counter 
        {
            resetKeyAndCounter();
        }

        if (c == '*')                               // if the key is '*', remove the last letter of sequence and reset the counter 
        {
            if (keySequence.Length > 0) keySequence.Length--;
            resetKeyAndCounter();
        }
    }

    if (tempChar != '\0')
    {
        keySequence.Append(keypad[tempChar][(keyCount - 1) % keypad[tempChar].Length]);
    }

    return keySequence.ToString();
}

// Console.WriteLine(OldPhonePad("33#"));                     // output => E

// Console.WriteLine(OldPhonePad("227 *#"));                  // output => B

// Console.WriteLine(OldPhonePad("4433555 555666#"));         // output => HELLO 

Console.WriteLine(OldPhonePad("8 88777444666 * 664#"));    // output => TURING