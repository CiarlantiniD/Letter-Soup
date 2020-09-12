using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ClickLetterActionShould
    {
        private ClickLetterAction action;
        private IPositionSelected repository;

        [SetUp]
        public void Setup()
        {
            repository = new InMemoryPositionSelected();
            action = new ClickLetterAction(repository);
        }

        [Test]
        public void tets()
        {
        }
    }
}


