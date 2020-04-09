using System;
using Xunit.Abstractions;

namespace TestProject
{
    public class DiamondBuilder
    {
        private readonly ITestOutputHelper outputHelper;

        public DiamondBuilder(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        public string[] Build(char value)
        {
            int charIndex = value;
            charIndex -= 65;

            if (charIndex == 0)
            {
                var letter = (char)65;
                return new[] { letter.ToString() };
            }
            else
            {
                var output = new string[1 + (2 * charIndex)];
                var totalLengthOfLine = (2 * (1 + charIndex)) - 1;

                int outerPadding = charIndex;
                
                bool beforeMiddle = true;
                for (var i = 0; i <= 2 * charIndex; i++)
                {
                    var padding = new string(' ', charIndex);

                    char letter;
                    if (i <= charIndex)
                    {
                        letter = (char)(65 + i);
                    }
                    else
                    {
                        letter = (char)(65 + Math.Abs((2 * charIndex) - i));
                    }

                    if (letter == value)
                    {
                        if (charIndex > 1)
                        {
                            padding = new string(' ', totalLengthOfLine-2);
                        }

                        output[i] = $"{letter}{padding}{letter}";
                    }
                    else
                    {
                        var secondPaddingLength = (totalLengthOfLine - 2) - (2 * outerPadding);
                        secondPaddingLength = secondPaddingLength < 0 ? 0 : secondPaddingLength;

                        var secondLetterCharacter = secondPaddingLength > 0 ? letter.ToString() : string.Empty;
                        var secondLetter = i == 0 ? "" : $"{new string(' ', secondPaddingLength)}{secondLetterCharacter }";

                        output[i] = $"{new string(' ', outerPadding)}{letter}{secondLetter}{new string(' ', outerPadding)}";
                    }

                    if (beforeMiddle)
                    {
                        outerPadding--;
                    }
                    else
                    {
                        outerPadding++;
                    }

                    if (outerPadding == 0)
                    {
                        beforeMiddle = false;
                    }
                }

                return output;

            }
        }
    }
}
//value = B

// 0  A
// 1  B
// 2  null
