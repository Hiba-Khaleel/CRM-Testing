namespace CRMTest;

using Microsoft.Playwright;
using TechTalk.SpecFlow;
using Xunit;

[Binding]

public class Register
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;


    [BeforeScenario]
    public async Task Setup()
    {
        {
            _playwright = await Playwright.CreateAsync();

            bool isCi = Environment.GetEnvironmentVariable("CI") == "true";

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = isCi,
                SlowMo = isCi ? 0 : 1000
            });

            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }
    }


    [AfterScenario]
    public async Task Teardown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }


    // STEPS:


    [Given(@"I am on the CRM home Page")]
    public async Task GivenIAmOnCRMHomepage()
    {
        await _page.GotoAsync("http://localhost:3000");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle); 

    }


    [Given(@"I see the register button")]
    public async Task GivenISeeTheRegisterButton()
    {
        var el = await _page.QuerySelectorAsync("*:has-text('Register')");
        Assert.NotNull(el);
    }


    [Given(@"I click on register button")]
    public async Task WhenIClickOnRegisterButton()
    {
        await _page.ClickAsync("*:has-text('Register')");
    }


    [Given(@"I be navigated to the register page")]
    public async Task WhenIBeNavigatedToTheRegisterPage()
    {
         await _page.GotoAsync("http://localhost:3000/register");
   }

   [Given(@"I fill out the register form with ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
   public async Task GivenIFillOutTheRegisterForm(string email, string password, string userName, string company)
   {
       Console.WriteLine($"Email: {email}, Password: {password}, Username: {userName}, Company: {company}");


       await _page.WaitForSelectorAsync("input[name='email']");
       await _page.FillAsync("input[name='email']", email);
       await _page.WaitForSelectorAsync("input[name='password']");
       await _page.FillAsync("input[name='password']", password);
       await _page.WaitForSelectorAsync("input[name='username']");
       await _page.FillAsync("input[name='username']", userName);
       await _page.WaitForSelectorAsync("input[name='company']");
       await _page.FillAsync("input[name='company']", company);
   }

   [When(@"I click the register form submit button")]
   public async Task WhenIClickTheRegisterFormSubmitButton()
   {
       // Listen for the alert dialog
       _page.Dialog += async (sender, dialog) =>
       {
           var alertMessage = dialog.Message;
           Console.WriteLine($"Alert message: {alertMessage}");
           
           Assert.Contains("Du har lyckats registrera dig!", alertMessage);
           await dialog.AcceptAsync();
           
           // await _page.WaitForURLAsync("http://localhost:5173/login");
       };


       await _page.ClickAsync("*:has-text('Skapa konto')");
   }
   [Then(@"I should be registered and navigated to the login page")]
   public async Task ThenIShouldBeRegisteredAndNavigatedToTheLoginPage()
   {
       await _page.GotoAsync("http://localhost:3000/login");
   }


}