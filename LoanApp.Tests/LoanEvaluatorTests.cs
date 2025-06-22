namespace LoanApp.Tests;

public class LoanEvaluatorTests
{
    [Fact]
    public void CheckDependents_NoDependents_ReturnsEligible()
    {
        // Arrange
        int dependents = 0;

        // Act
        string result = new LoanEvaluator().CheckDependents(dependents);

        // Assert
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void CheckDependents_LessThanTwoDependents_ReturnsReviewManually()
    {
        // Arrange
        int dependents = 1;

        // Act
        string result = new LoanEvaluator().CheckDependents(dependents);

        // Assert
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void CheckDependents_MoreThanTwoDependents_ReturnsNotEligible()
    {
        // Arrange
        int dependents = 3;

        // Act
        string result = new LoanEvaluator().CheckDependents(dependents);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void CheckOwningHouse_OwnsHouse_ReturnsReviewManually()
    {
        // Arrange
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckOwningHouse(ownsHouse);

        // Assert
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void CheckOwningHouse_NotOwnsHouse_ReturnsNotEligible()
    {
        // Arrange
        bool ownsHouse = false;

        // Act
        string result = new LoanEvaluator().CheckOwningHouse(ownsHouse);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void CheckHavingJob_CreditScoreMoreThan700_CheckDependents()
    {
        // Arrange
        int creditScore = 700;
        int dependents = 0;
        bool ownsHouse = false;

        // Act
        LoanEvaluator evaluator = new LoanEvaluator();
        string result = evaluator.CheckHavingJob(creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal(evaluator.CheckDependents(dependents), result);
    }

    [Fact]
    public void CheckHavingJob_CreditScoreMoreThan600_CheckOwningHouse()
    {
        // Arrange
        int creditScore = 650;
        int dependents = 0;
        bool ownsHouse = false;

        // Act
        LoanEvaluator evaluator = new LoanEvaluator();
        string result = evaluator.CheckHavingJob(creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal(evaluator.CheckOwningHouse(ownsHouse), result);
    }

    [Fact]
    public void CheckHavingJob_CreditScoreLessThan600_ReturnsNotEligible()
    {
        // Arrange
        int creditScore = 500;
        int dependents = 0;
        bool ownsHouse = false;

        // Act
        LoanEvaluator evaluator = new LoanEvaluator();
        string result = evaluator.CheckHavingJob(creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void CheckIfNotHaveJob_AllConditionsMet_ReturnsEligible()
    {
        // Arrange
        int income = 5001;
        int creditScore = 750;
        int dependents = 0;
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Eligible", result);
    }

    [Fact]
    public void CheckIfNotHaveJob_NoHouseButOtherConditionsMet_ReturnsReviewManually()
    {
        // Arrange
        int income = 6000;
        int creditScore = 800;
        int dependents = 0;
        bool ownsHouse = false;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Review Manually", result);
    }


    [Fact]
    public void CheckIfNotHaveJob_LowIncomeButOtherConditionsMet_ReturnsReviewManually()
    {
        // Arrange
        int income = 5000;
        int creditScore = 800;
        int dependents = 0;
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Review Manually", result);
    }


    [Fact]
    public void CheckIfNotHaveJob_MinCreditScoreAndNoDependents_ReturnsReviewManually()
    {
        // Arrange
        int income = 6000;
        int creditScore = 650;
        int dependents = 0;
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Review Manually", result);
    }

    [Fact]
    public void CheckIfNotHaveJob_CreditScoreTooLow_ReturnsNotEligible()
    {
        // Arrange
        int income = 6000;
        int creditScore = 649;
        int dependents = 0;
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void CheckIfNotHaveJob_DependentsExist_ReturnsNotEligible()
    {
        // Arrange
        int income = 6000;
        int creditScore = 700;
        int dependents = 1;
        bool ownsHouse = true;

        // Act
        string result = new LoanEvaluator().CheckIfNotHaveJob(income, creditScore, dependents, ownsHouse);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_IncomeLessThan2000_ReturnsNotEligible()
    {
        // Arrange
        int income = 1000;

        // Act
        string result = new LoanEvaluator().GetLoanEligibility(income, default, default, default, default);

        // Assert
        Assert.Equal("Not Eligible", result);
    }

    [Fact]
    public void GetLoanEligibility_HasJob_CheckHavingJob()
    {
        // Arrange
        int income = 3000;
        bool hasJob = true;

        // Act
        LoanEvaluator evaluator = new LoanEvaluator();
        string result = evaluator.GetLoanEligibility(income, hasJob, default, default, default);

        // Assert
        Assert.Equal(evaluator.CheckHavingJob(default, default, default), result);
    }
    
    [Fact]
    public void GetLoanEligibility_IncomeMoreThan2000AndNotHasJob_CheckIfNotHaveJob()
    {
        // Arrange
        int income = 3000;
        bool hasJob = false;

        // Act
        LoanEvaluator evaluator = new LoanEvaluator();
        string result = evaluator.GetLoanEligibility(income, hasJob, default, default, default);

        // Assert
        Assert.Equal(evaluator.CheckIfNotHaveJob(income, default, default, default), result);
    }
}
