﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionChangeUndoFacts.cs" company="WildGums">
//   Copyright (c) 2008 - 2016 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Memento.Tests
{
    using System;
    using System.Collections.Generic;
    using Catel.Collections;
    using Catel.Test;
    using NUnit.Framework;

    public class CollectionChangeUndoFacts
    {
        #region Nested type: TheConstructor
        [TestFixture]
        public class TheConstructor
        {
            [TestCase]
            public void ThrowsArgumentNullExceptionForNullInstance()
            {
                ExceptionTester.CallMethodAndExpectException<ArgumentNullException>(() => new CollectionChangeUndo(null, CollectionChangeType.Add, 0, 0, null, null));
            }

            [TestCase]
            public void SetsValuesCorrectly()
            {
                var table = new List<object>();
                var collectionChangeUndo = new CollectionChangeUndo(table, CollectionChangeType.Add, 0, 0, "currentValue", "nextValue");

                Assert.IsNotNull(collectionChangeUndo.Collection);
                Assert.AreEqual(CollectionChangeType.Add, collectionChangeUndo.ChangeType);
                Assert.AreEqual(table, collectionChangeUndo.Collection);
                Assert.AreEqual("currentValue", collectionChangeUndo.OldValue);
                Assert.AreEqual("nextValue", collectionChangeUndo.NewValue);
                Assert.AreEqual(true, collectionChangeUndo.CanRedo);
            }
        }
        #endregion

        #region Nested type: TheRedoMethod
        [TestFixture]
        public class TheRedoMethod
        {
            [TestCase]
            public void HandlesCollectionAddCorrectly()
            {
                var table = new List<string>();
                var tableAfter = new List<string>(new[] {"currentValue"});

                var collectionChangeUndo = new CollectionChangeUndo(table, CollectionChangeType.Add, 0, 1, null, "currentValue");
                collectionChangeUndo.Redo();

                Assert.IsTrue(CollectionHelper.IsEqualTo(table, tableAfter));
            }

            // TODO: Write replace, remove, move
        }
        #endregion

        #region Nested type: TheUndoMethod
        [TestFixture]
        public class TheUndoMethod
        {
            [TestCase]
            public void HandlesCollectionAddCorrectly()
            {
                var table = new List<string>(new[] {"currentValue"});
                var tableAfter = new List<string>();

                var collectionChangeUndo = new CollectionChangeUndo(table, CollectionChangeType.Add, 0, 1, null, "currentValue");
                collectionChangeUndo.Undo();

                Assert.IsTrue(CollectionHelper.IsEqualTo(table, tableAfter));
            }

            // TODO: Write replace, remove, move
        }
        #endregion
    }
}