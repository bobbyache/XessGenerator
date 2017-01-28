//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CygSoft.Xess.Infrastructure;
//using CygSoft.Xess.Infrastructure.ReplaceEngine;

//namespace UnitTests
//{
//    [TestClass]
//    public class ReplaceEngineTests
//    {
//        /*
//         * SubstitutionMask - An object purely concerned with using an ActionIdentifier, Prefix, Postfix to create
//         * a placeholder for substitution during generation.
//         * 
//         * SubstitutionExpression - serves as a placeholder and substitution value. The placeholder is replaced with
//         * data and the ActionIdentifier acts as the identifier which is enclosed within a SubsitutionMask Postfix
//         * and Prefix.
//         * 
//         * 
//         */

//        [TestMethod]
//        public void ReplaceEngine_SubstitutionExpression()
//        {
//            // although widely used, this object is nothing but an anemic data object. should look to possibly merge it with the
//            // substitutionMask.
//            SubstitutionExpression substitutionExpress = new SubstitutionExpression("@{DepositId}", "DepositId", "Hello World");
//            Assert.AreEqual("DepositId", substitutionExpress.ActionIdentifier);
//            Assert.AreEqual("Hello World", substitutionExpress.OutputData);
//            Assert.AreEqual("@{DepositId}", substitutionExpress.OutputPlaceholder);
//        }

//        [TestMethod]
//        public void ReplaceEngine_SubstitutionMask()
//        {
//            // Wraps an action identifier between an enclosing prefix and postifix.
//            // Idea for improvement. Constructor to pass in prefix, postfix and action identifier at once.
//            SubstitutionMask substitutionMask = new SubstitutionMask("@{", "}");
//            substitutionMask.ActionIdentity = "DepositId";
//            Assert.AreEqual("@{DepositId}", substitutionMask.ToString());
//        }



//        // =======================================================================================================
//        // How does ReplaceAction work?
//        // Using the ITransformFunction interface we can modify the original data to replace the output with a
//        // transformed output, rather than the basic original data passed in..
//        // Ordinal Property: this informs the engine in what order we would like this transform to run on the 
//        // actual data. For instance, we might wish to have a quoted transform occur after a prefixed transform
//        // so that the prefix is not prepended outside the quotes!
//        // =======================================================================================================
//        private class QuoteTransformFunction : ITransformFunction
//        {
//            public int Ordinal { get; set; }

//            public string OriginalData { get; set; }

//            public string Transform()
//            {
//                return string.Format("\"{0}\"", this.OriginalData);
//            }
//        }

//        private class PrePendHelloTransformFunction : ITransformFunction
//        {
//            public int Ordinal { get; set; }

//            public string OriginalData { get; set; }

//            public string Transform()
//            {
//                return string.Format("Hello {0}!", this.OriginalData);
//            }
//        }

//        [TestMethod]
//        public void ReplaceEngine_QuotedTransformFunction()
//        {
//            QuoteTransformFunction quoteTransformFunction = new QuoteTransformFunction();
//            quoteTransformFunction.Ordinal = 1;     // this is the order in which we want the transform to run on
//            quoteTransformFunction.OriginalData = "Hello World";

//            // should enclose the original data with quotes.
//            string output = quoteTransformFunction.Transform();
//            Assert.AreEqual("\"Hello World\"", output);
//        }

//        [TestMethod]
//        public void ReplaceEngine_ReplaceAction()
//        {
//            SubstitutionMask substitutionMask = new SubstitutionMask("@{", "}");
//            QuoteTransformFunction quoteTransformFunction = new QuoteTransformFunction();
//            quoteTransformFunction.Ordinal = 1;     // this is the order in which we want the transform to run on
//            quoteTransformFunction.OriginalData = "Hello World";

//            ReplaceAction replaceAction = new ReplaceAction("DepositId", new SubstitutionMask("@{", "}"));
//            replaceAction.AddTransform(new QuoteTransformFunction());

//            // so at this point, have a replace action that includes a single transform to take place on the data
//            // before the data is subsituted for the placeholder.
//            SubstitutionExpression expression = replaceAction.CreateSubstitution("Hello World");
//            Assert.AreEqual("\"Hello World\"", expression.OutputData);
//            Assert.AreEqual("DepositId", expression.ActionIdentifier);
//            Assert.AreEqual("@{DepositId}", expression.OutputPlaceholder);
//        }
        


//        [TestMethod]
//        public void ReplaceEngine_ReplaceActionSet()
//        {
//            /*
//             * Each ReplaceAction will result in a placeholder to be subsituted for a specific column or constant (SourceId).
//             * Transforms are added to the action. So when @{prepend-hello-quoted} placeholder is encountered, the engine
//             * will apply the ReplaceAction together with its "transforms" to the data before substituting the placeholder
//             * with the output data.
//             * 
//             * One can add multiple actions to a column or constant which will result in a new placeholder for each
//             * action.
//             * 
//             * Other methods: ClearActions(), ClearTransforms(), ActionExists(), GetSubstitutionPlaceholders()
//             */

//            // SourceId - Either a column Id or a constant Id
//            ReplaceActionSet replaceActionSet = new ReplaceActionSet("DepositId", new SubstitutionMask("@{", "}"));
//            replaceActionSet.AddAction("prepend-hello-quoted");
//            replaceActionSet.AddActionTransform("prepend-hello-quoted", new PrePendHelloTransformFunction());
//            replaceActionSet.AddActionTransform("prepend-hello-quoted", new QuoteTransformFunction());

//            // should return a single substitution expression.
//            //List<SubstitutionExpression> expressionList = replaceActionSet.GetSubstitutionPlaceHolders();

//            SubstitutionExpression[] expressionList = replaceActionSet.CreateSubstitutions("World");
//            Assert.IsTrue(expressionList.Length == 1);
//            SubstitutionExpression expression = expressionList[0];
//            Assert.AreEqual("\"Hello World!\"", expression.OutputData);
//            Assert.AreEqual("prepend-hello-quoted", expression.ActionIdentifier);
//            Assert.AreEqual("@{prepend-hello-quoted}", expression.OutputPlaceholder);

//        }

//        [TestMethod]
//        public void ReplaceEngine_ReplaceEngine_Proper()
//        {
//            /*
//             * The ReplaceEngine wraps up all this functionality into an engine.
//             */
//            ReplaceEngine replaceEngine = new ReplaceEngine(new SubstitutionMask("@{", "}"));
//            replaceEngine.AddAction("DepositId", "prepend-hello-quoted");
//            replaceEngine.AddActionTransform("prepend-hello-quoted", new PrePendHelloTransformFunction());
//            replaceEngine.AddActionTransform("prepend-hello-quoted", new QuoteTransformFunction());

//            SubstitutionExpression[] expressionList = replaceEngine.CreateSubstitutions("DepositId", "World");
//            Assert.IsTrue(expressionList.Length == 1);
//            SubstitutionExpression expression = expressionList[0];
//            Assert.AreEqual("\"Hello World!\"", expression.OutputData);
//            Assert.AreEqual("prepend-hello-quoted", expression.ActionIdentifier);
//            Assert.AreEqual("@{prepend-hello-quoted}", expression.OutputPlaceholder);
//        }

//        // =======================================================================================================

//        [TestMethod]
//        public void ReplaceEngine_GenerateDefaultActions()
//        {
//            // Given an array, extract the "named constants" and create default actions which will contain 1-1
//            // substitution expressions (1 default substitution expression for each action).

//            SubstitutionMask substitionMask = new SubstitutionMask("@{", "}");
//            ReplaceEngine replaceEngine = new ReplaceEngine(substitionMask);

//            replaceEngine.GenerateDefaultActions(new string[] { "DepositId", "Amount", "CreateDate", "UpdateDate" });

//            SubstitutionExpression[] expressions = replaceEngine.GetSubstitutionPlaceholders();
//            Assert.AreEqual("@{DepositId}", expressions[0].OutputPlaceholder);
//            Assert.AreEqual("DepositId", expressions[0].ActionIdentifier);

//            Assert.AreEqual("@{Amount}", expressions[1].OutputPlaceholder);
//            Assert.AreEqual("Amount", expressions[1].ActionIdentifier);

//            Assert.AreEqual("@{CreateDate}", expressions[2].OutputPlaceholder);
//            Assert.AreEqual("CreateDate", expressions[2].ActionIdentifier);

//            Assert.AreEqual("@{UpdateDate}", expressions[3].OutputPlaceholder);
//            Assert.AreEqual("UpdateDate", expressions[3].ActionIdentifier);
//        }

//        [TestMethod]
//        public void ReplaceEngine_CreateSubsitutions()
//        {
//            // Note we're creating two placeholders (one for each action on a single column or constant).
//            ReplaceEngine engine = new ReplaceEngine(new SubstitutionMask("@{", "}"));
//            engine.AddAction("DepositID", "DepositID");
//            engine.AddAction("DepositID", "AdditionalDepositID");

//            SubstitutionExpression[] subExps = engine.CreateSubstitutions("DepositID", "23");
//            Assert.IsTrue(subExps.Length == 2);

//            if (subExps.Length == 2)
//            {
//                // the sustitutions have been created...
//                Assert.AreEqual(subExps[0].OutputPlaceholder, "@{DepositID}");
//                Assert.AreEqual(subExps[0].OutputData, "23");
//                Assert.AreEqual(subExps[1].OutputPlaceholder, "@{AdditionalDepositID}");
//                Assert.AreEqual(subExps[1].OutputData, "23");
//            }
//        }

//        //[TestMethod]
//        //public void TestRightPaddingTransform()
//        //{
//        //    ReplaceEngine engine = new ReplaceEngine(new SubstitutionMask("@{", "}"));
//        //    engine.AddAction("DepositID", "DepositID");

//        //    ITransformFunction func = TransformFactory.CreatePaddedTransform(30, PaddedTransformJustifyEnum.Right);
//        //    engine.AddActionTransform("DepositID", func);
//        //    SubstitutionExpression[] exps = engine.CreateSubstitutions("DepositID", "2345454");

//        //    Assert.AreEqual(exps.Length, 1);
//        //    Assert.IsTrue(exps[0].OutputData.Length == 30);
//        //    Assert.IsTrue(exps[0].OutputData.StartsWith("2"));
//        //}

//        //[TestMethod]
//        //public void TestLeftPaddingTransform()
//        //{
//        //    ReplaceEngine engine = new ReplaceEngine(new SubstitutionMask("@{", "}"));
//        //    engine.AddAction("DepositID", "DepositID");

//        //    ITransformFunction func = TransformFactory.CreatePaddedTransform(30, PaddedTransformJustifyEnum.Left);
//        //    engine.AddActionTransform("DepositID", func);
//        //    SubstitutionExpression[] exps = engine.CreateSubstitutions("DepositID", "2345454");

//        //    Assert.AreEqual(exps.Length, 1);
//        //    Assert.IsTrue(exps[0].OutputData.Length == 30);
//        //    Assert.IsTrue(exps[0].OutputData.StartsWith(" "));
//        //}
//    }
//}
