namespace CRMTest;

using Microsoft.Playwright;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
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
        // await _page.WaitForLoadStateAsync(LoadState.NetworkIdle); 

    }
    [Given(@"I see the login button")]
    public async Task GivenISeeTheLoginButton()
    {
        await _page.WaitForSelectorAsync("*:has-text('Login')"); 
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
        await _page.GotoAsync("http://localhost:3000/login");

    }
    
    
    [Given(@"I see the login form and I fill out the login form with ""(.*)"" and ""(.*)""")]
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
        var logoutButton = await _page.WaitForSelectorAsync("button:has-text('Logout')", new PageWaitForSelectorOptions
        {
            Timeout = 5000 
        });

        Assert.NotNull(logoutButton);
        await logoutButton.ClickAsync();

       
    }


}