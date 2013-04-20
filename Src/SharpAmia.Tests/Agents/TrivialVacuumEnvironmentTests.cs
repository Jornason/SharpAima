﻿namespace SharpAmia.Tests.Agents
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SharpAmia.Agents;

    [TestClass]
    public class TrivialVacuumEnvironmentTests
    {
        [TestMethod]
        public void GetAgentPerception()
        {
            TrivialVacuumEnvironment environment = new TrivialVacuumEnvironment();
            environment.SetStatus(VacuumLocation.A, VacuumStatus.Clean);
            VacuumAgent agent = new RandomVacuumAgent();
            agent.Location = VacuumLocation.A;

            var result = environment.GetPerception(agent);

            Assert.AreEqual(VacuumLocation.A, result.Location);
            Assert.AreEqual(VacuumStatus.Clean, result.Status);
        }

        [TestMethod]
        public void ExecuteSuckActionOnDirtyStatus()
        {
            TrivialVacuumEnvironment environment = new TrivialVacuumEnvironment();
            environment.SetStatus(VacuumLocation.A, VacuumStatus.Dirty);
            VacuumAgent agent = new RandomVacuumAgent();
            agent.Location = VacuumLocation.A;

            environment.ExecuteAction(agent, VacuumAction.Suck);

            Assert.AreEqual(VacuumLocation.A, agent.Location);
            Assert.AreEqual(10, agent.Performance);
            Assert.AreEqual(VacuumStatus.Clean, environment.GetStatus(VacuumLocation.A));
        }
    }
}
