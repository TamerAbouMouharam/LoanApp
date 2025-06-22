namespace LoanApp;

public class LoanEvaluator
{
    public string CheckDependents(int dependents)
    {
        if (dependents == 0)
            return "Eligible";
        else if (dependents <= 2)
            return "Review Manually";
        else
            return "Not Eligible";
    }

    public string CheckOwningHouse(bool ownsHouse)
    {
        if (ownsHouse)
            return "Review Manually";
        else
            return "Not Eligible";
    }

    public string CheckHavingJob(int creditScore, int dependents, bool ownsHouse)
    {
        if (creditScore >= 700)
            return CheckDependents(dependents);
        else if (creditScore >= 600)
            return CheckOwningHouse(ownsHouse);
        else
            return "Not Eligible";
    }

    public string CheckIfNotHaveJob(int income, int creditScore, int dependents, bool ownsHouse)
    {
        if (creditScore >= 750 && income > 5000 && ownsHouse)
            return "Eligible";
        else if (creditScore >= 650 && dependents == 0)
            return "Review Manually";
        else
            return "Not Eligible";
    }

    public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
    {
        if (income < 2000)
            return "Not Eligible";
        else if (hasJob)
            return CheckHavingJob(creditScore, dependents, ownsHouse);
        else
            return CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);
    }
}
