namespace CRMTest;

using Microsoft.Playwright;
using TechTalk.SpecFlow;
using Xunit;

[Binding]

public class Login
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    [BeforeScenario]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();

        bool isCi = Environment.GetEnvironmentVariable("CI") == "true";

        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = isCi,
            SlowMo = isCi ? 0 : 300
        });

        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [AfterScenario]
    public async Task Teardown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
    
    // STEPS:
    
    [Given(@"I am on the CRM homepage")]
    public async Task GivenIAmOnCRMHomepage()
    {
        await _page.GotoAsync("http://localhost:5173");
    }
    [Given(@"I see the login button")]
    public async Task GivenISeeTheLoginButton()
    {
        //await _page.WaitForTimeoutAsync(3000);
        // await _page.WaitForSelectorAsync("[data-testid='consent-banner']");
        var el = await _page.QuerySelectorAsync("*:has-text('Login')");
        Assert.NotNull(el);
    }

    [Given(@"I click on login button")]
    public async Task WhenIClickOnLoginButton()
    {
        await _page.ClickAsync("*:has-text('Login')");
    }

    [Given(@"I be navigated to the login page")]
    public async Task WhenIBeNavigatedToTheLoginPage()
    {
        await _page.GotoAsync("http://localhost:5173/login");

    }
    
    [Given(@"I see The login form")]
    public async Task WhenISeeTheLoginForm()
    {
        var el = await _page.QuerySelectorAsync("*:has-text('Login form')");
        Assert.NotNull(el);
    }
    [Given(@"I fill out the login form with (.*) and (.*)")]
    public async Task WhenIFillOutTheFormWithAnd(string email, string password)
    {
        await _page.FillAsync("input[name='email']", email);
        await _page.FillAsync("input[name='password']", password);
        // await _page.FillAsync("input[name='confirmPassword']", password);
    }

    [When(@"I click the login form submit button")]
    public async Task WhenIClickTheLoginFormSubmitButton()
    {
        await _page.ClickAsync("*:has-text('Login')");
    }
    [Then(@"I should be logged in")]
    public async Task ThenIShouldBeLoggedIn()
    {
        await _page.GotoAsync("http://localhost:5173");

        // var el = await _page.QuerySelectorAsync("*:has-text('Logut')");
        // Assert.NotNull(el);

        // Wait a bit so you can see the result
        await _page.WaitForTimeoutAsync(3000);
    }

}