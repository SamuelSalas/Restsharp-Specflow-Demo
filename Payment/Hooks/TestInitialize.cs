using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Payment.Utilities;
using TechTalk.SpecFlow;

namespace Payment.Hooks
{
    [Binding]
    class TestInitialize
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;

        public TestInitialize(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            string file = "ExtentReport.html";
            var path = APIHelper.GetFilePath(file);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
        }

        [BeforeScenario]
        public void Initialize()
        {
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }
    }
}
