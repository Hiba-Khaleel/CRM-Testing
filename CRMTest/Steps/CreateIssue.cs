namespace CRMTest;

using Microsoft.Playwright;
using TechTalk.SpecFlow;
using Xunit;

[Binding]

public class CreateIssue
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
    
    
    [Given(@"I am logged in as ""(.*)"" with password ""(.*)""")]
    public async Task GivenIAmLoggedInAsWithPassword(string email, string password)
    {
        await _page.GotoAsync("http://localhost:3000");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await _page.WaitForSelectorAsync("*:has-text('Login')");
        await _page.ClickAsync("*:has-text('Login')");
        // await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        await _page.GotoAsync("http://localhost:3000/login");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);


        await _page.WaitForSelectorAsync("form");
        var el = await _page.QuerySelectorAsync("form");
        Assert.NotNull(el);
        await _page.FillAsync("input[name='email']", email);
        await _page.FillAsync("input[name='password']", password);
        await _page.ClickAsync("[type='submit']");
    }

    [Given(@"I see the company name")]
    public async Task GivenISeeTheCompanyName()
    {
       var companyName= await _page.QuerySelectorAsync("*:has-text('Demo AB')");
       Assert.NotNull(companyName);
    }    
    [Given(@"I click on the company name")]
    public async Task GivenIClickOnTheCompanyName()
    {
       await _page.ClickAsync("*:has-text('Demo AB')");
       await _page.GotoAsync("http://localhost:3000/Demo%20AB/issueform");
       await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

       
    }    
    [Given(@"I see the Issue form")]
    public async Task GivenISeeTheIssueForm()
    {
        var form = await _page.QuerySelectorAsync("form");
        Assert.NotNull(form);
    }
    [Given(@"I fill it by ""(.*)"", ""(.*)"" and ""(.*)""")]
    public async Task GivenIFillItByAnd(string senderEmail, string title, string message)
    {
        await _page.FillAsync("input[name='email']", senderEmail);
        await _page.FillAsync("input[name='title']", title);
        await _page.FillAsync("textarea[name='message']", message);
    }

    [When(@"I click create issue button")]
    public async Task WhenIClickCreateIssueButton()
    {
        await _page.ClickAsync("button[type='submit']"); 
    }



}