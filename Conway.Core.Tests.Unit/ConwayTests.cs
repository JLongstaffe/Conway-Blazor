
using System;
using System.Collections;
using System.Linq;

using NUnit.Framework;

namespace Conway.Core.Tests.Unit
{
    public class ConwayTests
    {
        [Test]
        public void Cannot_call_with_null_arguments()
        {
            Assert.That(() => Conway.NextState(null).ToArray(),
                        Throws.TypeOf<ArgumentNullException>());
        }

        private static IEnumerable Next_state_test_cases()
        {
            yield return new TestCaseData
                (new [] { new [] { false, false },
                          new [] { false, false } },
                 new [] { new [] { false, false },
                          new [] { false, false } });

            yield return new TestCaseData
                (new [] { new [] { true,  true },
                          new [] { false, false } },
                 new [] { new [] { false, false },
                          new [] { false, false } });

            yield return new TestCaseData
                (new [] { new [] { true, true },
                          new [] { true, false } },
                 new [] { new [] { true, true },
                          new [] { true, true } });

            yield return new TestCaseData
                (new [] { new [] { true, true },
                          new [] { true, true } },
                 new [] { new [] { true, true },
                          new [] { true, true } });
        }

        [TestCaseSource(nameof(Next_state_test_cases))]
        public void Next_state_is_generated_correctly(bool[][] initialState,
                                                      bool[][] nextState)
        {
            Assert.That(Conway.NextState(initialState), Is.EqualTo(nextState));
        }
    }
}