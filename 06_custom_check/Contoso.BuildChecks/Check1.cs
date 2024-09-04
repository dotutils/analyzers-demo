using Microsoft.Build.Construction;
using Microsoft.Build.Experimental.BuildCheck;
using System.Collections.Generic;

namespace Contoso.BuildChecks
{
    public sealed class Check1 : Check
    {
        public static CheckRule SupportedRule = new CheckRule(
            "X01234",
            "Title",
            "Description",
            "Unexpected value of 'Authors' property: '{0}', Should contain '{1}'",
            new CheckConfiguration());

        public override string FriendlyName => "Contoso.AuthorsCheck";
        private string _authorsName = "Contoso";

        public override IReadOnlyList<CheckRule> SupportedRules { get; } = new List<CheckRule>() { SupportedRule };

        private string message = "Argument for the message format";

        public override void Initialize(ConfigurationContext configurationContext)
        {
            if (configurationContext.CustomConfigurationData[0]?.ConfigurationData?.TryGetValue("authors_name", out string value) ?? false)
            {
                _authorsName = value;
            }
        }

        public override void RegisterActions(IBuildCheckRegistrationContext registrationContext)
        {
            registrationContext.RegisterEvaluatedPropertiesAction(EvaluatedPropertiesAction);
        }

        private void EvaluatedPropertiesAction(BuildCheckDataContext<EvaluatedPropertiesCheckData> context)
        {
            if (context.Data.EvaluatedProperties.TryGetValue("Authors", out string authors) && !authors.Contains(_authorsName))
            {
                context.ReportResult(BuildCheckResult.Create(
                    SupportedRule,
                    ElementLocation.EmptyLocation,
                    authors, _authorsName));

            }
        }
    }
}
