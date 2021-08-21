using System.Text;
using GitHub;
using Microsoft.Extensions.Logging;

namespace ScientistDemo
{
    internal class MyTestClass : IMyTestClass
    {
        private readonly ILogger<MyTestClass> _logger;

        public MyTestClass(ILogger<MyTestClass> log)
        {
            _logger = log;
        }

        public void Run()
        {
            _logger.LogInformation(GiveMeAnA());
        }

        public string GiveMeAnA()
        {
            return Scientist.Science<string>("gimme-a", experiment =>
            {
                experiment.Use(() => _classic());
                experiment.Try("stringbuilder", () => _withStringBuilder());
            });
        }

        private string _classic()
        {
            var output = string.Empty;

            for (int i = 0; i < 100; i++)
            {
                output += "a";
            }

            return output;
        }

        private string _withStringBuilder()
        {
            var output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append('a');
            }

            return output.ToString();
        }
    }
}
