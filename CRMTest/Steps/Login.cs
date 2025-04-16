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
            SlowMo = isCi ? 0 : 1000
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
        await _page.GotoAsync("http://localhost:3000");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle); 
    }
    [Given(@"I see the login button")]
    public async Task GivenISeeTheLoginButton()
    {
        //await _page.WaitForTimeoutAsync(3000);
        // await _page.WaitForSelectorAsync("[data-testid='consent-banner']");
        await _page.WaitForSelectorAsync("*:has-text('Login')"); 
        var el = await _page.QuerySelectorAsync("*:has-text('Login')");
        Assert.NotNull(el);
    }

    [Given(@"I click on login button")]
    public async Task WhenIClickOnLoginButton()
    {
        await _page.ClickAsync("*:has-text('Login')");
        await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded); // Wait after click
    }

    [Given(@"I be navigated to the login page")]
    public async Task WhenIBeNavigatedToTheLoginPage()
    {
        await _page.GotoAsync("http://localhost:3000/login");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

    }
    
    [Given(@"I see The login form")]
    public async Task WhenISeeTheLoginForm()
    {
        await _page.WaitForSelectorAsync("*:has-text('Login form')");
        var el = await _page.QuerySelectorAsync("*:has-text('Login form')");
        Assert.NotNull(el);
    }
    [Given(@"I fill out the login form with (.*) and (.*)")]
    public async Task WhenIFillOutTheFormWithAnd(string email, string password)
    {
        await _page.FillAsync("input[name='email']", email);
        await _page.FillAsync("input[name='password']", password);
    }

    [When(@"I click the login form submit button")]
    public async Task WhenIClickTheLoginFormSubmitButton()
    {
        await _page.ClickAsync("[type='submit']");
    }

    [Then(@"I should be logged and click Logout button to return to homePage")]
    public async Task ThenIShouldBeLoggedIn()
    {
        await _page.WaitForSelectorAsync("*:has-text('Logout')");

        var logoutButton = await _page.QuerySelectorAsync("*:has-text('Logout')");
        Assert.NotNull(logoutButton);
        await logoutButton.ClickAsync();
        await _page.GotoAsync("http://localhost:3000");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }


}