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
        private IGameRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new InMemoryGame();
            action = new ClickLetterAction(repository);
        }

        [Test]
        public void tets()
        {
        }
    }
}


