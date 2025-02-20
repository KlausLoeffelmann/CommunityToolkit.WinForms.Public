using CommunityToolkit.WinForms.AI;
using CommunityToolkit.WinForms.AI.ConverterLogic;
using CommunityToolkit.WinForms.BasicTests.UnitTests.SemanticKernel.TestClass;

namespace CommunityToolkit.WinForms.BasicTests.UnitTests.SemanticKernel;

public class PromptBuilderTests
{
    [Fact]
    public void TestGetJsonSchema()
    {
        string expectedSchema = """
            {
              "$schema": "http://json-schema.org/draft-07/schema#",
              "type": "object",
              "properties": {
                "Guid": {
                  "type": "string",
                  "description": ""
                },
                "Items": {
                  "type": "array",
                  "description": "",
                  "items": {
                    "Guid": {
                      "type": "string",
                      "description": ""
                    },
                    "SourceCode": {
                      "type": "string",
                      "description": ""
                    },
                    "DetectedIssues": {
                      "type": "array",
                      "description": ""
                    },
                    "ConfidenceLevel": {
                      "type": "integer",
                      "description": ""
                    }
                  }
                }
              },
              "required": [
                "Guid",
                "Items"
              ],
              "additionalProperties": false
            }
            """;

        string json = PromptFromTypeGenerator.GetJSonSchema<AITemplateTestClass>();
        Assert.Equal(expectedSchema, json);

        string prompt = PromptFromTypeGenerator.GetTypePrompt<AITemplateTestClass>();
    }
}
