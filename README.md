# OldPhonePad

## Explanation

1. Keypad Mapping:
    * The `keypad` dictionary maps each digit to its corresponding letters.

2. Processing Each Character:
    * Iterate through each character in the input.
    * If the character is `#`, break out of the loop.
    * If the character is the same as the temp character, increment the key count.
    * If the character is different, append the corresponding letter from the temp character's key sequence to the key sequence and reset the temp character and key count.
    * If the character is a white space, handle the pause by appending the current character and resetting the counters.
    * If the character is `*`, handle the backspace by removing the last character from the key sequence.
    * If the character is not null or `\0`, appends the appropriate character to the output based on the previous character and its count.