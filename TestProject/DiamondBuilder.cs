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
                return new[] { "A" };
            }

            var output = GetSizedOutputArray(charIndex);
            int totalLengthOfLine = GetLineLength(charIndex);

            int outerPadding = charIndex;

            bool beforeMiddle = true;
            for (var i = 0; i <= 2 * charIndex; i++)
            {
                char letter = GetAlphabeticCharacterByAscii(charIndex, i);

                if (letter == value)
                {
                    output[i] = AppendLineForInputLetter(charIndex, totalLengthOfLine, letter);
                }
                else
                {
                    output[i] = AppendLineForSurroundingLetter(totalLengthOfLine, outerPadding, i, letter);
                }

                outerPadding = GetOuterPadding(outerPadding, beforeMiddle);

                if (outerPadding == 0)
                {
                    beforeMiddle = false;
                }
            }
            return output;
        }

        private static char GetAlphabeticCharacterByAscii(int charIndex, int offset)
        {
            char letter;
            if (offset <= charIndex)
            {
                letter = (char)(65 + offset);
            }
            else
            {
                letter = (char)(65 + Math.Abs((2 * charIndex) - offset));
            }

            return letter;
        }

        private static int GetOuterPadding(int outerPadding, bool beforeMiddle)
        {
            if (beforeMiddle)
            {
                outerPadding--;
            }
            else
            {
                outerPadding++;
            }

            return outerPadding;
        }

        private static string AppendLineForSurroundingLetter(int totalLengthOfLine, int outerPadding, int i, char letter)
        {
            var secondPaddingLength = (totalLengthOfLine - 2) - (2 * outerPadding);
            secondPaddingLength = secondPaddingLength < 0 ? 0 : secondPaddingLength;

            var secondLetterCharacter = secondPaddingLength > 0 ? letter.ToString() : string.Empty;
            var secondLetter = i == 0 ? "" : $"{new string(' ', secondPaddingLength)}{secondLetterCharacter }";

            return $"{new string(' ', outerPadding)}{letter}{secondLetter}{new string(' ', outerPadding)}";
            
        }

        private static string AppendLineForInputLetter(int charIndex, int totalLengthOfLine, char letter)
        {
            var padding = new string(' ', charIndex);

            if (charIndex > 1)
            {
                padding = new string(' ', totalLengthOfLine - 2);
            }

            return $"{letter}{padding}{letter}";
        }

        private static string[] GetSizedOutputArray(int charIndex)
        {
            return new string[1 + (2 * charIndex)];
        }

        private static int GetLineLength(int charIndex)
        {
            return (2 * (1 + charIndex)) - 1;
        }
    }
}
//value = B

// 0  A
// 1  B
// 2  null
