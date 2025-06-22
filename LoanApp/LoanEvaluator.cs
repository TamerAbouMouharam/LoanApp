namespace LoanApp;

public class LoanEvaluator
{
    public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
    {
        if (income < 2000)
            return "Not Eligible";
        if (hasJob)
        {
            if (creditScore >= 700)
            {
                if (dependents == 0)
                    return "Eligible";
                else if (dependents <= 2)
                    return "Review Manually";
                else
                    return "Not Eligible";
            }
            else if (creditScore >= 600)
            {
                if (ownsHouse)
                    return "Review Manually";
                else
                    return "Not Eligible";
            }
            else
            {
                return "Not Eligible";
            }
        }
        else
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";
            else
                return "Not Eligible";
        }
    }
}
