using System;
using System.Collections.Generic;
using BSC.Code.Library.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BSC.Code.Test
{
    class InputClass
    {
        public int item { get; set; }
        public string message { get; set; }
        public int multipleOf { get; set; }
    }



    [Binding]
    public class PrintMultipleOfInArraySteps
    {
        private Dictionary<int, InputClass> _arrayInputs;
        private List<int> _arrayOfIntegers;

        public PrintMultipleOfInArraySteps()
        {
            this._arrayInputs = new Dictionary<int, InputClass>();

        }

        [Given(@"an array of integers between (.*) and (.*)")]
        public void GivenAnArrayOfIntegersBetweenAnd(int initial, int final)
        {
            _arrayOfIntegers = BDD_Result.ArrayOfInteger(initial, final);
        }
        
        
        [When(@"The array have following items")]
        public void WhenTheArrayHaveFollowingItems(Table table)
        {
            //Arrange
            var rows = table.CreateSet<InputClass>();
            // Storing rach row/object in a dictionary
            foreach (InputClass obj in rows)
            {
                this._arrayInputs.Add(obj.item, obj);
            }
        }
        
        [Then(@"should print item")]
        public void ThenShouldPrintItem(Table table)
        {
            var expectedObjects = table.CreateSet<InputClass>();

            //Check that each object that should be present, really is present
            foreach (InputClass obj in expectedObjects)
            {
                InputClass actualObject = this._arrayInputs[obj.item];
                if (false == actualObject.message.Equals(obj.message))
                {
                    Assert.Fail(String.Format(
                        "Expected message '{0}', actual text was {1}", obj.message, actualObject.message));
                }

                if (actualObject.item != obj.item)
                {
                    Assert.Fail(String.Format(
                        "Expected item '{0}', actual item was {1}", obj.item, actualObject.item));
                }

                if ((actualObject.item % actualObject.multipleOf == 0) && (actualObject.item % 10 == 6))
                {
                    Assert.Pass(String.Format(
                        "Expected message '{0}', actual text was {1}", obj.message, actualObject.message));
                }else if (actualObject.item % actualObject.multipleOf == 0)
                {
                    Assert.Pass(String.Format(
                        "Expected message '{0}', actual text was {1}", obj.message, actualObject.message));
                }else if (actualObject.item % 10 == 6)
                {
                    Assert.Pass(String.Format(
                        "Expected message '{0}', actual text was {1}", obj.message, actualObject.message));
                }



            }
        }
    }
}
