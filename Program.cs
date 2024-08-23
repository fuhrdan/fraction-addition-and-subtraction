//*****************************************************************************
//** 592. Fraction Addition and Subtraction  leetcode                        **
//**                                                                         **
//**                                                                         **
//**                                                                         **
//*****************************************************************************

int greatestCommonDivisor(int m, int d)
{
    return m == 0 ? d : greatestCommonDivisor(d % m, m);
}

char* fractionAddition(char* expression) {
    int numerator = 0;
    int denominator = 1;
    int scoreNumberator = 0;
    int scoreDenominator = 0;
    int symbol = 1;
    int num = 0;
    int i = 0;
    char currentExpression;
    
    while ((currentExpression = expression[i]) != '\0')
    {
        if (currentExpression == '-' || currentExpression == '+')
        {
            symbol = (currentExpression == '-') ? -1 : 1;
        }
        else if (currentExpression == '/')
        {
            scoreNumberator = symbol * num;
            num = 0;
        }
        else if (isdigit(currentExpression))
        {
            num = num * 10 + (currentExpression - '0');
        }

        // Check conditions for finalizing the fraction
        if ((currentExpression == '-' || currentExpression == '+') && num != 0)
        {
            scoreDenominator = num;
            numerator = scoreNumberator * denominator + scoreDenominator * numerator;
            denominator = scoreDenominator * denominator;
            
            int gcd = greatestCommonDivisor(abs(numerator), denominator);
            numerator /= gcd;
            denominator /= gcd;
            
            num = 0;
        }

        i++;
    }

    // Final case when loop ends but last number is not processed yet
    if (num != 0)
    {
        scoreDenominator = num;
        numerator = scoreNumberator * denominator + scoreDenominator * numerator;
        denominator = scoreDenominator * denominator;
        
        int gcd = greatestCommonDivisor(abs(numerator), denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Allocate memory for the result
    char* result = malloc(20 * sizeof(char));
    sprintf(result, "%d/%d", numerator, denominator);
    
    return result;
}